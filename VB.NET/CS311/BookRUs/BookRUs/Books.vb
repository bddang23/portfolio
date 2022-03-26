Public Class clsBooks
    '------------------------------------------------------------
    '-            Class Name: clsBook  -
    '------------------------------------------------------------
    '-                Written By: Binh Dang                -
    '-                Written On: Feb 25, 2022              -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This class only includes the property for the class
    '- and the constructor that take in the array then distributed the data
    '------------------------------------------------------------
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):
    '- strCategory - a string contain the category
    '  intQuantity - how many books left in storage
    '  sngPrice - price of one unit book
    '  strTitle - _Title of book
    '  sngInventoryTotal - Total value of the book in inventory
    '------------------------------------------------------------
    Public Property strCategory As String
    Public Property intQuantity As Integer
    Public Property sngPrice As Single
    Public Property strTitle As String
    Public Property sngInventoryTotal As Single

    'default constructor take in array of string
    'seperate the first 3 to category,quatity and price, the rest is title
    Public Sub New(ByRef info() As String)
        strCategory = info(0)
        intQuantity = CInt(info(1))
        sngPrice = CSng(info(2))
        Dim i As Integer
        For i = 3 To info.Length - 1
            strTitle += info(i) + " "
        Next

        'using the price and quantity for the inventory total
        sngInventoryTotal = sngPrice * intQuantity
    End Sub

End Class
