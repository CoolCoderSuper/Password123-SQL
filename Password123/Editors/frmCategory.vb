Public Class frmCategory
    Dim intId As Integer
    Dim bEdit As Boolean = False

    Public Sub ShowNew()
        Text = "New Category"
        tmrCheck.Start()
        ShowDialog()
    End Sub

    Public Sub ShowEdit(intId As Integer)
        Me.intId = intId
        bEdit = True
        Text = "Edit Category"
        Dim q As String = "select * from categories where Id='" & intId & "'"
        conn.executequery(q)
        If conn.hasexception(True) Then
            Exit Sub
        End If
        If conn.dbdt.Rows.Count = 0 Then
            MsgBox("Failed to get item.", MsgBoxStyle.Critical, "Database Error")
            Exit Sub
        End If
        Dim dr As DataRow = conn.dbdt.Rows(0)
        txtName.Text = DecryptTripleDES(dr("Name"), Key)
        ShowDialog()
    End Sub

    Private Sub Save()
        conn.addparam("@name", EncryptTripleDES(txtName.Text, Key))
        If bEdit Then
            Dim q As String = "update categories set Name=@name where Id='" & intId & "';"
            conn.executequery(q)
        Else
            Dim q As String = "insert into categories(Name) Values(@name);"
            conn.executequery(q)
        End If
        conn.hasexception(True)
    End Sub

    Private Sub tmrCheck_Tick(sender As Object, e As EventArgs) Handles tmrCheck.Tick
        If txtName.Text.Trim = "" Then
            epError.SetError(txtName, "Enter a name")
        Else
            epError.SetError(txtName, "")
        End If
        btnOk.Enabled = Not txtName.Text.Trim = ""
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        Save()
        Dispose()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Dispose()
    End Sub

End Class