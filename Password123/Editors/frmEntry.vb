Public Class frmEntry
    Dim intId As Integer
    Dim bEdit As Boolean = False

    Public Sub ShowNew()
        Text = "New Entry"
        LoadCategories()
        Dim q As String = "select Id from entries where Id=(select max(Id) from entries);"
        conn.executequery(q)
        Try
            intId = Integer.Parse(conn.dbdt.Rows(0)("Id").ToString) + 1
        Catch ex As Exception
            intId = 1
        End Try
        tmrCheck.Start()
        ShowDialog()
    End Sub

    Public Sub ShowEdit(intId As Integer)
        Me.intId = intId
        bEdit = True
        Text = "Edit Entry"
        LoadCategories()
        Dim qEntry As String = "select * from entries where Id='" & intId & "';"
        conn.executequery(qEntry)
        If conn.hasexception(True) Then
            Exit Sub
        End If
        If conn.dbdt.Rows.Count = 0 Then
            MsgBox("Failed to get item.", MsgBoxStyle.Critical, "DATABASE ERROR")
            Exit Sub
        End If
        Dim dr As DataRow = conn.dbdt.Rows(0)
        txtName.Text = dr("Name")
        txtUsername.Text = dr("Username")
        txtPassword.Text = DecryptTripleDES(dr("Password"), Key)
        chFavourite.Checked = dr("Favourite")
        txtNotes.Text = dr("Notes")
        cbxCategory.SelectedValue = dr("CategoryId")
        Dim qURLs As String = "select * from urls where EntryId='" & intId & "'"
        conn.executequery(qURLs)
        For Each drURL As DataRow In conn.dbdt.Rows
            lvURLs.Items.Add(drURL("URL"))
        Next
        tmrCheck.Start()
        ShowDialog()
    End Sub

    Private Sub Save()
        conn.addparam("@name", txtName.Text)
        conn.addparam("@username", txtUsername.Text)
        conn.addparam("@password", EncryptTripleDES(txtPassword.Text, Key))
        conn.addparam("@fav", chFavourite.Checked)
        conn.addparam("@notes", txtNotes.Text)
        conn.addparam("@categoryid", cbxCategory.SelectedValue)
        If bEdit Then
            Dim q1 As String = "update entries set Name=@name,Username=@username,Password=@password,Favourite=@fav,Notes=@notes,CategoryId=@categoryid where Id='" & intId & "';"
            conn.executequery(q1)
        Else
            Dim q1 As String = "insert into entries(Name,Username,Password,Favourite,Notes,CategoryId) Values(@name,@username,@password,@fav,@notes,@categoryid);"
            conn.executequery(q1)
        End If
        If conn.hasexception(True) Then
            Exit Sub
        End If
        conn.executequery("delete from urls where EntryId='" & intId & "';")
        If conn.hasexception(True) Then
            Exit Sub
        End If
        Dim q As String = ""
        Dim c As Integer = 0
        For Each item As ListViewItem In lvURLs.Items
            conn.addparam("@url" & c, item.Text)
            q &= "insert into urls(Url,EntryId) Values(@url" & c & ",'" & intId & "');"
            c += 1
        Next
        If Not q = "" Then
            conn.executequery(q)
        End If
        If conn.hasexception(True) Then
            Exit Sub
        End If
    End Sub

    Private Sub LoadCategories()
        Dim q As String = "select * from categories"
        conn.executequery(q)
        conn.dbdt.Rows.Add(-1, "No Category")
        cbxCategory.DataSource = conn.dbdt
        cbxCategory.DisplayMember = "Name"
        cbxCategory.ValueMember = "Id"
        cbxCategory.SelectedIndex = 0
    End Sub

    Private Sub chPWD_CheckedChanged(sender As Object, e As EventArgs) Handles chPWD.CheckedChanged
        txtPassword.UseSystemPasswordChar = Not chPWD.Checked
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        lvURLs.Items.Add("")
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            lvURLs.Items.Remove(lvURLs.SelectedItems(0))
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        Save()
        Dispose()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Dispose()
    End Sub

    Private Sub tmrCheck_Tick(sender As Object, e As EventArgs) Handles tmrCheck.Tick
        If txtName.Text.Trim = "" Then
            epError.SetError(txtName, "Enter a name")
        Else
            epError.SetError(txtName, "")
        End If
        btnOk.Enabled = Not txtName.Text.Trim = ""
    End Sub

End Class