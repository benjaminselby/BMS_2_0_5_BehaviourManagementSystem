Imports System.Data.SqlClient
Imports System.Configuration

Public Class SanctionsForUser

    Private currentUser As User
    Private sanctionListDtbl As New DataTable

    Public Structure dataValidationResult
        Public isValid As Boolean
        Public message As String
    End Structure


    '======================================================================================
    ' WINDOW INITIALISATION
    '======================================================================================


    Public Sub New(user As User)

        ' This call is required by the designer.
        InitializeComponent()

        Me.currentUser = user

    End Sub



    Private Sub SanctionsForUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Text = "Current sanctions for " + Me.currentUser.firstName + " " + Me.currentUser.surname

        PopulateSanctionListDgv()

    End Sub



    '======================================================================================
    ' FUNCTIONS
    '======================================================================================


    Private Sub PopulateSanctionListDgv()

        sanctionListDgv.Columns.Clear()
        sanctionListDgv.DataSource = Nothing
        sanctionListDtbl.Clear()

        ' Add a checkbox column to the data table so users can select particular sanctions. 
        If Not sanctionListDtbl.Columns.Contains("Selected") Then
            sanctionListDtbl.Columns.Add("Selected", GetType(Boolean))
        End If

        Using synergyConnection As New SqlConnection(
                ConfigurationManager.ConnectionStrings("Synergy").ConnectionString)
            Using sanctionListAdapter = New SqlDataAdapter(
                    ConfigurationManager.AppSettings("GetCurrentSanctionsForStaff"), synergyConnection)

                sanctionListAdapter.SelectCommand.CommandType = CommandType.StoredProcedure
                sanctionListAdapter.SelectCommand.Parameters.AddWithValue("StaffId", currentUser.id)

                synergyConnection.Open()
                sanctionListAdapter.Fill(sanctionListDtbl)

            End Using
        End Using

        sanctionListDgv.DataSource = sanctionListDtbl


        ' ========================================================================================

        ' Add combo box columns for some fields to enable users to modify them, but only within 
        ' sets of allowed values. We do this by creating duplicate columns which display combo boxes
        ' for these fields. The combo box columns are bound to the original data columns, which are
        ' not displayed. 

        ' I tried to implement this with Sanction Date, but it proved to be quite difficult given 
        ' that certain dates are only available for certain sanctions, and also that they may 
        ' already be booked by another staff member (or even the current user). Instead, I decided
        ' to allow users to enter any valid date in the Sanction Date column and then catch any 
        ' clashes or invalid dates during data validation. 


        ' ========================================================================================
        ' SANCTION TYPE
        ' ========================================================================================


        Dim sanctionTypeCbxColumn As New DataGridViewComboBoxColumn()
        sanctionTypeCbxColumn.Name = "SanctionTypeCbx"
        sanctionTypeCbxColumn.HeaderText = "SanctionType"
        sanctionListDgv.Columns.Add(sanctionTypeCbxColumn)

        ' The sanction types which may be assigned differ depending on the student's year level
        ' (possibly other factors as well), so we need to iterate over each row and add
        ' the list of available sanctions to the combobox cell for each row.

        For Each sanctionRow As DataGridViewRow In sanctionListDgv.Rows

            For Each sanctionType In ConfigHandler.GetConfigValues(
                    "SanctionType", sanctionRow.Cells("StudentYearLevel").Value)
                CType(sanctionRow.Cells("SanctionTypeCbx"), DataGridViewComboBoxCell).Items.Add(sanctionType)
            Next

        Next

        sanctionTypeCbxColumn.DataPropertyName = "SanctionType"
        sanctionTypeCbxColumn.DisplayMember = "SanctionType"
        sanctionTypeCbxColumn.ValueMember = "SanctionType"
        sanctionListDgv.Columns("SanctionTypeCbx").DefaultCellStyle.WrapMode = DataGridViewTriState.False
        sanctionListDgv.Columns("SanctionTypeCbx").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells


        ' ========================================================================================
        ' SANCTION REASON
        ' ========================================================================================

        ' Similar to available sanction types, these can differ for each row. 

        Dim reasonCbxColumn As New DataGridViewComboBoxColumn()
        reasonCbxColumn.Name = "ReasonCbx"
        reasonCbxColumn.HeaderText = "Reason"
        sanctionListDgv.Columns.Add(reasonCbxColumn)

        For Each sanctionRow As DataGridViewRow In sanctionListDgv.Rows

            For Each sanctionReason In ConfigHandler.GetConfigValues("Reason")
                CType(sanctionRow.Cells("ReasonCbx"), DataGridViewComboBoxCell).Items.Add(sanctionReason)
            Next

        Next

        reasonCbxColumn.DataPropertyName = "Reason"
        reasonCbxColumn.DisplayMember = "Reason"
        reasonCbxColumn.ValueMember = "Reason"
        sanctionListDgv.Columns("ReasonCbx").DefaultCellStyle.WrapMode = DataGridViewTriState.False
        sanctionListDgv.Columns("ReasonCbx").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells


        ' ========================================================================================


        ' Default Settings for all columns. 
        For columnIndex As Integer = 0 To sanctionListDgv.Columns.Count - 1
            With sanctionListDgv.Columns(columnIndex)
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Visible = False
                .ReadOnly = If(columnIndex <> 0, True, False)
            End With
        Next


        With sanctionListDgv

            .Columns("Selected").DisplayIndex = 0
            .Columns("StudentName").DisplayIndex = 1
            .Columns("ReasonCbx").DisplayIndex = 2
            .Columns("SanctionTypeCbx").DisplayIndex = 3
            .Columns("SanctionDate").DisplayIndex = 4
            .Columns("Comment").DisplayIndex = 5

            .Columns("Selected").Visible = True
            .Columns("StudentName").Visible = True
            .Columns("ReasonCbx").Visible = True
            .Columns("SanctionTypeCbx").Visible = True
            .Columns("SanctionDate").Visible = True
            .Columns("Comment").Visible = True

            ' Allow certain fields to be editable. 
            .Columns("Selected").ReadOnly = False
            .Columns("ReasonCbx").ReadOnly = False
            .Columns("SanctionTypeCbx").ReadOnly = False
            .Columns("SanctionDate").ReadOnly = False
            .Columns("Comment").ReadOnly = False

            .Columns("Selected").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            .Columns("Selected").Width = 50
            .Columns("Selected").HeaderText = "Delete?"

            .Columns("StudentName").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            .Columns("StudentName").Width = 100

            .Columns("Comment").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

            .Columns("StudentName").DefaultCellStyle.BackColor = Color.LightGray
            .Columns("SanctionTypeCbx").DefaultCellStyle.BackColor = Color.White
            .Columns("ReasonCbx").DefaultCellStyle.BackColor = Color.White

        End With

        sanctionListDgv.Refresh()

    End Sub



    Private Function validateSanctionDates() As dataValidationResult

        Dim validationResult As New dataValidationResult
        Dim modified As DataTable = sanctionListDtbl.GetChanges

        If modified Is Nothing OrElse modified.Rows.Count < 1 Then
            validationResult.isValid = True
            validationResult.message = "No rows modified."
            Return validationResult
        End If


        ' ========================================================================
        ' SANCTION DATE IS VALID AND NOT ALREADY BOOKED
        ' ========================================================================

        ' Ensure that the selected sanction dates are valid for the selected sanction types, 
        ' and also that they are not already booked by another staff member. (If they are booked 
        ' by the current staff member then check if it is the same booking as the one we are validating).
        ' Sanction dates can vary based on sanction type (ie. some kinds of sanction 
        ' bookings may only be made for certain days in the future) and also based on 
        ' student year level (Junior School requested that sanction dates be in THE PAST
        ' because they use them only as a record of when a punishment was applied, not 
        ' to book a sanction in the future. 

        Using synergyConn As New SqlConnection(
                    ConfigurationManager.ConnectionStrings("Synergy").ToString())
            Using getSanctionDatesCmd As New SqlCommand(
                    ConfigurationManager.AppSettings("GetSanctionDatesProc"),
                    synergyConn)

                synergyConn.Open()

                For Each modifiedRow As DataRow In modified.Rows

                    ' We assume the date selected by the user is invalid unless an available date is found. 
                    validationResult.message = String.Format(
                            "The date ({0}) you have selected for a {1} for {2} is not valid for this sanction type." +
                            vbCrLf + "Please select a different date, or delete this sanction and try creating a new one.",
                            CType(modifiedRow("SanctionDate"), Date).ToString("dd/MM/yyyy"),
                            modifiedRow("SanctionType"),
                            modifiedRow("StudentName"))
                    validationResult.isValid = False


                    getSanctionDatesCmd.CommandType = CommandType.StoredProcedure
                    getSanctionDatesCmd.Parameters.Clear()
                    getSanctionDatesCmd.Parameters.AddWithValue("StudentId", modifiedRow("StudentId"))
                    getSanctionDatesCmd.Parameters.AddWithValue("SanctionType", modifiedRow("SanctionType"))


                    Using sanctionDatesRdr As SqlDataReader = getSanctionDatesCmd.ExecuteReader()

                        ' TODO: Could this logic be implemented better by loading all data 
                        ' from the SQL procedure into a table and then SELECTing the matching date?
                        Do While sanctionDatesRdr.Read()

                            If modifiedRow("SanctionDate") = sanctionDatesRdr("Date") Then

                                If IsDBNull(sanctionDatesRdr("SanctionId")) Then

                                    validationResult.isValid = True
                                    validationResult.message = "OK, date is available."
                                    Exit Do

                                ElseIf modifiedRow("Seq") = sanctionDatesRdr("SanctionId") Then

                                    validationResult.isValid = True
                                    validationResult.message = "OK, date is unchanged."
                                    Exit Do

                                ElseIf sanctionDatesRdr("StaffId") = currentUser.id Then

                                    validationResult.message = String.Format(
                                            "The date ({0}) you have selected for a {1} for {2} has already been booked by you." +
                                            vbCrLf + "Please select a different date, or delete this sanction and create a new one.",
                                            CType(modifiedRow("SanctionDate"), Date).ToString("dd/MM/yyyy"),
                                            modifiedRow("SanctionType"),
                                            modifiedRow("StudentName"))

                                    validationResult.isValid = False
                                    Exit Do

                                Else

                                    validationResult.message = String.Format(
                                            "The date ({0}) you have selected for a {1} for {2} has already been booked by {3}." +
                                            vbCrLf + "Please select a different date, or delete this sanction and create a new one.",
                                            CType(modifiedRow("SanctionDate"), Date).ToString("dd/MM/yyyy"),
                                            modifiedRow("SanctionType"),
                                            modifiedRow("StudentName"),
                                            sanctionDatesRdr("StaffPreferred") +
                                                " " + sanctionDatesRdr("StaffSurname"))

                                    validationResult.isValid = False
                                    Exit Do

                                End If
                            End If

                        Loop

                    End Using

                    ' We have found an invalid row. Don't need to keep searching. 
                    If validationResult.isValid = False Then
                        Return validationResult
                    End If

                Next

            End Using
        End Using

        Return validationResult

    End Function



    '======================================================================================
    ' EVENT HANDLERS
    '======================================================================================



    Private Sub sanctionListDgv_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) _
            Handles sanctionListDgv.DataError

        Dim msg As String = "The value you have just entered is not in the correct format. Please review your edit and try again."

        If e.ColumnIndex = sanctionListDgv.Columns("SanctionDate").Index Then
            msg = "The value you have entered for SanctionDate is not a valid date." _
                & "Please only enter dates using the format DD/MM/YYYY."
        End If

        MsgBox(msg & vbCrLf & vbCrLf & "If this problem persists, please contact Data Management for assistance.",
                MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Data Format Error")

    End Sub




    Private Sub DeleteBtn_Click(sender As Object, e As EventArgs) Handles DeleteBtn.Click

        If sanctionListDtbl IsNot Nothing Then

            Dim sanctionsToDelete As DataTable = sanctionListDtbl.Select("Selected=1").CopyToDataTable

            If sanctionsToDelete.Rows.Count > 0 Then

                Dim pluralSuffix As String = If(sanctionsToDelete.Rows.Count > 1, "s", "")

                If MsgBox(String.Format(
                        "{0} sanction{1} will be deleted. Do you wish to proceed?",
                        sanctionsToDelete.Rows.Count,
                        pluralSuffix),
                    MsgBoxStyle.YesNo,
                    "Delete Selected Sanctions?") = MsgBoxResult.Yes Then

                    Using synergyConn = New SqlConnection(
                                ConfigurationManager.ConnectionStrings("synergy").ConnectionString)

                        Using deleteCmd = New SqlCommand(
                            ConfigurationManager.AppSettings("DeleteSanctionProc"),
                            synergyConn)

                            deleteCmd.CommandType = CommandType.StoredProcedure

                            synergyConn.Open()

                            For Each sanctionRow As DataRow In sanctionsToDelete.Rows

                                deleteCmd.Parameters.Clear()
                                deleteCmd.Parameters.AddWithValue("Seq", sanctionRow("Seq"))
                                deleteCmd.ExecuteScalar()

                            Next

                        End Using
                    End Using

                End If
            End If
        End If

        PopulateSanctionListDgv()

    End Sub



    Private Sub SaveAndExitBtn_Click(sender As Object, e As EventArgs) Handles SaveAndExitBtn.Click

        Dim validationResult As dataValidationResult = validateSanctionDates()
        If Not validationResult.isValid Then
            MsgBox(validationResult.message,
                   MsgBoxStyle.Critical + MsgBoxStyle.OkOnly,
                   "Invalid Selection")
            Return
        End If

        Try

            Dim modified As DataTable = sanctionListDtbl.GetChanges()

            If modified IsNot Nothing AndAlso modified.Rows.Count > 0 Then

                Using synergyConn = New SqlConnection(
                        ConfigurationManager.ConnectionStrings("synergy").ConnectionString)

                    Using updateCmd = New SqlCommand(
                            ConfigurationManager.AppSettings("UpdateSanctionProc"),
                            synergyConn)

                        synergyConn.Open()

                        updateCmd.CommandType = CommandType.StoredProcedure

                        For Each modifiedRow As DataRow In modified.Rows

                            updateCmd.Parameters.Clear()

                            ' Catch up classes and lunchtime detentions can only be held on certain days if 
                            ' they are handled by the assigning staff member (InformationOnly=Y). 
                            ' If user is not happy with this then skip save. 
                            If (modifiedRow("SanctionType") = "Catch up class" _
                                    Or modifiedRow("SanctionType") = "Detention (Level 1: Lunchtime)") _
                                And (
                                    CType(modifiedRow("SanctionDate"), Date).DayOfWeek = 2 _
                                    Or CType(modifiedRow("SanctionDate"), Date).DayOfWeek = 4) Then

                                If MessageBox.Show(
                                        String.Format(
                                            "Catch up classes and lunchtime detentions on Tuesdays or Thursdays " +
                                            "must be administered in full by the setting teacher. " +
                                            "Your booking for a {0} for {1} on {2} will need to be handled by you. " +
                                            "Do you still wish to set the detention for this date?",
                                            modifiedRow("SanctionType"),
                                            modifiedRow("StudentName"),
                                            CType(modifiedRow("SanctionDate"), Date).ToString("dd/MM/yyyy")),
                                        "Detention Must be Handled by Assigning Teacher",
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question
                                    ) = DialogResult.Yes Then

                                    updateCmd.Parameters.AddWithValue("InformationOnly", True)

                                Else

                                    ' User is not happy to handle this detention themself. 
                                    ' Exit without saving any more rows and go back to the data grid screen. 

                                    Return

                                End If

                            End If

                            updateCmd.Parameters.AddWithValue("Seq", modifiedRow("Seq"))
                            updateCmd.Parameters.AddWithValue("SanctionDate", modifiedRow("SanctionDate"))
                            updateCmd.Parameters.AddWithValue("SanctionType", modifiedRow("SanctionType"))
                            updateCmd.Parameters.AddWithValue("SanctionReason", modifiedRow("Reason"))
                            updateCmd.Parameters.AddWithValue("Comment", modifiedRow("Comment"))

                            updateCmd.ExecuteNonQuery()

                        Next

                    End Using
                End Using

            End If

        Catch ex As Exception

            MsgBox(
                "WARNING: Your changes may not have been saved correctly!" & vbCrLf &
                "Please ensure that you are connected to the Woodcroft network and try again." & vbCrLf &
                "If this problem persists, contact Data Management for assistance." & vbCrLf & vbCrLf &
                "========" & vbCrLf &
                "EXCEPTION DETAILS:" & vbCrLf &
                ex.ToString, MsgBoxStyle.Critical, "Database error!")

        End Try

        MyBase.Close()

    End Sub


End Class