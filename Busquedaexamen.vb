Imports System.Windows.Forms.Cursors

Public Class Busquedaexamen

    'Private SQL As New SQLControl(Form1.aux_conexion_sql)

    Private Sub Busquedaexamen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MdiParent = Form1

        'ANTES 0.8
        Me.Width = Form1.screenWidth * 0.6
        Me.Height = Form1.screenHeight * 0.6



        ordenar_buscar_examen()
       

        Me.StartPosition = FormStartPosition.CenterScreen

        ' Me.Location = New Point(250, 150)
        Me.Location = New Point(Form1.screenWidth * 0.2, Form1.screenHeight * 0.2)
        '  Me.StartPosition.Manual(100, 200)

    End Sub


    Private Sub botonbuscarexamen_Click(sender As Object, e As EventArgs) Handles botonbuscarexamen.Click

        Form1.Buscarexamen(txtbuscarexamen, "Examen", DGVexamen)

        Try
            ordenar_grilla_examen()
        Catch ex As Exception

        End Try

        ' Me.Cursor = Cursors.WaitCursor

    End Sub





    Private Sub Busquedaexamen_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        If Form1.ventana_inicial = True Then
            Form1.GO_Inicio()
            ' Form1.Esconder_Datos()
        End If
        Form1.Ordenar_TODO()
        Form1.BringToFront()
        Form1.TabGeneral.BringToFront()
        Me.SendToBack()

    End Sub
    Private Sub Busquedaexamen_FormClosing(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        If Form1.ventana_inicial = True Then
            Form1.GO_Inicio()
            'Form1.Esconder_Datos()
        End If
        Form1.BringToFront()
        Form1.TabGeneral.BringToFront()
        Me.SendToBack()

    End Sub

    Private Sub botonseleccionarexamen_Click(sender As Object, e As EventArgs) Handles botonseleccionarexamen.Click
        'Me.Cursor = Cursors.WaitCursor
        'Form1.TabPersonales.BackgroundImage = Nothing
        'Form1.TabGeneral.Hide()
        'Me.Hide()

        Me.Cursor = Cursors.WaitCursor
        ' Primero lleno los datos disponibles directamente en la tabla examen , es decir:
        'DNI, nombre y apellido del paciente; fechadelexamen, sintoma , ritmo , estado de internado y datos (FC,PD,PS) del examen 
        Dim i As Integer
        Try
            i = DGVexamen.CurrentCell.RowIndex
        Catch ex As Exception
            MsgBox("No hay ningun examen seleccionado!", MsgBoxStyle.Exclamation, "Tilt Test")
            Me.Cursor = Cursors.Default
            Exit Sub
        End Try


        Me.Cursor = Cursors.WaitCursor
        Form1.TabPersonales.BackgroundImage = Nothing
        ' Form1.TabGeneral.Hide()


        i = DGVexamen.CurrentCell.RowIndex
        Form1.TextDNI.Text = DGVexamen.Item(1, i).Value.ToString().Trim()
        Form1.TextNombre.Text = DGVexamen.Item(2, i).Value.ToString().Trim()
        Form1.TextApellido.Text = DGVexamen.Item(3, i).Value.ToString().Trim()
        Form1.txtfechaexamen.Text = DGVexamen.Item(4, i).Value.ToString().Substring(0, 10)

        Form1.fecha_examen = DGVexamen.Item(4, i).Value

        Form1.TextSintoma.Text = DGVexamen.Item(8, i).Value.ToString().Trim()
        Form1.TextRitmo.Text = DGVexamen.Item(9, i).Value.ToString().Trim()
        'aca agrego lo de conclusion
        Form1.conclusiontext.Text = DGVexamen.Item(13, i).Value.ToString().Trim()


        If DGVexamen.Item(10, i).Value = True Then Form1.InternadoSI.Checked = True

        If DGVexamen.Item(10, i).Value = False Then Form1.InternadoNO.Checked = True

        Dim aux_datos As String = DGVexamen.Item(11, i).Value.ToString()

        'abro los datos de ecg y las tiras
        ' guardar el ecg en el string
        Form1.aux_datos_ecg = DGVexamen.Item(14, i).Value.ToString()

        '   Dim debug_eg As String = Form1.aux_datos_ecg

        '  Form1.debug.Text = Form1.aux_datos_ecg

        'guardo las tiras
        Form1.tiras_aux = DGVexamen.Item(12, i).Value.ToString()
        'muestro los eventos
        Form1.abrir_tiras()
        Form1.listar_eventos()

        'luego utilizo el dni del paciente para buscarlo en la tabla de pacientes
        'asi consigo el resto de los datos del paciente: domicilio, telefono, edad, sexo
        Form1.SQL.AddParam("@dni", DGVexamen.Item(1, i).Value)
        Form1.Loadgrilla("Pacientes", DGVpacientesnovisible, "SELECT Domicilio, Telefono , Edad, Sexo FROM Pacientes WHERE DNI=@dni;")
        Form1.TextDomicilio.Text = DGVpacientesnovisible.Item(0, 0).Value.ToString()
        Form1.TextTelefono.Text = DGVpacientesnovisible.Item(1, 0).Value.ToString()
        Form1.TextEdad.Text = DGVpacientesnovisible.Item(2, 0).Value.ToString()
        Dim aux_sexo As Boolean = DGVpacientesnovisible.Item(3, 0).Value

        If aux_sexo = True Then Form1.botonMsexo.Checked = True
        If aux_sexo = False Then Form1.botonFsexo.Checked = True




        ' ahora busco al tecnico del examen
        Form1.SQL.AddParam("@tecnico", DGVexamen.Item(5, i).Value)
        Form1.Loadgrilla("Tecnicos", DGVpacientesnovisible, "SELECT * FROM Tecnicos WHERE Id=@tecnico;") ' aca decia pacientes en vez de tecnicos

        Dim aux As String = DGVpacientesnovisible.Item(0, 0).Value

        Dim lista As String
        Dim cantidad_tec As Integer = Form1.cbxTecnico.Items.Count - 1

        Dim actividad_tec As Boolean = False
        'aca estaba mal porque el valor maximo debe ser la cantidad de items menos uno
        For k As Integer = 0 To cantidad_tec
            lista = Form1.cbxTecnico.Items(k).ToString
            If lista.Substring(0, 1) = DGVpacientesnovisible.Item(0, 0).Value Then
                Form1.cbxTecnico.SelectedIndex = k
                actividad_tec = True
                Form1.actividad_del_tecnico = True
                Exit For
            End If
        Next

        If actividad_tec = False Then
            Dim a As String = DGVpacientesnovisible.Item(0, 0).Value
            Dim a2 As String = DGVpacientesnovisible.Item(1, 0).Value.ToString.Trim()
            Dim a3 As String = DGVpacientesnovisible.Item(2, 0).Value.ToString.Trim()
            Dim auxi As String = a & "- " & a3 & ", " & a2

            'Form1.cbxTecnico.Text = a & "- " & a3 & ", " & a2
            Form1.cbxTecnico.SelectedIndex = -1
            Form1.cbxTecnico.DropDownStyle = ComboBoxStyle.DropDown
            Form1.cbxTecnico.Text = auxi
            Form1.Labeltecnico.Visible = True
            Form1.actividad_del_tecnico = False


        End If

        If DGVexamen.Item(6, i).Value > 0 Then

            Form1.SQL.AddParam("@mandante", DGVexamen.Item(6, i).Value)
            Form1.Loadgrilla("Mandantes", DGVpacientesnovisible, "SELECT * FROM Mandantes WHERE Id=@mandante;")
            Dim cantidad_man As Integer = Form1.cbxMandante.Items.Count - 1
            Dim actividad_man As Boolean = False
            'aca estaba mal porque el valor maximo debe ser la cantidad de items menos uno
            For k As Integer = 0 To cantidad_man


                lista = Form1.cbxMandante.Items(k).ToString

                If lista.Substring(0, 1) = DGVpacientesnovisible.Item(0, 0).Value Then
                    Form1.cbxMandante.SelectedIndex = k
                    actividad_man = True
                    Form1.actividad_del_mandante = True
                    Exit For
                End If
            Next

            If actividad_man = False Then
                Dim a As String = DGVpacientesnovisible.Item(0, 0).Value
                Dim a2 As String = DGVpacientesnovisible.Item(1, 0).Value.ToString.Trim()
                Dim a3 As String = DGVpacientesnovisible.Item(2, 0).Value.ToString.Trim()


                Dim auxi As String = a & "- " & a3 & ", " & a2

                'Form1.cbxTecnico.Text = a & "- " & a3 & ", " & a2
                Form1.cbxMandante.SelectedIndex = -1
                Form1.cbxMandante.DropDownStyle = ComboBoxStyle.DropDown
                Form1.cbxMandante.Text = auxi


                Form1.Labelmandante.Visible = True
                Form1.actividad_del_mandante = False
            End If

        Else
            If DGVexamen.Item(6, i).Value = 0 Then
                Form1.cbxMandante.SelectedIndex = -1
                Form1.cbxMandante.DropDownStyle = ComboBoxStyle.Simple
                Form1.cbxMandante.Text = ""
                Dim auxexterno As String = DGVexamen.Item(15, i).Value.ToString.Trim()

                Form1.cbxMandante.Text = auxexterno

                Form1.Labelmandante.Text = "*Externo"
                Form1.Labelmandante.Visible = True
                Form1.actividad_del_mandante = False
                Form1.estado_mandante_externo = True

            End If

        End If

        Form1.SQL.AddParam("@actuante", DGVexamen.Item(7, i).Value)
        Form1.Loadgrilla("Actuantes", DGVpacientesnovisible, "SELECT * FROM Actuantes WHERE Id=@actuante;")
        Dim cantidad_act As Integer = Form1.cbxActuante.Items.Count - 1
        Dim actividad_act As Boolean = False
        'aca estaba mal porque el valor maximo debe ser la cantidad de items menos uno
        For k As Integer = 0 To cantidad_act


            lista = Form1.cbxActuante.Items(k).ToString

            If lista.Substring(0, 1) = DGVpacientesnovisible.Item(0, 0).Value Then
                Form1.cbxActuante.SelectedIndex = k
                actividad_act = True
                Form1.actividad_del_actuante = True
                Exit For
            End If
        Next

        If actividad_act = False Then
            Dim a As String = DGVpacientesnovisible.Item(0, 0).Value
            Dim a2 As String = DGVpacientesnovisible.Item(1, 0).Value.ToString.Trim()
            Dim a3 As String = DGVpacientesnovisible.Item(2, 0).Value.ToString.Trim()



            Dim auxi As String = a & "- " & a3 & ", " & a2

            'Form1.cbxTecnico.Text = a & "- " & a3 & ", " & a2
            Form1.cbxActuante.SelectedIndex = -1
            Form1.cbxActuante.DropDownStyle = ComboBoxStyle.DropDown
            Form1.cbxActuante.Text = auxi




            Form1.Labelactuante.Visible = True
            Form1.actividad_del_actuante = False
        End If

        Form1.estado_examen_viejo = True

        Form1.abrir_datos(aux_datos)


        'Dim i As Integer = DGVmedicosact.CurrentCell.RowIndex

        'Form1.TextDomicilio.Text = DGVpacientesnovisible.Item(5, 0).Value.ToString()
        'Form1.TextTelefono.Text = DGVpacientesnovisible.Item(6, 0).Value.ToString()

        '  activoactuante.Checked = DGVmedicosact.Item(3, i).Value
        'Form1.TextDomicilio.Text = DGVpacientesnovisible.Rows.cell


        'si hasta aca llego todo bien declaro que se pudo
        Form1.examen_abierto = True

        If Form1.examen_abierto = True Then

            ''Form1.Go_ExamenViejo()
            ''Form1.Mostrar_datos()
            'Form1.TextNombre.Enabled = True
            'Form1.TextNombre.ReadOnly = True
            'Form1.TextApellido.Enabled = True
            'Form1.TextApellido.ReadOnly = True
            'Form1.TextEdad.Enabled = True
            'Form1.TextEdad.ReadOnly = True
            'Form1.TextDNI.Enabled = True
            'Form1.TextDNI.ReadOnly = True
            'Form1.TextDomicilio.Enabled = True
            'Form1.TextDomicilio.ReadOnly = True
            'Form1.TextTelefono.Enabled = True
            'Form1.TextTelefono.ReadOnly = True
            'Form1.Panelsexo.Enabled = False
            'Form1.TextSintoma.Enabled = True
            'Form1.TextSintoma.ReadOnly = True
            'Form1.TextRitmo.Enabled = True
            'Form1.TextRitmo.ReadOnly = True
            'Form1.cbxTecnico.Enabled = False
            'Form1.cbxMandante.Enabled = False
            'Form1.cbxActuante.Enabled = False
        End If

        '----------------------------------------esta parte estaba no comentada

        'If actividad_tec = False Then
        '    Dim a As String = DGVpacientesnovisible.Item(0, 0).Value
        '    Dim a2 As String = DGVpacientesnovisible.Item(1, 0).Value.ToString.Trim()
        '    Dim a3 As String = DGVpacientesnovisible.Item(2, 0).Value.ToString.Trim()
        '    Form1.cbxTecnico.Text = a & "- " & a3 & ", " & a2
        '    Form1.Labeltecnico.Visible = True
        'End If

        'If actividad_man = False Then
        '    Dim a As String = DGVpacientesnovisible.Item(0, 0).Value
        '    Dim a2 As String = DGVpacientesnovisible.Item(1, 0).Value.ToString.Trim()
        '    Dim a3 As String = DGVpacientesnovisible.Item(2, 0).Value.ToString.Trim()
        '    Form1.cbxMandante.Text = a & "- " & a3 & ", " & a2
        '    Form1.Labelmandante.Visible = True
        'End If


        'If actividad_act = False Then
        '    Dim a As String = DGVpacientesnovisible.Item(0, 0).Value
        '    Dim a2 As String = DGVpacientesnovisible.Item(1, 0).Value.ToString.Trim()
        '    Dim a3 As String = DGVpacientesnovisible.Item(2, 0).Value.ToString.Trim()
        '    Form1.cbxActuante.Text = a & "- " & a3 & ", " & a2
        '    Form1.Labelactuante.Visible = True
        'End If


        '----------------------------------------la parte de arriba estaba no comentada

        'LO QUE COMENTO PARA VER QUE QUEDA
        Form1.ventana_inicial = False
        Me.SendToBack()
        Form1.BringToFront()
        Form1.TabGeneral.BringToFront()


        Form1.estado_examen_viejo = True

        Dim auxi_ecg As String = Form1.aux_datos_ecg

        Dim auxi_array() As String = auxi_ecg.Split(vbCrLf)

        For k As Integer = 0 To (auxi_array.Length() - 1)
            '.Text = Form1.debug.Text & auxi_array(k)

        Next


        Form1.Go_ExamenViejo()

        Me.Close()

        'Form1.TabPersonales.BackgroundImage = New Bitmap(Form1.direccion_txt & "\fondo3.png")

        Form1.TabGeneral.Show()




    End Sub

   

    Sub ordenar_buscar_examen()
        '0.266
        ' botonbuscarexamen.Width = Me.Width * 0.2 * 1.33

        LabelTituloBuscarExamen.Location = New Point(txtbuscarexamen.Location.X, 5)

        txtbuscarexamen.Location = New Point(txtbuscarexamen.Location.X, LabelTituloBuscarExamen.Location.Y + LabelTituloBuscarExamen.Height + 5)

        botonbuscarexamen.Width = Me.Width * 0.2902

        botonseleccionarexamen.Width = botonbuscarexamen.Width
        botoneliminarexamen.Width = botonbuscarexamen.Width

        botonbuscarexamen.Location = New Point(txtbuscarexamen.Location.X, txtbuscarexamen.Location.Y + txtbuscarexamen.Height + 5)
        botonseleccionarexamen.Location = New Point(botonbuscarexamen.Location.X + botonbuscarexamen.Width + 25, txtbuscarexamen.Location.Y + txtbuscarexamen.Height + 5)
        botoneliminarexamen.Location = New Point(botonseleccionarexamen.Location.X + botonseleccionarexamen.Width + 25, txtbuscarexamen.Location.Y + txtbuscarexamen.Height + 5)





        txtbuscarexamen.Width = botoneliminarexamen.Location.X + botoneliminarexamen.Width - botonbuscarexamen.Location.X

        ' DGVexamen.Width = Me.Width * 0.7
        DGVexamen.Width = txtbuscarexamen.Width

        DGVexamen.Location = New Point(txtbuscarexamen.Location.X, botonbuscarexamen.Location.Y + botonbuscarexamen.Height + 5)

        ' antes estaba puesto en 0,7
        ' DGVexamen.Height = Me.Height * 0.7
        DGVexamen.Height = Me.Height - 50 - DGVexamen.Location.Y

        'DGVexamen.Location = New Point(txtbuscarexamen.Location.X, botonbuscarexamen.Location.Y + botonbuscarexamen.Height + 5)



    End Sub


    Private Sub botoneliminarexamen_Click(sender As Object, e As EventArgs) Handles botoneliminarexamen.Click

        Try


            Dim i As Integer = DGVexamen.CurrentCell.RowIndex
            Dim numero As Integer = DGVexamen.Item(0, i).Value
            'Dim nombre As String = DGVp.Item(2, i).Value.ToString
            'Dim apellido As String = DGVpacientes.Item(3, i).Value.ToString

            Form1.SQL.AddParam("@id", numero)
            'SQL.ExecQuery("SELECT * from Examen  WHERE IDNpaciente= @idnpaciente;")
            'If SQL.HasException(True) Then Exit Sub

            'If SQL.DBDT.Rows.Count <> 0 Then

            '    MsgBox("No se puede eliminar al paciente seleccionado ya que esta asociado a un examen en la base de datos", MsgBoxStyle.Information, "Error")

            '    Exit Sub
            'End If

            'Borrar_Campo(txtNombreMandante, txtApellidoMandante, DGVmedicosman, "Mandantes", cbxMandante)
            If MsgBox("Esta seguro que quiere borrar el siguiente examen?", MsgBoxStyle.YesNo, "title") = MsgBoxResult.Yes Then




                Form1.SQL.ExecQuery("DELETE  from  Examen WHERE Id= @id;")

                If Form1.SQL.HasException(True) Then Exit Sub



            End If



            Form1.Loadgrilla("Examen", DGVexamen)

        Catch ex As Exception
            MsgBox("No hay ningun examen seleccionado!")
        End Try


    End Sub



    Private Sub DGVexamen_Click(sender As Object, e As EventArgs) Handles DGVexamen.Click
        'botoneliminarexamen.Enabled = True
    End Sub


    Sub ordenar_grilla_examen()

        Dim columna As DataGridViewColumn = DGVexamen.Columns(0)
        columna.Width = 0

        columna = DGVexamen.Columns(1)
        columna.Width = 150

        columna = DGVexamen.Columns(4)
        columna.Width = 100

        For i As Integer = 2 To 3
            columna = DGVexamen.Columns(i)
            columna.Width = (DGVexamen.Width - DGVexamen.Columns(1).Width - DGVexamen.Columns(4).Width) / 2
        Next

    End Sub

    Private Sub txtbuscarexamen_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtbuscarexamen.KeyPress
        If e.KeyChar = ControlChars.Cr Then
            botonbuscarexamen_Click(sender, e)
            e.Handled = True
            ' e.suppresskeypress = True
        End If
    End Sub

    Private Sub DGVexamen_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGVexamen.CellClick
        botoneliminarexamen.Enabled = True
    End Sub

    Private Sub DGVexamen_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGVexamen.CellDoubleClick
        botonseleccionarexamen_Click(sender, e)
    End Sub

    Private Sub DGVexamen_KeyDown(sender As Object, e As KeyEventArgs) Handles DGVexamen.KeyDown

        If e.KeyData = Keys.Enter Then
            botonseleccionarexamen_Click(sender, e)
            Exit Sub
        End If

        If e.KeyData = Keys.Tab Or e.KeyData = Keys.Left Or e.KeyData = Keys.Right Then
            e.Handled = True
        End If

    End Sub

    Private Sub txtbuscarexamen_KeyDown(sender As Object, e As KeyEventArgs) Handles txtbuscarexamen.KeyDown
        If e.KeyData = Keys.Enter Then
            botonbuscarexamen_Click(sender, e)
            e.Handled = True
            e.SuppressKeyPress = True
        End If
    End Sub
End Class