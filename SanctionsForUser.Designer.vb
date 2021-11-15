<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SanctionsForUser
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.sanctionListDgv = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DeleteBtn = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SaveAndExitBtn = New System.Windows.Forms.Button()
        CType(Me.sanctionListDgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'sanctionListDgv
        '
        Me.sanctionListDgv.AllowUserToAddRows = False
        Me.sanctionListDgv.AllowUserToDeleteRows = False
        Me.sanctionListDgv.AllowUserToResizeRows = False
        Me.sanctionListDgv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sanctionListDgv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.sanctionListDgv.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.sanctionListDgv.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.sanctionListDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.sanctionListDgv.DefaultCellStyle = DataGridViewCellStyle5
        Me.sanctionListDgv.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.sanctionListDgv.Location = New System.Drawing.Point(12, 53)
        Me.sanctionListDgv.MultiSelect = False
        Me.sanctionListDgv.Name = "sanctionListDgv"
        Me.sanctionListDgv.RowHeadersVisible = False
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.sanctionListDgv.RowsDefaultCellStyle = DataGridViewCellStyle6
        Me.sanctionListDgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.sanctionListDgv.Size = New System.Drawing.Size(963, 271)
        Me.sanctionListDgv.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(665, 17)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "To delete sanctions, select them using the tick-boxes in the first column and the" &
    "n click 'Delete Selected'. "
        '
        'DeleteBtn
        '
        Me.DeleteBtn.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DeleteBtn.AutoSize = True
        Me.DeleteBtn.BackColor = System.Drawing.Color.Firebrick
        Me.DeleteBtn.FlatAppearance.BorderColor = System.Drawing.Color.Maroon
        Me.DeleteBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.DeleteBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DeleteBtn.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.DeleteBtn.Location = New System.Drawing.Point(842, 20)
        Me.DeleteBtn.Name = "DeleteBtn"
        Me.DeleteBtn.Size = New System.Drawing.Size(133, 27)
        Me.DeleteBtn.TabIndex = 2
        Me.DeleteBtn.Text = "Delete Selected"
        Me.DeleteBtn.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(237, 17)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Modify your existing sanctions here. "
        '
        'SaveAndExitBtn
        '
        Me.SaveAndExitBtn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SaveAndExitBtn.AutoSize = True
        Me.SaveAndExitBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.SaveAndExitBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SaveAndExitBtn.Location = New System.Drawing.Point(811, 330)
        Me.SaveAndExitBtn.Name = "SaveAndExitBtn"
        Me.SaveAndExitBtn.Size = New System.Drawing.Size(164, 27)
        Me.SaveAndExitBtn.TabIndex = 6
        Me.SaveAndExitBtn.Text = "Save Changes and Exit"
        Me.SaveAndExitBtn.UseVisualStyleBackColor = True
        '
        'SanctionsForUser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(987, 369)
        Me.Controls.Add(Me.SaveAndExitBtn)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.DeleteBtn)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.sanctionListDgv)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SanctionsForUser"
        Me.Text = "Future Sanctions"
        CType(Me.sanctionListDgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents sanctionListDgv As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents DeleteBtn As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents SaveAndExitBtn As Button
End Class
