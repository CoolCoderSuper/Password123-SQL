Public Class frmMain
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Application.Exit()
    End Sub

    Private Sub btnLock_Click(sender As Object, e As EventArgs) Handles btnLock.Click
        Dispose()
        frmLogin.ShowDialog()
    End Sub

    Private Sub btnNewCategory_Click(sender As Object, e As EventArgs) Handles btnNewCategory.Click
        frmCategory.ShowNew()
        LoadCategories()
    End Sub

    Private Sub btnEditCategory_Click(sender As Object, e As EventArgs) Handles btnEditCategory.Click
        Try
            frmCategory.ShowEdit(Integer.Parse(lstCategories.SelectedValue.ToString))
        Catch ex As Exception

        End Try
        LoadCategories()
    End Sub

    Private Sub btnDeleteCategory_Click(sender As Object, e As EventArgs) Handles btnDeleteCategory.Click
        Try
            Dim intId As Integer = Integer.Parse(lstCategories.SelectedValue.ToString)
            Dim q As String = "delete from categories where Id='" & intId & "'"
            conn.executequery(q)
            conn.hasexception(True)
        Catch ex As Exception

        End Try
        LoadCategories()
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadCategories()
    End Sub

    Private Sub LoadCategories()
        Dim qCategroies As String = "select * from categories"
        conn.executequery(qCategroies)
        For i As Integer = 0 To conn.dbdt.Rows.Count - 1
            conn.dbdt.Rows(i)("Name") = DecryptTripleDES(conn.dbdt.Rows(i)("Name"), Key)
        Next
        Dim drAll As DataRow = conn.dbdt.NewRow
        drAll("Id") = 0
        drAll("Name") = "All"
        conn.dbdt.Rows.InsertAt(drAll, 0)
        conn.dbdt.Rows.Add(-1, "No Category")
        lstCategories.DisplayMember = "Name"
        lstCategories.ValueMember = "Id"
        lstCategories.DataSource = conn.dbdt
    End Sub

    Private Sub btnNewEntry_Click(sender As Object, e As EventArgs) Handles btnNewEntry.Click
        frmEntry.ShowNew()
        LoadEntries(lstCategories.SelectedValue, txtSearchEntries.Text)
    End Sub

    Private Sub btnEditEntry_Click(sender As Object, e As EventArgs) Handles btnEditEntry.Click
        Try
            Dim intId As Integer = Integer.Parse(dgvEntries.SelectedRows(0).Cells(0).Value.ToString)
            frmEntry.ShowEdit(intId)
        Catch ex As Exception

        End Try
        LoadEntries(lstCategories.SelectedValue, txtSearchEntries.Text)
    End Sub

    Private Sub btnDeleteEntry_Click(sender As Object, e As EventArgs) Handles btnDeleteEntry.Click
        Try
            Dim intId As Integer = Integer.Parse(dgvEntries.SelectedRows(0).Cells(0).Value.ToString)
            Dim q As String = "delete from entries where Id='" & intId & "';delete from urls where entryid='" & intId & "';"
            conn.executequery(q)
            conn.hasexception(True)
        Catch ex As Exception

        End Try
        LoadEntries(lstCategories.SelectedValue, txtSearchEntries.Text)
    End Sub

    Private Sub btnCopyUser_Click(sender As Object, e As EventArgs) Handles btnCopyUser.Click
        Try
            Dim intId As Integer = Integer.Parse(dgvEntries.SelectedRows(0).Cells(0).Value.ToString)
            Dim q As String = "select * from entries where Id='" & intId & "';"
            conn.executequery(q)
            If conn.dbdt.Rows.Count = 0 Then
                MsgBox("Failed to get entry!", MsgBoxStyle.Critical, "Database Error")
            End If
            Clipboard.SetText(conn.dbdt.Rows(0)("Username"))
            conn.hasexception(True)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnCopyPassword_Click(sender As Object, e As EventArgs) Handles btnCopyPassword.Click
        Try
            Dim intId As Integer = Integer.Parse(dgvEntries.SelectedRows(0).Cells(0).Value.ToString)
            Dim q As String = "select * from entries where Id='" & intId & "';"
            conn.executequery(q)
            If conn.dbdt.Rows.Count = 0 Then
                MsgBox("Failed to get entry!", MsgBoxStyle.Critical, "Database Error")
            End If
            Clipboard.SetText(DecryptTripleDES(conn.dbdt.Rows(0)("Password"), Key))
            conn.hasexception(True)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtSearchEntries_TextChanged(sender As Object, e As EventArgs) Handles txtSearchEntries.TextChanged
        LoadEntries(lstCategories.SelectedValue, txtSearchEntries.Text)
    End Sub

    Private Sub lstCategories_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstCategories.SelectedIndexChanged
        LoadEntries(lstCategories.SelectedValue, txtSearchEntries.Text)
    End Sub

    Private Sub LoadEntries(intCategoryId As Integer, strSeacrh As String)
        conn.addparam("@search", "%" & strSeacrh & "%")
        Dim q As String
        If intCategoryId = 0 Then
            q = "select * from entries where Name like @search;"
        Else
            q = "select * from entries where CategoryId='" & intCategoryId & "' and Name like @search;"
        End If
        conn.executequery(q)
        If conn.hasexception(True) Then
            Exit Sub
        End If
        For i As Integer = 0 To conn.dbdt.Rows.Count - 1
            conn.dbdt.Rows(i)("Name") = DecryptTripleDES(conn.dbdt.Rows(i)("Name"), Key)
            conn.dbdt.Rows(i)("Username") = DecryptTripleDES(conn.dbdt.Rows(i)("Username"), Key)
            conn.dbdt.Rows(i)("Notes") = DecryptTripleDES(conn.dbdt.Rows(i)("Notes"), Key)
        Next
        dgvEntries.DataSource = conn.dbdt
        dgvEntries.Columns(0).Visible = False
        dgvEntries.Columns(3).Visible = False
        dgvEntries.Columns(6).Visible = False
    End Sub

    Private Sub btnSettings_Click(sender As Object, e As EventArgs) Handles btnSettings.Click
        frmSettings.ShowDialog()
    End Sub

    Private Sub frmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            Application.Exit()
        End If
    End Sub
End Class