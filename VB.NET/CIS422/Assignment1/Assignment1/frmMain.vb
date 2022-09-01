Public Class frmMain

    Private Sub mnuNew_Click(sender As Object, e As EventArgs) Handles mnuNew.Click
        '------------------------------------------------------------
        '-            Subprogram Name: mnuNew_Click  -
        '------------------------------------------------------------
        '-                Written By: Binh Dang                -
        '-                Written On: September 9th, 2022           -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine create a new child form - Order Form
        '------------------------------------------------------------
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- newChildform - child Order form                                                   -
        '------------------------------------------------------------
        Dim newChildForm As frmOrdering = New frmOrdering()
        newChildForm.MdiParent = Me
        newChildForm.Show()
    End Sub

    Private Sub mnuExit_Click(sender As Object, e As EventArgs) Handles mnuExit.Click

    End Sub
End Class