'Class:  CS146, Fall 2019
' Student Name: Binh Dang
' Instructor:   Dr. Cho
' Program: hw2
' Description: This program display a simplified bill.
' Date:  09/22/2019
Public Class Form1
    Private Sub btnBill_Click(sender As Object, e As EventArgs) Handles btnBill.Click
        Dim fmtStr As String = "{0, -12} {1, 10:C2}"
        Dim labors, parts, total As Double
        labors = CDbl(txtLabors.Text) * 35 'rate of $35 per hour multiply with hours of labor
        parts = CDbl(txtParts.Text) * 0.05 + CDbl(txtParts.Text) '5% sale tax
        total = labors + parts
        lstCost.Items.Clear()
        lstCost.Items.Add(String.Format(fmtStr, "Customers", txtName.Text))
        lstCost.Items.Add(String.Format(fmtStr, "Labor cost", labors.ToString("C2")))
        lstCost.Items.Add(String.Format(fmtStr, "Parts cost", parts.ToString("C2")))
        lstCost.Items.Add(String.Format(fmtStr, "Total cost", total.ToString("C2")))
    End Sub
End Class
