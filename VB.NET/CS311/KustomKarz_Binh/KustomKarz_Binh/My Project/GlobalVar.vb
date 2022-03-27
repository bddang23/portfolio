Module GlobalVar
    '------------------------------------------------------------
    '-                File Name : GlobalVar.cb                   - 
    '-                Part of Project: KustomKarz_Binh           -
    '------------------------------------------------------------
    '-                Written By: Binh Dang                     -
    '-                Written On: January 23, 2022              -
    '------------------------------------------------------------
    '- File Purpose:                                            -
    '-                                                          -
    '- This file contains the module of the application that include 
    '- gloval variable as well as sub for other main form to use
    '------------------------------------------------------------
    '- Program Purpose:                                         -
    '-                                                          -
    '- The purpose of this program is to handle the calculations-
    '- and bill generation for a project carried out by KustomKarz-
    '- company, which we give to our client. Cars costs are  -
    '- made up of base price, powertrain cost, and optional choice cost.  
    '- User will choose their desire type and options.The program will then display a neatly         -
    '- formatted invoice.                                       -
    '------------------------------------------------------------
    '------------------------------------------------------------
    '- Global Variable Dictionary (alphabetically):              -
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

    Public strCusName As String ' name of Customer
    Public dblbasePrice As Double ' Price of the car type
    Public strBase As String ' Name of the type of car BAse
    Public dblPower As Double ' price of power train
    Public strPower As String 'name of the Powertrain
    Public dblOptional As Double = 0 ' Total price of the optional choice
    Public arrOptional As ArrayList = New ArrayList() ' ArrayList that is used to store user's options
    Public blnisClose As Boolean = False ' boolean Check to see if the main Order form can close or not
    Public decQuantity As Decimal ' Cars Quanity that user want

    '---------------------------------------------------------------------------------------
    '--- GLOBAL CONSTANTS --- GLOBAL CONSTANTS --- GLOBAL CONSTANTS --- GLOBAL CONSTANTS ---
    '--- GLOBAL CONSTANTS --- GLOBAL CONSTANTS --- GLOBAL CONSTANTS --- GLOBAL CONSTANTS ---
    '--- GLOBAL CONSTANTS --- GLOBAL CONSTANTS --- GLOBAL CONSTANTS --- GLOBAL CONSTANTS ---
    '---------------------------------------------------------------------------------------
    Const PRICE_PER_OPTION As Double = 750

    Public Sub Reset()
        '------------------------------------------------------------
        '-                Subprogram Name: Reset          -
        '------------------------------------------------------------
        '-                Written By: Binh Dang            -
        '-                Written On: January 22, 2022              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                       
        '- This subroutine will show reset all the box and buttons to the original
        '------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):               -
        'none
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- none
        '------------------------------------------------------------
        'make customer's name txtbox blank
        frmOrder.txtName.Text = ""

        'makequanity 0
        frmOrder.nudQuantity.Value = 0

        'clear the selected car base
        frmOrder.lstType.ClearSelected()

        'Turn all the checkboxed off
        frmOrder.chkAir.Checked = False
        frmOrder.chkBluetooth.Checked = False
        frmOrder.chkCD.Checked = False
        frmOrder.chkEvt.Checked = False
        frmOrder.chkGPS.Checked = False
        frmOrder.chkHeated.Checked = False
        frmOrder.chkLeather.Checked = False
        frmOrder.chkRear.Checked = False
        frmOrder.chkStereo.Checked = False

        'Turn all the Radio buttons off
        frmOrder.optElect.Checked = False
        frmOrder.optHybrid.Checked = False
        frmOrder.optV4.Checked = False
        frmOrder.optV6.Checked = False
        frmOrder.optV8.Checked = False
        frmOrder.optV12.Checked = False
    End Sub

    Public Sub PrintInvoice()
        '------------------------------------------------------------
        '-                Subprogram Name: PrintInvoice          -
        '------------------------------------------------------------
        '-                Written By: Binh Dang            -
        '-                Written On: January 23, 2022              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                       
        '- This subroutine will print the inovice from the given input from order form 
        '------------------------------------------------------------

        '------------------------------------------------------------
        frmInvoice.lstInvoice.Items.Add("=================================================================================")
        frmInvoice.lstInvoice.Items.Add(vbTab + vbTab + vbTab + vbTab + "Kustom Karz")
        frmInvoice.lstInvoice.Items.Add("=================================================================================")
        frmInvoice.lstInvoice.Items.Add("Getting ready to kustom manufacture for " + strCusName)
        frmInvoice.lstInvoice.Items.Add("")
        frmInvoice.lstInvoice.Items.Add("There will be " + decQuantity.ToString + " car(s) kustom built")
        frmInvoice.lstInvoice.Items.Add("")
        frmInvoice.lstInvoice.Items.Add("Kar from factor: " + strBase + " at " + FormatCurrency(dblbasePrice, 2))
        frmInvoice.lstInvoice.Items.Add("With Powertrain " + strPower + " at " + FormatCurrency(dblPower, 2))
        frmInvoice.lstInvoice.Items.Add("")
        frmInvoice.lstInvoice.Items.Add("Here are the option(s) requested:")
        'Check if user choose any options, if yes list them out. If no, make it blank
        If (arrOptional.Count > 0) Then
            dblOptional = arrOptional.Count * PRICE_PER_OPTION
            For Each i In arrOptional
                frmInvoice.lstInvoice.Items.Add(vbTab + " " + i.ToString)
            Next
        End If
        frmInvoice.lstInvoice.Items.Add(arrOptional.Count.ToString + " Options Selected for a total of " + FormatCurrency(dblOptional, 2))
        frmInvoice.lstInvoice.Items.Add("")
        frmInvoice.lstInvoice.Items.Add("")
        Dim dblPerCar As Double = dblOptional + dblbasePrice + dblPower
        frmInvoice.lstInvoice.Items.Add("Per vehicle total :" + vbTab + FormatCurrency(dblPerCar))
        frmInvoice.lstInvoice.Items.Add("----------------------------------------------------")
        frmInvoice.lstInvoice.Items.Add("Quantity Ordered: " + vbTab + decQuantity.ToString())
        frmInvoice.lstInvoice.Items.Add("----------------------------------------------------")
        frmInvoice.lstInvoice.Items.Add("Grand Total:" + vbTab + FormatCurrency(dblPerCar * decQuantity))
        frmInvoice.lstInvoice.Items.Add("")
        frmInvoice.lstInvoice.Items.Add("=================================================================================")
    End Sub
End Module
