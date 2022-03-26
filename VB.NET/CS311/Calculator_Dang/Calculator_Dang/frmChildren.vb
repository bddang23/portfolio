Imports System.ComponentModel

Public Class frmChildren
    '------------------------------------------------------------
    '-                File Name : frmMain.vb                   - 
    '-                Part of Project: Calculator_Dang -
    '------------------------------------------------------------
    '-                Written By: Binh Dang               -
    '-                Written On: March 18, 2022             -
    '------------------------------------------------------------
    '- File Purpose:                                            -
    '-                                                          -
    '- This file contains the window that allows user to open multipe
    'MDI children inside itself. It can control and arrange its children 
    '------------------------------------------------------------
    '- Program Purpose:                                         -
    '-                                                          -
    '- The purpose of this program is to build an MDI calculator application.-
    '- main form should have a main menu with the following options: File, Window and Help.
    '- The Window Option should serve As a Windowlist And have the Tile And Cascade options available under it
    '- .Help should have an About Option that activates an about box dialog.  File should have submenu
    '- Option Onchoices Of New And Exit.  New will instantiate a New child calculator form And Exit
    '------------------------------------------------------------
    '---------------------------------------------------------------------------------------
    '--- GLOBAL CONSTANTS --- GLOBAL CONSTANTS --- GLOBAL CONSTANTS --- GLOBAL CONSTANTS ---
    '--- GLOBAL CONSTANTS --- GLOBAL CONSTANTS --- GLOBAL CONSTANTS --- GLOBAL CONSTANTS ---
    '--- GLOBAL CONSTANTS --- GLOBAL CONSTANTS --- GLOBAL CONSTANTS --- GLOBAL CONSTANTS ---
    '---------------------------------------------------------------------------------------
    Dim txtRecentSelected As TextBox
    '------------------------------------------------------------
    '- Global Variable Dictionary (alphabetically) FROM GLOBAL VAR MODULE:   
    '-txtRecentSelected - global textbox to check what is the last selected textbox 
    '---------------------------------------------------------------------

    Private Sub txtFieldFocus(sender As Object, e As EventArgs) Handles txtBin1.GotFocus, txtBin2.GotFocus, txtDec1.GotFocus, txtDec2.GotFocus, txtHex1.GotFocus, txtHex2.GotFocus
        '------------------------------------------------------------
        '-            Subprogram Name: txtFieldFocus  -
        '------------------------------------------------------------
        '-                Written By: Binh Dang                -
        '-                Written On: March 18, 2022           -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine process everytime the user focus in the textbox
        '- whenever txtBox have bin, dec, or hex, it will call an approriate function
        '- according to the txtbox
        '------------------------------------------------------------
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- txtBox    - the selected textbox                                               -
        '------------------------------------------------------------
        Dim txtBox As TextBox = CType(sender, TextBox)
        txtRecentSelected = txtBox
        'when has "bin" in name call binarySetting sub
        If txtBox.Name.Contains("Bin") Then
            BinarySetting()
            'when has "dec" in name call DecimalSetting sub
        ElseIf txtBox.Name.Contains("Dec") Then
            DecimalSetting()
            'else call HexSetting sub
        Else
            HexSetting()
        End If
    End Sub

    Sub BinarySetting()
        '------------------------------------------------------------
        '-            Subprogram Name: BinarySetting  -
        '------------------------------------------------------------
        '-                Written By: Binh Dang                -
        '-                Written On: March 18, 2022           -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine disable all the buttons excpt button 0 and 1
        '------------------------------------------------------------
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- txtBox    - the selected textbox                                               -
        '------------------------------------------------------------
        Dim arrDisButton As Button() = {btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9, btnA, btnB, btnC, btnD, btnE, btnF}
        For Each button In arrDisButton
            button.Enabled = False
        Next
    End Sub

    Sub DecimalSetting()
        '------------------------------------------------------------
        '-            Subprogram Name: DecimalSetting  -
        '------------------------------------------------------------
        '-                Written By: Binh Dang                -
        '-                Written On: March 18, 2022           -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine disable all the buttons excpt all the number button
        '------------------------------------------------------------
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- txtBox    - the selected textbox                                               -
        '------------------------------------------------------------
        'this loop disable all the buttons from A to F
        Dim arrDisButton As Button() = {btnA, btnB, btnC, btnD, btnE, btnF}
        For Each button In arrDisButton
            button.Enabled = False
        Next
        'this loop enable all the buttons from 0 to 9
        Dim arrEnButton As Button() = {btn0, btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9}
        For Each button In arrEnButton
            button.Enabled = True
        Next
    End Sub

    Sub HexSetting()
        '------------------------------------------------------------
        '-            Subprogram Name: HexSetting  -
        '------------------------------------------------------------
        '-                Written By: Binh Dang                -
        '-                Written On: March 18, 2022           -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine enable all the buttons
        '------------------------------------------------------------
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- txtBox    - the selected textbox                                               -
        '------------------------------------------------------------
        'for loop enable all the buttons
        Dim arrEnButton As Button() = {btn0, btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9, btnA, btnB, btnC, btnD, btnE, btnF}
        For Each button In arrEnButton
            button.Enabled = True
        Next
    End Sub

    Private Sub btn2toF_Click(sender As Object, e As EventArgs) Handles btnA.Click, btnB.Click, btnC.Click, btnD.Click, btnE.Click, btnF.Click, btn2.Click, btn3.Click, btn4.Click, btn5.Click, btn6.Click, btn7.Click, btn8.Click, btn9.Click
        '------------------------------------------------------------
        '-            Subprogram Name: btn2toF_Click  -
        '------------------------------------------------------------
        '-                Written By: Binh Dang                -
        '-                Written On: March 18, 2022           -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine erase the textboxes that contains only 0
        '-then appends the approriate letter and number using FillTExtBox Function
        '------------------------------------------------------------
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- btnText    - the selected button                                               -
        '------------------------------------------------------------
        Dim btnText = CType(sender, Button)
        If txtRecentSelected.Text.Equals("0") Then
            txtRecentSelected.Text = ""
        End If
        FillTextbox(btnText.Text)
    End Sub

    Private Sub btn0n1_Click(sender As Object, e As EventArgs) Handles btn0.Click, btn1.Click
        '------------------------------------------------------------
        '-            Subprogram Name: btn0n1_Click  -
        '------------------------------------------------------------
        '-                Written By: Binh Dang                -
        '-                Written On: March 18, 2022           -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine the approriate number 0 or 1 button using FillTExtBox Function
        '------------------------------------------------------------
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- btnText    - the selected button                                               -
        '------------------------------------------------------------
        Dim btnText = CType(sender, Button)
        FillTextbox(btnText.Text)
    End Sub

    Sub FillTextbox(strVal As String)
        '------------------------------------------------------------
        '-            Subprogram Name: FillTextbox  -
        '------------------------------------------------------------
        '-                Written By: Binh Dang                -
        '-                Written On: March 18, 2022           -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine add the text to the approriate textbox field
        '------------------------------------------------------------
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):                                           -
        '------------------------------------------------------------
        Dim value As String = txtRecentSelected.Text
        value += strVal
        txtRecentSelected.Text = value
    End Sub

    Private Sub btnConvert_Click(sender As Object, e As EventArgs) Handles btnConvert.Click
        '------------------------------------------------------------
        '-            Subprogram Name: btnConvert_Click  -
        '------------------------------------------------------------
        '-                Written By: Binh Dang                -
        '-                Written On: March 18, 2022           -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine convert number from the most recent textbox
        '- to approriate binary, hex or decimal value
        '------------------------------------------------------------
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically): 
        '-charBinary() - return a binary char array that have all the binary value from start to end
        '-intDecimal - returmn a decimal form
        '------------------------------------------------------------

        'if the textbox selected is decimal then check if its value 1 or 2
        'then call the function DectoBin function passing in the decimal vale to get the binary
        'call buildin hex function to get the hex value
        If txtRecentSelected.Name.Contains("Dec") Then
            If txtRecentSelected.Name.Contains("1") Then
                Try
                    txtBin1.Text = DectoBin(CInt(txtRecentSelected.Text))
                    txtHex1.Text = Hex(CInt(txtRecentSelected.Text))
                Catch
                    txtDec1.Text = "Cannot Handle"
                End Try
            Else
                Try
                    txtBin2.Text = DectoBin(CInt(txtRecentSelected.Text))
                    txtHex2.Text = Hex(CInt(txtRecentSelected.Text))
                Catch
                    txtDec2.Text = "Cannot Handle"
                End Try
            End If

            'if the textbox selected is binary check if its value 1 or 2
            'then call the function BintoDec function passing in the binary char array to get the decimal
            'call buildin hex function to get the hex value. also recall the decimal to binary function to get a full 32 bits binary
        ElseIf txtRecentSelected.Name.Contains("Bin") Then
            Dim intDecimal = 0
            Dim charBinary() As Char = txtRecentSelected.Text.Replace(" ", "").ToCharArray
            intDecimal = BintoDec(charBinary)
            If intDecimal = -1 Then
                txtRecentSelected.Text = "Cannot Handle this Number"
            Else
                If txtRecentSelected.Name.Contains("1") Then
                    txtBin1.Text = DectoBin(intDecimal)
                    txtDec1.Text = intDecimal.ToString
                    txtHex1.Text = Hex(intDecimal)
                Else
                    txtBin2.Text = DectoBin(intDecimal)
                    txtDec2.Text = intDecimal.ToString
                    txtHex2.Text = Hex(intDecimal)
                End If
            End If

            'if the textbox selected is binary check if its value 1 or 2
            'then call the function BintoDec function passing in the binary char array to get the decimal
            'call buildin hex function to get the hex value. also recall the decimal to binary function to get a full 32 bits binary
        Else
            Try
                Dim intDecimal As Integer = CInt(Convert.ToInt64(txtRecentSelected.Text, 16))
                If txtRecentSelected.Name.Contains("1") Then
                    txtBin1.Text = DectoBin(intDecimal)
                    txtDec1.Text = intDecimal.ToString
                Else
                    txtBin2.Text = DectoBin(intDecimal)
                    txtDec2.Text = intDecimal.ToString
                End If
            Catch
                If txtRecentSelected.Name.Contains("1") Then
                    txtHex1.Text = "Cannot Handle this Number"
                Else
                    txtHex2.Text = "Cannot Handle this Number"
                End If
            End Try

        End If
    End Sub

    Function DectoBin(dec As Integer) As String
        '------------------------------------------------------------
        '-            Function Name: DectoBin  -
        '------------------------------------------------------------
        '-                Written By: Binh Dang                -
        '-                Written On: March 18, 2022           -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This function convert number from decimal to binary that return a binary number from
        '- decimal number
        '------------------------------------------------------------
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically): 
        '- strBinary - binary string that represent 32 bit 0 and 1
        '- intSeperate - keep track of the binary bit make sure there are a space in every 4 bit 
        '------------------------------------------------------------
        Dim strBinary As String = ""
        Dim intSeperate As Integer = 1
        For i As Integer = 31 To 0 Step -1
            'Compare the decimal value we're trying to convert with
            'a power of 2 value – if we And them And get a True value
            'back, that means that that power's bit is on, e.g. a 1...
            Dim bool As Long = dec And CLng(Math.Pow(2, i))

            If CBool(dec And CLng(Math.Pow(2, i))) = True Then
                If intSeperate = 4 Then
                    strBinary = strBinary & "1" & " "
                    intSeperate = 0
                Else
                    strBinary = strBinary & "1"
                    intSeperate = intSeperate + 1
                End If

            Else
                '...otherwise we need to set that power at 0
                If intSeperate = 4 Then
                    strBinary = strBinary & "0" & " "
                    intSeperate = 1
                Else
                    strBinary = strBinary & "0"
                    intSeperate = intSeperate + 1
                End If
            End If
        Next
        Return strBinary
    End Function

    Function BintoDec(bin() As Char) As Integer
        '------------------------------------------------------------
        '-            Function Name: BintoDec  -
        '------------------------------------------------------------
        '-                Written By: Binh Dang                -
        '-                Written On: March 18, 2022           -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This function convert number from binary to (positive) decimal
        '- by using a loop run through every digit of 1 and 0 bit
        '------------------------------------------------------------
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically): 
        '- intDec - integer represent a decimal value
        '- intPow - keep track of the power of 2         
        '------------------------------------------------------------
        Dim intDec As Integer = 0
        Dim intPow As Integer = 0
        For i As Integer = bin.Length - 1 To 0 Step -1
            If bin(i) = "1"c Then
                Try
                    intDec = intDec + CInt(Math.Pow(2, intPow))
                Catch
                    Return -1
                End Try
            End If
            intPow = intPow + 1
        Next
        Return intDec
    End Function

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear1.Click, btnClear2.Click, btnClearRes.Click
        '------------------------------------------------------------
        '-            Subprogram Name: btnClear_Click  -
        '------------------------------------------------------------
        '-                Written By: Binh Dang                -
        '-                Written On: March 18, 2022           -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine clear all the value for value1, value2, and the result value
        '------------------------------------------------------------
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):       
        '- btnSelected - a copy of the selected button 
        '------------------------------------------------------------
        Dim btnSelected As Button = CType(sender, Button)
        'if the button contain 1, 2, or result, then clear all the textfield accordingly
        If btnSelected.Name.Contains("1") Then
            txtDec1.Text = "0"
            txtBin1.Text = "0"
            txtHex1.Text = "0"
        ElseIf btnSelected.Name.Contains("2") Then
            txtDec2.Text = "0"
            txtBin2.Text = "0"
            txtHex2.Text = "0"
        Else
            txtDecRes.Text = "0"
            txtBinRes.Text = "0"
            txtHexRes.Text = "0"
        End If
    End Sub


    Private Sub btnAnd_Click(sender As Object, e As EventArgs) Handles btnAnd.Click
        '------------------------------------------------------------
        '-            Subprogram Name: btnAnd_Click  -
        '------------------------------------------------------------
        '-                Written By: Binh Dang                -
        '-                Written On: March 18, 2022           -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine 'and' the value1 and value2 together then printed it to the result textfield 
        '------------------------------------------------------------
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):       
        '- intDecimal - result that 2 value anded together
        '------------------------------------------------------------
        Dim intDecimal As Integer = CInt(CLng(txtDec1.Text) And CLng(txtDec2.Text))
        txtDecRes.Text = intDecimal.ToString
        txtBinRes.Text = DectoBin(intDecimal)
        txtHexRes.Text = Hex(intDecimal)
    End Sub

    Private Sub btnOr_Click(sender As Object, e As EventArgs) Handles btnOr.Click
        '------------------------------------------------------------
        '-            Subprogram Name: btnOr_Click  -
        '------------------------------------------------------------
        '-                Written By: Binh Dang                -
        '-                Written On: March 18, 2022           -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine 'or' the value1 and value2 together then printed it to the result textfield 
        '------------------------------------------------------------
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):       
        '- intDecimal - result that 2 value or together
        '------------------------------------------------------------
        Dim intDecimal As Integer = CInt(CLng(txtDec1.Text) Or CLng(txtDec2.Text))
        txtDecRes.Text = intDecimal.ToString
        txtBinRes.Text = DectoBin(intDecimal)
        txtHexRes.Text = Hex(intDecimal)
    End Sub

    Private Sub btnXor_Click(sender As Object, e As EventArgs) Handles btnXor.Click
        '------------------------------------------------------------
        '-            Subprogram Name: btnXor_Click  -
        '------------------------------------------------------------
        '-                Written By: Binh Dang                -
        '-                Written On: March 18, 2022           -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine 'xor' the value1 and value2 together then printed it to the result textfield 
        '------------------------------------------------------------
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):       
        '- intDecimal - result that 2 value xor together
        '------------------------------------------------------------
        Dim intDecimal As Integer = CInt(CLng(txtDec1.Text) Xor CLng(txtDec2.Text))
        txtDecRes.Text = intDecimal.ToString
        txtBinRes.Text = DectoBin(intDecimal)
        txtHexRes.Text = Hex(intDecimal)
    End Sub

    Private Sub btnNot1_Click(sender As Object, e As EventArgs) Handles btnNot1.Click
        '------------------------------------------------------------
        '-            Subprogram Name: btnXor_Click  -
        '------------------------------------------------------------
        '-                Written By: Binh Dang                -
        '-                Written On: March 18, 2022           -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine 'not' the value1 and value2 together then printed it to the result textfield 
        '------------------------------------------------------------
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):       
        '- intDecimal - result that 2 value xor together
        '------------------------------------------------------------
        Dim intDecimal As Integer = CInt(Not CLng(txtDec1.Text))
        txtDecRes.Text = intDecimal.ToString
        txtBinRes.Text = DectoBin(intDecimal)
        txtHexRes.Text = Hex(intDecimal)
    End Sub

    Private Sub frmChildren_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        '------------------------------------------------------------
        '-            Subprogram Name: frmMain_Closing  -
        '------------------------------------------------------------
        '-                Written By: Binh Dang                -
        '-                Written On: March 18, 2022           -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine check and see if there are any value in the value1 and value2
        '-if yes then hide the children form
        '------------------------------------------------------------
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        If txtDec1.Text <> "0" Or txtDec2.Text <> "0" Or txtBin1.Text <> "0" Or txtBin2.Text <> "0" Or txtHex1.Text <> "0" Or txtHex2.Text <> "0" Then
            If MessageBox.Show("Are you sure you want to quit? Dirty Calculator", "Programmer's Calculator", MessageBoxButtons.YesNo) = DialogResult.No Then
                e.Cancel = True
            Else
                e.Cancel = False
                Hide()
            End If
        End If
    End Sub
End Class