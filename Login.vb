Imports System.IO 'IN OUT
Imports System.Data.SqlClient ' CLIENTE SQL PARA CONEXIO A BASE DE DATOS
Imports System.Net.Sockets ' COMUNICACION ARDUINO


Imports System.Net
'Imports System.Net.Sockets  
Imports System.Threading  
Imports System.Text

Public Class Login

    'Private SQL As New SQLControl(Form1.aux_conexion_sql)
    Dim direccion_txt As String = My.Application.Info.DirectoryPath ' aca guardo la dirección de la carpeta donde corre la aplicación
    Dim aux_sql As Array = File.ReadAllLines(direccion_txt & "\conexionsql.txt")
    Public aux_conexion_sql As String = aux_sql(0)
    'Dim aux_conexion_sql As String = ""


    'DECLARO MI OBJETO QUE SERA MI CONEXION A LA BASE DE DATOS 

    ' lo declaro en el form load si no tengo txt que tenga conexion 
    'Public SQL As New SQLControl


    'asi estaba antes
    Public SQL As New SQLControl '(aux_conexion_sql)

    Dim estado_login As Boolean = False
    Public nivel_login As Integer = 0

    Dim resultado As Boolean = False

    Dim cliente As New System.Net.Sockets.TcpClient()

    Public tmr As System.Threading.Timer

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'MdiParent = Form1

        Dim aux_sql As Array = File.ReadAllLines(direccion_txt & "\conexionSQL.txt")
        aux_conexion_sql = aux_sql(0)

        Try
            ' Dim SQL As New SqlConnection(aux_conexion_sql)
            SQL = New SQLControl(aux_conexion_sql)
            'Dim SQL As New SqlConnection
        Catch ex As SqlException
            'Dim SQL As New SqlConnection
            MsgBox("NO se pudo conectar al servidor SQL!")
        End Try

        cargar_usuarios()

       
    End Sub

    Private Sub Login_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing



    End Sub


  
    Private Sub botonAceptarPass_Click(sender As Object, e As EventArgs) Handles botonAceptarPass.Click

        resultado = chequear_login()

        If resultado = True Then
            'Me.SendToBack()

            ''RaiseEvent Load(Form1)
            ''Form1.Load()
            'Form1.Show()
            'Form1.BringToFront()
            'Form1.TabGeneral.BringToFront()

            Me.Close()
        End If

    End Sub

    Sub cargar_usuarios()


        SQL.ExecQuery("SELECT * FROM Usuarios;")

        If SQL.HasException(True) Then Exit Sub
        DGVLogin.DataSource = SQL.DBDT

    End Sub

    Function chequear_login()

        For i As Integer = 0 To DGVLogin.RowCount - 1

            Dim puto As String = DGVLogin.Item(1, i).Value.ToString.Trim()
            puto = DGVLogin.Item(2, i).Value.ToString.Trim()

            If txtUsuario.Text = DGVLogin.Item(1, i).Value.ToString.Trim() Then

                If txtContraseña.Text = DGVLogin.Item(2, i).Value.ToString.Trim() Then

                    estado_login = True
                    nivel_login = DGVLogin.Item(3, i).Value

                    Return True
                Else
                    'LabelFallo.Text = "Usuario o contraseña incorrecta"
                    'Return False
                End If

            Else
                'LabelFallo.Text = "Usuario o contraseña incorrecta"
                'Return False

            End If
        Next
        LabelFallo.Text = "Usuario o contraseña incorrecta"
        Return False

    End Function



    Private Sub Login_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        If resultado = True Then

            Me.SendToBack()

            ''RaiseEvent Load(Form1)
            ''Form1.Load()
            Form1.Show()
            Form1.BringToFront()
            Form1.TabGeneral.BringToFront()

            Form1.nivel_login = nivel_login

            ' Form1.login_exitoso()
        End If

        If resultado = False Then


        End If
    End Sub

    Private Sub botonCancelarPass_Click(sender As Object, e As EventArgs) Handles botonCancelarPass.Click
        resultado = False
        Me.Close()
    End Sub


End Class