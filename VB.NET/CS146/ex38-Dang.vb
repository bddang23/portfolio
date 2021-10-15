Public Class frmTextBox
    Private Sub frmTextBox_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Text Box - BD"
    End Sub
    Private Sub btnDisable_Click(sender As Object, e As EventArgs) Handles btnDisable.Click
        btnDisable.Text = "Disable Text Box"
        txtBox.Enabled = False
    End Sub
    Private Sub btnEnable_Click(sender As Object, e As EventArgs) Handles btnEnable.Click
        btnEnable.Text = "Enable Text Box"
        txtBox.Enabled = True
    End Sub
End Class
