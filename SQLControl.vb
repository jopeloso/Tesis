Imports System.Data.SqlClient

Public Class SQLControl

    'Private DBCon As New SqlConnection("Server=DESKTOP-6DOE76A\SQLEXPRESS;database=tilt_test;User=admin;Pwd=arduino;")
    Private DBCon As New SqlConnection("Server= mal; Database= mal ; User= mal; Pwd= mal;")
    'Private DBCon As New SqlConnection("Server=DESKTOP-5TGQ5N8\SQLEXPRESS;database=tilt_test;User=admin;Pwd=arduino;")

    Private DBCmd As New SqlCommand

    'DB DATA
    Public DBDA As SqlDataAdapter
    Public DBDT As DataTable

    'query parameters
    Public Params As New List(Of SqlParameter)

    'query statistics
    Public Recordcount As Integer
    Public Exception As String


    Public Sub New()

    End Sub

    'antes no tenia el try
    Public Sub New(ConnectionString As String)
        Try
            DBCon = New SqlConnection(ConnectionString)
        Catch ex As Exception

        End Try


    End Sub

    'execute query sub
    Public Sub ExecQuery(Query As String)
        'reset query stats
        Recordcount = 0
        Exception = ""

        Try
            DBCon.Open()

            'Create DB COmmand
            DBCmd = New SqlCommand(Query, DBCon)

            'load params into the DB COMMAND

            Params.ForEach(Sub(p) DBCmd.Parameters.Add(p))

            'clear param list
            Params.Clear()

            'Execute command & fill dataset
            DBDT = New DataTable
            DBDA = New SqlDataAdapter(DBCmd)
            Recordcount = DBDA.Fill(DBDT)

        Catch ex As Exception
            'Capture error
            Exception = "ExecQuery Error:" & vbNewLine & ex.Message
        Finally
            'CLOSE CONNECTION   
            If DBCon.State = ConnectionState.Open Then DBCon.Close()

        End Try


    End Sub

    Public Sub AddParam(Name As String, Value As Object)
        Dim NewParam As New SqlParameter(Name, Value)
        Params.Add(NewParam)
    End Sub

    'Error checking
    Public Function HasException(Optional Report As Boolean = False) As Boolean
        If String.IsNullOrEmpty(Exception) Then Return False
        If Report = True Then MsgBox(Exception, MsgBoxStyle.Critical, "Exception:")
        Return True

    End Function


End Class
