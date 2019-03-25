Public Class Usuarios

    
    Private Sub Usuarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MdiParent = Form1
        Form1.Loadgrilla_usuarios()

        Me.Width = Form1.Width * 0.5
        ordenar_usuarios()

        Form1.ordenar_grillas_usuarios()
    End Sub




    Sub ordenar_usuarios()


        botonNuevoUsuario.Width = Me.Width * 0.3
        botoneditarUsuario.Width = botonNuevoUsuario.Width
        botoneliminarUsuario.Width = botonNuevoUsuario.Width

        botoneditarUsuario.Location = New Point(botonNuevoUsuario.Location.X + botonNuevoUsuario.Width + 15, botonNuevoUsuario.Location.Y)

        botoneliminarUsuario.Location = New Point(botoneditarUsuario.Location.X + botoneditarUsuario.Width + 15, botonNuevoUsuario.Location.Y)

        DGVUsuarios.Location = New Point(botonNuevoUsuario.Location.X, botonNuevoUsuario.Location.Y + botonNuevoUsuario.Height + 15)
        DGVUsuarios.Width = botoneliminarUsuario.Location.X + botoneliminarUsuario.Width - botonNuevoUsuario.Location.X
        DGVUsuarios.Height = Me.Height - 70 - DGVUsuarios.Location.Y

    End Sub

    Private Sub Usuarios_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.SendToBack()
        Form1.BringToFront()
        Form1.TabGeneral.BringToFront()
    End Sub

    Private Sub botonNuevoUsuario_Click(sender As Object, e As EventArgs) Handles botonNuevoUsuario.Click
        Dim usuario_nuevo As String = InputBox("Ingrese el nuevo nombre de usuario:", "Nuevo Usuario")

        If usuario_nuevo = "" Then
            Exit Sub
        End If

        Dim nivel_nuevo As Integer = 1
        Try
            nivel_nuevo = InputBox("Ingrese el nivel de acceso del nuevo usuario:", "Nuevo Usuario", "1")
        Catch ex As Exception
          
                'MsgBox("El nivel debe ser un entero entre 1 y 3!")
                Exit Sub
           
           
        End Try


        If Not IsNumeric(nivel_nuevo) Or nivel_nuevo > 3 Or nivel_nuevo < 1 Then

            MsgBox("El nivel debe ser un entero entre 1 y 3!")
            Exit Sub
        End If

        Dim contraseña_nuevo As String = InputBox("Ingrese la nueva contraseña:", "Nuevo Usuario")

        If contraseña_nuevo = "" Then
            Exit Sub
        End If

        Dim confirmada As String = InputBox("Confirme la nueva contraseña:", "Nuevo Usuario")

        If confirmada = "" Then
            Exit Sub
        End If

        If contraseña_nuevo = confirmada Then

            Form1.nuevo_usuario(usuario_nuevo, contraseña_nuevo, nivel_nuevo)

            Form1.Loadgrilla_usuarios()


        Else
            MsgBox("Las contraseñas ingresadas no coinciden!")
            Exit Sub

        End If


    End Sub

    Private Sub DGVUsuarios_MouseClick(sender As Object, e As MouseEventArgs) Handles DGVUsuarios.MouseClick

        botoneliminarUsuario.Enabled = True
        botoneditarUsuario.Enabled = True


    End Sub

    Private Sub botoneliminarUsuario_Click(sender As Object, e As EventArgs) Handles botoneliminarUsuario.Click

        Dim i As Integer
        Try
            i = DGVUsuarios.CurrentCell.RowIndex
        Catch ex As Exception
            MsgBox("No hay ningun usuario seleccionado!")
            Exit Sub
        End Try

        Form1.eliminar_usuario()
        Form1.Loadgrilla_usuarios()

    End Sub

    Private Sub botoneditarUsuario_Click(sender As Object, e As EventArgs) Handles botoneditarUsuario.Click

        Dim i As Integer
        Try
            i = DGVUsuarios.CurrentCell.RowIndex
        Catch ex As Exception
            MsgBox("No hay ningun usuario seleccionado!")
            Exit Sub
        End Try

        Form1.editar_usuario()
        Form1.Loadgrilla_usuarios()
    End Sub
End Class