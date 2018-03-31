Public Class Form1
    Dim Score, LevelCount, OverallScore, ClickCounter, Timeaddon As Integer
    Dim Rand As New Random()
    Dim Speed As Integer = 10
    Public Sub Reset()
        ClickCounter = 0
        Label1.Visible = False
        Score = 0
        LevelCount = 0
        OverallScore = 0
        Speed = 10
        OvalShape1.Location = New System.Drawing.Point(106, 12)
        OvalShape1.Size = New System.Drawing.Point(75, 75)
        OvalShape1.FillColor() = Color.Red
        Panel1.Size = New System.Drawing.Point(18, Me.Size.Height / 2)
        Me.Text = "Level: " & LevelCount / 10 & ". Score: " & OverallScore
        MessageBox.Show("Go!", "Go!")
        OvalShape1.Visible = True
        Timer1.Start()
    End Sub

    Public Sub Pause()
        Timer1.Stop()
        Timer1.Enabled = False
        Label1.Visible = True
        Label1.Text = "Paused" & vbCrLf & "(click to continue)"
        OvalShape1.Visible = False
        Label1.Location = New System.Drawing.Point(Math.Ceiling((Me.Width / 2) - Label1.Width / 2), Math.Ceiling((Me.Height / 2) - Label1.Height / 2))
        Panel2.Size = New System.Drawing.Point(Me.Size.Width, Me.Size.Height)
        OvalShape1.Location = New System.Drawing.Point(Rand.Next(Convert.ToInt16(Panel2.Size.Width - (Panel2.Size.Width / 5))), Rand.Next(Convert.ToInt16(Panel2.Size.Height - (Panel2.Size.Height / 5))))
    End Sub
    Private Sub OvalShape1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OvalShape1.Click
        Dim Colour As Integer
        ClickCounter = ClickCounter + 1
        Timer1.Start()
        OvalShape1.Location = New System.Drawing.Point(Rand.Next(Convert.ToInt16(Panel2.Size.Width - (Panel2.Size.Width / 5))), Rand.Next(Convert.ToInt16(Panel2.Size.Height - (Panel2.Size.Height / 5))))
        OvalShape1.Size = New System.Drawing.Point(Rand.Next(10, 100), OvalShape1.Size.Width)
        OvalShape1.Size = New System.Drawing.Point(OvalShape1.Size.Width, OvalShape1.Size.Width)
        Colour = Rand.Next(1, 8)
        Select Case Colour
            Case 1
                OvalShape1.FillColor() = Color.Blue
            Case 2
                OvalShape1.FillColor() = Color.Red
            Case 3
                OvalShape1.FillColor() = Color.Yellow
            Case 4
                OvalShape1.FillColor() = Color.Green
            Case 5
                OvalShape1.FillColor() = Color.Orange
            Case 6
                OvalShape1.FillColor() = Color.Purple
            Case 7
                OvalShape1.FillColor() = Color.White
            Case 8
                OvalShape1.FillColor() = Color.Cyan
        End Select

        Select Case OvalShape1.Size.Width
            Case 10 To 19
                Score = 100
            Case 20 To 29
                Score = 90
            Case 30 To 39
                Score = 80
            Case 40 To 49
                Score = 70
            Case 50 To 59
                Score = 60
            Case 60 To 69
                Score = 50
            Case 70 To 79
                Score = 40
            Case 80 To 89
                Score = 30
            Case 90 To 99
                Score = 20
            Case 100
                Score = 10
        End Select

        Panel1.Size = New System.Drawing.Point(Panel1.Size.Width, Panel1.Size.Height + (OvalShape1.Size.Width + Score))
        LevelCount = LevelCount + 1
        Timeaddon = Timeaddon + (Score * (LevelCount / 100))
        Select Case ClickCounter
            Case 10
                OvalShape1.Visible = False
                Label1.Text = "Level " & Math.Ceiling(LevelCount / 10)
                Label1.Visible = True
                Timer1.Stop()
                Timer1.Enabled = False
                Speed = Speed + 2
                Panel1.Size = New System.Drawing.Point(18, Panel1.Height + Timeaddon)
                MessageBox.Show("Level " & Math.Ceiling(LevelCount / 10) & ", Time added (+" & Timeaddon & ")", "New Level")
                ClickCounter = 0
                Timeaddon = 0
        End Select
        If Timer1.Enabled = False Then
            Label1.Visible = False
            OvalShape1.Visible = True
            Timer1.Enabled = True
            Timer1.Start()
        End If
        OverallScore = OverallScore + Score
        Me.Text = "Level: " & Math.Floor(LevelCount / 10) & ". Score: " & OverallScore
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Panel1.Size = New System.Drawing.Point(Panel1.Size.Width, Panel1.Size.Height - Speed)
        Label2.Text = Panel1.Height
        If Panel1.Size.Height = 0 Then
            Timer1.Stop()
            Label1.Text = "Game Over!"
            Label1.Visible = True
            OvalShape1.Visible = False
            If MessageBox.Show("Game Over!" & vbCrLf & "Level " & Math.Floor(LevelCount / 10) & vbCrLf & "Score: " & OverallScore & vbCrLf & "Number of circles clicked: " & LevelCount & vbCrLf & "New Game?", "Game Over!", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                Reset()
            Else
                End
            End If
        End If
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Show()
        Panel1.Size = New System.Drawing.Point(18, Me.Size.Height / 2)
        Label1.Location = New System.Drawing.Point(Math.Ceiling((Panel2.Size.Width / 2) - Label1.Size.Width / 2), Math.Ceiling((Panel2.Size.Height / 2) - Label1.Size.Height / 2))
        Reset()
    End Sub

    Private Sub Form1_Move(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Move
        Pause()
    End Sub

    Private Sub Form1_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SizeChanged
        Pause()
    End Sub

    Private Sub Panel2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Panel2.Click
        If Timer1.Enabled = False Then
            Label1.Visible = False
            OvalShape1.Visible = True
            Timer1.Enabled = True
            Timer1.Start()
        End If
    End Sub

    Private Sub Label1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label1.Click
        If Timer1.Enabled = False Then
            Label1.Visible = False
            OvalShape1.Visible = True
            Timer1.Enabled = True
            Timer1.Start()
        End If
    End Sub
End Class
