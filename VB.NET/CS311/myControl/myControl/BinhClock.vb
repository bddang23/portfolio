
Public Class BinhClock
    '------------------------------------------------------------
    '-                File Name : BinhColor.vb                   - 
    '-                Part of Project: BinhCLock            -
    '------------------------------------------------------------
    '-                Written By: Binh D. Dang                  -
    '-                Written On: April 12th, 2022            -
    '------------------------------------------------------------
    '- File Purpose:                                            -                                             -
    '- This file contains a property that neccessary for Coorddinated Universal Time Timeclock
    '- control (DLL) that can be used in other places
    '------------------------------------------------------------
    '- Program Purpose:                                         -
    '- The purpose of this program is to create a personal control (DLL) 
    '- to use in other application
    '------------------------------------------------------------

    'the base color usinbg for the box that have MVBoli Font - size 12 - regular font
    Dim MVBoliFont As New Font("MV Boli", 12, FontStyle.Regular)
    Dim myBrush As New SolidBrush(Color.Black)
    Dim CurrentforeColor As Color = Color.CadetBlue

    'Override the getter and setter of ForeCOlor and font
    Public Overrides Property ForeColor As Color
        Get
            Return CurrentforeColor
        End Get
        Set(value As Color)
            CurrentforeColor = value
            Me.Invalidate()
        End Set
    End Property

    Public Overrides Property Font As Font
        Get
            Return MVBoliFont
        End Get
        Set(value As Font)
            MVBoliFont = value
            Me.Invalidate()
        End Set
    End Property

    Private Sub Timer_Tick(sender As Object, e As EventArgs) Handles Timer.Tick
        '------------------------------------------------------------
        '-            Subprogram Name: Timer_Tick  -
        '------------------------------------------------------------
        '-                Written By: Binh Dang                -
        '-                Written On: April 13, 2022              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine make sure every time the timer ticks, refresh the control's context, 
        'which in effect will force the time to be updated since
        '------------------------------------------------------------
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (None)                                                   -
        '------------------------------------------------------------
        Me.Refresh() ' regresh painter
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        '------------------------------------------------------------
        '-            Subprogram Name: OnPaint  -
        '------------------------------------------------------------
        '-                Written By: Binh Dang                -
        '-                Written On: January 25, 2022              -
        '------------------------------------------------------------
        '- Subprogram Purpose:                                      -
        '-                                                          -
        '- This subroutine overrides onPaint function
        '------------------------------------------------------------
        '------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):              -
        '- (myGfx) - Graphics as a context for control                -
        '------------------------------------------------------------
        'e.Graphics is the graphics context for the control
        Dim myGfx As Graphics = e.Graphics

        'Set the brush to whatever the current foreground color is
        myBrush.Color = CurrentforeColor

        'Print the time out
        myGfx.DrawString(DateTime.UtcNow.ToString, MVBoliFont, myBrush, 10, 10)

    End Sub

End Class
