Imports System.Text.RegularExpressions

Public Class ChezSousa_Dang
    '------------------------------------------------------------
    '-                File Name : ChezSousa_Dang.vb                 - 
    '-                Part of Project: ChezSousa_Dang -
    '------------------------------------------------------------
    '-                Written By: Binh Dang               -
    '-                Written On: Feb 12, 2022              -
    '------------------------------------------------------------
    '- File Purpose:                                            -
    '-                                                          -
    '- This file contains the subdirectory that allow user to input different dish, prepep items and raws ingredient
    '-With the use of Sorted Dictionary, it makes easier to explore all the functionality of a library which connect 
    '------------------------------------------------------------
    '- Program Purpose:                                         -
    '-                                                          -
    '- a system that will allow the chefs to keep track of what dishes the restaurant prepares and what goes into each dish.
    '- Each dish is usually further broken down into prepared items that are assembled into that particular dish.
    '- Finally the prepared items can be broken down into the raw components that make Each up.                                       -
    '------------------------------------------------------------
    '---------------------------------------------------------------------------------------
    '--- GLOBAL DICTIONARIES
    '---------------------------------------------------------------------------------------

    'sdictRaw - Dictionary that have a key and value of string of raw ingredient
    'sdictPrepped - Dictionary that have a key and value of string of the Prepped dioctionaey of raw ingredient dictionary
    'sdictDish - Dictionary that thave a key and value of string of the PsdictDish dioctionaey of raw ingredient dictionary
    Public sdictRaw As New SortedDictionary(Of String, String)

    Public sdictPrepped As New SortedDictionary(Of String, SortedDictionary(Of String, String))

    Public sdictDish As New SortedDictionary(Of String, SortedDictionary(Of String, SortedDictionary(Of String, String)))

    '------------------------------------------------------------
    '--- SUBPROGRAMS --- SUBPROGRAMS --- SUBPROGRAMS --- SUBPROGRAMS --- SUBPROGRAMS ---
    '--- SUBPROGRAMS --- SUBPROGRAMS --- SUBPROGRAMS --- SUBPROGRAMS --- SUBPROGRAMS ---
    '--- SUBPROGRAMS --- SUBPROGRAMS --- SUBPROGRAMS --- SUBPROGRAMS --- SUBPROGRAMS ---
    '-----------------------------------------------------------------------------------

    Private Sub ChezSousa_Dang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '-            Subprogram Name: ChezSousa_Dang_Load  -
        '------------------------------------------------------------
        '-                Written By: Binh Dang                -
        '-                Written On: January 23, 2022              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine populate the raw ingredients, prepped items, and dishes
        '-when the form started loading
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):        
        '-sdictCom - a dictionary base on sdictDish structure
        '-sdictDrink - a dictionary base on sdictPrepped structure  
        '-sdictEgg - a dictionary base on sdictPrepped structure 
        '-sdictGoi - a dictionary base on sdictDish structure
        '-sdictGrilledPork - a dictionary base on sdictPrepped structure
        '-sdictPicle - a dictionary base on sdictPrepped structure
        '-sdictRice - a dictionary base on sdictPrepped structure
        '-sdictSauce - a dictionary base on sdictPrepped structure
        '-sdictSRoll -a dictionary base on sdictPrepped structure
        '-sdictVeggie - a dictionary base on sdictPrepped structure
        '-ALL THESE DICTIONARIES ARE CREATED FOR PURPOSE ADDING TO THE THREE MAIN DICTIONARIES  
        '------------------------------------------------------------

        'populate Raw Ingredients
        sdictRaw.Add("Pork", "Pork")
        sdictRaw.Add("Sugar", "Sugar")
        sdictRaw.Add("Cucumber", "Cucumber")
        sdictRaw.Add("Tomato", "Tomato")
        sdictRaw.Add("Fish sauce", "Fish sauce")
        sdictRaw.Add("Garlic", "Garlic")
        sdictRaw.Add("Chillies", "Chillies")
        sdictRaw.Add("Oil", "Oil")
        sdictRaw.Add("MSG", "MSG")
        sdictRaw.Add("Broken rice", "Broken rice")
        sdictRaw.Add("Carrot", "Carrot")
        sdictRaw.Add("Salt", "Salt")
        sdictRaw.Add("Vinegar", "Vinegar")
        sdictRaw.Add("Green onion", "Green onion")
        sdictRaw.Add("Rice vermicelli", "Rice vermicelli")
        sdictRaw.Add("Shrimp", "Shrimp")
        sdictRaw.Add("Hoisin", "Hoisin")
        sdictRaw.Add("Water", "Water")
        sdictRaw.Add("Thai basil", "Thai basil")
        sdictRaw.Add("Mint", "Mint")
        sdictRaw.Add("Rice paper", "Rice paper")
        sdictRaw.Add("Tea", "Tea")
        sdictRaw.Add("Pepper", "Pepper")
        sdictRaw.Add("Lettuce", "Lettuce")
        sdictRaw.Add("Egg", "Egg")

        'Populate Prepped Items
        'by creating individual raw items library for every prepped items
        Dim sdictGrilledPork As New SortedDictionary(Of String, String)
        sdictGrilledPork.Add("Pork", sdictRaw("Pork"))
        sdictGrilledPork.Add("Sugar", sdictRaw("Sugar"))
        sdictGrilledPork.Add("MSG", sdictRaw("MSG"))
        sdictGrilledPork.Add("Oil", sdictRaw("Oil"))
        sdictGrilledPork.Add("Salt", sdictRaw("Salt"))
        sdictGrilledPork.Add("Garlic", sdictRaw("Garlic"))
        sdictGrilledPork.Add("Hoisin", sdictRaw("Hoisin"))
        sdictGrilledPork.Add("Pepper", sdictRaw("Pepper"))
        sdictGrilledPork.Add("Fish sauce", sdictRaw("Fish sauce"))
        sdictPrepped.Add("Grilled pork", sdictGrilledPork)

        Dim sdictRice As New SortedDictionary(Of String, String)
        sdictRice.Add("Water", sdictRaw("Water"))
        sdictRice.Add("Broken rice", sdictRaw("Broken rice"))
        sdictPrepped.Add("Steamed rice", sdictRice)

        Dim sdictVeggie As New SortedDictionary(Of String, String)
        sdictVeggie.Add("Cucumber", sdictRaw("Cucumber"))
        sdictVeggie.Add("Tomato", sdictRaw("Tomato"))
        sdictVeggie.Add("Green onion", sdictRaw("Green onion"))
        sdictPrepped.Add("Fresh vegetables", sdictVeggie)

        Dim sdictPickle As New SortedDictionary(Of String, String)
        sdictPickle.Add("Carrot", sdictRaw("Carrot"))
        sdictPickle.Add("Sugar", sdictRaw("Sugar"))
        sdictPickle.Add("Salt", sdictRaw("Salt"))
        sdictPickle.Add("Vinegar", sdictRaw("Vinegar"))
        sdictPrepped.Add("Pickle carrots", sdictPickle)

        Dim sdictSauce As New SortedDictionary(Of String, String)
        sdictSauce.Add("Fish sauce", sdictRaw("Fish sauce"))
        sdictSauce.Add("Sugar", sdictRaw("Sugar"))
        sdictSauce.Add("Water", sdictRaw("Water"))
        sdictSauce.Add("Garlic", sdictRaw("Garlic"))
        sdictSauce.Add("Vinegar", sdictRaw("Vinegar"))
        sdictSauce.Add("Chillies", sdictRaw("Chillies"))
        sdictPrepped.Add("Nước mắm chấm", sdictSauce)

        Dim sdictDrink As New SortedDictionary(Of String, String)
        sdictDrink.Add("Water", sdictRaw("Water"))
        sdictDrink.Add("Tea", sdictRaw("Tea"))
        sdictPrepped.Add("Iced tea", sdictDrink)

        Dim sdictEgg As New SortedDictionary(Of String, String)
        sdictEgg.Add("Egg", sdictRaw("Egg"))
        sdictEgg.Add("Oil", sdictRaw("Oil"))
        sdictPrepped.Add("Fried egg", sdictEgg)

        Dim sdictSRoll As New SortedDictionary(Of String, String)
        sdictSRoll.Add("Rice vermicelli", sdictRaw("Rice vermicelli"))
        sdictSRoll.Add("Lettuce", sdictRaw("Lettuce"))
        sdictSRoll.Add("Thai basil", sdictRaw("Thai basil"))
        sdictSRoll.Add("Shrimp", sdictRaw("Shrimp"))
        sdictSRoll.Add("Pork", sdictRaw("Pork"))
        sdictSRoll.Add("Mint", sdictRaw("Mint"))
        sdictPrepped.Add("Vietnamese spring rolls", sdictSRoll)

        'Populate Dish 
        Dim sdictCom As New SortedDictionary(Of String, SortedDictionary(Of String, String))
        sdictCom.Add("Grilled pork", sdictPrepped("Grilled pork"))
        sdictCom.Add("Nước mắm chấm", sdictPrepped("Nước mắm chấm"))
        sdictCom.Add("Fried egg", sdictPrepped("Fried egg"))
        sdictCom.Add("Fresh Vegetables", sdictPrepped("Fresh vegetables"))
        sdictCom.Add("Pickle carrots", sdictPrepped("Pickle carrots"))
        sdictCom.Add("Steamed rice", sdictPrepped("Steamed rice"))
        sdictCom.Add("Iced tea", sdictPrepped("Iced tea"))
        sdictDish.Add("Cơm tấm platter", sdictCom)

        Dim sdictGoi As New SortedDictionary(Of String, SortedDictionary(Of String, String))
        sdictGoi.Add("Iced tea", sdictPrepped("Iced tea"))
        sdictGoi.Add("Vietnamese spring rolls", sdictPrepped("Vietnamese spring rolls"))
        sdictGoi.Add("Nước mắm chấm", sdictPrepped("Nước mắm chấm"))
        sdictDish.Add("Gỏi cuốn appertizer", sdictGoi)

        printDict() 'Call a print dictionaries to print out all the
    End Sub

    Sub printDict()
        '------------------------------------------------------------
        '-            Subprogram Name: printDict()  -
        '------------------------------------------------------------
        '-                Written By: Binh Dang                -
        '-                Written On: FEbruary 12, 2022              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine print the dictionary to three different listbox
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------

        lstRaw.Items.Clear()
        lstPrepped.Items.Clear()
        lstDish.Items.Clear()

        'Print out everything to approriate listbox
        For Each value As String In sdictRaw.Values
            lstRaw.Items.Add(value)
        Next
        For Each key As String In sdictPrepped.Keys
            lstPrepped.Items.Add(key)
        Next
        For Each key As String In sdictDish.Keys
            lstDish.Items.Add(key)
        Next
    End Sub

    Private Sub lstPrepped_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstPrepped.SelectedIndexChanged
        '------------------------------------------------------------
        '-            Subprogram Name: lstPrepped_SelectedIndexChanged
        '------------------------------------------------------------
        '-                Written By: Binh Dang                -
        '-                Written On: FEbruary 12, 2022              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine print out the selected RAw item that associated 
        '- with the Prepped Item that is being selected by customer
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- dictKey - a dictionary of all the Keys                                                   -
        '------------------------------------------------------------
        'Reset the selected raw ingr
        lstSelectedRaw.Items.Clear()

        'Every time Prep item listbox index change then assigned new key dictinary to dictKey
        Dim dictKey = sdictPrepped.Item(lstPrepped.Text).Keys

        'If it's empty then print no raw Ingredient attached
        If dictKey.Count = 0 Then
            MessageBox.Show("There is No Attached Raw Ingrdient to this Prepped Item!")
        Else 'else print the raw ingredient attached to the prepped items
            For Each s In dictKey
                lstSelectedRaw.Items.Add(s)
            Next
        End If

    End Sub

    Private Sub lstDish_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstDish.SelectedIndexChanged
        '------------------------------------------------------------
        '-            Subprogram Name: lstDish_SelectedIndexChanged
        '------------------------------------------------------------
        '-                Written By: Binh Dang                -
        '-                Written On: FEbruary 12, 2022              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine print out the selected Prepped item that associated 
        '- with the Dish that is being selected by customer
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- dictKey - a dictionary of all the Keys                                                  -
        '------------------------------------------------------------
        'Reset the selected raw ingr
        lstSelectedPrep.Items.Clear()

        'Every time Dish listbox index change then assigned new key dictinary to dictKey
        Dim dictKey = sdictDish.Item(lstDish.Text).Keys

        'If it's empty then print no items attached
        If dictKey.Count = 0 Then
            MessageBox.Show("There is No Attached Prepped Item to this Dish!")
        Else 'else print the prepped items attached to the dish
            For Each s In dictKey
                lstSelectedPrep.Items.Add(s)
            Next
        End If
    End Sub

    Private Sub btnRaw_Click(sender As Object, e As EventArgs) Handles btnRaw.Click
        '------------------------------------------------------------
        '-            Subprogram Name: btnRaw_Click
        '------------------------------------------------------------
        '-                Written By: Binh Dang                -
        '-                Written On: FEbruary 12, 2022              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine create a new pair key-value thena dded it to 
        '- the according sdictRaw dictionary
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        'Call function to verified the input text
        'If approriate then assigned it the dictionary and print out all the listbox
        'reset the textField
        If textVerified(txtRaw.Text) Then
            If sdictRaw.ContainsKey(txtRaw.Text) Then
                MessageBox.Show("Duplicate Raw Ingredient, Please try Again!")
            Else
                sdictRaw.Add(txtRaw.Text, txtRaw.Text)
                printDict()
                txtRaw.Text = ""
            End If
        End If
    End Sub

    Private Sub btnPrepped_Click(sender As Object, e As EventArgs) Handles btnPrepped.Click
        '------------------------------------------------------------
        '-            Subprogram Name: btnPrepped_Click
        '------------------------------------------------------------
        '-                Written By: Binh Dang                -
        '-                Written On: FEbruary 12, 2022              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine create a new pair key and value(Creating a new dictionary based on the 
        '- sdictRaw) then added it to the according sdictPrepped dictionary
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- sdictEmpty - empty dictionary based on sdictRaw structure                                                -
        '------------------------------------------------------------
        'Call function to verified the input text
        'If approriate then assigned it the dictionary and print out all the listbox
        'reset the textField
        If textVerified(txtPrepped.Text) Then
            If sdictPrepped.ContainsKey(txtPrepped.Text) Then
                MessageBox.Show("Duplicate Prepped Items, Please try Again!")
            Else
                Dim sdictEmpty As New SortedDictionary(Of String, String)
                sdictPrepped.Add(txtPrepped.Text, sdictEmpty)
                printDict()
                txtPrepped.Text = ""
            End If
        End If
    End Sub

    Private Sub btnDish_Click(sender As Object, e As EventArgs) Handles btnDish.Click
        '------------------------------------------------------------
        '-            Subprogram Name: btnDish_Click
        '------------------------------------------------------------
        '-                Written By: Binh Dang                -
        '-                Written On: FEbruary 12, 2022              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine create a new pair key and value(Creating a new dictionary based on the 
        '- sdictPrepped) then added it to the according sdictDish dictionary
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- sdictEmpty - empty dictionary based on sdictPrepped structure                                                -
        '------------------------------------------------------------
        'Call function to verified the input text
        'If approriate then assigned it the dictionary and print out all the listbox
        'reset the textField
        If textVerified(txtDish.Text) Then
            If sdictDish.ContainsKey(txtDish.Text) Then
                MessageBox.Show("Duplicate Dish, Please try Again!")
            Else
                Dim sdictEmpty As New SortedDictionary(Of String, SortedDictionary(Of String, String))
                sdictDish.Add(txtDish.Text, sdictEmpty)
                printDict()
                txtDish.Text = ""
            End If
        End If
    End Sub

    Function textVerified(ByRef strTxt As String) As Boolean
        '------------------------------------------------------------
        '-            Subprogram Name: textVerified
        '------------------------------------------------------------
        '-                Written By: Binh Dang                -
        '-                Written On: FEbruary 12, 2022              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine pass in the reference of the string text then
        '-validate it, if qualified return true and make the first letter upper
        '-else show a error message box
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- sdictEmpty - empty dictionary based on sdictPrepped structure                                                -
        '------------------------------------------------------------
        'Accept a series of String without anynumber
        Dim MyRegex As New Regex("[a-zA-Z]+\s?[a-zA-Z]+$")

        'return false if string is not in approriate format
        If String.IsNullOrWhiteSpace(strTxt) Or String.IsNullOrEmpty(strTxt) Or IsNumeric(strTxt) Or Not MyRegex.IsMatch(strTxt) Then
            MessageBox.Show("Invalid Name. Please try again!")
            Return False
        Else 'change the string to have upper case in the first letter and the rest is lowercase
            strTxt = strTxt.Substring(0, 1).ToUpper + strTxt.Substring(1).ToLower
            Return True
        End If
    End Function

    Private Sub btnAddRaw_Click(sender As Object, e As EventArgs) Handles btnAddRaw.Click
        '------------------------------------------------------------
        '-            Subprogram Name: btnAddRaw_Click
        '------------------------------------------------------------
        '-                Written By: Binh Dang                -
        '-                Written On: February 12, 2022              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine add raw items to the particular prepped items.
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '-None                                               -
        '------------------------------------------------------------
        'If none of them selected then show the inbox
        If lstPrepped.SelectedIndex = -1 Or lstRaw.SelectedIndex = -1 Then
            MessageBox.Show("Need to select one Prepped items and one Raw Item to Add")
        Else
            'if already in the selected list, then show msgbox.
            'else Add to the dictionary 
            If Not sdictPrepped(lstPrepped.Text).ContainsKey(lstRaw.Text) Then
                sdictPrepped(lstPrepped.Text).Add(lstRaw.Text, lstRaw.Text)
                lstSelectedRaw.Items.Add(lstRaw.Text)
            Else
                MessageBox.Show("Duplicate Selected Raw Items!")
            End If
        End If
    End Sub

    Private Sub btnRemoveRaw_Click(sender As Object, e As EventArgs) Handles btnRemoveRaw.Click
        '------------------------------------------------------------
        '-            Subprogram Name: btnRemoveRaw_Click
        '------------------------------------------------------------
        '-                Written By: Binh Dang                -
        '-                Written On: February 13, 2022              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine remove raw items from a particular prepped items
        '- while also update the associated dictionary
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- None                                       -
        '------------------------------------------------------------
        'If none of them selected then show the inbox
        If lstPrepped.SelectedIndex = -1 Or lstSelectedRaw.SelectedIndex = -1 Then
            MessageBox.Show("Need to select one Prepped items and one Selected Raw Ingredient to Remove")
        Else
            'Remove it from the dictionary then delete from listbox
            sdictPrepped(lstPrepped.Text).Remove(lstSelectedRaw.Text)
            lstSelectedRaw.Items.Remove(lstSelectedRaw.Text)
        End If
    End Sub

    Private Sub btnAddPrepped_Click(sender As Object, e As EventArgs) Handles btnAddPrepped.Click
        '------------------------------------------------------------
        '-            Subprogram Name: btnAddPrepped_Click
        '------------------------------------------------------------
        '-                Written By: Binh Dang                -
        '-                Written On: February 13, 2022              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine add prepped items to the particular dish
        '- while also update the dictionary that associated.
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- None                                    -
        '------------------------------------------------------------
        'If none of them selected then show the inbox
        If lstDish.SelectedIndex = -1 Or lstPrepped.SelectedIndex = -1 Then
            MessageBox.Show("Need to select one Prepped items and one Dish Item to Add")
        Else
            'if already in the selected list, then show msgbox.
            'else Add to the dictionary 
            If Not sdictDish(lstDish.Text).ContainsKey(lstPrepped.Text) Then
                sdictDish(lstDish.Text).Add(lstPrepped.Text, sdictPrepped(lstPrepped.Text))
                lstSelectedPrep.Items.Add(lstPrepped.Text)
            Else
                MessageBox.Show("Duplicate Selected Prepped Items!")
            End If
        End If
    End Sub

    Private Sub btnRemovePrepped_Click(sender As Object, e As EventArgs) Handles btnRemovePrepped.Click
        '------------------------------------------------------------
        '-            Subprogram Name: btnRemovePrepped_Click
        '------------------------------------------------------------
        '-                Written By: Binh Dang                -
        '-                Written On: February 13, 2022              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '- This subroutine remove Prepped items from a particular dish
        '- while also update the associated dictionary
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- None                                       -
        '------------------------------------------------------------
        If lstDish.SelectedIndex = -1 Or lstSelectedPrep.SelectedIndex = -1 Then
            MessageBox.Show("Need to select one Selected Prepped items and one Dish Item to Add")
        Else
            'Remove from the selected dictionary then renove from the text box
            sdictDish(lstDish.Text).Remove(lstSelectedPrep.Text)
            lstSelectedPrep.Clear()
            For Each s In dictKey
                lstSelectedPrep.Items.Add(s)
            Next
        End If
    End Sub
End Class
