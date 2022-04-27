Public Class clsStudent
    '------------------------------------------------------------
    '-                File Name : clsStudent.vb                   - 
    '-                Part of Project: StudentOOP            -
    '------------------------------------------------------------
    '-                Written By: Binh D. Dang                  -
    '-                Written On: April 7th, 2022            -
    '------------------------------------------------------------
    '- File Purpose:                                            -                                             -
    '- This file contains the student object class
    '------------------------------------------------------------
    '- Program Purpose:                                         -
    '- The purpose of this program is showing the Student object class
    '-having a constructor and getters and setters for each purpose
    '------------------------------------------------------------
    Private strFirstandMiddleIni As String
    Private strLast As String
    Private arrAssignment(4) As Single
    Private dblExam As Double
    'constructor for student 
    Public Sub New(ByVal FirstandMiddleInitial As String, ByVal LastName As String,
                   ByVal newArrAssignment As Single(), ByVal Exam As Double)
        strFirstandMiddleIni = FirstandMiddleInitial
        strLast = LastName
        arrAssignment = newArrAssignment
        dblExam = Exam
    End Sub

    'getter and setters 
    Public Property FirstandMiddleIni As String
        Get
            Return strFirstandMiddleIni
        End Get
        Set(value As String)
            strFirstandMiddleIni = value
        End Set
    End Property
    Public Property Last As String
        Get
            Return strLast
        End Get
        Set(value As String)
            strLast = value
        End Set
    End Property
    Public Property Assignments As Single()
        Get
            Return arrAssignment
        End Get
        Set(value As Single())
            arrAssignment = value
        End Set
    End Property
    Public Property Exam As Double
        Get
            Return dblExam
        End Get
        Set(value As Double)
            dblExam = value
        End Set
    End Property
End Class
