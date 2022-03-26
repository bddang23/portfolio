<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.mnuFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFileNew = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFileExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuWindow = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuWindowCascade = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuWindowTile = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuWindowTileVertical = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuWindowTileHorizontal = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFile, Me.mnuWindow, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.MdiWindowListItem = Me.mnuWindow
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1112, 28)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'mnuFile
        '
        Me.mnuFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFileNew, Me.mnuFileExit})
        Me.mnuFile.Name = "mnuFile"
        Me.mnuFile.Size = New System.Drawing.Size(44, 24)
        Me.mnuFile.Text = "File"
        '
        'mnuFileNew
        '
        Me.mnuFileNew.Name = "mnuFileNew"
        Me.mnuFileNew.Size = New System.Drawing.Size(216, 26)
        Me.mnuFileNew.Text = "New"
        '
        'mnuFileExit
        '
        Me.mnuFileExit.Name = "mnuFileExit"
        Me.mnuFileExit.Size = New System.Drawing.Size(216, 26)
        Me.mnuFileExit.Text = "Exit"
        '
        'mnuWindow
        '
        Me.mnuWindow.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuWindowCascade, Me.mnuWindowTile})
        Me.mnuWindow.Name = "mnuWindow"
        Me.mnuWindow.Size = New System.Drawing.Size(76, 24)
        Me.mnuWindow.Text = "Window"
        '
        'mnuWindowCascade
        '
        Me.mnuWindowCascade.Name = "mnuWindowCascade"
        Me.mnuWindowCascade.Size = New System.Drawing.Size(139, 26)
        Me.mnuWindowCascade.Text = "Cascade"
        '
        'mnuWindowTile
        '
        Me.mnuWindowTile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuWindowTileVertical, Me.mnuWindowTileHorizontal})
        Me.mnuWindowTile.Name = "mnuWindowTile"
        Me.mnuWindowTile.Size = New System.Drawing.Size(139, 26)
        Me.mnuWindowTile.Text = "Tile"
        '
        'mnuWindowTileVertical
        '
        Me.mnuWindowTileVertical.Name = "mnuWindowTileVertical"
        Me.mnuWindowTileVertical.Size = New System.Drawing.Size(154, 26)
        Me.mnuWindowTileVertical.Text = "Vertical"
        '
        'mnuWindowTileHorizontal
        '
        Me.mnuWindowTileHorizontal.Name = "mnuWindowTileHorizontal"
        Me.mnuWindowTileHorizontal.Size = New System.Drawing.Size(154, 26)
        Me.mnuWindowTileHorizontal.Text = "Horizontal"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(53, 24)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(125, 26)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1112, 662)
        Me.Controls.Add(Me.MenuStrip1)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmMain"
        Me.Text = "Programmer's Calculators"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents mnuFile As ToolStripMenuItem
    Friend WithEvents mnuFileNew As ToolStripMenuItem
    Friend WithEvents mnuFileExit As ToolStripMenuItem
    Friend WithEvents mnuWindow As ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents mnuWindowCascade As ToolStripMenuItem
    Friend WithEvents mnuWindowTile As ToolStripMenuItem
    Friend WithEvents mnuWindowTileVertical As ToolStripMenuItem
    Friend WithEvents mnuWindowTileHorizontal As ToolStripMenuItem
End Class
