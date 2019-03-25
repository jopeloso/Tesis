Public Class Protocolo

    Private SQL As New SQLControl(Form1.aux_conexion_sql)
    Private aux_datos As String



    Dim insercion_ok As Boolean = False

    Dim editando_protocolo As Boolean = False

    Dim nuevo_protocolo As Boolean = False


    Private Sub Protocolo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MdiParent = Form1

        Me.Width = Form1.screenWidth * 0.45
        Me.Height = Form1.screenHeight * 0.45

        ' Me.StartPosition = FormStartPosition.CenterScreen
        Me.Location = New Point(Form1.screenWidth * 0.2, Form1.screenHeight * 0.2)

        Form1.Loadcomboboxprotocolo(cbxProto, "Protocolos")
        txtDuracionBasal.ReadOnly = True
        txtInclinacionBasal.ReadOnly = True
        txtDuracionE1.ReadOnly = True
        txtInclinacionE1.ReadOnly = True
        txtDuracionE2.ReadOnly = True
        txtInclinacionE2.ReadOnly = True
        txtDuracionE3.ReadOnly = True
        txtInclinacionE3.ReadOnly = True

        txtDuracionBasal.Enabled = True
        txtInclinacionBasal.Enabled = True
        txtDuracionE1.Enabled = True
        txtInclinacionE1.Enabled = True
        txtDuracionE2.Enabled = True
        txtInclinacionE2.Enabled = True
        txtDuracionE3.Enabled = True
        txtInclinacionE3.Enabled = True

        ordenar_protocolo()
    End Sub

    Private Sub Protocolo_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.SendToBack()
        Form1.BringToFront()
        Form1.TabGeneral.BringToFront()
    End Sub

    Private Sub cbxProto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxProto.SelectedIndexChanged
        Dim protocoloNombre As String = cbxProto.Text
        Form1.SQL.AddParam("@nombreprotocolo", protocoloNombre)
        Form1.SQL.ExecQuery("SELECT * From Protocolos WHERE Nombre=@nombreprotocolo;")
        If Form1.SQL.HasException(True) Then Exit Sub
        For Each r As DataRow In Form1.SQL.DBDT.Rows
            Dim a0 As String = r("Descripcion")
            txtDescripcion.Text = a0.Trim()
            txtDuracionBasal.Text = r("DuracionBasal").ToString().Trim()
            txtInclinacionBasal.Text = r("InclinacionBasal").ToString().Trim()
            txtDuracionE1.Text = r("DuracionE1").ToString().Trim()
            txtInclinacionE1.Text = r("InclinacionE1").ToString().Trim()
            txtDuracionE2.Text = r("DuracionE2").ToString().Trim()
            txtInclinacionE2.Text = r("InclinacionE2").ToString().Trim()
            txtDuracionE3.Text = r("DuracionE3").ToString().Trim()
            txtInclinacionE3.Text = r("InclinacionE3").ToString().Trim()
        Next
        EliminarProtocolo.Enabled = True
        EditarProtocolo.Enabled = True
    End Sub


    

    Private Sub EditarProtocolo_Click(sender As Object, e As EventArgs) Handles EditarProtocolo.Click

        If nuevo_protocolo = True Then Exit Sub

        If editando_protocolo = False Then
            txtDuracionBasal.ReadOnly = False
            txtInclinacionBasal.ReadOnly = False
            txtDuracionE1.ReadOnly = False
            txtInclinacionE1.ReadOnly = False
            txtDuracionE2.ReadOnly = False
            txtInclinacionE2.ReadOnly = False
            txtDuracionE3.ReadOnly = False
            txtInclinacionE3.ReadOnly = False
            editando_protocolo = True
            EditarProtocolo.Text = "Guardar"
            Exit Sub
        End If

        If editando_protocolo = True Then
            Dim protocoloNombre As String = cbxProto.Text
            Dim protocoloDescripcion As String = txtDescripcion.Text.Trim()
            If MsgBox("Esta seguro de actualizar el protocolo?", MsgBoxStyle.YesNo, "Editar Protocolo") = MsgBoxResult.Yes Then

               
                SQL.AddParam("@nombreprotocolo", protocoloNombre.Trim())
                SQL.AddParam("@descripcionprotocolo", protocoloDescripcion.Trim())

                Try
                    SQL.AddParam("@durbasal", Convert.ToInt16(txtDuracionBasal.Text))
                Catch ex As Exception
                    SQL.AddParam("@durbasal", 0)
                End Try

                Try
                    SQL.AddParam("@incbasal", Convert.ToInt16(txtInclinacionBasal.Text))
                Catch ex As Exception
                    SQL.AddParam("@incbasal", 0)
                End Try

                Try
                    SQL.AddParam("@dure1", Convert.ToInt16(txtDuracionE1.Text))
                Catch ex As Exception
                    SQL.AddParam("@dure1", 0)
                End Try

                Try
                    SQL.AddParam("@ince1", Convert.ToInt16(txtInclinacionE1.Text))
                Catch ex As Exception
                    SQL.AddParam("@ince1", 0)
                End Try

                Try
                    SQL.AddParam("@dure2", Convert.ToInt16(txtDuracionE2.Text))
                Catch ex As Exception
                    SQL.AddParam("@dure2", 0)
                End Try

                Try
                    SQL.AddParam("@ince2", Convert.ToInt16(txtInclinacionE2.Text))
                Catch ex As Exception
                    SQL.AddParam("@ince2", 0)
                End Try

                Try
                    SQL.AddParam("@dure3", Convert.ToInt16(txtDuracionE3.Text))
                Catch ex As Exception
                    SQL.AddParam("@dure3", 0)
                End Try

                Try
                    SQL.AddParam("@ince3", Convert.ToInt16(txtInclinacionE3.Text))
                Catch ex As Exception
                    SQL.AddParam("@ince3", 0)
                End Try



                SQL.ExecQuery("UPDATE Protocolos set Descripcion = @descripcionprotocolo , DuracionBasal =@durbasal , InclinacionBasal= @incbasal , DuracionE1 = @dure1, InclinacionE1= @ince1 , DuracionE2 = @dure2, InclinacionE2= @ince2 , DuracionE3 = @dure3, InclinacionE3= @ince3  WHERE Nombre = @nombreprotocolo")
                If SQL.HasException(True) Then Exit Sub
               
                SQL.AddParam("@nombreprotocolo", protocoloNombre.Trim())
                SQL.ExecQuery("SELECT * From Protocolos WHERE Nombre=@nombreprotocolo;")
                If SQL.HasException(True) Then Exit Sub

                For Each r As DataRow In Form1.SQL.DBDT.Rows
                    Dim a0 As String = r("Descripcion")
                    txtDescripcion.Text = a0.Trim()
                    txtDuracionBasal.Text = r("DuracionBasal").ToString().Trim()
                    txtInclinacionBasal.Text = r("InclinacionBasal").ToString().Trim()
                    txtDuracionE1.Text = r("DuracionE1").ToString().Trim()
                    txtInclinacionE1.Text = r("InclinacionE1").ToString().Trim()
                    txtDuracionE2.Text = r("DuracionE2").ToString().Trim()
                    txtInclinacionE2.Text = r("InclinacionE2").ToString().Trim()
                    txtDuracionE3.Text = r("DuracionE3").ToString().Trim()
                    txtInclinacionE3.Text = r("InclinacionE3").ToString().Trim()
                Next


            End If

            txtDuracionBasal.ReadOnly = True
            txtInclinacionBasal.ReadOnly = True
            txtDuracionE1.ReadOnly = True
            txtInclinacionE1.ReadOnly = True
            txtDuracionE2.ReadOnly = True
            txtInclinacionE2.ReadOnly = True
            txtDuracionE3.ReadOnly = True
            txtInclinacionE3.ReadOnly = True
            editando_protocolo = False
            EditarProtocolo.Text = "Editar"
            cbxProto.SelectedIndex = -1


            txtDuracionBasal.Clear()
            txtInclinacionBasal.Clear()
            txtDuracionE1.Clear()
            txtInclinacionE1.Clear()
            txtDuracionE2.Clear()
            txtInclinacionE2.Clear()
            txtDuracionE3.Clear()
            txtInclinacionE3.Clear()
            txtDescripcion.Clear()
            editando_protocolo = False

            Exit Sub
        End If

    End Sub

    Private Sub EliminarProtocolo_Click(sender As Object, e As EventArgs) Handles EliminarProtocolo.Click

        If editando_protocolo = True Then Exit Sub
        If nuevo_protocolo = True Then Exit Sub

        If MsgBox("Esta seguro de querer eliminar el siguiente protocolo? : " & cbxProto.SelectedText, MsgBoxStyle.OkCancel, "Eliminar Protocolo") = MsgBoxResult.Ok Then
            Dim protocoloNombre As String = cbxProto.Text
            SQL.AddParam("@nombreprotocolo", protocoloNombre)
            SQL.ExecQuery("DELETE  from Protocolos WHERE Nombre= @nombreprotocolo;")
            If SQL.HasException(True) Then Exit Sub
            Form1.Loadcomboboxprotocolo(cbxProto, "Protocolos")
            MsgBox("Se he eliminado el protocolo", MsgBoxStyle.Information, "Eliminar Protocolo")
        End If
    End Sub

    Private Sub InsertarProtocolo_Click(sender As Object, e As EventArgs) Handles NuevoProtocolo.Click

        If editando_protocolo = True Then Exit Sub

        If nuevo_protocolo = False Then
          
            txtDuracionBasal.ReadOnly = False
            txtDuracionBasal.Text = "0"
            txtDuracionE1.ReadOnly = False
            txtDuracionE1.Text = "0"
            txtDuracionE2.ReadOnly = False
            txtDuracionE2.Text = "0"
            txtDuracionE3.ReadOnly = False
            txtDuracionE3.Text = "0"
            txtInclinacionBasal.ReadOnly = False
            txtInclinacionBasal.Text = "0"
            txtInclinacionE1.ReadOnly = False
            txtInclinacionE1.Text = "0"
            txtInclinacionE2.ReadOnly = False
            txtInclinacionE2.Text = "0"
            txtInclinacionE3.ReadOnly = False
            txtInclinacionE3.Text = "0"

            cbxProto.SelectedIndex = -1
            cbxProto.DropDownStyle = ComboBoxStyle.Simple

            NuevoProtocolo.Text = "Insertar"
            nuevo_protocolo = True
            Exit Sub
        End If


        If nuevo_protocolo = True Then

            insertar_protocolo()
            If insercion_ok = True Then
                NuevoProtocolo.Text = "Nuevo"

                txtDuracionBasal.ReadOnly = True
                txtDuracionE1.ReadOnly = True
                txtInclinacionBasal.ReadOnly = True
                txtInclinacionE1.ReadOnly = True
                txtDuracionE2.ReadOnly = True
                txtInclinacionE2.ReadOnly = True
                txtDuracionE3.ReadOnly = True
                txtInclinacionE3.ReadOnly = True

                NuevoProtocolo.Text = "Nuevo"
                nuevo_protocolo = False
                Exit Sub
            End If
        End If
    End Sub


    Sub insertar_protocolo()

      
        Dim nuevo_protocolo As String = cbxProto.Text

     
        If nuevo_protocolo = "" Then
            MsgBox("No puede agregar un protocolo con nombre vacio")
            Exit Sub
        End If

        Form1.Loadgrilla("Protocolos", DGVprotocolos, "SELECT * FROM Protocolos WHERE Nombre= '" & nuevo_protocolo & "' ;")


        If DGVprotocolos.RowCount > 1 Then
            MsgBox("Ya existe un protocolo con ese nombre. Por favor elija otro.", MsgBoxStyle.Information, "Nombre Protocolo")
            Exit Sub
        End If


        SQL.AddParam("@nombreprotocolo", nuevo_protocolo)
        SQL.AddParam("@descripcionprotocolo", txtDescripcion.Text)
        SQL.AddParam("@durbasal", txtDuracionBasal.Text)
        SQL.AddParam("@incbasal", txtInclinacionBasal.Text)
        SQL.AddParam("@dure1", txtDuracionE1.Text)
        SQL.AddParam("@ince1", txtInclinacionE1.Text)
        SQL.AddParam("@dure2", txtDuracionE2.Text)
        SQL.AddParam("@ince2", txtInclinacionE2.Text)
        SQL.AddParam("@dure3", txtDuracionE3.Text)
        SQL.AddParam("@ince3", txtInclinacionE3.Text)

        SQL.ExecQuery("INSERT INTO Protocolos (Nombre, Descripcion ,  DuracionBasal , InclinacionBasal , DuracionE1, InclinacionE1 , DuracionE2, InclinacionE2, DuracionE3, InclinacionE3) VALUES (@nombreprotocolo, @descripcionprotocolo, @durbasal , @incbasal , @dure1 , @ince1 , @dure2 , @ince2 , @dure3, @ince3);")
        If SQL.HasException(True) Then Exit Sub

        MsgBox("Se ha agregado el nuevo protocolo", MsgBoxStyle.Information, "Nuevo Protocolo")

        insercion_ok = True
        cbxProto.DropDownStyle = ComboBoxStyle.DropDownList

        Form1.Loadcomboboxprotocolo(cbxProto, "Protocolos")
        Form1.Loadcomboboxprotocolo(Form1.ComboBoxProtocolo, "Protocolos")
    End Sub

    Sub actualizar_descripcion()

        txtDescripcion.Text = "1-Período Basal dura: " & txtDuracionBasal.Text & " minutos y tiene una inclinación de: " & txtInclinacionBasal.Text & " grados." & vbCrLf
        txtDescripcion.Text = txtDescripcion.Text & "2-La primera etapa dura: " & txtDuracionE1.Text & " minutos y tiene una inclinación de: " & txtInclinacionE1.Text & " grados." & vbCrLf



        txtDescripcion.Text = txtDescripcion.Text & "3-La segunda etapa dura: " & txtDuracionE2.Text & " minutos y tiene una inclinación de: " & txtInclinacionE2.Text & " grados." & vbCrLf


            txtDescripcion.Text = txtDescripcion.Text & "4-La tercera etapa dura: " & txtDuracionE3.Text & " minutos y tiene una inclinación de: " & txtInclinacionE3.Text & " grados." & vbCrLf
      
    End Sub

    Private Sub txtDuracionBasal_TextChanged(sender As Object, e As EventArgs) Handles txtDuracionBasal.TextChanged

        Dim aux_string As String = sender.Text
        Try
            Dim aux_entero As Integer = Convert.ToInt32(aux_string)
            If aux_entero >= 10 Then
                sender.text = "10"
            End If
        Catch ex As Exception

        End Try
       
        If nuevo_protocolo = True Then
            actualizar_descripcion()
        End If

    End Sub

    Private Sub txtInclinacionBasal_TextChanged(sender As Object, e As EventArgs) Handles txtInclinacionBasal.TextChanged

        Dim aux_string As String = sender.Text
        Try
            Dim aux_entero As Integer = Convert.ToInt32(aux_string)
            If aux_entero >= 90 Then
                sender.text = "90"
            End If
        Catch ex As Exception

        End Try

        If nuevo_protocolo = True Then
            actualizar_descripcion()
        End If
    End Sub

    Private Sub txtDuracionE1_TextChanged(sender As Object, e As EventArgs) Handles txtDuracionE1.TextChanged


        Try

            If Convert.ToInt16(sender.text) + Convert.ToInt16(txtDuracionE2.Text) + Convert.ToInt16(txtDuracionE3.Text) >= 90 Then

                sender.text = (90 - (Convert.ToInt16(txtDuracionE2.Text) + Convert.ToInt16(txtDuracionE3.Text))).ToString()
            End If

            If Convert.ToInt16(sender.text) >= 90 Then
                sender.text = "90"
            End If


        Catch ex As Exception

        End Try



        If nuevo_protocolo = True Then
            actualizar_descripcion()
        End If

    End Sub

    Private Sub txtInclinacionE1_TextChanged(sender As Object, e As EventArgs) Handles txtInclinacionE1.TextChanged

        Dim aux_string As String = sender.Text
        Try
            Dim aux_entero As Integer = Convert.ToInt32(aux_string)
            If aux_entero >= 90 Then
                sender.text = "90"
            End If
        Catch ex As Exception

        End Try

        If nuevo_protocolo = True Then
            actualizar_descripcion()
        End If

    End Sub

    Private Sub txtDuracionE2_TextChanged(sender As Object, e As EventArgs) Handles txtDuracionE2.TextChanged

        Try

            If Convert.ToInt16(sender.text) + Convert.ToInt16(txtDuracionE1.Text) + Convert.ToInt16(txtDuracionE3.Text) >= 90 Then

                sender.text = (90 - (Convert.ToInt16(txtDuracionE1.Text) + Convert.ToInt16(txtDuracionE3.Text))).ToString()
            End If

            If Convert.ToInt16(sender.text) >= 90 Then
                sender.text = "90"
            End If


        Catch ex As Exception

        End Try


        If nuevo_protocolo = True Then
            actualizar_descripcion()
        End If

    End Sub

    Private Sub txtInclinacionE2_TextChanged(sender As Object, e As EventArgs) Handles txtInclinacionE2.TextChanged

        Dim aux_string As String = sender.Text
        Try
            Dim aux_entero As Integer = Convert.ToInt32(aux_string)
            If aux_entero >= 90 Then
                sender.text = "90"
            End If
        Catch ex As Exception

        End Try

        If nuevo_protocolo = True Then
            actualizar_descripcion()
        End If

    End Sub

    Private Sub txtDuracionE3_TextChanged(sender As Object, e As EventArgs) Handles txtDuracionE3.TextChanged

        Try

            If Convert.ToInt16(sender.text) + Convert.ToInt16(txtDuracionE1.Text) + Convert.ToInt16(txtDuracionE2.Text) >= 90 Then

                sender.text = (90 - (Convert.ToInt16(txtDuracionE1.Text) + Convert.ToInt16(txtDuracionE2.Text))).ToString()
            End If

            If Convert.ToInt16(sender.text) >= 90 Then
                sender.text = "90"
            End If


        Catch ex As Exception

        End Try
        If nuevo_protocolo = True Then
            actualizar_descripcion()
        End If
    End Sub

    Private Sub txtInclinacionE3_TextChanged(sender As Object, e As EventArgs) Handles txtInclinacionE3.TextChanged
        Dim aux_string As String = sender.Text
        Try
            Dim aux_entero As Integer = Convert.ToInt32(aux_string)
            If aux_entero >= 90 Then
                sender.text = "90"
            End If
        Catch ex As Exception

        End Try
        If nuevo_protocolo = True Then
            actualizar_descripcion()
        End If
    End Sub

    
    Private Sub txtDuracionBasal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDuracionBasal.KeyPress
        Dim allowedChars As String = "0123456789"


        If sender.text.Length >= 2 Then
            If e.KeyChar = ControlChars.Back Then
                e.Handled = False
                Exit Sub
            End If
            e.Handled = True
            Exit Sub
        End If

        If e.KeyChar = ControlChars.Back Then
            e.Handled = False
            Exit Sub
        End If


        If allowedChars.IndexOf(e.KeyChar) = -1 Then
            ' Invalid Character
            e.Handled = True
        End If
    End Sub

    Private Sub txtInclinacionBasal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtInclinacionBasal.KeyPress
        Dim allowedChars As String = "0123456789"

      
        If sender.text.Length >= 2 Then
            If e.KeyChar = ControlChars.Back Then
                e.Handled = False
                Exit Sub
            End If
            e.Handled = True
            Exit Sub
        End If

        If e.KeyChar = ControlChars.Back Then
            e.Handled = False
            Exit Sub
        End If


        If allowedChars.IndexOf(e.KeyChar) = -1 Then
            ' Invalid Character
            e.Handled = True
        End If

    End Sub

    Private Sub txtInclinacionE1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtInclinacionE1.KeyPress
        Dim allowedChars As String = "0123456789"

      

        If sender.text.Length >= 2 Then
            If e.KeyChar = ControlChars.Back Then
                e.Handled = False
                Exit Sub
            End If
            e.Handled = True
            Exit Sub
        End If

        If e.KeyChar = ControlChars.Back Then
            e.Handled = False
            Exit Sub
        End If


        If allowedChars.IndexOf(e.KeyChar) = -1 Then
            ' Invalid Character
            e.Handled = True
        End If
    End Sub

    Private Sub txtInclinacionE2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtInclinacionE2.KeyPress
        Dim allowedChars As String = "0123456789"

       

        If sender.text.Length >= 2 Then
            If e.KeyChar = ControlChars.Back Then
                e.Handled = False
                Exit Sub
            End If
            e.Handled = True
            Exit Sub
        End If

        If e.KeyChar = ControlChars.Back Then
            e.Handled = False
            Exit Sub
        End If


        If allowedChars.IndexOf(e.KeyChar) = -1 Then
            ' Invalid Character
            e.Handled = True
        End If
    End Sub

    Private Sub txtInclinacionE3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtInclinacionE3.KeyPress
        Dim allowedChars As String = "0123456789"

      

        If sender.text.Length >= 2 Then
            If e.KeyChar = ControlChars.Back Then
                e.Handled = False
                Exit Sub
            End If
            e.Handled = True
            Exit Sub
        End If

        If e.KeyChar = ControlChars.Back Then
            e.Handled = False
            Exit Sub
        End If


        If allowedChars.IndexOf(e.KeyChar) = -1 Then
            ' Invalid Character
            e.Handled = True
        End If
    End Sub

    Private Sub txtDuracionE1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDuracionE1.KeyPress
        Dim allowedChars As String = "0123456789"


       
        If sender.text.Length >= 2 Then
            If e.KeyChar = ControlChars.Back Then
                e.Handled = False
                Exit Sub
            End If
            e.Handled = True
            Exit Sub
        End If

        If e.KeyChar = ControlChars.Back Then
            e.Handled = False
            Exit Sub
        End If


        If allowedChars.IndexOf(e.KeyChar) = -1 Then
            ' Invalid Character
            e.Handled = True
        End If
    End Sub

    Private Sub txtDuracionE2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDuracionE2.KeyPress
        Dim allowedChars As String = "0123456789"




        If sender.text.Length >= 2 Then
            If e.KeyChar = ControlChars.Back Then
                e.Handled = False
                Exit Sub
            End If
            e.Handled = True
            Exit Sub
        End If

        If e.KeyChar = ControlChars.Back Then
            e.Handled = False
            Exit Sub
        End If


        If allowedChars.IndexOf(e.KeyChar) = -1 Then
            ' Invalid Character
            e.Handled = True
        End If
    End Sub
    

    Private Sub txtDuracionE3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDuracionE3.KeyPress
        Dim allowedChars As String = "0123456789"


        

        If sender.text.Length >= 2 Then
            If e.KeyChar = ControlChars.Back Then
                e.Handled = False
                Exit Sub
            End If
            e.Handled = True
            Exit Sub
        End If

        If e.KeyChar = ControlChars.Back Then
            e.Handled = False
            Exit Sub
        End If


        If allowedChars.IndexOf(e.KeyChar) = -1 Then
            ' Invalid Character
            e.Handled = True
        End If
    End Sub


    Sub ordenar_protocolo()

        NuevoProtocolo.Width = Me.Width * 0.2902
        EditarProtocolo.Width = NuevoProtocolo.Width
        EliminarProtocolo.Width = NuevoProtocolo.Width
        cbxProto.Width = NuevoProtocolo.Width

        LabelBasal.Width = NuevoProtocolo.Width * 0.5
        LabelE1.Width = NuevoProtocolo.Width * 0.5
        LabelE2.Width = NuevoProtocolo.Width * 0.5
        LabelE3.Width = NuevoProtocolo.Width * 0.5
        LabelDur.Width = NuevoProtocolo.Width * 0.5


        txtDuracionBasal.Width = NuevoProtocolo.Width * 0.5

        txtInclinacionBasal.Width = txtDuracionBasal.Width

        txtInclinacionE1.Width = txtDuracionBasal.Width
        txtInclinacionE2.Width = txtDuracionBasal.Width
        txtInclinacionE3.Width = txtDuracionBasal.Width
        txtDuracionE1.Width = txtDuracionBasal.Width
        txtDuracionE2.Width = txtDuracionBasal.Width
        txtDuracionE3.Width = txtDuracionBasal.Width

        NuevoProtocolo.Location = New Point(cbxProto.Location.X, cbxProto.Location.Y + cbxProto.Height + 10)
        EditarProtocolo.Location = New Point(cbxProto.Location.X, NuevoProtocolo.Location.Y + NuevoProtocolo.Height + 10)
        EliminarProtocolo.Location = New Point(cbxProto.Location.X, EditarProtocolo.Location.Y + EditarProtocolo.Height + 10)

        txtDescripcion.Location = New Point(EditarProtocolo.Location.X, EliminarProtocolo.Location.Y + EliminarProtocolo.Height + 5)

        txtDescripcion.Height = Me.Height * 0.85 - (EliminarProtocolo.Location.Y + EliminarProtocolo.Height + 5)
        txtDescripcion.Width = Me.Width * 0.95 - (NuevoProtocolo.Location.X)

        

        LabelBasal.Location = New Point(NuevoProtocolo.Location.X + NuevoProtocolo.Width + 30, txtDuracionBasal.Location.Y)
        LabelE1.Location = New Point(LabelBasal.Location.X, txtDuracionE1.Location.Y)
        LabelE2.Location = New Point(LabelBasal.Location.X, txtDuracionE2.Location.Y)
        LabelE3.Location = New Point(LabelBasal.Location.X, txtDuracionE3.Location.Y)



        LabelDur.Location = New Point(LabelBasal.Location.X + LabelBasal.Width + 50, cbxProto.Location.Y)
        LabelInc.Location = New Point(LabelDur.Location.X + txtDuracionBasal.Width + 50, cbxProto.Location.Y)

        txtDuracionBasal.Location = New Point(LabelDur.Location.X, txtDuracionBasal.Location.Y)
        txtDuracionE1.Location = New Point(LabelDur.Location.X, txtDuracionE1.Location.Y)
        txtDuracionE2.Location = New Point(LabelDur.Location.X, txtDuracionE2.Location.Y)
        txtDuracionE3.Location = New Point(LabelDur.Location.X, txtDuracionE3.Location.Y)

        txtInclinacionBasal.Location = New Point(LabelInc.Location.X, txtDuracionBasal.Location.Y)
        txtInclinacionE1.Location = New Point(LabelInc.Location.X, txtDuracionE1.Location.Y)
        txtInclinacionE2.Location = New Point(LabelInc.Location.X, txtDuracionE2.Location.Y)
        txtInclinacionE3.Location = New Point(LabelInc.Location.X, txtDuracionE3.Location.Y)



    End Sub


End Class