<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Main
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SanctionTypeCbx = New System.Windows.Forms.ComboBox()
        Me.SanctionTypeLbl = New System.Windows.Forms.Label()
        Me.DateSelectorCbx = New System.Windows.Forms.ComboBox()
        Me.SanctionDateLbl = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CommentTbx = New System.Windows.Forms.TextBox()
        Me.CommentLbl = New System.Windows.Forms.Label()
        Me.SubmitBtn = New System.Windows.Forms.Button()
        Me.CurrentGradeCbx = New System.Windows.Forms.ComboBox()
        Me.CurrentGradeLbl = New System.Windows.Forms.Label()
        Me.DueDateCbx = New System.Windows.Forms.ComboBox()
        Me.DueDateLbl = New System.Windows.Forms.Label()
        Me.TaskNameTbx = New System.Windows.Forms.TextBox()
        Me.TaskNameLbl = New System.Windows.Forms.Label()
        Me.InformationOnlyChk = New System.Windows.Forms.CheckBox()
        Me.InformationOnlyLbl = New System.Windows.Forms.TextBox()
        Me.ReasonLbl = New System.Windows.Forms.Label()
        Me.ReasonCbx = New System.Windows.Forms.ComboBox()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.ClassLbl = New System.Windows.Forms.Label()
        Me.ClassCbx = New System.Windows.Forms.ComboBox()
        Me.StaffMemberCbx = New System.Windows.Forms.ComboBox()
        Me.StaffMemberLbl = New System.Windows.Forms.Label()
        Me.IncidentDateLbl = New System.Windows.Forms.Label()
        Me.ViewCurrentBookingsBtn = New System.Windows.Forms.Button()
        Me.StudentPhotoPbx = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.StudentPhotoPbx, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(10, 237)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 18)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Student:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(10, 160)
        Me.Label2.Margin = New System.Windows.Forms.Padding(0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(508, 65)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Start by selecting the student you wish to sanction. " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Type part of the student's" &
    " name in the box below to see a list of suggestions. "
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'SanctionTypeCbx
        '
        Me.SanctionTypeCbx.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SanctionTypeCbx.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.SanctionTypeCbx.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.SanctionTypeCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.SanctionTypeCbx.Font = New System.Drawing.Font("Gill Sans MT", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SanctionTypeCbx.FormattingEnabled = True
        Me.SanctionTypeCbx.Location = New System.Drawing.Point(740, 90)
        Me.SanctionTypeCbx.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.SanctionTypeCbx.Name = "SanctionTypeCbx"
        Me.SanctionTypeCbx.Size = New System.Drawing.Size(367, 29)
        Me.SanctionTypeCbx.TabIndex = 4
        Me.SanctionTypeCbx.Visible = False
        '
        'SanctionTypeLbl
        '
        Me.SanctionTypeLbl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SanctionTypeLbl.AutoSize = True
        Me.SanctionTypeLbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SanctionTypeLbl.Location = New System.Drawing.Point(636, 95)
        Me.SanctionTypeLbl.Margin = New System.Windows.Forms.Padding(0)
        Me.SanctionTypeLbl.Name = "SanctionTypeLbl"
        Me.SanctionTypeLbl.Size = New System.Drawing.Size(101, 18)
        Me.SanctionTypeLbl.TabIndex = 16
        Me.SanctionTypeLbl.Text = "Sanction type:"
        Me.SanctionTypeLbl.Visible = False
        '
        'DateSelectorCbx
        '
        Me.DateSelectorCbx.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DateSelectorCbx.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.DateSelectorCbx.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.DateSelectorCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.DateSelectorCbx.Font = New System.Drawing.Font("Gill Sans MT", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateSelectorCbx.FormattingEnabled = True
        Me.DateSelectorCbx.Location = New System.Drawing.Point(840, 234)
        Me.DateSelectorCbx.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.DateSelectorCbx.Name = "DateSelectorCbx"
        Me.DateSelectorCbx.Size = New System.Drawing.Size(267, 29)
        Me.DateSelectorCbx.TabIndex = 9
        Me.DateSelectorCbx.Visible = False
        '
        'SanctionDateLbl
        '
        Me.SanctionDateLbl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SanctionDateLbl.AutoSize = True
        Me.SanctionDateLbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SanctionDateLbl.Location = New System.Drawing.Point(734, 239)
        Me.SanctionDateLbl.Margin = New System.Windows.Forms.Padding(0)
        Me.SanctionDateLbl.Name = "SanctionDateLbl"
        Me.SanctionDateLbl.Size = New System.Drawing.Size(102, 18)
        Me.SanctionDateLbl.TabIndex = 20
        Me.SanctionDateLbl.Text = "Sanction date:"
        Me.SanctionDateLbl.Visible = False
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(121, 12)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(469, 23)
        Me.Label4.TabIndex = 21
        Me.Label4.Text = "Welcome to the Behaviour Management System"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CommentTbx
        '
        Me.CommentTbx.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CommentTbx.Font = New System.Drawing.Font("Gill Sans MT", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CommentTbx.Location = New System.Drawing.Point(741, 273)
        Me.CommentTbx.Multiline = True
        Me.CommentTbx.Name = "CommentTbx"
        Me.CommentTbx.Size = New System.Drawing.Size(367, 79)
        Me.CommentTbx.TabIndex = 10
        Me.CommentTbx.Visible = False
        '
        'CommentLbl
        '
        Me.CommentLbl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CommentLbl.AutoSize = True
        Me.CommentLbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CommentLbl.Location = New System.Drawing.Point(659, 277)
        Me.CommentLbl.Margin = New System.Windows.Forms.Padding(0)
        Me.CommentLbl.Name = "CommentLbl"
        Me.CommentLbl.Size = New System.Drawing.Size(78, 18)
        Me.CommentLbl.TabIndex = 24
        Me.CommentLbl.Text = "Comment:"
        Me.CommentLbl.Visible = False
        '
        'SubmitBtn
        '
        Me.SubmitBtn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SubmitBtn.Font = New System.Drawing.Font("Gill Sans MT", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SubmitBtn.Location = New System.Drawing.Point(953, 451)
        Me.SubmitBtn.Name = "SubmitBtn"
        Me.SubmitBtn.Size = New System.Drawing.Size(156, 31)
        Me.SubmitBtn.TabIndex = 12
        Me.SubmitBtn.Text = "Submit Booking"
        Me.SubmitBtn.UseVisualStyleBackColor = True
        Me.SubmitBtn.Visible = False
        '
        'CurrentGradeCbx
        '
        Me.CurrentGradeCbx.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CurrentGradeCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CurrentGradeCbx.Font = New System.Drawing.Font("Gill Sans MT", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CurrentGradeCbx.FormattingEnabled = True
        Me.CurrentGradeCbx.Items.AddRange(New Object() {"NOT APPLICABLE", "1", "2", "3", "4", "5", "6", "7", "1 Modified", "2 Modified", "3 Modified", "4 Modified", "5 Modified", "6 Modified", "7 Modified", "A+", "A", "A-", "B+", "B", "B-", "C+", "C", "C-", "D+", "D", "D-", "E+", "E", "E-", "U"})
        Me.CurrentGradeCbx.Location = New System.Drawing.Point(966, 125)
        Me.CurrentGradeCbx.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.CurrentGradeCbx.Name = "CurrentGradeCbx"
        Me.CurrentGradeCbx.Size = New System.Drawing.Size(141, 29)
        Me.CurrentGradeCbx.TabIndex = 6
        Me.CurrentGradeCbx.Visible = False
        '
        'CurrentGradeLbl
        '
        Me.CurrentGradeLbl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CurrentGradeLbl.AutoSize = True
        Me.CurrentGradeLbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CurrentGradeLbl.Location = New System.Drawing.Point(860, 130)
        Me.CurrentGradeLbl.Margin = New System.Windows.Forms.Padding(0)
        Me.CurrentGradeLbl.Name = "CurrentGradeLbl"
        Me.CurrentGradeLbl.Size = New System.Drawing.Size(102, 18)
        Me.CurrentGradeLbl.TabIndex = 27
        Me.CurrentGradeLbl.Text = "Current grade:"
        Me.CurrentGradeLbl.Visible = False
        '
        'DueDateCbx
        '
        Me.DueDateCbx.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DueDateCbx.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.DueDateCbx.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.DueDateCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.DueDateCbx.Font = New System.Drawing.Font("Gill Sans MT", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DueDateCbx.FormattingEnabled = True
        Me.DueDateCbx.Location = New System.Drawing.Point(840, 160)
        Me.DueDateCbx.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.DueDateCbx.Name = "DueDateCbx"
        Me.DueDateCbx.Size = New System.Drawing.Size(267, 29)
        Me.DueDateCbx.TabIndex = 7
        Me.DueDateCbx.Visible = False
        '
        'DueDateLbl
        '
        Me.DueDateLbl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DueDateLbl.AutoSize = True
        Me.DueDateLbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DueDateLbl.Location = New System.Drawing.Point(765, 165)
        Me.DueDateLbl.Margin = New System.Windows.Forms.Padding(0)
        Me.DueDateLbl.Name = "DueDateLbl"
        Me.DueDateLbl.Size = New System.Drawing.Size(71, 18)
        Me.DueDateLbl.TabIndex = 30
        Me.DueDateLbl.Text = "Due date:"
        Me.DueDateLbl.Visible = False
        '
        'TaskNameTbx
        '
        Me.TaskNameTbx.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TaskNameTbx.Font = New System.Drawing.Font("Gill Sans MT", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TaskNameTbx.Location = New System.Drawing.Point(740, 127)
        Me.TaskNameTbx.Name = "TaskNameTbx"
        Me.TaskNameTbx.Size = New System.Drawing.Size(367, 25)
        Me.TaskNameTbx.TabIndex = 5
        Me.TaskNameTbx.Visible = False
        '
        'TaskNameLbl
        '
        Me.TaskNameLbl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TaskNameLbl.AutoSize = True
        Me.TaskNameLbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TaskNameLbl.Location = New System.Drawing.Point(651, 130)
        Me.TaskNameLbl.Margin = New System.Windows.Forms.Padding(0)
        Me.TaskNameLbl.Name = "TaskNameLbl"
        Me.TaskNameLbl.Size = New System.Drawing.Size(86, 18)
        Me.TaskNameLbl.TabIndex = 32
        Me.TaskNameLbl.Text = "Task name:"
        Me.TaskNameLbl.Visible = False
        '
        'InformationOnlyChk
        '
        Me.InformationOnlyChk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.InformationOnlyChk.AutoSize = True
        Me.InformationOnlyChk.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.InformationOnlyChk.Font = New System.Drawing.Font("Gill Sans MT", 11.0!)
        Me.InformationOnlyChk.Location = New System.Drawing.Point(971, 367)
        Me.InformationOnlyChk.Name = "InformationOnlyChk"
        Me.InformationOnlyChk.Size = New System.Drawing.Size(137, 25)
        Me.InformationOnlyChk.TabIndex = 11
        Me.InformationOnlyChk.Text = "Information Only:"
        Me.InformationOnlyChk.UseVisualStyleBackColor = True
        Me.InformationOnlyChk.Visible = False
        '
        'InformationOnlyLbl
        '
        Me.InformationOnlyLbl.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.InformationOnlyLbl.Enabled = False
        Me.InformationOnlyLbl.Font = New System.Drawing.Font("Gill Sans MT", 9.0!)
        Me.InformationOnlyLbl.Location = New System.Drawing.Point(744, 399)
        Me.InformationOnlyLbl.Multiline = True
        Me.InformationOnlyLbl.Name = "InformationOnlyLbl"
        Me.InformationOnlyLbl.ReadOnly = True
        Me.InformationOnlyLbl.Size = New System.Drawing.Size(364, 45)
        Me.InformationOnlyLbl.TabIndex = 36
        Me.InformationOnlyLbl.Text = "Tick this box if you intend to handle the detention or catch up class yourself. T" &
    "he sanction will be recorded for statistical purposes only."
        Me.InformationOnlyLbl.Visible = False
        '
        'ReasonLbl
        '
        Me.ReasonLbl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ReasonLbl.AutoSize = True
        Me.ReasonLbl.Font = New System.Drawing.Font("Gill Sans MT", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReasonLbl.Location = New System.Drawing.Point(774, 200)
        Me.ReasonLbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.ReasonLbl.Name = "ReasonLbl"
        Me.ReasonLbl.Size = New System.Drawing.Size(62, 23)
        Me.ReasonLbl.TabIndex = 37
        Me.ReasonLbl.Text = "Reason:"
        Me.ReasonLbl.Visible = False
        '
        'ReasonCbx
        '
        Me.ReasonCbx.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ReasonCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ReasonCbx.Font = New System.Drawing.Font("Gill Sans MT", 11.0!)
        Me.ReasonCbx.FormattingEnabled = True
        Me.ReasonCbx.Location = New System.Drawing.Point(840, 197)
        Me.ReasonCbx.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ReasonCbx.Name = "ReasonCbx"
        Me.ReasonCbx.Size = New System.Drawing.Size(267, 29)
        Me.ReasonCbx.TabIndex = 8
        Me.ReasonCbx.Visible = False
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ReportViewer1.BackColor = System.Drawing.SystemColors.Control
        Me.ReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ReportViewer1.Location = New System.Drawing.Point(218, 284)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Remote
        Me.ReportViewer1.ServerReport.ReportPath = "/Behaviour Monitoring System/Staffsms"
        Me.ReportViewer1.ServerReport.ReportServerUrl = New System.Uri("http://testserver2.woodcroft.sa.edu.au/reportserver", System.UriKind.Absolute)
        Me.ReportViewer1.ShowParameterPrompts = False
        Me.ReportViewer1.ShowToolBar = False
        Me.ReportViewer1.Size = New System.Drawing.Size(413, 235)
        Me.ReportViewer1.TabIndex = 40
        Me.ReportViewer1.Visible = False
        '
        'ClassLbl
        '
        Me.ClassLbl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ClassLbl.AutoSize = True
        Me.ClassLbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ClassLbl.Location = New System.Drawing.Point(687, 58)
        Me.ClassLbl.Margin = New System.Windows.Forms.Padding(0)
        Me.ClassLbl.Name = "ClassLbl"
        Me.ClassLbl.Size = New System.Drawing.Size(50, 18)
        Me.ClassLbl.TabIndex = 42
        Me.ClassLbl.Text = "Class:"
        Me.ClassLbl.Visible = False
        '
        'ClassCbx
        '
        Me.ClassCbx.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ClassCbx.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.ClassCbx.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ClassCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ClassCbx.Font = New System.Drawing.Font("Gill Sans MT", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ClassCbx.FormattingEnabled = True
        Me.ClassCbx.Location = New System.Drawing.Point(740, 53)
        Me.ClassCbx.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ClassCbx.Name = "ClassCbx"
        Me.ClassCbx.Size = New System.Drawing.Size(367, 29)
        Me.ClassCbx.TabIndex = 3
        Me.ClassCbx.Visible = False
        '
        'StaffMemberCbx
        '
        Me.StaffMemberCbx.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.StaffMemberCbx.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.StaffMemberCbx.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.StaffMemberCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.StaffMemberCbx.Font = New System.Drawing.Font("Gill Sans MT", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StaffMemberCbx.FormattingEnabled = True
        Me.StaffMemberCbx.Location = New System.Drawing.Point(740, 14)
        Me.StaffMemberCbx.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.StaffMemberCbx.Name = "StaffMemberCbx"
        Me.StaffMemberCbx.Size = New System.Drawing.Size(367, 29)
        Me.StaffMemberCbx.TabIndex = 2
        Me.StaffMemberCbx.Visible = False
        '
        'StaffMemberLbl
        '
        Me.StaffMemberLbl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.StaffMemberLbl.AutoSize = True
        Me.StaffMemberLbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StaffMemberLbl.Location = New System.Drawing.Point(635, 18)
        Me.StaffMemberLbl.Margin = New System.Windows.Forms.Padding(0)
        Me.StaffMemberLbl.Name = "StaffMemberLbl"
        Me.StaffMemberLbl.Size = New System.Drawing.Size(101, 18)
        Me.StaffMemberLbl.TabIndex = 44
        Me.StaffMemberLbl.Text = "Staff Member:"
        Me.StaffMemberLbl.Visible = False
        '
        'IncidentDateLbl
        '
        Me.IncidentDateLbl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IncidentDateLbl.AutoSize = True
        Me.IncidentDateLbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IncidentDateLbl.Location = New System.Drawing.Point(742, 239)
        Me.IncidentDateLbl.Margin = New System.Windows.Forms.Padding(0)
        Me.IncidentDateLbl.Name = "IncidentDateLbl"
        Me.IncidentDateLbl.Size = New System.Drawing.Size(94, 18)
        Me.IncidentDateLbl.TabIndex = 45
        Me.IncidentDateLbl.Text = "Incident date:"
        Me.IncidentDateLbl.Visible = False
        '
        'ViewCurrentBookingsBtn
        '
        Me.ViewCurrentBookingsBtn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ViewCurrentBookingsBtn.AutoSize = True
        Me.ViewCurrentBookingsBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ViewCurrentBookingsBtn.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ViewCurrentBookingsBtn.Font = New System.Drawing.Font("Gill Sans MT", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ViewCurrentBookingsBtn.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.ViewCurrentBookingsBtn.Location = New System.Drawing.Point(911, 488)
        Me.ViewCurrentBookingsBtn.Name = "ViewCurrentBookingsBtn"
        Me.ViewCurrentBookingsBtn.Size = New System.Drawing.Size(198, 31)
        Me.ViewCurrentBookingsBtn.TabIndex = 46
        Me.ViewCurrentBookingsBtn.Text = "View Your Current Bookings"
        Me.ViewCurrentBookingsBtn.UseVisualStyleBackColor = False
        '
        'StudentPhotoPbx
        '
        Me.StudentPhotoPbx.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.StudentPhotoPbx.Location = New System.Drawing.Point(13, 284)
        Me.StudentPhotoPbx.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.StudentPhotoPbx.Name = "StudentPhotoPbx"
        Me.StudentPhotoPbx.Size = New System.Drawing.Size(198, 235)
        Me.StudentPhotoPbx.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.StudentPhotoPbx.TabIndex = 39
        Me.StudentPhotoPbx.TabStop = False
        Me.StudentPhotoPbx.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.BMS.My.Resources.Resources.Woodcroft_College_CMYK_TransBack_v2
        Me.PictureBox1.Location = New System.Drawing.Point(13, 14)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(102, 116)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 3
        Me.PictureBox1.TabStop = False
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1120, 531)
        Me.Controls.Add(Me.ViewCurrentBookingsBtn)
        Me.Controls.Add(Me.SanctionDateLbl)
        Me.Controls.Add(Me.IncidentDateLbl)
        Me.Controls.Add(Me.StaffMemberLbl)
        Me.Controls.Add(Me.StaffMemberCbx)
        Me.Controls.Add(Me.InformationOnlyChk)
        Me.Controls.Add(Me.ClassLbl)
        Me.Controls.Add(Me.ClassCbx)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Controls.Add(Me.StudentPhotoPbx)
        Me.Controls.Add(Me.ReasonCbx)
        Me.Controls.Add(Me.ReasonLbl)
        Me.Controls.Add(Me.InformationOnlyLbl)
        Me.Controls.Add(Me.TaskNameLbl)
        Me.Controls.Add(Me.DueDateLbl)
        Me.Controls.Add(Me.DueDateCbx)
        Me.Controls.Add(Me.CurrentGradeLbl)
        Me.Controls.Add(Me.CurrentGradeCbx)
        Me.Controls.Add(Me.SubmitBtn)
        Me.Controls.Add(Me.CommentLbl)
        Me.Controls.Add(Me.CommentTbx)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.DateSelectorCbx)
        Me.Controls.Add(Me.SanctionTypeLbl)
        Me.Controls.Add(Me.SanctionTypeCbx)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.TaskNameTbx)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Main"
        Me.Text = "BMS - Behaviour Management System"
        CType(Me.StudentPhotoPbx, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents SanctionTypeCbx As ComboBox
    Friend WithEvents SanctionTypeLbl As Label
    Friend WithEvents StudentsMbx As MatchingComboBox
    Friend WithEvents DateSelectorCbx As ComboBox
    Friend WithEvents SanctionDateLbl As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents CommentTbx As TextBox
    Friend WithEvents CommentLbl As Label
    Friend WithEvents SubmitBtn As Button
    Friend WithEvents CurrentGradeCbx As ComboBox
    Friend WithEvents CurrentGradeLbl As Label
    Friend WithEvents DueDateCbx As ComboBox
    Friend WithEvents DueDateLbl As Label
    Friend WithEvents TaskNameTbx As TextBox
    Friend WithEvents TaskNameLbl As Label
    Friend WithEvents InformationOnlyChk As CheckBox
    Friend WithEvents InformationOnlyLbl As TextBox
    Friend WithEvents ReasonLbl As Label
    Friend WithEvents ReasonCbx As ComboBox
    Friend WithEvents BindingSource1 As BindingSource
    Friend WithEvents StudentPhotoPbx As PictureBox
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents ClassLbl As Label
    Friend WithEvents ClassCbx As ComboBox
    Friend WithEvents StaffMemberCbx As ComboBox
    Friend WithEvents StaffMemberLbl As Label
    Friend WithEvents IncidentDateLbl As Label
    Friend WithEvents ViewCurrentBookingsBtn As Button
End Class
