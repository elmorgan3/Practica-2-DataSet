<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormListaCP
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
        Me.ListBoxCP = New System.Windows.Forms.ListBox()
        Me.TextBoxBuscar = New System.Windows.Forms.TextBox()
        Me.ButtonCerrar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ButtonEscogerCodigo = New System.Windows.Forms.Button()
        Me.RadioButtonCP = New System.Windows.Forms.RadioButton()
        Me.RadioButtonPoblacion = New System.Windows.Forms.RadioButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ListBoxCP
        '
        Me.ListBoxCP.FormattingEnabled = True
        Me.ListBoxCP.ItemHeight = 16
        Me.ListBoxCP.Location = New System.Drawing.Point(12, 12)
        Me.ListBoxCP.Name = "ListBoxCP"
        Me.ListBoxCP.Size = New System.Drawing.Size(194, 356)
        Me.ListBoxCP.TabIndex = 0
        '
        'TextBoxBuscar
        '
        Me.TextBoxBuscar.Location = New System.Drawing.Point(228, 164)
        Me.TextBoxBuscar.Name = "TextBoxBuscar"
        Me.TextBoxBuscar.Size = New System.Drawing.Size(100, 22)
        Me.TextBoxBuscar.TabIndex = 22
        '
        'ButtonCerrar
        '
        Me.ButtonCerrar.Location = New System.Drawing.Point(427, 345)
        Me.ButtonCerrar.Name = "ButtonCerrar"
        Me.ButtonCerrar.Size = New System.Drawing.Size(75, 30)
        Me.ButtonCerrar.TabIndex = 23
        Me.ButtonCerrar.Text = "Cerrar"
        Me.ButtonCerrar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(228, 144)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 17)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "Filtrar"
        '
        'ButtonEscogerCodigo
        '
        Me.ButtonEscogerCodigo.Location = New System.Drawing.Point(292, 233)
        Me.ButtonEscogerCodigo.Name = "ButtonEscogerCodigo"
        Me.ButtonEscogerCodigo.Size = New System.Drawing.Size(99, 48)
        Me.ButtonEscogerCodigo.TabIndex = 25
        Me.ButtonEscogerCodigo.Text = "Escoger codigo"
        Me.ButtonEscogerCodigo.UseVisualStyleBackColor = True
        '
        'RadioButtonCP
        '
        Me.RadioButtonCP.AutoSize = True
        Me.RadioButtonCP.Checked = True
        Me.RadioButtonCP.Location = New System.Drawing.Point(9, 38)
        Me.RadioButtonCP.Name = "RadioButtonCP"
        Me.RadioButtonCP.Size = New System.Drawing.Size(115, 21)
        Me.RadioButtonCP.TabIndex = 26
        Me.RadioButtonCP.TabStop = True
        Me.RadioButtonCP.Text = "Codigo postal"
        Me.RadioButtonCP.UseVisualStyleBackColor = True
        '
        'RadioButtonPoblacion
        '
        Me.RadioButtonPoblacion.AutoSize = True
        Me.RadioButtonPoblacion.Location = New System.Drawing.Point(9, 65)
        Me.RadioButtonPoblacion.Name = "RadioButtonPoblacion"
        Me.RadioButtonPoblacion.Size = New System.Drawing.Size(91, 21)
        Me.RadioButtonPoblacion.TabIndex = 27
        Me.RadioButtonPoblacion.Text = "Población"
        Me.RadioButtonPoblacion.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 17)
        Me.Label2.TabIndex = 28
        Me.Label2.Text = "Filtrar"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.RadioButtonCP)
        Me.GroupBox1.Controls.Add(Me.RadioButtonPoblacion)
        Me.GroupBox1.Location = New System.Drawing.Point(231, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(200, 100)
        Me.GroupBox1.TabIndex = 29
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Ordenar por"
        '
        'FormListaCP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(514, 387)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ButtonEscogerCodigo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ButtonCerrar)
        Me.Controls.Add(Me.TextBoxBuscar)
        Me.Controls.Add(Me.ListBoxCP)
        Me.Name = "FormListaCP"
        Me.Text = "FormListaCP"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ListBoxCP As ListBox
    Friend WithEvents TextBoxBuscar As TextBox
    Friend WithEvents ButtonCerrar As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents ButtonEscogerCodigo As Button
    Friend WithEvents RadioButtonCP As RadioButton
    Friend WithEvents RadioButtonPoblacion As RadioButton
    Friend WithEvents Label2 As Label
    Friend WithEvents GroupBox1 As GroupBox
End Class
