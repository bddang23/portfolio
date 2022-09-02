Public Class frmOrdering
    Private Sub frmOrdering_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        pnlReceipt.Hide()
    End Sub

    Private Sub btnCalc_Click(sender As Object, e As EventArgs) Handles btnCalc.Click
        If ValidateForm() Then
            pnlReceipt.Visible = True
            printReceipt()
        End If
    End Sub

    Private Sub printReceipt()
        Dim strSelectedService As String = "N/A"
        If radDeluxe.Checked = True Then
            strSelectedService = "Deluxe Meal"
        ElseIf radStandard.Checked = True Then
            strSelectedService = "Standard Meal"
        End If
        lstReceipt.Items.Add("Selected Service: " + vbTab + strSelectedService)
    End Sub

    Private Function ValidateForm() As Boolean
        If ValidateTxtName(txtFirst) And ValidateTxtName(txtLast) And ValidatePhone(mtbPhone) And ValidateAmount(numAmount) And ValidateDiscount(txtDiscount) Then
            Return True
        End If

        Return False
    End Function

    Private Function ValidateAmount(numAmount As NumericUpDown) As Boolean
        If numAmount.Value <= 0 Then
            MessageBox.Show("Please enter more than 0 for Amount!")
            Return False
        Else
            Return True
        End If
    End Function

    Private Function ValidateDiscount(txtDiscount As TextBox) As Boolean
        Dim i As Double
        If Double.TryParse(txtDiscount.Text, i) Then
            If i >= 0 And i <= 100 Then
                Return True
            Else
                MessageBox.Show("Please enter approriate Discount!")
            End If
        Else
            MessageBox.Show("Please enter approriate Discount!")
            Return False
        End If
    End Function

    Private Function ValidatePhone(mtbPhone As MaskedTextBox) As Boolean
        If mtbPhone.Text.Contains("  ") Then
            MessageBox.Show("Please enter approriate phone number!")
            Return False
        End If
        Return True
    End Function

    Private Function ValidateTxtName(txtBox As TextBox) As Boolean
        If String.IsNullOrEmpty(txtBox.Text) Then
            MessageBox.Show("Empty Text Box! Please fill in the blank.")
            Return False
        End If
        Return True
    End Function

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        pnlReceipt.Visible = False
        txtDiscount.Text = ""
        txtFirst.Text = ""
        txtLast.Text = ""
        txtMiddle.Text = ""
        numAmount.Value = 0
        mtbPhone.Text = ""
    End Sub

End Class