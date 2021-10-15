Public Class frm123
    Private Sub frm123_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "1,2,3 - BD"
    End Sub
    Private Sub txtOne_TextChanged(sender As Object, e As EventArgs) Handles txtOne.TextChanged
        txtOne.Text = "One"
    End Sub
    Private Sub txtOne_MouseClick(sender As Object, e As MouseEventArgs) Handles txtOne.MouseClick
        txtOne.ForeColor = Color.Red
    End Sub
    Private Sub txtOne_Leave(sender As Object, e As EventArgs) Handles txtOne.Leave
        txtOne.ForeColor = Color.Black
    End Sub
    Private Sub txtTwo_TextChanged(sender As Object, e As EventArgs) Handles txtTwo.TextChanged
        txtTwo.Text = "Two"
    End Sub
    Private Sub txtTwo_MouseClick(sender As Object, e As MouseEventArgs) Handles txtTwo.MouseClick
        txtTwo.ForeColor = Color.Red
    End Sub
    Private Sub txtTwo_Leave(sender As Object, e As EventArgs) Handles txtTwo.Leave
        txtTwo.ForeColor = Color.Black
    End Sub
    Private Sub TxtThree_TextChanged(sender As Object, e As EventArgs) Handles txtThree.TextChanged
        txtThree.Text = "Three"
    End Sub
    Private Sub TxtThree_Leave(sender As Object, e As EventArgs) Handles txtThree.Leave
        txtThree.ForeColor = Color.Black
    End Sub
    Private Sub TxtThree_MouseClick(sender As Object, e As MouseEventArgs) Handles txtThree.MouseClick
        txtThree.ForeColor = Color.Red
    End Sub
    Private Sub btnLeft_Click(sender As Object, e As EventArgs) Handles btnLeft.Click
        btnLeft.Text = "Left"
        txtOne.TextAlign = HorizontalAlignment.Left
        txtTwo.TextAlign = HorizontalAlignment.Left
        txtThree.TextAlign = HorizontalAlignment.Left
    End Sub

    Private Sub btnRight_Click(sender As Object, e As EventArgs) Handles btnRight.Click
        btnRight.Text = "Right"
        txtOne.TextAlign = HorizontalAlignment.Right
        txtTwo.TextAlign = HorizontalAlignment.Right
        txtThree.TextAlign = HorizontalAlignment.Right
    End Sub
End Class
