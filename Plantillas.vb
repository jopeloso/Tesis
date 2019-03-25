Public Class Plantillas

    Private SQL As New SQLControl(Form1.aux_conexion_sql)

    Dim estado_nuevo As Boolean = False
    Dim estado_editar As Boolean = False


    Private Sub Plantillas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MdiParent = Form1
        Loadcombobox(cbxConclusiones, "Plantillas")

        Me.Width = Form1.screenWidth * 0.5
        Me.Height = Form1.screenHeight * 0.45

        ordenar_plantillas()
       

        ' Me.StartPosition = FormStartPosition.CenterScreen
        Me.Location = New Point(Form1.screenWidth * 0.2, Form1.screenHeight * 0.2)

    End Sub



    Private Sub Loadcombobox(combo As ComboBox, tabla As String)

        'refresco el contenido de la combobox
        combo.Items.Clear()

        'ejecuto la query
        SQL.ExecQuery("SELECT * From " & tabla & ";")

        If SQL.HasException(True) Then Exit Sub
        'loop row & sumar al combobox

        For Each r As DataRow In SQL.DBDT.Rows

            Dim a0 As String = r("Nombre")
            combo.Items.Add(a0)
        Next
    End Sub


    Private Sub botonseditarplantilla_Click(sender As Object, e As EventArgs) Handles botonseditarplantilla.Click


        If estado_editar = False Then

            estado_editar = True
            conclusiontext.ReadOnly = False

            botonseditarplantilla.Text = "Guardar"
            Exit Sub
        End If

        If estado_editar = True Then

            Dim plantillaNombre As String = cbxConclusiones.Text

            Dim plantillatexto As String = conclusiontext.Text
            plantillatexto = plantillatexto.Trim()
            Dim debugeo As Integer = 0
            If MsgBox("Esta seguro de actualizar la plantilla?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then



                Dim debugeo2 As Integer = 0

                SQL.AddParam("@nombreplantilla", plantillaNombre)
                SQL.AddParam("@textoplantilla", plantillatexto)

                SQL.ExecQuery("UPDATE Plantillas SET texto=@textoplantilla WHERE Nombre=@nombreplantilla;")
                '   UPDATE Plantillas SET texto='algoalgoalgo' WHERE Nombre='Ejemplo';
                If SQL.HasException(True) Then Exit Sub


                SQL.AddParam("@nombreplantilla", plantillaNombre)
                SQL.ExecQuery("SELECT texto From Plantillas WHERE Nombre=@nombreplantilla;")

                If SQL.HasException(True) Then Exit Sub

                For Each r As DataRow In SQL.DBDT.Rows
                    Dim a0 As String = r("texto")
                    conclusiontext.Text = a0
                Next

                botoneliminarplantilla.Enabled = False
                botonseditarplantilla.Enabled = False

                cbxConclusiones.SelectedIndex = -1

                conclusiontext.ReadOnly = True
                botonseditarplantilla.Text = "Editar"
                estado_editar = False
                conclusiontext.ReadOnly = True
                conclusiontext.Clear()
            End If

        End If

    End Sub


    Private Sub botoneliminarplantilla_Click(sender As Object, e As EventArgs) Handles botoneliminarplantilla.Click

        If MsgBox("Esta seguro de eliminar la plantilla?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

            Dim plantillaNombre As String = cbxConclusiones.Text

            SQL.AddParam("@nombreplantilla", plantillaNombre)
            SQL.ExecQuery("DELETE  from Plantillas WHERE Nombre= @nombreplantilla;")
            If SQL.HasException(True) Then Exit Sub

            Loadcombobox(cbxConclusiones, "PLantillas")

            conclusiontext.Clear()
            cbxConclusiones.SelectedIndex = -1
            botoneliminarplantilla.Enabled = False
            botonseditarplantilla.Enabled = False
        Else


        End If

    End Sub

    Private Sub cbxConclusiones_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxConclusiones.SelectedIndexChanged

        If sender.selectedindex <> -1 Then

            botoneliminarplantilla.Enabled = True
            botonseditarplantilla.Enabled = True
        End If

        If sender.selectedindex = -1 Then

            botoneliminarplantilla.Enabled = False
            botonseditarplantilla.Enabled = False
        End If


        Dim plantillaNombre As String = cbxConclusiones.Text
        SQL.AddParam("@nombreplantilla", plantillaNombre)

        SQL.ExecQuery("SELECT Texto From Plantillas WHERE Nombre=@nombreplantilla;")

        If SQL.HasException(True) Then Exit Sub

        For Each r As DataRow In SQL.DBDT.Rows

            Dim a0 As String = r("Texto")
            conclusiontext.Text = a0.Trim()
        Next

        estado_nuevo = False
        estado_editar = False
        botonNuevaplantilla.Text = "Nueva"
        botonseditarplantilla.Text = "Editar"
        conclusiontext.ReadOnly = True

    End Sub

    Private Sub Plantillas_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed

        Me.SendToBack()
        Form1.BringToFront()
        Form1.TabGeneral.BringToFront()
    End Sub

    Private Sub botonNuevaplantilla_Click(sender As Object, e As EventArgs) Handles botonNuevaplantilla.Click

        If estado_nuevo = False Then

            conclusiontext.Enabled = True
            conclusiontext.ReadOnly = False
            estado_nuevo = True
            'cbxConclusiones.Enabled = False

            cbxConclusiones.SelectedIndex = -1
            conclusiontext.Clear()
            botoneliminarplantilla.Enabled = False
            botonseditarplantilla.Enabled = False
            botonNuevaplantilla.Text = "Insertar"
            conclusiontext.ReadOnly = False

            estado_nuevo = True
            Exit Sub


        End If
       

        If estado_nuevo = True Then

            Dim nuevaplantilla As String = InputBox("Ingrese el nombre de la nueva plantilla. Se la asociará con el texto presente en el cuadro.")

            If String.IsNullOrWhiteSpace(nuevaplantilla) Then
                MsgBox("No puede agregar una plantilla con nombre vacio")
                Exit Sub
            End If

            Dim plantillatexto As String = conclusiontext.Text

            SQL.AddParam("@nombreplantilla", nuevaplantilla)
            SQL.AddParam("@textoplantilla", plantillatexto)

            SQL.ExecQuery("INSERT INTO Plantillas (Nombre, texto) VALUES (@nombreplantilla, @textoplantilla);")

            If SQL.HasException(True) Then Exit Sub

            MsgBox("Se ha agregado la nueva plantilla")

            Loadcombobox(cbxConclusiones, "Plantillas")


            ' conclusiontext.Enabled = False
            conclusiontext.ReadOnly = True
            estado_nuevo = False
            conclusiontext.Clear()

            cbxConclusiones.SelectedIndex = -1
            botonNuevaplantilla.Text = "Nueva"
            'cbxConclusiones.Enabled = True
        End If
    End Sub


    Sub ordenar_plantillas()

        botonNuevaplantilla.Width = Me.Width * 0.2902
        botonseditarplantilla.Width = botonNuevaplantilla.Width
        botoneliminarplantilla.Width = botonNuevaplantilla.Width
        cbxConclusiones.Width = botonNuevaplantilla.Width

        '  conclusiontext.Width = botoneliminarplantilla.Location.X + botoneliminarplantilla.Width - cbxConclusiones.Location.X
        botonNuevaplantilla.Location = New Point(cbxConclusiones.Location.X, cbxConclusiones.Location.Y + cbxConclusiones.Height + 5)
        botonseditarplantilla.Location = New Point(botonNuevaplantilla.Location.X + botonNuevaplantilla.Width + 25, cbxConclusiones.Location.Y + cbxConclusiones.Height + 5)
        botoneliminarplantilla.Location = New Point(botonseditarplantilla.Location.X + botonseditarplantilla.Width + 25, cbxConclusiones.Location.Y + cbxConclusiones.Height + 5)

        conclusiontext.Width = botoneliminarplantilla.Location.X + botoneliminarplantilla.Width - botonNuevaplantilla.Location.X
        conclusiontext.Location = New Point(cbxConclusiones.Location.X, botonNuevaplantilla.Location.Y + botonNuevaplantilla.Height + 5)

    End Sub



    Private Sub Plantillas_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Form1.Loadcomboboxplantilla(cbxConclusiones, "Plantillas")
    End Sub
End Class