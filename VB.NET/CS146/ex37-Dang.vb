Public Class frmQuote
    Private Sub frmQuote_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Sayings - BD"
    End Sub
    Private Sub txtQuote_TextChanged(sender As Object, e As EventArgs) Handles txtQuote.TextChanged
        txtQuote.ReadOnly = True
    End Sub
    Private Sub txtLife_TextChanged(sender As Object, e As EventArgs) Handles txtLife.TextChanged
        txtLife.Text = "Life"
           End Sub
    Private Sub txtLife_Click(sender As Object, e As EventArgs) Handles txtLife.Click
        txtQuote.Text = "I like life, it's something to do."
    End Sub
    Private Sub txtFuture_TextChanged(sender As Object, e As EventArgs) Handles txtFuture.TextChanged
        txtFuture.Text = "Future"
    End Sub
    Private Sub txtFuture_Click(sender As Object, e As EventArgs) Handles txtFuture.Click
        txtQuote.Text = "The future isn't what it used to be."
    End Sub
    Private Sub txtTruth_TextChanged(sender As Object, e As EventArgs) Handles txtTruth.TextChanged
        txtTruth.Text = "Truth"
    End Sub
    Private Sub txtTruth_Click(sender As Object, e As EventArgs) Handles txtTruth.Click
        txtQuote.Text = "Tell the truth and run."
    End Sub
End Class
