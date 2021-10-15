'Class:  CS146, Fall 2019
' Student Name: Binh Dang
' Instructor:   Dr. Cho
' Program: hw2
' Description: This program calculates the monthly payment after the user gives the amount of loan, interest rate, and number of years.
' Date:  09/22/2019
Public Class Form1
    Private Sub bthCalculate_Click(sender As Object, e As EventArgs) Handles bthCalculate.Click
        Dim A As Double = CDbl(txtLoan.Text) 'A is car loan
        Dim r As Double = CDbl(txtRate.Text) 'r is interest rate
        Dim n As Double = CDbl(txtYears.Text) 'n is number of year
        Dim i As Double 'i is rate 
        Dim Payment As Double
        i = r / 1200
        Payment = (i * A) / (1 - (1 + i) ^ (-12 * n))
        txtCalculate.Text = Payment.ToString("C2")
    End Sub
End Class
