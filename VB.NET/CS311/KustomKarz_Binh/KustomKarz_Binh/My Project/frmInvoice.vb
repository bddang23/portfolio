Imports System.ComponentModel

Public Class frmInvoice
    '------------------------------------------------------------
    '-                File Name : frmInvoice.vb                   - 
    '-                Part of Project: KustomKarz_Binh -
    '------------------------------------------------------------
    '-                Written By: Binh Dang               -
    '-                Written On: January 24, 2022              -
    '------------------------------------------------------------
    '- File Purpose:                                            -
    '-                                                          -
    '- This file contains the subdirectory that allow user to see the invoice
    '- with their input value. Also it allow user to change order before submitting it.
    '- IF user is done, they can submit to exit! which is the only way to exit in the program
    '------------------------------------------------------------
    '- Program Purpose:                                         -
    '-                                                          -
    '- The purpose of this program is to handle the calculations-
    '- and bill generation for a project carried out by KustomKarz-
    '- company, which we give to our client. Cars costs are  -
    '- made up of base price, powertrain cost, and optional choice cost.  
    '- User will choose their desire type and options.The program will then display a neatly         -
    '- formatted receipt.                                       -
    '------------------------------------------------------------
    '------------------------------------------------------------
    '- Global Variable Dictionary (alphabetically) FROM GLOBAL VAR MODULE:              -
    '- arrOptional - ArrayList that is used to store user's options
    '- blnisClose - Check to see if the main Order form can close or not

    '- Global Variable from frmInvoice:
    '- blnisChange - condition to see when switching form to form
    '- 
    '- GLOBAL SUBPROGRAM FROM GLOBALVAR Module
    '- Reset() - Subprocedure that reset all the elements on the Order form
    '- PrintInvoice() - Subprocedure that print invoice
    '------------------------------------------------------------
    Dim blnisChange As Boolean = False
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        '------------------------------------------------------------
        '-            Subprogram Name: btnExit_Click  -
        '------------------------------------------------------------
        '-                Written By: Binh Dang                -
        '-                Written On: January 25, 2022              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine close the program which will show the pop-up message box
        '- asking if user want to exit the system or not
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        blnisChange = False
        Close()
    End Sub

    Private Sub frmInvoice_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        '------------------------------------------------------------
        '-            Subprogram Name: frmInvoice_Closing  -
        '------------------------------------------------------------
        '-                Written By: Binh Dang                -
        '-                Written On: January 24, 2022              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This closing subroutines checking if the user is switching between form 
        '-if the boolean ischange is true then it will hide this form and switch
        '- else showing yes/no messagebox that close the whole prog by say yes
        '- or say keep the form the same when say no
        '------------------------------------------------------------
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------

        'Global variable that is set up in the globalvar.vb file and it will change when the user
        'finish with the application And exit from the invoice screen.
        If blnisChange = True Then
            Hide()
        Else
            If MessageBox.Show("Are you sure you want to quit?", "Kustom Karz Order System", MessageBoxButtons.YesNo) = DialogResult.No Then
                e.Cancel = True
            Else
                e.Cancel = False
                blnisClose = True 'Condition for the frmOrder to close
                frmOrder.Close() ' if user say yes then also  close the next form
            End If
        End If


    End Sub

    Private Sub btnChange_Click(sender As Object, e As EventArgs) Handles btnChange.Click
        '------------------------------------------------------------
        '-            Subprogram Name: btnChange_Click  -
        '------------------------------------------------------------
        '-                Written By: Binh Dang                -
        '-                Written On: January 25, 2022              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine allows user to change their order after submitting their order
        '- All the options that they choose should be all the same. the ivoice form will be close and 
        '- the order form will pop-up
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------

        blnisChange = True
        'clear the array so later can read and print the correct amount of options
        arrOptional.Clear()
        lstInvoice.Items.Clear() 'delete the invoice
        frmOrder.Show() 'show the order form
        Hide() 'close the form
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        '------------------------------------------------------------
        '-            Subprogram Name: btnSubmit_Click
        '------------------------------------------------------------
        '-                Written By: Binh Dang                -
        '-                Written On: January 25, 2022              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine allows user to submit to the manufacture which
        '- then return back to the Order form with all reset value
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        Reset() 'reset function in the public module
        frmOrder.Show() 'Show the order form
        'clear the array so later can read and print the correct amount of options
        arrOptional.Clear()
        blnisChange = True
        lstInvoice.Items.Clear() 'Clear the invoice
        Hide() ' Hide the form
    End Sub

    Private Sub frmInvoice_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '------------------------------------------------------------
        '-            Subprogram Name: frmInvoice_Load
        '------------------------------------------------------------
        '-                Written By: Binh Dang                -
        '-                Written On: January 25, 2022              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine will print out the invoice that using 
        '- the global subprocedure PrintInvoice from Global Var module
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        blnisChange = False
        PrintInvoice() ' Print out the invoice 
    End Sub
End Class