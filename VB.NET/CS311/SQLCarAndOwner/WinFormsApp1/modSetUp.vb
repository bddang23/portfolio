Imports System.Data.SqlClient

Module modSetUp
    '------------------------------------------------------------
    '-                File Name : modSetUp.vb                 - 
    '-                Part of Project: CarAndOwnerDatabase -
    '------------------------------------------------------------
    '-                Written By: Binh Dang               -
    '-                Written On: March 31,2022              -
    '------------------------------------------------------------
    '- File Purpose:                                            -
    '-                                                          -
    '- This file contains the subdirectory that set up the whole
    '- car owners database including 2 tables
    '------------------------------------------------------------
    '- Program Purpose:                                         -
    '-                                                          -
    '- a system that will allow the user to connect to the Car database
    '- which help them see the user and the car associated with the users. They can navigate to
    '- different user, add, delete,and update
    '---------------------------------------------------------------------------------------

    Sub Main()
        '------------------------------------------------------------
        '-            Subprogram Name: Main  -
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
        '- DBConn - sqlConnection object
        '- strCONNECTION - This is the full connection string
        '- strDBNAME - name of database
        '- strDBPATH - Path to database in executable
        '- strSERVERNAME - Name of the database server                      -
        '------------------------------------------------------------

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

        'If the database doesn't exist, create it
        If Not (System.IO.File.Exists(strDBPATH)) Then
            CreateDatabase(strSERVERNAME, strDBNAME, strDBPATH, strCONNECTION)
        End If

        'Make sure all tables are cleaned out each time we run this
        CleanOutOwnersTable(strCONNECTION)
        CleanOutVehiclesTable(strCONNECTION)

        'Put some data into the tables
        PopulateOwnersTable(strCONNECTION)
        PopulateVehiclesTable(strCONNECTION)

        'Show the main dialog
        frmCar.ShowDialog()
    End Sub
    Sub CreateDatabase(ByVal strSERVERNAME As String, ByVal strDBNAME As String,
                       ByVal strDBPATH As String, ByVal strCONNECTION As String)
        '------------------------------------------------------------
        '-            Subprogram Name: CreateDatabase  -
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
        '- strSQLCmd - SQL STring 
        '- DBCmd - SqlCommand that run the string
        '------------------------------------------------------------
        Dim strSQLCmd As String
        Dim DBConn As SqlConnection
        Dim DBCmd As SqlCommand

        'All we need to do initially is just point at the server
        DBConn = New SqlConnection("Server=" & strSERVERNAME)

        'Let's write a SQL DDL Command to build the database
        'There are a lot of other parameters but we can let them default
        'All we need are these three
        strSQLCmd = "CREATE DATABASE " & strDBNAME & " On " &
                    "(NAME = '" & strDBNAME & "', " &
                    "FILENAME = '" & strDBPATH & "')"

        DBCmd = New SqlCommand(strSQLCmd, DBConn)

        Try
            'Open the connection and try running the command
            DBConn.Open()
            DBCmd.ExecuteNonQuery()
            MessageBox.Show("Database was successfully created", "",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            'If we can't build the database, we are dead in the water so bail...
            MessageBox.Show(ex.ToString())
            MessageBox.Show("Cannot build database!  Closing program down...")
            End
        End Try

        'We are currently pointing at the [MASTER] database, so we
        'need to close the connection and reopen it pointing at the
        'Registration database...
        If (DBConn.State = ConnectionState.Open) Then
            DBConn.Close()
        End If

        'Now we need to use the full connection string with the Integrated 
        'Security line, et cetera
        DBConn = New SqlConnection(strCONNECTION)
        DBConn.Open()

        'Build the Tables one at a time

        'Build the Student Table by writing the SQL DDL Command
        DBCmd.CommandText = "CREATE TABLE Owners (" &
                             "TUID int not null, " &
                             "FirstName varchar(50) null, " &
                             "LastName varchar(50) null," &
                             "StreetAddress varchar(50) null," &
                             "City varchar(50) null," &
                             "State varchar(50) null," &
                             "ZipCode varchar(50) null," &
                             "PRIMARY KEY CLUSTERED (TUID ASC))"

        DBCmd.Connection = DBConn
        Try
            DBCmd.ExecuteNonQuery()
            MessageBox.Show("Created Owners Table")
        Catch Ex As Exception
            MessageBox.Show("Owners Table Already Exists")
        End Try

        'Build the Courses Table
        DBCmd.CommandText = "CREATE TABLE Vehicles (" &
                             "TUID int not null, " &
                             "OwnerID int not null, " &
                             "Make varchar(50) null," &
                             "Model varchar(50) null," &
                             "Color varchar(50) null," &
                             "ModelYear int null, " &
                             "VIN varchar(50) null," &
                             "PRIMARY KEY CLUSTERED (TUID ASC))"
        DBCmd.Connection = DBConn
        Try
            DBCmd.ExecuteNonQuery()
            MessageBox.Show("Created Vehicles Table")
        Catch Ex As Exception
            MessageBox.Show("Courses Table Already Exists")
        End Try

        'We can check to see if we're open before trying to
        'issue a connection close
        If (DBConn.State = ConnectionState.Open) Then
            DBConn.Close()
        End If
    End Sub
    Sub CleanOutOwnersTable(ByVal strConn As String)
        '------------------------------------------------------------
        '-            Subprogram Name: CleanOutOwnersTable  -
        '------------------------------------------------------------
        '-                Written By: Binh Dang                -
        '-                Written On: March 31, 2022           -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine clean out the owner table
        '------------------------------------------------------------
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- DBCmd - SqlCommand that run the string
        '------------------------------------------------------------

        'Now try to open up a connection to the database
        Dim DBConn As SqlConnection = New SqlConnection(strConn)
        Dim DBCmd As SqlCommand = New SqlCommand()

        'Now try to open up a connection to the database
        DBConn = New SqlConnection(strConn)
        DBConn.Open()

        'Use SQL DML to zap the contents of the table
        DBCmd.CommandText = "DELETE FROM Owners"
        DBCmd.Connection = DBConn
        DBCmd.ExecuteNonQuery()
        MessageBox.Show("Deleted Everything In Owners")

        DBConn.Close()
    End Sub
    Sub CleanOutVehiclesTable(ByVal strConn As String)
        '------------------------------------------------------------
        '-            Subprogram Name: CleanOutVehiclesTable  -
        '------------------------------------------------------------
        '-                Written By: Binh Dang                -
        '-                Written On: March 31, 2022           -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine clean out the Vehivles table
        '------------------------------------------------------------
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- DBCmd - SqlCommand that run the string
        '------------------------------------------------------------
        Dim DBCmd As SqlCommand = New SqlCommand()
        Dim DBConn As SqlConnection = New SqlConnection(strConn)
        'Now try to open up a connection to the database
        DBConn = New SqlConnection(strConn)
        DBConn.Open()


        'Use SQL DML to zap the contents of the table
        DBCmd.CommandText = "DELETE FROM Vehicles"
        DBCmd.Connection = DBConn
        DBCmd.ExecuteNonQuery()
        MessageBox.Show("Deleted Everything In Vehicles")

        DBConn.Close()
    End Sub
    Sub PopulateOwnersTable(ByVal strConn As String)
        '------------------------------------------------------------
        '-            Subprogram Name: CleanOutVehiclesTable  -
        '------------------------------------------------------------
        '-                Written By: Binh Dang                -
        '-                Written On: March 31, 2022           -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine add in the user to the Owner table
        '------------------------------------------------------------
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- DBCmd - SqlCommand that run the string
        '------------------------------------------------------------
        Dim DBCmd As SqlCommand = New SqlCommand()
        Dim DBConn As SqlConnection = New SqlConnection(strConn)
        'Now try to open up a connection to the database
        DBConn = New SqlConnection(strConn)
        DBConn.Open()

        'Add a student using SQL DML
        DBCmd.CommandText = "INSERT INTO Owners (TUID, FirstName, LastName,StreetAddress,City,State,ZipCode) " &
                            "VALUES ('1','Scott','James','123 Elm','Saginaw','MI','48604')"
        DBCmd.Connection = DBConn
        DBCmd.ExecuteNonQuery()

        DBCmd.CommandText = "INSERT INTO Owners (TUID, FirstName, LastName,StreetAddress,City,State,ZipCode) " &
                            "VALUES ('2','Binh','Dang','456 Pine','Saginaw','MI','48604')"
        DBCmd.Connection = DBConn
        DBCmd.ExecuteNonQuery()

        DBCmd.CommandText = "INSERT INTO Owners (TUID, FirstName, LastName,StreetAddress,City,State,ZipCode) " &
                            "VALUES ('3','Duy','Nguyen','789 Alm','Birch Run','MI','48415')"
        DBCmd.Connection = DBConn
        DBCmd.ExecuteNonQuery()

        DBConn.Close()
        MessageBox.Show("Added Owners To Owners Table")
    End Sub
    Sub PopulateVehiclesTable(ByVal strConn As String)
        '------------------------------------------------------------
        '-            Subprogram Name: PopulateVehiclesTable  -
        '------------------------------------------------------------
        '-                Written By: Binh Dang                -
        '-                Written On: March 31, 2022           -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine add in the user to the Vehicle
        '------------------------------------------------------------
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- DBCmd - SqlCommand that run the string
        '------------------------------------------------------------
        Dim DBConn As SqlConnection
        Dim DBCmd As SqlCommand = New SqlCommand()

        'Now try to open up a connection to the database
        DBConn = New SqlConnection(strConn)
        DBConn.Open()

        'Add courses using SQL DML
        DBCmd.CommandText = "INSERT INTO Vehicles (TUID, OwnerID, Make, Model, Color, ModelYear,VIN) " &
                            "VALUES ('1','1','Chevy','Carmaro','Blue','2018','14XA1394394')"
        DBCmd.Connection = DBConn
        DBCmd.ExecuteNonQuery()

        DBCmd.CommandText = "INSERT INTO Vehicles (TUID, OwnerID, Make, Model, Color, ModelYear,VIN) " &
                            "VALUES ('2','2','Ford','F-150','Red','2017','2A7764747236')"
        DBCmd.Connection = DBConn
        DBCmd.ExecuteNonQuery()

        DBCmd.CommandText = "INSERT INTO Vehicles (TUID, OwnerID, Make, Model, Color, ModelYear,VIN) " &
                            "VALUES ('3','2','Dodge','Dart','Red','2016','56B6D7667')"
        DBCmd.Connection = DBConn
        DBCmd.ExecuteNonQuery()

        DBCmd.CommandText = "INSERT INTO Vehicles (TUID, OwnerID, Make, Model, Color, ModelYear,VIN) " &
                            "VALUES ('4','3','Kia','Soul','Green','2020','1A1467464484')"
        DBCmd.Connection = DBConn
        DBCmd.ExecuteNonQuery()

        DBCmd.CommandText = "INSERT INTO Vehicles (TUID, OwnerID, Make, Model, Color, ModelYear,VIN) " &
                            "VALUES ('5','3','Toyota','Cambry','Blue','2018','2638HSU928S')"
        DBCmd.Connection = DBConn
        DBCmd.ExecuteNonQuery()

        DBCmd.CommandText = "INSERT INTO Vehicles (TUID, OwnerID, Make, Model, Color, ModelYear,VIN) " &
                            "VALUES ('6','3','Dodge','Carmaro','Blue','2018','68J76E7433')"
        DBCmd.Connection = DBConn
        DBCmd.ExecuteNonQuery()

        DBConn.Close()
        MessageBox.Show("Added Vehicle To Vehicles Table")
    End Sub


    Sub DeleteDatabase(ByVal strSERVERNAME As String, ByVal strDBNAME As String)
        '------------------------------------------------------------
        '-            Subprogram Name: DeleteDatabase  -
        '------------------------------------------------------------
        '-                Written By: Binh Dang                -
        '-                Written On: March 31, 2022           -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                  
        '- This routine shows how to delete a database completely
        '- from code.  It does not consider deleting the data from
        '- the tables nor dropping the tables -- it just zaps the
        '- database completely        
        '------------------------------------------------------------
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- strSQLCmd - STring contain sql commands
        '- DBCmd - SqlCommand that run the string
        '------------------------------------------------------------


        Dim strSQLCmd As String
        Dim DBCommand As SqlCommand

        'We need to point back at the [Master] database itself
        Dim DBConn As SqlConnection = New SqlConnection("Server=" & strSERVERNAME)

        'Try to force single ownership of the database so that we have the
        'permissions to delete it
        strSQLCmd = "ALTER DATABASE [" & strDBNAME & "] SET " &
                    "SINGLE_USER WITH ROLLBACK IMMEDIATE"

        DBCommand = New SqlCommand(strSQLCmd, DBConn)

        Try
            DBConn.Open()
            DBCommand.ExecuteNonQuery()
            MessageBox.Show("Database set for exclusive use", "",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try

        If (DBConn.State = ConnectionState.Open) Then
            DBConn.Close()
        End If

        'Now drop the database
        strSQLCmd = "DROP DATABASE " & strDBNAME
        DBCommand = New SqlCommand(strSQLCmd, DBConn)

        Try
            DBConn.Open()
            DBCommand.ExecuteNonQuery()
            MessageBox.Show("Database has been deleted", "", MessageBoxButtons.OK,
                            MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try

        If (DBConn.State = ConnectionState.Open) Then
            DBConn.Close()
        End If
    End Sub
End Module

