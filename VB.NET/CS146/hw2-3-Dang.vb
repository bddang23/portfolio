'Class:  CS146, Fall 2019
' Student Name: Binh Dang
' Instructor:   Dr. Cho
' Program: hw2
' Description: This program makes change for an amount of money from 0 through 99 cents input by the user.
' Date:  09/22/2019

Public Class Form1
    Dim quarters As Integer = 25
    Dim dimes As Integer = 10
    Dim nickels As Integer = 5
    Dim cents As Integer = 1
    Dim amount As Integer 'how much change left

    Private Sub btnChange_Click(sender As Object, e As EventArgs) Handles btnChange.Click
        amount = CInt(txtChange.Text) 'total amount
        txtQuaters.Text = CStr(amount \ quarters)
        amount -= CInt(txtQuaters.Text) * quarters 'amount of change left
        txtDimes.Text = CStr((amount) \ dimes)
        amount -= CInt(txtDimes.Text) * dimes 'amount of change left
        txtNickels.Text = CStr((amount) \ nickels)
        amount -= CInt(txtNickels.Text) * nickels 'amount of change left
        txtCents.Text = CStr((amount) \ cents)
    End Sub

End Class
