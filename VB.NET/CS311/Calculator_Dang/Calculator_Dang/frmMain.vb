Public Class frmMain
    '------------------------------------------------------------
    '-                File Name : frmMain.vb                   - 
    '-                Part of Project: Calculator_Dang -
    '------------------------------------------------------------
    '-                Written By: Binh Dang               -
    '-                Written On: March 18, 2022             -
    '------------------------------------------------------------
    '- File Purpose:                                            -
    '-                                                          -
    '- This file contains the window that allows user to open multipe
    'MDI children inside itself. It can control and arrange its children 
    '------------------------------------------------------------
    '- Program Purpose:                                         -
    '-                                                          -
    '- The purpose of this program is to build an MDI calculator application.-
    '- main form should have a main menu with the following options: File, Window and Help.
    '- The Window Option should serve As a Windowlist And have the Tile And Cascade options available under it
    '- .Help should have an About Option that activates an about box dialog.  File should have submenu
    '- Option Onchoices Of New And Exit.  New will instantiate a New child calculator form And Exit
    '------------------------------------------------------------

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        '------------------------------------------------------------
        '-            Subprogram Name: AboutToolStripMenuItem_Click  -
        '------------------------------------------------------------
        '-                Written By: Binh Dang                -
        '-                Written On: March 18, 2022           -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine show the aboutBox information about this program
        '------------------------------------------------------------
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        AboutBox.ShowDialog()
    End Sub

    Public Sub mnuFileNew_Click(sender As Object, e As EventArgs) Handles mnuFileNew.Click
        '------------------------------------------------------------
        '-            Subprogram Name: mnuFileNew_Click  -
        '------------------------------------------------------------
        '-                Written By: Binh Dang                -
        '-                Written On: March 18, 2022           -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine create a new child form which is the calculator form 
        '- which then later show in the main form
        '------------------------------------------------------------
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- aNewChildform - child calculator form                                                   -
        '------------------------------------------------------------
        Dim aNewChildform As frmChildren = New frmChildren()
        aNewChildform.MdiParent = Me
        aNewChildform.Show()
    End Sub

    Private Sub ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnuWindowCascade.Click, mnuWindowTileVertical.Click, mnuWindowTileHorizontal.Click
        '------------------------------------------------------------
        '-            Subprogram Name: ToolStripMenuItem_Click  -
        '------------------------------------------------------------
        '-                Written By: Binh Dang                -
        '-                Written On: March 18, 2022           -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine create a change in different tile form
        '- including cascade, horizontal, and vertical. Managing 3 different click events
        '------------------------------------------------------------
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- mnuItem - look at tool strip items                                             -
        '------------------------------------------------------------
        Dim mnuItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
        If mnuItem.Text.Contains("Cascade") Then
            LayoutMdi(MdiLayout.Cascade) 'make layout cascade
        ElseIf mnuItem.Text.Contains("Vertical") Then
            LayoutMdi(MdiLayout.TileVertical) 'make layout vertical
        Else
            LayoutMdi(MdiLayout.TileHorizontal) 'make layout horizontal
        End If
    End Sub

    Private Sub mnuFileExit_Click(sender As Object, e As EventArgs) Handles mnuFileExit.Click
        '------------------------------------------------------------
        '-            Subprogram Name: mnuFileExit_Click  -
        '------------------------------------------------------------
        '-                Written By: Binh Dang                -
        '-                Written On: March 18, 2022           -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine call form closing event 
        '------------------------------------------------------------
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        Close()
    End Sub
End Class
