Public Class frmInstruction
    Private Sub frmInstruction_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Instruction - BD"
    End Sub

    Private Sub txtName_Enter(sender As Object, e As EventArgs) Handles txtName.Enter
        lbl1.Text = "Enter your full name."
    End Sub

    Private Sub txtPhone_Enter(sender As Object, e As EventArgs) Handles txtPhone.Enter
        lbl1.Text = "Enter your phone number, including area code"
    End Sub

End Class
