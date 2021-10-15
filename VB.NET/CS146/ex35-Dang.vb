Public Class frmColors
    Private Sub frmColors_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Colorful Text - BD"
    End Sub
    Private Sub lblBlack_Click(sender As Object, e As EventArgs) Handles lblBlack.Click
        lblBlack.Text = "Background"
    End Sub
    Private Sub btnRed_Click(sender As Object, e As EventArgs) Handles btnRed.Click
        btnRed.Text = "Red"
        txtBox.BackColor = Color.Red
    End Sub
    Private Sub btnBlue_Click(sender As Object, e As EventArgs) Handles btnBlue.Click
        btnBlue.Text = "Blue"
        txtBox.BackColor = Color.Blue
    End Sub
    Private Sub txtBox_TextChanged(sender As Object, e As EventArgs) Handles txtBox.TextChanged
        txtBox.Text = "Beautiful Day"
        txtBox.TextAlign = HorizontalAlignment.Center
    End Sub
    Private Sub lblFore_Click(sender As Object, e As EventArgs) Handles lblFore.Click
        lblFore.Text = "Foreground"
    End Sub
    Private Sub btnWhite_Click(sender As Object, e As EventArgs) Handles btnWhite.Click
        btnWhite.Text = "White"
        txtBox.ForeColor = Color.White
    End Sub
    Private Sub btnYellow_Click(sender As Object, e As EventArgs) Handles btnYellow.Click
        btnYellow.Text = "Yellow"
        txtBox.ForeColor = Color.Yellow
    End Sub
End Class
