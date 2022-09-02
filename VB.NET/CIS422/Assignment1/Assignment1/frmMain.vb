Imports System.ComponentModel

Public Class frmMain
    '------------------------------------------------------------
    '-                File Name : frmMain.vb                   - 
    '-                Part of Project: Assignment 1 -
    '------------------------------------------------------------
    '-                Written By: Binh Dang               -
    '-                Written On: September 1,2022             -
    '------------------------------------------------------------
    '- File Purpose:                                            -
    '-                                                          -
    '- This file contains the window that allows user to open multipe
    'MDI children inside itself. It can control and arrange its children 
    '------------------------------------------------------------
    '- Program Purpose:                                         -
    '-                                                          -
    '- The purpose of this program is to build an MDI  application.-
    '- main form should have a main menu with the following options: File.
    '- File should have submenu Option Onchoices Of New And Exit.  
    '- New will instantiate a New child form, And Exit will close all form
    '------------------------------------------------------------
    Private Sub mnuNew_Click(sender As Object, e As EventArgs) Handles mnuNew.Click
        '------------------------------------------------------------
        '-            Subprogram Name: mnuNew_Click  -
        '------------------------------------------------------------
        '-                Written By: Binh Dang                -
        '-                Written On: September 1st, 2022           -
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
        '------------------------------------------------------------
        '-            Subprogram Name: mnuFileExit_Click  -
        '------------------------------------------------------------
        '-                Written By: Binh Dang                -
        '-                Written On: September 1st, 2022           -
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

    Private Sub frmMain_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        '------------------------------------------------------------
        '-            Subprogram Name: frmMain_Closing  -
        '------------------------------------------------------------
        '-                Written By: Binh Dang                -
        '-                Written On: September 1st, 2022           -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine close and show a yes/no prompt only when there
        '- is one or more MDI children
        '------------------------------------------------------------
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        If MdiChildren.Length > 0 Then
            If MessageBox.Show("Are you sure you want to quit?", "Ordering Form", MessageBoxButtons.YesNo) = DialogResult.No Then
                e.Cancel = True
            Else
                e.Cancel = False
            End If
        End If
    End Sub
End Class