<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Interfaz
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnConectada = New System.Windows.Forms.Button()
        Me.btnDesconectada = New System.Windows.Forms.Button()
        Me.btnConectadaUna = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnConectada
        '
        Me.btnConectada.Location = New System.Drawing.Point(153, 95)
        Me.btnConectada.Name = "btnConectada"
        Me.btnConectada.Size = New System.Drawing.Size(158, 23)
        Me.btnConectada.TabIndex = 0
        Me.btnConectada.Text = "Conectado Ejercicio 3"
        Me.btnConectada.UseMnemonic = False
        Me.btnConectada.UseVisualStyleBackColor = True
        '
        'btnDesconectada
        '
        Me.btnDesconectada.Location = New System.Drawing.Point(153, 137)
        Me.btnDesconectada.Name = "btnDesconectada"
        Me.btnDesconectada.Size = New System.Drawing.Size(158, 23)
        Me.btnDesconectada.TabIndex = 1
        Me.btnDesconectada.Text = "Desconectada Ejercicio 6"
        Me.btnDesconectada.UseVisualStyleBackColor = True
        '
        'btnConectadaUna
        '
        Me.btnConectadaUna.Location = New System.Drawing.Point(153, 52)
        Me.btnConectadaUna.Name = "btnConectadaUna"
        Me.btnConectadaUna.Size = New System.Drawing.Size(158, 23)
        Me.btnConectadaUna.TabIndex = 2
        Me.btnConectadaUna.Text = "Conectada Ejercio 1"
        Me.btnConectadaUna.UseVisualStyleBackColor = True
        '
        'Interfaz
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(498, 261)
        Me.Controls.Add(Me.btnConectadaUna)
        Me.Controls.Add(Me.btnDesconectada)
        Me.Controls.Add(Me.btnConectada)
        Me.Name = "Interfaz"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnConectada As Button
    Friend WithEvents btnDesconectada As Button
    Friend WithEvents btnConectadaUna As Button
End Class
