<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IP
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(IP))
        Me.txt1 = New System.Windows.Forms.TextBox()
        Me.txt2 = New System.Windows.Forms.TextBox()
        Me.txt3 = New System.Windows.Forms.TextBox()
        Me.txt4 = New System.Windows.Forms.TextBox()
        Me.botonCancelarIP = New System.Windows.Forms.Button()
        Me.botonAceptarIP = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txt1
        '
        Me.txt1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt1.Location = New System.Drawing.Point(17, 13)
        Me.txt1.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txt1.Name = "txt1"
        Me.txt1.Size = New System.Drawing.Size(81, 26)
        Me.txt1.TabIndex = 0
        '
        'txt2
        '
        Me.txt2.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt2.Location = New System.Drawing.Point(130, 39)
        Me.txt2.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txt2.Name = "txt2"
        Me.txt2.Size = New System.Drawing.Size(81, 26)
        Me.txt2.TabIndex = 1
        '
        'txt3
        '
        Me.txt3.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt3.Location = New System.Drawing.Point(243, 39)
        Me.txt3.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txt3.Name = "txt3"
        Me.txt3.Size = New System.Drawing.Size(81, 26)
        Me.txt3.TabIndex = 2
        '
        'txt4
        '
        Me.txt4.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt4.Location = New System.Drawing.Point(357, 39)
        Me.txt4.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txt4.Name = "txt4"
        Me.txt4.Size = New System.Drawing.Size(81, 26)
        Me.txt4.TabIndex = 3
        '
        'botonCancelarIP
        '
        Me.botonCancelarIP.Location = New System.Drawing.Point(265, 113)
        Me.botonCancelarIP.Margin = New System.Windows.Forms.Padding(8, 6, 8, 6)
        Me.botonCancelarIP.Name = "botonCancelarIP"
        Me.botonCancelarIP.Size = New System.Drawing.Size(188, 46)
        Me.botonCancelarIP.TabIndex = 9
        Me.botonCancelarIP.Text = "Cancelar"
        Me.botonCancelarIP.UseVisualStyleBackColor = True
        '
        'botonAceptarIP
        '
        Me.botonAceptarIP.Location = New System.Drawing.Point(17, 113)
        Me.botonAceptarIP.Margin = New System.Windows.Forms.Padding(8, 6, 8, 6)
        Me.botonAceptarIP.Name = "botonAceptarIP"
        Me.botonAceptarIP.Size = New System.Drawing.Size(188, 46)
        Me.botonAceptarIP.TabIndex = 8
        Me.botonAceptarIP.Text = "Aceptar"
        Me.botonAceptarIP.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(138, 223)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(13, 18)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(240, 223)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(13, 18)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "."
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(322, 201)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(13, 18)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "."
        '
        'IP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ClientSize = New System.Drawing.Size(640, 292)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.botonCancelarIP)
        Me.Controls.Add(Me.botonAceptarIP)
        Me.Controls.Add(Me.txt4)
        Me.Controls.Add(Me.txt3)
        Me.Controls.Add(Me.txt2)
        Me.Controls.Add(Me.txt1)
        Me.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "IP"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "IP"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txt1 As System.Windows.Forms.TextBox
    Friend WithEvents txt2 As System.Windows.Forms.TextBox
    Friend WithEvents txt3 As System.Windows.Forms.TextBox
    Friend WithEvents txt4 As System.Windows.Forms.TextBox
    Friend WithEvents botonCancelarIP As System.Windows.Forms.Button
    Friend WithEvents botonAceptarIP As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
