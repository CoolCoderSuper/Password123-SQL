Imports System.Text.RegularExpressions

Public Class frmIconChooser

    Public Overloads Sub Show(lUrls As String())
        Dim objGetter As New IconChooser
        For Each strURL As String In lUrls
            For Each i As Image In objGetter.Load(GetURL(strURL))
                lImages.Images.Add(i)
            Next
        Next
        lvImages.LargeImageList = lImages
        For i As Integer = 0 To lImages.Images.Count - 1
            lvImages.Items.Add(New ListViewItem With {.ImageIndex = i})
        Next
        ShowDialog()
    End Sub

    Private Function GetURL(url As String) As String
        If Not Regex.IsMatch(url, "(?i)\b(http:\/\/|https:\/\/|file:\/\/\/)\b") Then
            Using client As Net.WebClient = New Net.WebClient
                Try
                    client.DownloadData($"https://{url}")
                    Return $"https://{url}"
                Catch ex As Exception
                    Return $"http://{url}"
                End Try
            End Using
        Else
            Return url
        End If
    End Function

End Class