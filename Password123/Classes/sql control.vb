Imports System.Data.SqlClient
Public Class sql_control
    Private dbcon As New SqlConnection("server=CCH\CODINGCOOL;Database=Password123;User=sa;Pwd=k458wstm;")
    Private dbcmd As SqlCommand
    '*****************************
    Public dbda As SqlDataAdapter
    Public dbdt As DataTable
    '*****************************
    Public params As New List(Of SqlParameter)
    '******************************************
    Public recordcount As Integer
    Public exception As String
    Public Sub New()
    End Sub
    '******************************
    Public Sub New(connectionstring As String)
        dbcon = New SqlConnection(connectionstring)
    End Sub
    '***********************************************
    Public Sub executequery(query As String)
        recordcount = 0
        exception = ""

        Try
            dbcon.Open()
            dbcmd = New SqlCommand(query, dbcon)
            params.ForEach(Sub(p) dbcmd.Parameters.Add(p))
            params.Clear()
            dbdt = New DataTable
            dbda = New SqlDataAdapter(dbcmd)
            recordcount = dbda.Fill(dbdt)
        Catch ex As Exception
            exception = "Error: " & vbNewLine & ex.Message
        Finally
            If dbcon.State = ConnectionState.Open Then dbcon.Close()
        End Try
    End Sub
    '*************************************************************************
    Public Sub addparam(name As String, value As Object)
        Dim newparam As New SqlParameter(name, value)
        params.Add(newparam)
    End Sub
    Public Function hasexception(Optional report As Boolean = False) As Boolean
        If String.IsNullOrEmpty(exception) Then Return False
        If report = True Then MsgBox(exception, MsgBoxStyle.Critical, "DATABASE ERROR")
        Return True
    End Function
End Class
