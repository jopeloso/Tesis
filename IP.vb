Public Class IP

    Private Sub IP_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MdiParent = Form1

        Dim aux_ip() As String = Form1.IPadres.Split(".")

        txt1.Text = aux_ip(0)
        txt2.Text = aux_ip(1)
        txt3.Text = aux_ip(2)
        txt4.Text = aux_ip(3)

        ordenar_IP()

    End Sub


    Sub ordenar_IP()

        

        Label1.Location = New Point(txt1.Location.X + txt1.Width + 5, txt1.Location.Y)
        txt2.Location = New Point(Label1.Location.X + Label1.Width + 5, txt1.Location.Y)

        Label2.Location = New Point(txt2.Location.X + txt2.Width + 5, txt1.Location.Y)
        txt3.Location = New Point(Label2.Location.X + Label2.Width + 5, txt1.Location.Y)

        Label3.Location = New Point(txt3.Location.X + txt3.Width + 5, txt1.Location.Y)
        txt4.Location = New Point(Label3.Location.X + Label3.Width + 5, txt1.Location.Y)

        botonAceptarIP.Location = New Point(txt1.Location.X, txt1.Location.Y + txt1.Height + 5)
        botonCancelarIP.Location = New Point(txt4.Location.X + txt4.Width - botonCancelarIP.Width, txt1.Location.Y + txt1.Height + 5)

        'antes era 81
        Me.Width = txt4.Location.X + txt4.Width + 50
        Me.Height = botonAceptarIP.Height + botonAceptarIP.Location.Y + 60


    End Sub

    Private Sub txt1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt1.KeyPress
        Dim allowedChars As String = "0123456789"

        If txt1.Text.Length >= 3 Then
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

        'Dim aux_inte As Integer = txt1.Text
        'If txt1.Text > "255" Then

        '    txt1.Text = "255"
        'End If


    End Sub

    Private Sub txt2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt2.KeyPress
        Dim allowedChars As String = "0123456789"

        If txt2.Text.Length >= 3 Then
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

    Private Sub txt3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt3.KeyPress


        Dim allowedChars As String = "0123456789"

        If txt3.Text.Length >= 3 Then
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

    Private Sub txt4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt4.KeyPress
        Dim allowedChars As String = "0123456789"

        If txt4.Text.Length >= 3 Then
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

    Private Sub botonAceptarIP_Click(sender As Object, e As EventArgs) Handles botonAceptarIP.Click

        Dim nuevo_ip As String = txt1.Text & "." & txt2.Text & "." & txt3.Text & "." & txt4.Text

        Form1.SQL.AddParam("@ip", nuevo_ip)
        Form1.SQL.ExecQuery("UPDATE Auxiliar SET IP =@ip  WHERE Id= 1;")
        If Form1.SQL.HasException(True) Then Exit Sub

        MsgBox("Se ha actualizado la IP!")

        Form1.IPadres = nuevo_ip


    End Sub

    Private Sub botonCancelarIP_Click(sender As Object, e As EventArgs) Handles botonCancelarIP.Click
        Me.Close()
    End Sub

    Private Sub IP_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed

        Me.SendToBack()

        
        Form1.Show()
        Form1.BringToFront()
        Form1.TabGeneral.BringToFront()

    End Sub
End Class