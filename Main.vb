Imports System.Data.SqlClient
Imports System.IO
Imports Microsoft.Reporting.WinForms
Imports System.Configuration


Public Class Main

    'Private configManager As ConfigHandler = New ConfigHandler()

    Private currentUser As User
    Private Const comboboxSpacerText As String = "==============================================="

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Include version number in form title bar. 
        Me.Text += " v2.0.4"

        ' Not used any more but might be in future. 
        ' LoadConfigValues()

        ' The StudentsMbx is a custom control which enables better text-matching than an ordinary ComboBox. 
        ' It can't be successfully added to this form in the Design window because its code keeps disappearing 
        ' from the InitialiseComponent() function, so I have added it here. 
        Me.StudentsMbx = New BMS.MatchingComboBox()
        Me.StudentsMbx.FilterRule = Nothing
        Me.StudentsMbx.Font = New System.Drawing.Font("Gill Sans MT", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StudentsMbx.FormattingEnabled = True
        Me.StudentsMbx.Name = "StudentsMbx"
        Me.StudentsMbx.PropertySelector = Nothing
        Me.StudentsMbx.Location = New System.Drawing.Point(84, 220)
        Me.StudentsMbx.Size = New System.Drawing.Size(493, 29)
        Me.StudentsMbx.SuggestBoxHeight = 96
        Me.StudentsMbx.SuggestListOrderRule = Nothing
        Me.StudentsMbx.Anchor = AnchorStyles.Bottom + AnchorStyles.Left
        Me.StudentsMbx.TabIndex = 1
        Me.Controls.Add(Me.StudentsMbx)
        AddHandler StudentsMbx.SelectedIndexChanged, AddressOf StudentsMbx_SelectedIndexChanged
        Me.StudentsMbx.Select()

        Try

            ' Get information for the current user. 

            Dim currentUserWI As Security.Principal.WindowsIdentity = Security.Principal.WindowsIdentity.GetCurrent()
            Dim currentUserNetworkLogin = Strings.Right(currentUserWI.Name, Len(currentUserWI.Name) - Len("WOODCROFT/"))

            Using SynergyConn As New SqlConnection(ConfigurationManager.ConnectionStrings("SynergyOneConnectionString").ToString())

                Using CurrentUserQuery As New SqlCommand(
                        ConfigurationManager.AppSettings("GetUserDetailsFromNetworkLoginProc"),
                        SynergyConn)

                    CurrentUserQuery.CommandType = CommandType.StoredProcedure
                    CurrentUserQuery.Parameters.AddWithValue("NetworkLogin", currentUserNetworkLogin)

                    SynergyConn.Open()

                    Using CurrentUserReader As SqlDataReader = CurrentUserQuery.ExecuteReader()

                        If CurrentUserReader.HasRows Then
                            CurrentUserReader.Read()
                            currentUser = New User(
                                firstName:=CurrentUserReader("Preferred").ToString,
                                surname:=CurrentUserReader("Surname").ToString,
                                id:=CurrentUserReader("ID").ToString,
                                email:=CurrentUserReader("OccupEmail").ToString)
                        Else
                            Throw New Exception("Current user not found in Synergy Community table.")
                        End If

                    End Using 'CurrentUserReader
                End Using 'CurrentUserQuery
            End Using 'SynergyConn

            ' Populate other form controls. 

            PopulateStudentsMbx()
            PopulateStaffCbx()
            PopulateClassesCbx()

        Catch Ex As Exception
            HandleError(Ex)
        End Try

    End Sub


    Private Sub HandleError(Ex As Exception)
        MsgBox(Ex.Message, vbOKOnly + vbCritical, "An Exception Occurred")
        Me.Close()
    End Sub


    Private Sub LoadConfigValues()

        ' Examples only below. Do nothing for now. Later if required we can load config values from 
        ' the Synergy DB here. 

        'configManager.SetConfigValue(Of Boolean)(configSendEmails, "SendEmails")
        'configManager.SetConfigValue(Of String)(mailServerName, "MailServerName")

    End Sub


    Private Function Reset()

        ' Clears the form in preparation for user to commence new sanction booking. 

        HideAllSanctionControls()

        StudentsMbx.SelectedItem = Nothing
        StudentsMbx.Text = Nothing

        ' Don't reset the Staff Member combobox selection to enable 
        ' multiple sanctions for the same staff member. 
        StaffMemberCbx.Hide()
        StaffMemberLbl.Hide()

        ClassLbl.Hide()
        ClassCbx.SelectedItem = Nothing
        ClassCbx.Text = Nothing
        ClassCbx.Hide()

        SanctionTypeLbl.Hide()
        SanctionTypeCbx.SelectedItem = Nothing
        SanctionTypeCbx.Text = Nothing
        SanctionTypeCbx.Hide()

        StudentPhotoPbx.Hide()
        ReportViewer1.Hide()

        SubmitBtn.Hide()

        Me.Refresh()

    End Function


    Private Sub PopulateStaffCbx()

        ' The Staff Member Combo Box defaults to the current user, but a user can change it if they 
        ' choose to set sanctions on behalf of another staff member (e.g. sometimes Alison Williams
        ' will do this).

        StaffMemberCbx.Items.Clear()

        Try

            Using SynergyOneConn As New SqlConnection(ConfigurationManager.ConnectionStrings("SynergyOneConnectionString").ToString())

                SynergyOneConn.Open()

                Using StaffListCmd As New SqlCommand(
                        ConfigurationManager.AppSettings("GetStaffListProc"),
                        SynergyOneConn)

                    StaffListCmd.CommandType = CommandType.StoredProcedure

                    Using StaffListReader As SqlDataReader = StaffListCmd.ExecuteReader()
                        If StaffListReader.HasRows Then
                            Do While StaffListReader.Read()
                                StaffMemberCbx.Items.Add(New User(
                                    firstName:=StaffListReader("Preferred").ToString,
                                    surname:=StaffListReader("Surname").ToString,
                                    id:=StaffListReader("Id").ToString,
                                    email:=StaffListReader("Email").ToString))
                            Loop
                        End If
                    End Using 'StaffListReader
                End Using 'StaffListQuery

                ' Select the current user's entry in the Staff List by default. 

                StaffMemberCbx.SelectedIndex = -1
                For i = 0 To StaffMemberCbx.Items.Count - 1
                    Dim IndexUser As User = TryCast(StaffMemberCbx.Items(i), User)
                    If IndexUser IsNot Nothing AndAlso IndexUser.id = currentUser.id Then
                        StaffMemberCbx.SelectedIndex = i
                        Exit For
                    End If
                Next

            End Using 'SynergyConn

        Catch ex As Exception
            HandleError(ex)
        End Try

    End Sub


    Private Sub PopulateClassesCbx()

        ClassCbx.Items.Clear()

        ClassCbx.Items.Add("NOT APPLICABLE")

        Try

            Using SynergyOneConn As New SqlConnection(ConfigurationManager.ConnectionStrings("SynergyOneConnectionString").ToString())

                SynergyOneConn.Open()

                ' =========================================================================================
                ' 1. Add classes for the current user to the class selection ComboBox.
                ' =========================================================================================

                Using StaffClassListCmd As New SqlCommand(
                    ConfigurationManager.AppSettings("GetClassesForStaffProc"),
                    SynergyOneConn)

                    StaffClassListCmd.CommandType = CommandType.StoredProcedure
                    StaffClassListCmd.Parameters.AddWithValue("StaffId", currentUser.id)

                    Using StaffClassListReader As SqlDataReader = StaffClassListCmd.ExecuteReader()
                        If StaffClassListReader.HasRows Then
                            Do While StaffClassListReader.Read()
                                ClassCbx.Items.Add(New [Class](
                                StaffClassListReader("ClassCode").ToString,
                                StaffClassListReader("Description").ToString))
                            Loop
                        End If
                    End Using 'StaffClassListReader

                End Using 'StaffClassListQuery

                ClassCbx.Items.Add(comboboxSpacerText)

                ' =========================================================================================
                ' 2. Append all classes below the current user's class list.  
                ' =========================================================================================

                Using AllClassesQuery As New SqlCommand(
                    ConfigurationManager.AppSettings("GetAllClassesProc"),
                    SynergyOneConn)

                    AllClassesQuery.CommandType = CommandType.StoredProcedure

                    Using AllClassesReader As SqlDataReader = AllClassesQuery.ExecuteReader()
                        If AllClassesReader.HasRows Then
                            Do While AllClassesReader.Read()
                                ClassCbx.Items.Add(New [Class](
                                AllClassesReader("ClassCode").ToString,
                                AllClassesReader("Description").ToString))
                            Loop
                        End If

                    End Using 'AllClassesReader
                End Using 'AllClassesQuery
            End Using 'SynergyConn

        Catch Ex As Exception
            HandleError(Ex)
        End Try

        ClassCbx.SelectedItem = Nothing

    End Sub

    Private Sub PopulateStudentsMbx()

        ' The student selector MatchingComboBox is populated with ALL students at the school. 

        StudentsMbx.Items.Clear()
        StudentsMbx.Text = ""
        StudentsMbx.SelectedItem = Nothing

        Try
            Using SynergyConn As New SqlConnection(ConfigurationManager.ConnectionStrings("SynergyOneConnectionString").ToString())

                Using StudentsCmd As New SqlCommand(
                    ConfigurationManager.AppSettings("GetAllStudentsProc"), SynergyConn)

                    StudentsCmd.CommandType = CommandType.StoredProcedure

                    SynergyConn.Open()

                    Using StudentsReader As SqlDataReader = StudentsCmd.ExecuteReader()
                        If StudentsReader.HasRows Then
                            Do While StudentsReader.Read()
                                StudentsMbx.Items.Add(New Student(
                                StudentsReader("Preferred").ToString,
                                StudentsReader("Surname").ToString,
                                StudentsReader("ID").ToString,
                                CInt(StudentsReader("YearLevel"))))
                            Loop
                        End If

                    End Using 'StudentsReader
                End Using 'StudentsCmd
            End Using 'SynergyConn

        Catch Ex As Exception
            HandleError(Ex)
        End Try

    End Sub


    Private Sub PopulateSanctionsCbx()

        SanctionTypeCbx.Items.Clear()
        SanctionTypeCbx.Text = ""
        SanctionTypeCbx.SelectedItem = Nothing

        If StudentsMbx.SelectedItem Is Nothing Then
            ' No student selected - Clear sanctions combo box.
            SanctionTypeCbx.Items.Clear()
        End If

        Try
            Using SynergyConn As New SqlConnection(ConfigurationManager.ConnectionStrings("SynergyOneConnectionString").ToString())
                Using SanctionsCmd As New SqlCommand(
                    ConfigurationManager.AppSettings("GetSanctionsForYearLevelProc"), SynergyConn)

                    SanctionsCmd.CommandType = CommandType.StoredProcedure
                    SanctionsCmd.Parameters.AddWithValue("YearLevel", CType(StudentsMbx.SelectedItem, Student).yearLevel)

                    SynergyConn.Open()

                    Using SanctionsReader As SqlDataReader = SanctionsCmd.ExecuteReader()
                        If SanctionsReader.HasRows Then
                            Do While SanctionsReader.Read()
                                SanctionTypeCbx.Items.Add(SanctionsReader("SanctionType").ToString)
                            Loop
                        Else
                            ' No sanctions found for this student. Should never happen, but... 
                            MessageBox.Show("There was a problem selecting appropriate sanctions for this student." _
                            + Environment.NewLine + "Please report this error to Data Management.",
                            "Could Not Obtain Sanction List!",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Reset()
                        End If

                    End Using 'SanctionsReader
                End Using 'SanctionsCmd
            End Using 'SynergyConn

        Catch Ex As Exception
            HandleError(Ex)
        End Try

    End Sub


    Private Sub PopulateSanctionDatesCbx()

        SanctionDateCbx.Items.Clear()

        If SanctionTypeCbx.SelectedItem = Nothing Then
            Return
        End If

        Try

            Using futureSanctionDatesConn As New SqlConnection(
                        ConfigurationManager.ConnectionStrings("SynergyOneConnectionString").ToString())
                Using futureSanctionDatesCmd As New SqlCommand(
                        ConfigurationManager.AppSettings("GetFutureSanctionDatesProc"),
                        futureSanctionDatesConn)

                    futureSanctionDatesCmd.CommandType = CommandType.StoredProcedure
                    futureSanctionDatesCmd.Parameters.AddWithValue("StudentId", CType(StudentsMbx.SelectedItem, Student).id)
                    futureSanctionDatesCmd.Parameters.AddWithValue("SanctionType", SanctionTypeCbx.Text)

                    futureSanctionDatesConn.Open()

                    Using futureSanctionDatesRdr As SqlDataReader = futureSanctionDatesCmd.ExecuteReader()

                        Dim alreadyBooked As Boolean
                        Dim bookedByUser As User

                        If futureSanctionDatesRdr.HasRows Then
                            Do While futureSanctionDatesRdr.Read()

                                alreadyBooked = If(IsDBNull(futureSanctionDatesRdr("StaffId")), False, True)
                                bookedByUser = If(
                                    IsDBNull(futureSanctionDatesRdr("StaffId")),
                                        Nothing,
                                        New User(
                                            id:=futureSanctionDatesRdr("StaffId"),
                                            firstName:=futureSanctionDatesRdr("StaffPreferred"),
                                            surname:=futureSanctionDatesRdr("StaffSurname"),
                                            email:=futureSanctionDatesRdr("StaffEmail")))

                                SanctionDateCbx.Items.Add(New SanctionDate(
                                    day:=Convert.ToDateTime(futureSanctionDatesRdr("Date").ToString).Date,
                                    alreadyBooked:=alreadyBooked,
                                    bookedBy:=bookedByUser))

                            Loop
                        End If

                    End Using
                End Using
            End Using

        Catch Ex As Exception
            HandleError(Ex)
        End Try

    End Sub


    Private Sub StudentsMbx_SelectedIndexChanged(sender As Object, e As EventArgs)

        If StudentsMbx.SelectedItem Is Nothing Then
            Return
        End If

        HideAllSanctionControls()

        ' Display student photo.

        Try

            Using studentPhotoConn As New SqlConnection(ConfigurationManager.ConnectionStrings("SynergyOneConnectionString").ToString())

                Using studentPhotoCmd As New SqlCommand(
                        ConfigurationManager.AppSettings("GetPhotoDataForUserProc"), studentPhotoConn)

                    studentPhotoCmd.CommandType = CommandType.StoredProcedure
                    studentPhotoCmd.Parameters.AddWithValue("Id", CType(StudentsMbx.SelectedItem, Student).id.ToString())

                    studentPhotoConn.Open()

                    Using studentPhotoRdr As SqlDataReader = studentPhotoCmd.ExecuteReader()

                        If studentPhotoRdr.HasRows Then
                            Do While studentPhotoRdr.Read()
                                StudentPhotoPbx.Image = New Bitmap(New MemoryStream(CType(studentPhotoRdr("ImageData"), Byte())))
                                StudentPhotoPbx.Show()
                            Loop
                        Else
                            ' No photo found: empty and hide the student photo picture box. 
                            StudentPhotoPbx.Image = Nothing
                            StudentPhotoPbx.Hide()
                        End If

                    End Using 'studentPhotoReader
                End Using ' studentPhotoCmd
            End Using ' studentPhotoConn

            ' Display summary report of sanctions for the selected student. 
            Dim Params As New List(Of ReportParameter)
            Params.Add(New ReportParameter("StudentID", CType(StudentsMbx.SelectedItem, Student).id.ToString))
            Me.ReportViewer1.ServerReport.SetParameters(Params)
            Me.ReportViewer1.RefreshReport()
            Me.ReportViewer1.Visible = True

            PopulateSanctionsCbx()

            StaffMemberLbl.Show()
            StaffMemberCbx.Show()
            ClassLbl.Show()
            ClassCbx.Show()
            SanctionTypeLbl.Show()
            SanctionTypeCbx.Show()

        Catch Ex As Exception
            HandleError(Ex)
        End Try

    End Sub


    Private Sub HideAllSanctionControls()

        ' This hides the controls which are specialised relating to particular sanction types. 
        CurrentGradeLbl.Hide()
        CurrentGradeCbx.Text = ''
        CurrentGradeCbx.SelectedItem = Nothing
        CurrentGradeCbx.Hide()

        DueDateCbx.Items.Clear()
        DueDateLbl.Hide()
        DueDateCbx.SelectedItem = Nothing
        DueDateCbx.Text = Nothing
        DueDateCbx.Hide()

        TaskNameLbl.Hide()
        TaskNameTbx.Text = Nothing

        TaskNameTbx.Hide()

        SanctionDateLbl.Hide()
        SanctionDateCbx.SelectedItem = Nothing
        SanctionDateCbx.Text = Nothing
        SanctionDateCbx.Hide()

        ReasonLbl.Hide()
        ReasonCbx.SelectedItem = Nothing
        ReasonCbx.Text = Nothing
        ReasonCbx.Hide()

        InformationOnlyChk.Checked = False
        InformationOnlyLbl.Hide()
        InformationOnlyChk.Hide()

        CommentLbl.Hide()
        CommentTbx.Text = Nothing
        CommentTbx.Hide()

        Me.Refresh()

    End Sub


    Private Sub SanctionTypeCbx_SelectedIndexChanged(
            sender As Object, e As EventArgs) Handles SanctionTypeCbx.SelectedIndexChanged

        ' Hide the specialised controls by default, reveal later based on chosen sanction type. 
        HideAllSanctionControls()

        Try

            Select Case (SanctionTypeCbx.Text)

                Case "Report of Concern"

                    CurrentGradeLbl.Show()
                    CurrentGradeCbx.Show()

                Case "Non Submission: Summative"

                    DueDateCbx.Items.Clear()
                    DueDateCbx.Items.Add("NOT APPLICABLE")
                    ' Add previous dates to the Due Date combobox, excluding weekends (DayOfWeek = 6 or 0)
                    For dayCounter = -21 To 0
                        If (Now().AddDays(dayCounter)).DayOfWeek <> 6 And (Now().AddDays(dayCounter)).DayOfWeek <> 0 Then
                            DueDateCbx.Items.Add(String.Format("{0:ddd, d MMM}", Now().AddDays(dayCounter)))
                        End If
                    Next

                    TaskNameLbl.Show()
                    TaskNameTbx.Show()
                    DueDateLbl.Show()
                    DueDateCbx.Show()

                Case Else

                    SanctionDateLbl.Show()
                    SanctionDateCbx.Show()
                    ReasonLbl.Show()
                    ReasonCbx.Show()
                    InformationOnlyLbl.Show()
                    InformationOnlyLbl.Show()
                    InformationOnlyChk.Show()

                    PopulateSanctionDatesCbx()
            End Select

        Catch Ex As Exception
            HandleError(Ex)
        End Try

        CommentLbl.Show()
        CommentTbx.Show()
        SubmitBtn.Show()

    End Sub


    Private Sub SubmitBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SubmitBtn.Click

        Try

            ' =======================================================================================
            ' FORM VALIDATION
            ' =======================================================================================
            If StaffMemberCbx.SelectedItem Is Nothing Then
                ' This should never happen (only if current user is not active in [dbo.Staff] Synergy table). 
                MessageBox.Show("A sanction cannot be created without a staff name. Please select a staff member.",
                "No Staff Member Selected!",
                MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            ElseIf SanctionTypeCbx.Text = "" Then
                MessageBox.Show("Please select the category of sanction.", "No Category Selected!",
                MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            ElseIf StudentsMbx.Text = "" Then
                MessageBox.Show("Please select a student.", "No Student Selected!",
                MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            ElseIf ClassCbx.Text = "" Or ClassCbx.Text = comboboxSpacerText Then
                MessageBox.Show("Please select an appropriate class or NOT APPLICABLE.", "No Class Selected!",
                MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            Select Case (SanctionTypeCbx.Text)

                Case "Report of Concern"

                    If CurrentGradeCbx.Text = "" Then
                        MessageBox.Show("Please select the student's current grade or NOT APPLICABLE.", "No Current Grade Selected!",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    ElseIf SanctionTypeCbx.Text = "" Then
                        MessageBox.Show("Please select the category of sanction.", "No Category Selected!",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End If

                Case "Non Submission: Summative"

                    If TaskNameTbx.Text = "" Then
                        MessageBox.Show("Please enter the title of the summative task that has not been submitted.", "No Task Entered!",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    ElseIf DueDateCbx.Text = "" Then
                        MessageBox.Show("Please select the date the task was due for submission.", "No Due Date Selected!",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End If

                Case Else

                    ' Catchups and both detention types. 

                    If CType(SanctionDateCbx.SelectedItem, SanctionDate).alreadyBooked Then
                        MessageBox.Show("Please select a date that is not already booked by another staff member.", "Booking Clash!",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    ElseIf SanctionDateCbx.Text = "" Then
                        MessageBox.Show("Please select the date of the sanction.", "No Date Selected!",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    ElseIf (SanctionTypeCbx.Text = "Catch up class" Or SanctionTypeCbx.Text = "Detention (Level 1: Lunchtime)") _
                            And (CDate(SanctionDateCbx.Text).DayOfWeek = 2 Or CDate(SanctionDateCbx.Text).DayOfWeek = 4) _
                            And InformationOnlyChk.Checked = False Then
                        MessageBox.Show("Catch up classes and detentions can only be booked on a Tuesday or Thursday if administered in full by the setting teacher. Please signify that this is the case by ticking the 'Information Only' box, or change the date of the booking to a Monday, Wednesday or Friday.", "Day of Week Issue!",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    ElseIf Trim(ReasonCbx.Text) = "" Then
                        MessageBox.Show("Please select the reason for the sanction.", "No Reason Selected!",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End If

            End Select


            ' =========================================================================================
            ' CREATE NEW SANCTION RECORD IN DATABASE
            ' =========================================================================================

            ' Organise the query parameters which will be used to update the database. 
            ' Most fields are generic, some are set only for specific sanction types. 
            Dim summativeDueDate As String = ""
            Dim summativeTaskName As String = ""
            Dim sanctionDate As String = ""
            Dim sanctionCode As String = ""
            Dim reasonType As String = ""
            Dim currentGrade As String = ""

            Select Case (SanctionTypeCbx.Text)

                Case "Report of Concern"

                    sanctionCode = "Report of Concern"
                    reasonType = ReasonCbx.Text
                    currentGrade = CurrentGradeCbx.Text

                Case "Non Submission: Summative"

                    summativeTaskName = TaskNameTbx.Text
                    sanctionCode = "Non Submission"
                    reasonType = "Summative Work"

                    If DueDateCbx.Text = "NOT APPLICABLE" Or DueDateCbx.Text = "" Then
                        summativeDueDate = CDate("1900-1-1")
                    Else
                        summativeDueDate = CType(DueDateCbx.SelectedItem, Date).ToString("yyyy-MM-dd")
                    End If

                Case Else

                    ' Detentions and catch up classes.

                    sanctionCode = SanctionTypeCbx.Text
                    reasonType = ReasonCbx.Text
                    sanctionDate = CType(SanctionDateCbx.Text, Date).ToString("yyyy-MM-dd")

            End Select

            Using submitConn As New SqlConnection(ConfigurationManager.ConnectionStrings("SynergyOneConnectionString").ToString())

                Using submitCmd As New SqlCommand(ConfigurationManager.AppSettings("CreateSanctionProc"), submitConn)

                    submitCmd.CommandType = CommandType.StoredProcedure
                    submitCmd.Parameters.AddWithValue("StaffId", CType(StaffMemberCbx.SelectedItem, User).id)
                    submitCmd.Parameters.AddWithValue("StudentId", CType(StudentsMbx.SelectedItem, Student).id)
                    submitCmd.Parameters.AddWithValue("SanctionCode", sanctionCode)
                    submitCmd.Parameters.AddWithValue("SanctionReason", reasonType)
                    submitCmd.Parameters.AddWithValue("SanctionDate", sanctionDate)
                    submitCmd.Parameters.AddWithValue("ClassCode", ClassCbx.Text)
                    submitCmd.Parameters.AddWithValue("CurrentGrade", currentGrade)
                    submitCmd.Parameters.AddWithValue("SummativeTaskName", summativeTaskName)
                    submitCmd.Parameters.AddWithValue("SummativeDueDate", summativeDueDate)
                    submitCmd.Parameters.AddWithValue("Comment", CommentTbx.Text)
                    submitCmd.Parameters.AddWithValue("Completed", CInt(InformationOnlyChk.Checked))
                    submitCmd.Parameters.AddWithValue("ModifiedBy", currentUser.id)

                    submitConn.Open()
                    Dim InsertCount As Integer = submitCmd.ExecuteNonQuery()
                    submitConn.Close()

                    If InsertCount > 0 Then
                        Reset()
                    Else
                        MessageBox.Show("There was a problem saving this sanction to the Synergy database. " _
                        & "Please make sure that you are currently connected to the Woodcroft network." _
                        & "If this problem persists, try again later, and notify the Data Manager.",
                        "Sanction not saved!",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If

                End Using 'submitCmd
            End Using 'submitConn

            If MessageBox.Show("Booking saved, would you like to make another?",
                "Booking Saved!",
                MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                Reset()
            Else
                Me.Close()
            End If

        Catch Ex As Exception
            HandleError(Ex)
        End Try

    End Sub


    Private Sub SanctionDateCbx_SelectedIndexChanged(
            sender As Object, e As EventArgs) Handles SanctionDateCbx.SelectedIndexChanged

        If SanctionDateCbx.SelectedItem Is Nothing Then
            Return
        End If

        Dim selectedDate As SanctionDate = CType(SanctionDateCbx.SelectedItem, SanctionDate)
        If selectedDate.alreadyBooked Then
            MsgBox(
                "Sorry, that date has already been booked by another staff member. " +
                "Please select a different date.",
                MsgBoxStyle.Exclamation)

            SanctionDateCbx.SelectedIndex = -1
            SanctionDateCbx.SelectedItem = Nothing
        End If

    End Sub

End Class
