Public Class frmOrder
    '------------------------------------------------------------
    '-                File Name : frmOrder.vb                   - 
    '-                Part of Project: KustomKarz_Binh -
    '------------------------------------------------------------
    '-                Written By: Binh Dang               -
    '-                Written On: January 23, 2022              -
    '------------------------------------------------------------
    '- File Purpose:                                            -
    '-                                                          -
    '- This file contains the subdirectory that allow user to input their car
    '- preferences. Then take user to the invoice page. The program won't allow any 
    '-user to exit by the traditional way
    '------------------------------------------------------------
    '- Program Purpose:                                         -
    '-                                                          -
    '- The purpose of this program is to handle the calculations-
    '- and bill generation for a project carried out by KustomKarz-
    '- company, which we give to our client. Cars costs are  -
    '- made up of base price, powertrain cost, and optional choice cost.  
    '- User will choose their desire type and options.The program will then display a neatly         -
    '- formatted receipt.                                       -
    '------------------------------------------------------------
    '---------------------------------------------------------------------------------------
    '--- GLOBAL CONSTANTS --- GLOBAL CONSTANTS --- GLOBAL CONSTANTS --- GLOBAL CONSTANTS ---
    '--- GLOBAL CONSTANTS --- GLOBAL CONSTANTS --- GLOBAL CONSTANTS --- GLOBAL CONSTANTS ---
    '--- GLOBAL CONSTANTS --- GLOBAL CONSTANTS --- GLOBAL CONSTANTS --- GLOBAL CONSTANTS ---
    '---------------------------------------------------------------------------------------
    'Const Diffrent Car base
    Const COUPE As Double = 10000
    Const LUXURY As Double = 20000
    Const SEDAN As Double = 17000
    Const SPORTS As Double = 25000
    Const SUV As Double = 27000
    'Constant for different power train
    Const V12 As Double = 7500
    Const V8 As Double = 2500
    Const V6 As Double = 1000
    Const V4 As Double = 500
    Const HYBRID As Double = 3000
    Const ELECTRIC As Double = 6000
    '------------------------------------------------------------
    '- Global Variable Dictionary (alphabetically) FROM GLOBAL VAR MODULE:              -
    '- arrOptional - ArrayList that is used to store user's options
    '- blnisClose - Check to see if the main Order form can close or not
    '-dblbasePrice - Price of the car type
    '-dblOptional - Total price of the optional choice
    '-dblPower - price of power train
    '-decQuantity- Cars Quanity that user want
    '-strBase - Name of the type of car BAse
    '-strCusName - name of Customer
    '-strPower - name of the Powertrain
    '------------------------------------------------------------
    '--- SUBPROGRAMS --- SUBPROGRAMS --- SUBPROGRAMS --- SUBPROGRAMS --- SUBPROGRAMS ---
    '--- SUBPROGRAMS --- SUBPROGRAMS --- SUBPROGRAMS --- SUBPROGRAMS --- SUBPROGRAMS ---
    '--- SUBPROGRAMS --- SUBPROGRAMS --- SUBPROGRAMS --- SUBPROGRAMS --- SUBPROGRAMS ---
    '-----------------------------------------------------------------------------------

    Private Sub frmOder_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        '------------------------------------------------------------
        '-            Subprogram Name: frmInvoice_Closing  -
        '------------------------------------------------------------
        '-                Written By: Binh Dang                -
        '-                Written On: January 25, 2022              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine make sure that user is not allowed to close
        '- the program in the order form, it only allow to close in the invoice screen
        '- it also have a global boolean value to mak sure that 
        '- when it is true which is set up from the invoice page, this form can be closed.
        '- Else, it will show a message box that not allow user to exit.
        '------------------------------------------------------------
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        If blnisClose = False Then
            MessageBox.Show("Sorry but the application can only be closed on the Invoice Screen Please press Place Order to go to that screen...")
            e.Cancel = True
        Else
            e.Cancel = False
        End If
    End Sub

    Private Sub btnPlaceOrder_Click(sender As Object, e As EventArgs) Handles btnPlaceOrder.Click
        '------------------------------------------------------------
        '-            Subprogram Name: btnPlaceOrder_Click  -
        '------------------------------------------------------------
        '-                Written By: Binh Dang                -
        '-                Written On: January 23, 2022              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine extracts the values entered from the user-
        '- into the form and places them in the global variable in the GlobalVar module    –
        '- variable.  Any data conversions from string to numeric   -
        '- which are necessary are performed here as well.
        '- Also, th eprogram will check and see if user has entered any data or not-
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        'See if customer name type in or not
        'Not validate name since there are some unique character internationally!
        If String.IsNullOrEmpty(txtName.Text) Then
            MessageBox.Show("No Name was Entered!")
            'Check if it has white space
        ElseIf String.IsNullOrWhiteSpace(txtName.Text) Then
            MessageBox.Show("No Name was Entered!")
            'Checked if any radio button checked
        ElseIf Not (optElect.Checked Or optHybrid.Checked Or optV4.Checked Or optV6.Checked Or optV8.Checked Or optV12.Checked) Then
            MessageBox.Show("Drive Train Selection Required!")
            'Required quantity above 0
        ElseIf nudQuantity.Value = 0 Then
            MessageBox.Show("Need more than 0 car!")
            'Checked if the lst 
        ElseIf lstType.SelectedIndex = -1 Then
            MessageBox.Show("Choose your car type!")
        Else
            'Add Customer Name to the global CusName
            strCusName = txtName.Text

            'Adding the base price to global value
            If lstType.SelectedIndex = 0 Then
                strBase = lstType.SelectedItem.ToString
                dblbasePrice = COUPE
            ElseIf lstType.SelectedIndex = 1 Then
                strBase = lstType.SelectedItem.ToString
                dblbasePrice = LUXURY
            ElseIf lstType.SelectedIndex = 2 Then
                strBase = lstType.SelectedItem.ToString
                dblbasePrice = SEDAN
            ElseIf lstType.SelectedIndex = 3 Then
                strBase = lstType.SelectedItem.ToString
                dblbasePrice = SPORTS
            ElseIf lstType.SelectedIndex = 4 Then
                strBase = lstType.SelectedItem.ToString
                dblbasePrice = SUV
            End If

            'Adding the power train price to global value
            If optV12.Checked = True Then
                strPower = optV12.Text
                dblPower = V12
            ElseIf optV8.Checked = True Then
                strPower = optV8.Text
                dblPower = V8
            ElseIf optV6.Checked = True Then
                strPower = optV6.Text
                dblPower = V6
            ElseIf optV4.Checked = True Then
                strPower = optV4.Text
                dblPower = V4
            ElseIf optHybrid.Checked = True Then
                strPower = optHybrid.Text
                dblPower = HYBRID
            ElseIf optElect.Checked = True Then
                strPower = optElect.Text
                dblPower = ELECTRIC
            End If

            'Adding optional check to optional price global var
            If chkAir.Checked = True Then
                arrOptional.Add(chkAir.Text)
            End If
            If chkBluetooth.Checked = True Then
                arrOptional.Add(chkBluetooth.Text)
            End If
            If chkCD.Checked = True Then
                arrOptional.Add(chkCD.Text)
            End If
            If chkEvt.Checked = True Then
                arrOptional.Add(chkEvt.Text)
            End If
            If chkGPS.Checked = True Then
                arrOptional.Add(chkGPS.Text)
            End If
            If chkHeated.Checked = True Then
                arrOptional.Add(chkHeated.Text)
            End If
            If chkLeather.Checked = True Then
                arrOptional.Add(chkLeather.Text)
            End If
            If chkRear.Checked = True Then
                arrOptional.Add(chkRear.Text)
            End If
            If chkStereo.Checked = True Then
                arrOptional.Add(chkStereo.Text)
            End If

            'Assign the quantity to the quantity global var
            decQuantity = nudQuantity.Value

            'Open Invoice and hide the order form
            Hide()
            frmInvoice.ShowDialog()
        End If
    End Sub

End Class
