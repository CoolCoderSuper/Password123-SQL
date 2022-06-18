Imports HtmlAgilityPack
Imports System.IO

Public Class IconChooser

    'TODO: Relative urls in html
    Public Function Load(strURL As String) As Image()
        Dim lImages As New List(Of Image)
        Dim doc As New HtmlDocument
        Using client As New Net.WebClient
            doc.LoadHtml(client.DownloadString(strURL))
        End Using
        For Each node As HtmlNode In doc.DocumentNode.SelectNodes("//link").ToArray()
            Dim attr As HtmlAttribute = node.Attributes.Where(Function(x) x.Name = "rel").FirstOrDefault()
            If attr IsNot Nothing AndAlso (attr.Value = "icon" OrElse attr.Value = "shortcut icon" OrElse attr.Value = "apple-touch-icon" OrElse attr.Value = "apple-touch-icon-precomposed") Then
                Dim href As HtmlAttribute = node.Attributes.Where(Function(x) x.Name = "href").FirstOrDefault()
                Using client As New Net.WebClient
                    lImages.Add(Image.FromStream(New MemoryStream(client.DownloadData(href.Value))))
                End Using
            End If
        Next
        Return lImages.ToArray()
    End Function

    Private Function GetURL(url As String)

    End Function

End Class