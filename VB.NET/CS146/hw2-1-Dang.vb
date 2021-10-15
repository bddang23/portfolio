'Class:  CS146, Fall 2019
' Student Name: Binh Dang
' Instructor:   Dr. Cho
' Program: hw2
' Description: This program allows the users to specify 2 numbers and then adds,substracts, or multiplies them when user clicks on the approriate button.
' Date:  09/22/2019
Public Class Form1
    Dim num, num1, num2 As Double

    Private Sub txt1_TextChanged(sender As Object, e As EventArgs) Handles txt1.TextChanged
        txtResult.Text = Nothing 'When the numbers in the input text box is changed, the output text box will be clear
    End Sub

    Private Sub txt2_TextChanged(sender As Object, e As EventArgs) Handles txt2.TextChanged
        txtResult.Text = Nothing 'When the numbers in the input text box is changed, the output text box will be clear
    End Sub

    Private Sub btnPlus_Click(sender As Object, e As EventArgs) Handles btnPlus.Click
        num1 = CDbl(txt1.Text)
        num2 = CDbl(txt2.Text)
        num = num1 + num2
        txtResult.Text = txt1.Text & " + " & txt2.Text & " = " & CStr(num)
    End Sub

    Private Sub btnSubstract_Click(sender As Object, e As EventArgs) Handles btnSubstract.Click
        num1 = CDbl(txt1.Text)
        num2 = CDbl(txt2.Text)
        num = num1 - num2
        txtResult.Text = txt1.Text & " - " & txt2.Text & " = " & CStr(num)
    End Sub

    Private Sub btnMultiply_Click(sender As Object, e As EventArgs) Handles btnMultiply.Click
        num1 = CDbl(txt1.Text)
        num2 = CDbl(txt2.Text)
        num = num1 * num2
        txtResult.Text = txt1.Text & " x " & txt2.Text & " = " & CStr(num)
    End Sub
End Class
