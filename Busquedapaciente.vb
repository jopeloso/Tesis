Public Class Busquedapaciente

    Private SQL As New SQLControl

    Private Sub Busquedapaciente_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        MdiParent = Form1

        Me.Width = Form1.screenWidth * 0.6
        Me.Height = Form1.screenHeight * 0.6



        ordenar_buscar_paciente()
        'ordenar_buscar_paciente()
        'ordenar_buscar_paciente()
        'ordenar_buscar_paciente()

        Me.StartPosition = FormStartPosition.CenterScreen

        Me.Location = New Point(Form1.screenWidth * 0.2, Form1.screenHeight * 0.2)

    End Sub


    Private Sub botonbuscarpaciente_Click(sender As Object, e As EventArgs) Handles botonbuscarpaciente.Click
        Form1.Buscarpersonal(txtbuscarpaciente, "Pacientes", DGVpacientes)

        ordenar_grilla_paciente()

    End Sub


    Private Sub Busquedapaciente_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed

        If Form1.ventana_inicial = True Then

            'si no se eligio ningun paciente vuelvo a la ventana inicial
            Form1.GO_Inicio()
            'Form1.Esconder_Datos()
        End If
        Form1.Ordenar_TODO()
        Me.SendToBack()
        Form1.BringToFront()
        Form1.TabGeneral.BringToFront()

        'Form1.TabPersonales.BackgroundImage = New Bitmap(Form1.direccion_txt & "\fondo3.png")

    End Sub

    Private Sub botonseleccionarpaciente_Click(sender As Object, e As EventArgs) Handles botonseleccionarpaciente.Click
        Try
            Dim i As Integer = DGVpacientes.CurrentCell.RowIndex
            Form1.TextNombre.Text = DGVpacientes.Item(1, i).Value.ToString().Trim()
            Form1.TextApellido.Text = DGVpacientes.Item(2, i).Value.ToString().Trim()
            Form1.TextEdad.Text = DGVpacientes.Item(3, i).Value.ToString().Trim()
            Form1.TextDomicilio.Text = DGVpacientes.Item(4, i).Value.ToString().Trim()
            Form1.TextTelefono.Text = DGVpacientes.Item(5, i).Value.ToString().Trim()

            Dim algo As Boolean = DGVpacientes.Item(6, i).Value
            Dim algoo As String = DGVpacientes.Item(6, i).Value

            If DGVpacientes.Item(6, i).Value = True Then Form1.botonMsexo.Checked = True

            If DGVpacientes.Item(6, i).Value = False Then Form1.botonFsexo.Checked = True

            Form1.TextDNI.Text = DGVpacientes.Item(0, i).Value.ToString().Trim()

            Me.SendToBack()
            Form1.BringToFront()
            Form1.TabGeneral.BringToFront()

            Form1.paciente_ingresado = True


            If Form1.paciente_ingresado = True Then
                Form1.GO_PacienteViejo()
            End If

        Catch ex As Exception
            MsgBox("No hay ningun paciente seleccionado!")

            Exit Sub
        End Try

        'ya contemplado en la sub GO_pacienteviejo
        'Form1.ventana_inicial = False
        'Form1.estado_datos = True
        Me.Close()
    End Sub

    Private Sub botoneliminarpaciente_Click(sender As Object, e As EventArgs) Handles botoneliminarpaciente.Click
        'Try


        'Dim i As Integer = DGVpacientes.CurrentCell.RowIndex
        '    Dim dni As Integer = DGVpacientes.Item(0, i).Value
        '    Dim nombre As String = DGVpacientes.Item(1, i).Value.ToString
        '    Dim apellido As String = DGVpacientes.Item(2, i).Value.ToString

        '    SQL.AddParam("@dnipaciente", dni)
        '    SQL.ExecQuery("SELECT * from Examen  WHERE DNIPaciente= @dnipaciente;")
        'If SQL.HasException(True) Then Exit Sub

        'If SQL.DBDT.Rows.Count <> 0 Then

        '    MsgBox("No se puede eliminar al paciente seleccionado ya que esta asociado a un examen en la base de datos", MsgBoxStyle.Information, "Error")

        '    Exit Sub
        'End If

        '    SQL.AddParam("@dnipaciente", dni)
        ''Borrar_Campo(txtNombreMandante, txtApellidoMandante, DGVmedicosman, "Mandantes", cbxMandante)
        'If MsgBox("Esta seguro que quiere borrar el siguiente campo?" & vbCrLf & _
        '           "Nombre: " & nombre & vbCrLf & _
        '           "Apellido: " & apellido, MsgBoxStyle.YesNo, "title") = MsgBoxResult.Yes Then




        '        SQL.ExecQuery("DELETE  from  Pacientes WHERE DNI= @dnipaciente;")

        '    If SQL.HasException(True) Then Exit Sub



        'End If



        'Form1.Loadgrilla("Pacientes", DGVpacientes)

        'Catch ex As Exception
        '    MsgBox("No hay ningun paciente seleccionado!")
        'End Try

        Form1.eliminar_paciente()

    End Sub

    Private Sub DGVpacientes_Click(sender As Object, e As EventArgs) Handles DGVpacientes.Click
        'botoneliminarpaciente.Enabled = True
    End Sub

   

    Sub ordenar_buscar_paciente()

        '0.266
        ' botonbuscarexamen.Width = Me.Width * 0.2 * 1.33

        LabelTituloBuscarPaciente.Location = New Point(txtbuscarpaciente.Location.X, 5)

        txtbuscarpaciente.Location = New Point(txtbuscarpaciente.Location.X, LabelTituloBuscarPaciente.Location.Y + LabelTituloBuscarPaciente.Height + 5)

        'botonbuscarexamen.Width = Me.Width * 0.2902

        'botonseleccionarexamen.Width = botonbuscarexamen.Width
        'botoneliminarexamen.Width = botonbuscarexamen.Width

        'botonbuscarexamen.Location = New Point(txtbuscarexamen.Location.X, txtbuscarexamen.Location.Y + txtbuscarexamen.Height + 5)
        'botonseleccionarexamen.Location = New Point(botonbuscarexamen.Location.X + botonbuscarexamen.Width + 25, txtbuscarexamen.Location.Y + txtbuscarexamen.Height + 5)
        'botoneliminarexamen.Location = New Point(botonseleccionarexamen.Location.X + botonseleccionarexamen.Width + 25, txtbuscarexamen.Location.Y + txtbuscarexamen.Height + 5)





        ' txtbuscarexamen.Width = botoneliminarexamen.Location.X + botoneliminarexamen.Width - botonbuscarexamen.Location.X

        ' DGVexamen.Width = Me.Width * 0.7
        '  DGVexamen.Width = txtbuscarexamen.Width

        'DGVexamen.Location = New Point(txtbuscarexamen.Location.X, botonbuscarexamen.Location.Y + botonbuscarexamen.Height + 5)

        '' antes estaba puesto en 0,7
        '' DGVexamen.Height = Me.Height * 0.7
        'DGVexamen.Height = Me.Height - 50 - DGVexamen.Location.Y

        'DGVexamen.Location = New Point(txtbuscarexamen.Location.X, botonbuscarexamen.Location.Y + botonbuscarexamen.Height + 5)





        botonbuscarpaciente.Width = Me.Width * 0.2902
        botonseleccionarpaciente.Width = botonbuscarpaciente.Width
        botoneliminarpaciente.Width = botonbuscarpaciente.Width


        botonbuscarpaciente.Location = New Point(txtbuscarpaciente.Location.X, txtbuscarpaciente.Location.Y + txtbuscarpaciente.Height + 5)
        botonseleccionarpaciente.Location = New Point(botonbuscarpaciente.Location.X + botonbuscarpaciente.Width + 25, txtbuscarpaciente.Location.Y + txtbuscarpaciente.Height + 5)
        botoneliminarpaciente.Location = New Point(botonseleccionarpaciente.Location.X + botonseleccionarpaciente.Width + 25, txtbuscarpaciente.Location.Y + txtbuscarpaciente.Height + 5)

        txtbuscarpaciente.Width = botoneliminarpaciente.Location.X + botoneliminarpaciente.Width - botonbuscarpaciente.Location.X


        DGVpacientes.Width = txtbuscarpaciente.Width
        DGVpacientes.Location = New Point(txtbuscarpaciente.Location.X, botonbuscarpaciente.Location.Y + botonbuscarpaciente.Height + 5)


        ' DGVexamen.Width = Me.Width * 0.7

        DGVpacientes.Height = Me.Height - 50 - DGVpacientes.Location.Y


       

    End Sub

    Sub ordenar_grilla_paciente()

        Dim columna As DataGridViewColumn = DGVpacientes.Columns(0)
        columna.Width = 100

        'columna = DGVpacientes.Columns(1)
        'columna.Width = 150

        columna = DGVpacientes.Columns(3)
        columna.Width = 70

        For i As Integer = 1 To 2
            columna = DGVpacientes.Columns(i)
            columna.Width = (DGVpacientes.Width - DGVpacientes.Columns(0).Width - DGVpacientes.Columns(3).Width) / 2
        Next

    End Sub

    Private Sub txtbuscarpaciente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtbuscarpaciente.KeyPress
        If e.KeyChar = ControlChars.Cr Then
            '  botonbuscarpaciente_Click(sender, e)
        End If
    End Sub

    Private Sub DGVpacientes_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGVpacientes.CellDoubleClick
        botonseleccionarpaciente_Click(sender, e)
    End Sub

    Private Sub DGVpacientes_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGVpacientes.CellClick
        botoneliminarpaciente.Enabled = True
    End Sub

    
    Private Sub DGVpacientes_KeyDown(sender As Object, e As KeyEventArgs) Handles DGVpacientes.KeyDown

        If e.KeyData = Keys.Enter Then
            botonseleccionarpaciente_Click(sender, e)
            Exit Sub
        End If

        If e.KeyData = Keys.Tab Or e.KeyData = Keys.Left Or e.KeyData = Keys.Right Then
            e.Handled = True
        End If
    End Sub

    Private Sub DGVpacientes_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DGVpacientes.KeyPress

        'If e.KeyChar = ControlChars.Lf Then
        '    botonseleccionarpaciente_Click(sender, e)
        'End If

    End Sub

    Private Sub txtbuscarpaciente_KeyDown(sender As Object, e As KeyEventArgs) Handles txtbuscarpaciente.KeyDown
        If e.KeyData = Keys.Enter Then
            botonbuscarpaciente_Click(sender, e)

            e.Handled = True
            e.SuppressKeyPress = True
            Exit Sub
        End If
    End Sub
End Class