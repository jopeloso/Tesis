<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Login
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Login))
        Me.botonCancelarPass = New System.Windows.Forms.Button()
        Me.botonAceptarPass = New System.Windows.Forms.Button()
        Me.txtUsuario = New System.Windows.Forms.TextBox()
        Me.LabelUsuario = New System.Windows.Forms.Label()
        Me.LabelContraseña = New System.Windows.Forms.Label()
        Me.txtContraseña = New System.Windows.Forms.TextBox()
        Me.LabelFallo = New System.Windows.Forms.Label()
        Me.DGVLogin = New System.Windows.Forms.DataGridView()
        CType(Me.DGVLogin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'botonCancelarPass
        '
        Me.botonCancelarPass.Location = New System.Drawing.Point(213, 154)
        Me.botonCancelarPass.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.botonCancelarPass.Name = "botonCancelarPass"
        Me.botonCancelarPass.Size = New System.Drawing.Size(113, 33)
        Me.botonCancelarPass.TabIndex = 3
        Me.botonCancelarPass.Text = "Cancelar"
        Me.botonCancelarPass.UseVisualStyleBackColor = True
        '
        'botonAceptarPass
        '
        Me.botonAceptarPass.Location = New System.Drawing.Point(31, 154)
        Me.botonAceptarPass.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.botonAceptarPass.Name = "botonAceptarPass"
        Me.botonAceptarPass.Size = New System.Drawing.Size(113, 33)
        Me.botonAceptarPass.TabIndex = 2
        Me.botonAceptarPass.Text = "Aceptar"
        Me.botonAceptarPass.UseVisualStyleBackColor = True
        '
        'txtUsuario
        '
        Me.txtUsuario.Location = New System.Drawing.Point(31, 56)
        Me.txtUsuario.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.Size = New System.Drawing.Size(295, 26)
        Me.txtUsuario.TabIndex = 0
        '
        'LabelUsuario
        '
        Me.LabelUsuario.AutoSize = True
        Me.LabelUsuario.ImageAlign = System.Drawing.ContentAlignment.TopRight
        Me.LabelUsuario.Location = New System.Drawing.Point(28, 34)
        Me.LabelUsuario.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.LabelUsuario.Name = "LabelUsuario"
        Me.LabelUsuario.Size = New System.Drawing.Size(75, 18)
        Me.LabelUsuario.TabIndex = 4
        Me.LabelUsuario.Text = "Usuario:"
        '
        'LabelContraseña
        '
        Me.LabelContraseña.AutoSize = True
        Me.LabelContraseña.ImageAlign = System.Drawing.ContentAlignment.TopRight
        Me.LabelContraseña.Location = New System.Drawing.Point(30, 96)
        Me.LabelContraseña.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.LabelContraseña.Name = "LabelContraseña"
        Me.LabelContraseña.Size = New System.Drawing.Size(107, 18)
        Me.LabelContraseña.TabIndex = 8
        Me.LabelContraseña.Text = "Contraseña:"
        '
        'txtContraseña
        '
        Me.txtContraseña.Location = New System.Drawing.Point(31, 118)
        Me.txtContraseña.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txtContraseña.Name = "txtContraseña"
        Me.txtContraseña.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtContraseña.Size = New System.Drawing.Size(295, 26)
        Me.txtContraseña.TabIndex = 1
        Me.txtContraseña.UseSystemPasswordChar = True
        '
        'LabelFallo
        '
        Me.LabelFallo.AutoSize = True
        Me.LabelFallo.Location = New System.Drawing.Point(30, 16)
        Me.LabelFallo.Name = "LabelFallo"
        Me.LabelFallo.Size = New System.Drawing.Size(0, 18)
        Me.LabelFallo.TabIndex = 10
        '
        'DGVLogin
        '
        Me.DGVLogin.AllowUserToAddRows = False
        Me.DGVLogin.AllowUserToDeleteRows = False
        Me.DGVLogin.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVLogin.Enabled = False
        Me.DGVLogin.Location = New System.Drawing.Point(530, 177)
        Me.DGVLogin.Name = "DGVLogin"
        Me.DGVLogin.ReadOnly = True
        Me.DGVLogin.RowHeadersVisible = False
        Me.DGVLogin.RowHeadersWidth = 4
        Me.DGVLogin.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DGVLogin.Size = New System.Drawing.Size(34, 24)
        Me.DGVLogin.TabIndex = 125
        Me.DGVLogin.Visible = False
        '
        'Login
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(360, 213)
        Me.Controls.Add(Me.DGVLogin)
        Me.Controls.Add(Me.LabelFallo)
        Me.Controls.Add(Me.txtContraseña)
        Me.Controls.Add(Me.LabelContraseña)
        Me.Controls.Add(Me.botonCancelarPass)
        Me.Controls.Add(Me.botonAceptarPass)
        Me.Controls.Add(Me.txtUsuario)
        Me.Controls.Add(Me.LabelUsuario)
        Me.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(376, 252)
        Me.Name = "Login"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Login"
        CType(Me.DGVLogin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents botonCancelarPass As System.Windows.Forms.Button
    Friend WithEvents botonAceptarPass As System.Windows.Forms.Button
    Friend WithEvents txtUsuario As System.Windows.Forms.TextBox
    Friend WithEvents LabelUsuario As System.Windows.Forms.Label
    Friend WithEvents LabelContraseña As System.Windows.Forms.Label
    Friend WithEvents txtContraseña As System.Windows.Forms.TextBox
    Friend WithEvents LabelFallo As System.Windows.Forms.Label
    Friend WithEvents DGVLogin As System.Windows.Forms.DataGridView
End Class
