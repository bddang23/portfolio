'We need to bring in the SqlClient namespace
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports System.Text.RegularExpressions

Public Class frmCar
    '------------------------------------------------------------
    '-                File Name : frmCar.vb                 - 
    '-                Part of Project: CarAndOwnerDatabase -
    '------------------------------------------------------------
    '-                Written By: Binh Dang               -
    '-                Written On: March 31              -
    '------------------------------------------------------------
    '- File Purpose:                                            -
    '-                                                          -
    '- This file contains the subdirectory that allow user to connect to the Car database
    '- which help them see the user and the car associated with the users
    '------------------------------------------------------------
    '- Program Purpose:                                         -
    '-                                                          -
    '- a system that will allow the user to connect to the Car database
    '- which help them see the user and the car associated with the users. They can navigate to
    '- different user, add, delete,and update
    '---------------------------------------------------------------------------------------
    '---------------------------------------------------------------------------------------
    '--- GLOBAL DICTIONARIES
    '- DBAdaptOwners - Database Adapter for Owner
    '- DBAdaptVehicles - Database Adapter for Owner
    '- dsOwners - Dataset for Owner
    '- dsVehicles - Dataset for Vehicle
    '- intPos - keep track of position in the database
    '- myConn - sqlConnection object
    '- strCONNECTION - This is the full connection string
    '- strDBNAME - name of database
    '- strDBPATH - Path to database in executable
    '- strSERVERNAME - Name of the database server
    '- strStatus - String as Flag to know if it's adding or update
    '---------------------------------------------------------------------------------------

    'Create a dataset to point to each table
    Dim dsOwners As New DataSet
    Dim dsVehicles As New DataSet

    Dim intPos As Integer = 0
    Dim strStatus = ""

    Const strDBNAME As String = "CarSQL" 'Name of database

    'Name of the database server
    Const strSERVERNAME As String = "(localdb)\MSSQLLocalDB"

    'Path to database in executable
    Dim strDBPATH As String = My.Application.Info.DirectoryPath &
                                  "\" & strDBNAME & ".mdf"

    'This is the full connection string
    Dim strCONNECTION As String = "SERVER=" & strSERVERNAME & ";DATABASE=" &
                 strDBNAME & ";Integrated Security=SSPI;AttachDbFileName=" &
                 strDBPATH

    'a SqlConnection object 
    Dim myConn As New SqlConnection(strCONNECTION)

    'Likewise create 2 data adapters
    Dim DBAdaptOwners As SqlDataAdapter
    Dim DBAdaptVehicles As SqlDataAdapter

    Private Sub frmCar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '------------------------------------------------------------
        '-            Subprogram Name: frmCar_Load  -
        '------------------------------------------------------------
        '-                Written By: Binh Dang                -
        '-                Written On: March 31, 2022           -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine process when the form initially load
        '- binding the data to the textboxes, also so the attatched data in the datagridview
        '------------------------------------------------------------
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- strSQLCmd    - command for SQL                                            -
        '------------------------------------------------------------

        btnSave.Visible = False
        btnCancel.Visible = False

        'The user will never be able to type anything into the txtID textbox
        'We will pull the value from the txtStudentID textbox
        txtID.Enabled = False

        Dim strSQLCmd As String

        'Load up all information for User 
        strSQLCmd = "Select * From Owners"
        DBAdaptOwners = New SqlDataAdapter(strSQLCmd, strCONNECTION)
        DBAdaptOwners.Fill(dsOwners, "Owners")

        'Set bindings on the textboxes for owners
        txtFirst.DataBindings.Add(New Binding("Text", dsOwners, "Owners.FirstName"))
        txtLast.DataBindings.Add(New Binding("Text", dsOwners, "Owners.LastName"))
        txtAddress.DataBindings.Add(New Binding("Text", dsOwners, "Owners.StreetAddress"))
        txtCity.DataBindings.Add(New Binding("Text", dsOwners, "Owners.City"))
        txtState.DataBindings.Add(New Binding("Text", dsOwners, "Owners.State"))
        txtZip.DataBindings.Add(New Binding("Text", dsOwners, "Owners.ZipCode"))
        txtID.DataBindings.Add(New Binding("Text", dsOwners, "Owners.TUID"))

        'Load up all vehicc since they will never change while the program runs
        strSQLCmd = "Select * From Vehicles WHERE OwnerID= " & Trim(txtID.Text)

        DBAdaptVehicles = New SqlDataAdapter(strSQLCmd, strCONNECTION)
        DBAdaptVehicles.Fill(dsVehicles, "Vehicles")
        dgvResults.DataSource = dsVehicles.Tables("Vehicles")

    End Sub

    Private Sub btnNavigate_Click(sender As Object, e As EventArgs) Handles btnNext.Click, btnPrev.Click, btnFirst.Click, btnLast.Click
        '------------------------------------------------------------
        '-            Subprogram Name: btnNavigate_Click  -
        '------------------------------------------------------------
        '-                Written By: Binh Dang                -
        '-                Written On: March 31, 2022           -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine control the 4 navigation buttons including
        '- next, first, last, previous. Showing the approriate owner and car
        '------------------------------------------------------------
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- strSQLCmd    - command for SQL                                            -
        '------------------------------------------------------------
        Dim btn As Button = CType(sender, Button)
        If btn.Name.Contains("Next") Then
            BindingContext(dsOwners, "Owners").Position = BindingContext(dsOwners, "Owners").Position + 1
        ElseIf btn.Name.Contains("Prev") Then
            BindingContext(dsOwners, "Owners").Position = BindingContext(dsOwners, "Owners").Position - 1
        ElseIf btn.Name.Contains("First") Then
            BindingContext(dsOwners, "Owners").Position = 0
        Else
            BindingContext(dsOwners, "Owners").Position = dsOwners.Tables("Owners").Rows.Count - 1
        End If

        'Load up all vehicc since they will never change while the program runs
        Dim strSQLCmd As String = "Select * From Vehicles WHERE OwnerID= " & Trim(txtID.Text)
        dsVehicles.Clear()

        DBAdaptVehicles = New SqlDataAdapter(strSQLCmd, strCONNECTION)
        DBAdaptVehicles.Fill(dsVehicles, "Vehicles")
        dgvResults.DataSource = dsVehicles.Tables("Vehicles")
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        '------------------------------------------------------------
        '-            Subprogram Name: btnAdd_Click  -
        '------------------------------------------------------------
        '-                Written By: Binh Dang                -
        '-                Written On: March 31, 2022           -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine turn off all the buttons and the data grid view for
        '- vehicles
        '------------------------------------------------------------
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- None                                          -
        '------------------------------------------------------------
        'turn off all buttons
        btnAdd.Visible = False
        btnCancel.Visible = False
        btnDelete.Visible = False
        btnUpdate.Visible = False
        btnFirst.Visible = False
        btnLast.Visible = False
        btnNext.Visible = False
        btnPrev.Visible = False

        'make the textfields editable
        txtFirst.ReadOnly = False
        txtLast.ReadOnly = False
        txtAddress.ReadOnly = False
        txtCity.ReadOnly = False
        txtState.ReadOnly = False
        txtZip.ReadOnly = False

        'set all the text to blank
        txtFirst.Text = ""
        txtLast.Text = ""
        txtAddress.Text = ""
        txtCity.Text = ""
        txtState.Text = ""
        txtZip.Text = ""

        'get the position of the "new" owner
        intPos = dsOwners.Tables("Owners").Rows.Count
        strStatus = "Add" 'set status to add

        'set the ID to the "new" user by add 1
        txtID.Text = intPos + 1

        'tuen off the datagridview
        dgvResults.Visible = False

        'show button save and cancel
        btnSave.Visible = True
        btnCancel.Visible = True
    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        '------------------------------------------------------------
        '-            Subprogram Name: btnCancel_Click  -
        '------------------------------------------------------------
        '-                Written By: Binh Dang                -
        '-                Written On: March 31, 2022           -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine turn on all the buttons along with the textfields and data gridview
        '- hide the save and cancel button 
        '------------------------------------------------------------
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- None                                          -
        '------------------------------------------------------------
        btnAdd.Visible = True
        btnCancel.Visible = True
        btnDelete.Visible = True
        btnUpdate.Visible = True
        btnFirst.Visible = True
        btnLast.Visible = True
        btnNext.Visible = True
        btnPrev.Visible = True

        txtFirst.ReadOnly = True
        txtLast.ReadOnly = True
        txtAddress.ReadOnly = True
        txtCity.ReadOnly = True
        txtState.ReadOnly = True
        txtZip.ReadOnly = True

        dgvResults.Visible = True
        btnSave.Visible = False
        btnCancel.Visible = False

        'Set the bindinng data cancel
        BindingContext(dsOwners, "Owners").CancelCurrentEdit()
    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        '------------------------------------------------------------
        '-            Subprogram Name: btnSave_Click  -
        '------------------------------------------------------------
        '-                Written By: Binh Dang                -
        '-                Written On: March 31, 2022           -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine turn on all the buttons along with the textfields and data gridview
        '- hide the save and cancel button. ALong with that, update the database
        '- or add data in using SQL commands
        '------------------------------------------------------------
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- DBCmd - SQL command 
        '- strSQLCmd - a string showing sql command
        '------------------------------------------------------------
        Dim blnCheck As Boolean = ValidateInput() 'calling function validate input
        txtState.Text = txtState.Text.ToUpper
        'check if the data is satisfiedn then proceed. if not, exit the subprogram
        If blnCheck = False Then
            Exit Sub
        Else
            'show all buttons
            btnAdd.Visible = True
            btnCancel.Visible = True
            btnDelete.Visible = True
            btnUpdate.Visible = True
            btnFirst.Visible = True
            btnLast.Visible = True
            btnNext.Visible = True
            btnPrev.Visible = True

            'make textfield read only
            txtFirst.ReadOnly = True
            txtLast.ReadOnly = True
            txtAddress.ReadOnly = True
            txtCity.ReadOnly = True
            txtState.ReadOnly = True
            txtZip.ReadOnly = True

            'show the datagridview
            dgvResults.Visible = True
            'hiding buttons Save and Cancel
            btnSave.Visible = False
            btnCancel.Visible = False


            Dim DBCmd As SqlCommand = New SqlCommand()
            Dim strSQLCmd As String

            If strStatus = "Add" Then
                'Use SQL to insert a new row into Registration
                DBCmd.CommandText = "INSERT INTO Owners (TUID, FirstName, LastName,StreetAddress,City,State,ZipCode) " &
                                    "VALUES ('" & txtID.Text & "','" & txtFirst.Text & "','" & txtLast.Text & "','" & txtAddress.Text & "','" & txtCity.Text & "','" & txtState.Text & "','" & txtZip.Text & "')"

            Else
                DBCmd.CommandText = "UPDATE Owners " &
                                    "SET FirstName = '" & txtFirst.Text & "'," &
                                        "LastName = '" & txtLast.Text & "'," &
                                        "StreetAddress = '" & txtAddress.Text & "'," &
                                        "City = '" & txtCity.Text & "'," &
                                        "State = '" & txtState.Text & "'," &
                                        "ZipCode = '" & txtZip.Text & "' " &
                                    "WHERE TUID ='" & txtID.Text & "' "
            End If
            myConn.Open()
            DBCmd.Connection = myConn
            DBCmd.ExecuteNonQuery()  'Since it's a non-SELECT statement

            'clear the dataset
            dsOwners.Clear()
            dsVehicles.Clear()

            'Load up all information for User 
            strSQLCmd = "Select * From Owners"
            DBAdaptOwners = New SqlDataAdapter(strSQLCmd, strCONNECTION)
            DBAdaptOwners.Fill(dsOwners, "Owners")

            BindingContext(dsOwners, "Owners").Position = intPos

            'Load up all vehicles
            strSQLCmd = "Select * From Vehicles WHERE OwnerID= " & Trim(txtID.Text)
            DBAdaptVehicles = New SqlDataAdapter(strSQLCmd, strCONNECTION)
            DBAdaptVehicles.Fill(dsVehicles, "Vehicles")

            'refresh data grid view
            dgvResults.Refresh()
            myConn.Close()
        End If


    End Sub
    Private Sub frmCar_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        '------------------------------------------------------------
        '-            Subprogram Name: frmCar_Closing  -
        '------------------------------------------------------------
        '-                Written By: Binh Dang                -
        '-                Written On: March 31, 2022           -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine check if user want to delete the database or not
        '------------------------------------------------------------
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- DBCmd - SQL command 
        '- strSQLCmd - a string showing sql command
        '------------------------------------------------------------
        If MessageBox.Show("Do you want to physically delete the database?", "",
                           MessageBoxButtons.YesNo) = DialogResult.Yes Then
            DeleteDatabase(strSERVERNAME, strDBNAME)
        End If

    End Sub
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        '------------------------------------------------------------
        '-            Subprogram Name: btnDelete_Click  -
        '------------------------------------------------------------
        '-                Written By: Binh Dang                -
        '-                Written On: March 31, 2022           -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine check if user want to delete the owner in the owners database
        '------------------------------------------------------------
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- DBCmd - SQL command 
        '- strSQLCmd - a string showing sql command
        '------------------------------------------------------------
        If MessageBox.Show("Are you sure you want to delete this record?", "", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            Dim DBCmd As SqlCommand = New SqlCommand()
            Dim strSQLCmd As String

            'Delete the owner that currently on
            'Use SQL to insert a new row into Registration
            DBCmd.CommandText = "DELETE FROM Owners " &
                                "WHERE TUID =" & Trim(txtID.Text)
            myConn.Open()
            DBCmd.Connection = myConn
            DBCmd.ExecuteNonQuery()  'Since it's a non-SELECT statement

            'Use SQL to insert a new row into Registration
            'delete associated vehicle with the owner ID
            DBCmd.CommandText = "DELETE FROM Vehicles " &
                                "WHERE OwnerID =" & Trim(txtID.Text)
            DBCmd.Connection = myConn
            DBCmd.ExecuteNonQuery()  'Since it's a non-SELECT statement

            dsOwners.Clear()
            dsVehicles.Clear()

            'Load up all information for User 
            strSQLCmd = "Select * From Owners"
            DBAdaptOwners = New SqlDataAdapter(strSQLCmd, strCONNECTION)
            DBAdaptOwners.Fill(dsOwners, "Owners")

            BindingContext(dsOwners, "Owners").Position = 0


            'Load up all vehicc since they will never change while the program runs
            strSQLCmd = "Select * From Vehicles WHERE OwnerID= " & Trim(txtID.Text)
            DBAdaptVehicles = New SqlDataAdapter(strSQLCmd, strCONNECTION)
            DBAdaptVehicles.Fill(dsVehicles, "Vehicles")
            dgvResults.Refresh()
            myConn.Close()
        End If
    End Sub
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        '------------------------------------------------------------
        '-            Subprogram Name: btnUpdate_Click  -
        '------------------------------------------------------------
        '-                Written By: Binh Dang                -
        '-                Written On: March 31, 2022           -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine turn off all the buttons and the data grid view for
        '- vehicles
        '------------------------------------------------------------
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- None                                          -
        '------------------------------------------------------------
        btnAdd.Visible = False
        btnCancel.Visible = False
        btnDelete.Visible = False
        btnUpdate.Visible = False
        btnFirst.Visible = False
        btnLast.Visible = False
        btnNext.Visible = False
        btnPrev.Visible = False

        txtFirst.ReadOnly = False
        txtLast.ReadOnly = False
        txtAddress.ReadOnly = False
        txtCity.ReadOnly = False
        txtState.ReadOnly = False
        txtZip.ReadOnly = False

        strStatus = "Update"
        dgvResults.Visible = False
        btnSave.Visible = True
        btnCancel.Visible = True

        intPos = CInt(txtID.Text) - 1
    End Sub
    Private Function ValidateInput() As Boolean
        '------------------------------------------------------------
        '-            Function Name: ValidateInput  -
        '------------------------------------------------------------
        '-                Written By: Binh Dang                -
        '-                Written On: March 31, 2022           -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine turn on all the buttons along with the textfields and data gridview
        '- hide the save and cancel button. ALong with that, update the database
        '- or add data in using SQL commands
        '------------------------------------------------------------
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- DBCmd - SQL command 
        '- strSQLCmd - a string showing sql command
        '------------------------------------------------------------
        Dim txtInput() As TextBox = {txtAddress, txtCity, txtFirst, txtLast, txtState, txtZip}
        'Accept a series of String without anynumber
        Dim ZipRegex As New Regex("^\d{5}$")
        Dim StateRegex As New Regex("^[A-Z]{2}$")

        For Each input As TextBox In txtInput
            If String.IsNullOrWhiteSpace(input.Text) Then
                MessageBox.Show("Empty Input in " & input.Name & "! Please enter all info.")
                Return False
            ElseIf input.Name.Contains("State") Then
                If Not StateRegex.IsMatch(input.Text.ToUpper) Then
                    MessageBox.Show("Enter State with Abbreviation!")
                    Return False
                End If
            ElseIf input.Name.Contains("Zip") Then
                If Not ZipRegex.IsMatch(input.Text) Then
                    MessageBox.Show("Enter Valid Zip Code!")
                    Return False
                End If
            End If
        Next
        Return True
    End Function
End Class
