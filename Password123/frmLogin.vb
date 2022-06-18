Public Class frmLogin
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Application.Exit()
    End Sub

    Private Sub frmLogin_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            Application.Exit()
        End If
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        Dim strPass As String = txtKey.Text
        Dim lKeys As List(Of String) = GetKeys()
        Dim r As Random = GetRandom()
        If lKeys.Where(Function(x) x.Trim = "").Count = 0 And r IsNot Nothing Then
            lKeys.ForEach(Sub(x) strPass &= x)
            Dim list = New SortedList(Of Integer, Char)()
            For Each c In strPass
                list.Add(r.[Next](), c)
            Next
            strPass = list.Values.ToArray
            Try
                Dim strSample As String = GetSampleStringENC.Trim
                If Not strSample = "" Then
                    Dim strValue As String = DecryptTripleDES(strSample, strPass)
                    If Not strValue = GetSampleString() Then
                        MsgBox("Failed to unlock:" & vbCrLf & "Either database is corrupt or enterd key is wrong!", MsgBoxStyle.Critical, "Encryption Error")
                    Else
                        Key = strPass
                        frmMain.Show()
                        Dispose()
                    End If
                End If
            Catch ex As Exception
                MsgBox("Failed to unlock:" & vbCrLf & "Either database is corrupt or enterd key is wrong!", MsgBoxStyle.Critical, "Encryption Error")
            End Try
        Else
            MsgBox("Failed to generate key reason:" & vbCrLf & "Keys in database corrupt!", MsgBoxStyle.Critical, "Encryption Error")
        End If
    End Sub

    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tmrCheck.Start()
    End Sub

    Private Sub tmrCheck_Tick(sender As Object, e As EventArgs) Handles tmrCheck.Tick
        If txtKey.Text.Trim = "" Then
            epError.SetError(txtKey, "Enter a key")
        Else
            epError.SetError(txtKey, "")
        End If
        btnOk.Enabled = Not txtKey.Text.Trim = ""
    End Sub
End Class