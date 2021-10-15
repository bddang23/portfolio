Public Class frmPush
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Push Me - BD"
    End Sub
    Private Sub btn1_Click(sender As Object, e As EventArgs) Handles btn1.Click
        btn1.Text = "Push Me"
        btn1.Visible = False
        btn2.Visible = True
        btn3.Visible = True
        btn4.Visible = True
    End Sub
    Private Sub btn2_Click(sender As Object, e As EventArgs) Handles btn2.Click
        btn2.Text = "Push Me"
        btn1.Visible = True
        btn2.Visible = False
        btn3.Visible = True
        btn4.Visible = True
    End Sub
    Private Sub btn3_Click(sender As Object, e As EventArgs) Handles btn3.Click
        btn3.Text = "Push Me"
        btn1.Visible = True
        btn2.Visible = True
        btn3.Visible = False
        btn4.Visible = True
    End Sub
    Private Sub btn4_Click(sender As Object, e As EventArgs) Handles btn4.Click
        btn4.Text = "Push Me"
        btn1.Visible = True
        btn2.Visible = True
        btn3.Visible = True
        btn4.Visible = False
    End Sub
End Class
