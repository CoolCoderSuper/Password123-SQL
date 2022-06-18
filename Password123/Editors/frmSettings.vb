Public Class frmSettings
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Dispose()
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
        Else
            MsgBox("Failed to change key reason:" & vbCrLf & "Keys in database corrupt!", MsgBoxStyle.Critical, "Encryption Error")
        End If
        Dim qGet As String = "select * from categories"
        Dim qUpdate As String = ""
        Dim intC As Integer = 0
        conn.executequery(qGet)
        If conn.hasexception(False) Then MsgBox("The key update failed with this error: " & vbCrLf & conn.exception, MsgBoxStyle.Critical, "Encryption Error") : Return
        For Each dr As DataRow In conn.dbdt.Rows
            conn.addparam("@name" & intC, EncryptTripleDES(DecryptTripleDES(dr("Name"), Key), strPass))
            qUpdate &= "update categories set name=@name" & intC & " where id='" & dr("Id") & "';"
            intC += 1
        Next
        conn.executequery(qUpdate)
        If conn.hasexception(False) Then MsgBox("The key update failed with this error: " & vbCrLf & conn.exception, MsgBoxStyle.Critical, "Error") : Return
        intC = 0
        qGet = "select * from entries"
        conn.executequery(qGet)
        For Each dr As DataRow In conn.dbdt.Rows
            conn.addparam("@name" & intC, EncryptTripleDES(DecryptTripleDES(dr("Name"), Key), strPass))
            conn.addparam("@username" & intC, EncryptTripleDES(DecryptTripleDES(dr("Username"), Key), strPass))
            conn.addparam("@password" & intC, EncryptTripleDES(DecryptTripleDES(dr("Password"), Key), strPass))
            conn.addparam("@notes" & intC, EncryptTripleDES(DecryptTripleDES(dr("Notes"), Key), strPass))
            qUpdate &= "update entries set name=@name" & intC & ",username=@username" & intC & ",password=@password" & intC & ",notes=@notes" & intC & " where id='" & dr("Id") & "';"
            intC += 1
        Next
        conn.executequery(qUpdate)
        If conn.hasexception(False) Then MsgBox("The key update failed with this error: " & vbCrLf & conn.exception, MsgBoxStyle.Critical, "Error") : Return
        qGet = "select * from settings where name='ENCSample'"
        conn.executequery(qGet)
        If conn.dbdt.Rows.Count <> 0 Then
            Dim strSample As String = conn.dbdt.Rows(0)("Value")
            conn.addparam("@sample", EncryptTripleDES(DecryptTripleDES(strSample, Key), strPass))
            qUpdate = "update settings value=@sample where name='ENCSample'"
            conn.executequery(qUpdate)
            If conn.hasexception(False) Then MsgBox("The key update failed with this error: " & vbCrLf & conn.exception, MsgBoxStyle.Critical, "Error") : Return
        Else
            MsgBox("The key update failed with this error: " & vbCrLf & "Failed to change get sample", MsgBoxStyle.Critical, "Error") : Return
        End If
        Key = strPass
    End Sub

    Private Sub tmrCheck_Tick(sender As Object, e As EventArgs) Handles tmrCheck.Tick
        If txtKey.Text.Trim = "" Then
            epError.SetError(txtKey, "Enter a key")
        Else
            epError.SetError(txtKey, "")
        End If
        btnOk.Enabled = Not txtKey.Text.Trim = ""
    End Sub

    Private Sub frmSettings_Load(sender As Object, e As EventArgs) Handles Me.Load
        tmrCheck.Start()
    End Sub
End Class