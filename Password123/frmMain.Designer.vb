<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
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
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.lstCategories = New System.Windows.Forms.ListBox()
        Me.MenuStrip2 = New System.Windows.Forms.MenuStrip()
        Me.btnNewCategory = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnEditCategory = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnDeleteCategory = New System.Windows.Forms.ToolStripMenuItem()
        Me.dgvEntries = New System.Windows.Forms.DataGridView()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.btnNewEntry = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnEditEntry = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnDeleteEntry = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnCopyUser = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnCopyPassword = New System.Windows.Forms.ToolStripMenuItem()
        Me.txtSearchEntries = New System.Windows.Forms.ToolStripTextBox()
        Me.MenuStrip3 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnImport = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnExport = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnSettings = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnLock = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.MenuStrip2.SuspendLayout()
        CType(Me.dgvEntries, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.MenuStrip3.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 24)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.lstCategories)
        Me.SplitContainer1.Panel1.Controls.Add(Me.MenuStrip2)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.dgvEntries)
        Me.SplitContainer1.Panel2.Controls.Add(Me.MenuStrip1)
        Me.SplitContainer1.Size = New System.Drawing.Size(979, 529)
        Me.SplitContainer1.SplitterDistance = 127
        Me.SplitContainer1.TabIndex = 1
        '
        'lstCategories
        '
        Me.lstCategories.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstCategories.FormattingEnabled = True
        Me.lstCategories.Location = New System.Drawing.Point(0, 24)
        Me.lstCategories.Name = "lstCategories"
        Me.lstCategories.Size = New System.Drawing.Size(127, 505)
        Me.lstCategories.TabIndex = 0
        '
        'MenuStrip2
        '
        Me.MenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNewCategory, Me.btnEditCategory, Me.btnDeleteCategory})
        Me.MenuStrip2.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip2.Name = "MenuStrip2"
        Me.MenuStrip2.Size = New System.Drawing.Size(127, 24)
        Me.MenuStrip2.TabIndex = 1
        Me.MenuStrip2.Text = "MenuStrip2"
        '
        'btnNewCategory
        '
        Me.btnNewCategory.Name = "btnNewCategory"
        Me.btnNewCategory.Size = New System.Drawing.Size(43, 20)
        Me.btnNewCategory.Text = "New"
        '
        'btnEditCategory
        '
        Me.btnEditCategory.Name = "btnEditCategory"
        Me.btnEditCategory.Size = New System.Drawing.Size(39, 20)
        Me.btnEditCategory.Text = "Edit"
        '
        'btnDeleteCategory
        '
        Me.btnDeleteCategory.Name = "btnDeleteCategory"
        Me.btnDeleteCategory.Size = New System.Drawing.Size(52, 20)
        Me.btnDeleteCategory.Text = "Delete"
        '
        'dgvEntries
        '
        Me.dgvEntries.AllowUserToAddRows = False
        Me.dgvEntries.AllowUserToDeleteRows = False
        Me.dgvEntries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvEntries.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvEntries.Location = New System.Drawing.Point(0, 27)
        Me.dgvEntries.MultiSelect = False
        Me.dgvEntries.Name = "dgvEntries"
        Me.dgvEntries.ReadOnly = True
        Me.dgvEntries.Size = New System.Drawing.Size(848, 502)
        Me.dgvEntries.TabIndex = 1
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNewEntry, Me.btnEditEntry, Me.btnDeleteEntry, Me.CopyToolStripMenuItem, Me.txtSearchEntries})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(848, 27)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'btnNewEntry
        '
        Me.btnNewEntry.Name = "btnNewEntry"
        Me.btnNewEntry.Size = New System.Drawing.Size(43, 23)
        Me.btnNewEntry.Text = "New"
        '
        'btnEditEntry
        '
        Me.btnEditEntry.Name = "btnEditEntry"
        Me.btnEditEntry.Size = New System.Drawing.Size(39, 23)
        Me.btnEditEntry.Text = "Edit"
        '
        'btnDeleteEntry
        '
        Me.btnDeleteEntry.Name = "btnDeleteEntry"
        Me.btnDeleteEntry.Size = New System.Drawing.Size(52, 23)
        Me.btnDeleteEntry.Text = "Delete"
        '
        'CopyToolStripMenuItem
        '
        Me.CopyToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnCopyUser, Me.btnCopyPassword})
        Me.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem"
        Me.CopyToolStripMenuItem.Size = New System.Drawing.Size(47, 23)
        Me.CopyToolStripMenuItem.Text = "Copy"
        '
        'btnCopyUser
        '
        Me.btnCopyUser.Name = "btnCopyUser"
        Me.btnCopyUser.Size = New System.Drawing.Size(124, 22)
        Me.btnCopyUser.Text = "User"
        '
        'btnCopyPassword
        '
        Me.btnCopyPassword.Name = "btnCopyPassword"
        Me.btnCopyPassword.Size = New System.Drawing.Size(124, 22)
        Me.btnCopyPassword.Text = "Password"
        '
        'txtSearchEntries
        '
        Me.txtSearchEntries.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtSearchEntries.Name = "txtSearchEntries"
        Me.txtSearchEntries.Size = New System.Drawing.Size(150, 23)
        '
        'MenuStrip3
        '
        Me.MenuStrip3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.btnSettings, Me.btnLock})
        Me.MenuStrip3.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip3.Name = "MenuStrip3"
        Me.MenuStrip3.Size = New System.Drawing.Size(979, 24)
        Me.MenuStrip3.TabIndex = 2
        Me.MenuStrip3.Text = "MenuStrip3"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnImport, Me.btnExport, Me.btnExit})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'btnImport
        '
        Me.btnImport.Name = "btnImport"
        Me.btnImport.Size = New System.Drawing.Size(180, 22)
        Me.btnImport.Text = "Import"
        '
        'btnExport
        '
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(180, 22)
        Me.btnExport.Text = "Export"
        '
        'btnExit
        '
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(180, 22)
        Me.btnExit.Text = "Exit"
        '
        'btnSettings
        '
        Me.btnSettings.Name = "btnSettings"
        Me.btnSettings.Size = New System.Drawing.Size(61, 20)
        Me.btnSettings.Text = "Settings"
        '
        'btnLock
        '
        Me.btnLock.Name = "btnLock"
        Me.btnLock.Size = New System.Drawing.Size(44, 20)
        Me.btnLock.Text = "Lock"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(979, 553)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.MenuStrip3)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmMain"
        Me.Text = "Password123"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.MenuStrip2.ResumeLayout(False)
        Me.MenuStrip2.PerformLayout()
        CType(Me.dgvEntries, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.MenuStrip3.ResumeLayout(False)
        Me.MenuStrip3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents lstCategories As ListBox
    Friend WithEvents MenuStrip2 As MenuStrip
    Friend WithEvents btnNewCategory As ToolStripMenuItem
    Friend WithEvents btnEditCategory As ToolStripMenuItem
    Friend WithEvents dgvEntries As DataGridView
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents btnNewEntry As ToolStripMenuItem
    Friend WithEvents btnEditEntry As ToolStripMenuItem
    Friend WithEvents btnDeleteEntry As ToolStripMenuItem
    Friend WithEvents btnDeleteCategory As ToolStripMenuItem
    Friend WithEvents MenuStrip3 As MenuStrip
    Friend WithEvents CopyToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnCopyUser As ToolStripMenuItem
    Friend WithEvents btnCopyPassword As ToolStripMenuItem
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnImport As ToolStripMenuItem
    Friend WithEvents btnExport As ToolStripMenuItem
    Friend WithEvents btnExit As ToolStripMenuItem
    Friend WithEvents btnSettings As ToolStripMenuItem
    Friend WithEvents btnLock As ToolStripMenuItem
    Friend WithEvents txtSearchEntries As ToolStripTextBox
End Class
