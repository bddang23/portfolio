Public Class frmAlign
    Private Sub frmAlign_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Align Text - BD"
    End Sub
    Private Sub txtBox_VisibleChanged(sender As Object, e As EventArgs) Handles txtBox.VisibleChanged
        txtBox.ReadOnly = True
    End Sub
    Private Sub btnLeft_Click(sender As Object, e As EventArgs) Handles btnLeft.Click
        txtBox.Text = "Left Justify"
        txtBox.TextAlign = HorizontalAlignment.Left
    End Sub
    Private Sub btnCenter_Click(sender As Object, e As EventArgs) Handles btnCenter.Click
        txtBox.Text = "Center"
        txtBox.TextAlign = HorizontalAlignment.Center
    End Sub
    Private Sub btnRight_Click(sender As Object, e As EventArgs) Handles btnRight.Click
        txtBox.Text = "Right Justify"
        txtBox.TextAlign = HorizontalAlignment.Right
    End Sub
End Class
