Public Class CharacterMessage
    Private ReadOnly mood As Mood
    Private ReadOnly text As String
    Sub New(mood As Mood, text As String)
        Me.mood = mood
        Me.text = text
    End Sub
    Function GetMood() As Mood
        Return mood
    End Function
    Function GetText() As String
        Return text
    End Function
End Class
