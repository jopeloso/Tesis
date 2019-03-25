Public Class Contraseña

    Private Sub Contraseña_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MdiParent = Form1
        ' Form1.pass_aux = ""
    End Sub


    Private Sub botonAceptarPass_Click(sender As Object, e As EventArgs) Handles botonAceptarPass.Click
        Form1.pass_aux = txtPassword.Text

        If Form1.pass_aux = Form1.passwordP Then
            Form1.Mostrar_personal()
            Form1.pass_aux = ""
            Form1.pass_correcta = True
        Else
            Form1.esconder_personal()
            Form1.pass_aux = ""
            txtPassword.Text = ""
            Form1.pass_correcta = False
            Exit Sub
        End If


        Me.Close()
    End Sub

    Private Sub Contraseña_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.SendToBack()

        Form1.BringToFront()
        Form1.TabGeneral.BringToFront()
        If Form1.pass_correcta = False Then
            Form1.TabGeneral.SelectedIndex = 0
            Form1.Esconder_personal()

        End If

    End Sub

   
    Private Sub txtPassword_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPassword.KeyDown
        If e.KeyCode = Keys.Enter Then
            Form1.pass_aux = txtPassword.Text

            If Form1.pass_aux = Form1.passwordP Then
                Form1.Mostrar_personal()
                Form1.pass_aux = ""
                Form1.pass_correcta = True
            Else
                Form1.esconder_personal()
                Form1.pass_aux = ""
                txtPassword.Text = ""
                Form1.pass_correcta = False
                Exit Sub
            End If


            Me.Close()
        End If
    End Sub

    Private Sub botonCancelarPass_Click(sender As Object, e As EventArgs) Handles botonCancelarPass.Click
        Me.Close()

        Form1.TabGeneral.SelectedIndex = 0
    End Sub
End Class