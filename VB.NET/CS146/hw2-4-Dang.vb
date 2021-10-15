'Class:  CS146, Fall 2019
' Student Name: Binh Dang
' Instructor:   Dr. Cho
' Program: hw2
' Description: This program convert a U.S. System Lenghth to Metric System Length.
' Date:  09/24/2019
Public Class Form1
    Dim miles, yards, feet, inches As Double
    Dim kilometers, meters As Integer
    Dim centimeters, totalInches, totalMeters As Double

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'covert all the lenghth to double
        miles = CDbl(txtMiles.Text)
        yards = CDbl(txtYards.Text)
        feet = CDbl(txtFeet.Text)
        inches = CDbl(txtInches.Text)
        totalInches = 63360 * miles + 36 * yards + 12 * feet + inches 'add all of the length in Inches in order to convert to meters
        totalMeters = totalInches / 39.37
        kilometers = (CInt(totalMeters) \ 1000) '
        meters = CInt(Math.Floor(totalMeters - kilometers * 1000))
        centimeters = (totalMeters * 100) Mod 100 'Mod to find the remaining which is centimeters
        lstConversion.Items.Add("The metric length is")
        lstConversion.Items.Add(kilometers.ToString("N0") & " kilometers")
        lstConversion.Items.Add(meters.ToString("N0") & " meters")
        lstConversion.Items.Add(centimeters.ToString("N1") & " centimeters.")
    End Sub
End Class
