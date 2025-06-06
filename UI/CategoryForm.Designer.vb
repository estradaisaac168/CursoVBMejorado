<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCategory
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
        Me.components = New System.ComponentModel.Container()
        Me.DgvCategories = New System.Windows.Forms.DataGridView()
        Me.Seleccionar = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.TabMain = New System.Windows.Forms.TabControl()
        Me.TabListado = New System.Windows.Forms.TabPage()
        Me.BtnBuscar = New System.Windows.Forms.Button()
        Me.TxtBuscar = New System.Windows.Forms.TextBox()
        Me.LblTotal = New System.Windows.Forms.Label()
        Me.TabManteniento = New System.Windows.Forms.TabPage()
        Me.BtnEdit = New System.Windows.Forms.Button()
        Me.TxtID = New System.Windows.Forms.TextBox()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.TxtDescription = New System.Windows.Forms.TextBox()
        Me.TxtName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.CkbSelect = New System.Windows.Forms.CheckBox()
        Me.BtnDelete = New System.Windows.Forms.Button()
        Me.BtnEnable = New System.Windows.Forms.Button()
        Me.BtnDisable = New System.Windows.Forms.Button()
        CType(Me.DgvCategories, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabMain.SuspendLayout()
        Me.TabListado.SuspendLayout()
        Me.TabManteniento.SuspendLayout()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DgvCategories
        '
        Me.DgvCategories.AllowUserToAddRows = False
        Me.DgvCategories.AllowUserToDeleteRows = False
        Me.DgvCategories.AllowUserToOrderColumns = True
        Me.DgvCategories.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvCategories.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Seleccionar})
        Me.DgvCategories.Location = New System.Drawing.Point(9, 56)
        Me.DgvCategories.Name = "DgvCategories"
        Me.DgvCategories.ReadOnly = True
        Me.DgvCategories.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvCategories.Size = New System.Drawing.Size(847, 270)
        Me.DgvCategories.TabIndex = 0
        '
        'Seleccionar
        '
        Me.Seleccionar.HeaderText = "Seleccionar"
        Me.Seleccionar.Name = "Seleccionar"
        Me.Seleccionar.ReadOnly = True
        '
        'TabMain
        '
        Me.TabMain.Controls.Add(Me.TabListado)
        Me.TabMain.Controls.Add(Me.TabManteniento)
        Me.TabMain.Location = New System.Drawing.Point(12, 12)
        Me.TabMain.Name = "TabMain"
        Me.TabMain.SelectedIndex = 0
        Me.TabMain.Size = New System.Drawing.Size(870, 426)
        Me.TabMain.TabIndex = 1
        '
        'TabListado
        '
        Me.TabListado.Controls.Add(Me.BtnDisable)
        Me.TabListado.Controls.Add(Me.BtnEnable)
        Me.TabListado.Controls.Add(Me.BtnDelete)
        Me.TabListado.Controls.Add(Me.CkbSelect)
        Me.TabListado.Controls.Add(Me.BtnBuscar)
        Me.TabListado.Controls.Add(Me.TxtBuscar)
        Me.TabListado.Controls.Add(Me.LblTotal)
        Me.TabListado.Controls.Add(Me.DgvCategories)
        Me.TabListado.Location = New System.Drawing.Point(4, 22)
        Me.TabListado.Name = "TabListado"
        Me.TabListado.Padding = New System.Windows.Forms.Padding(3)
        Me.TabListado.Size = New System.Drawing.Size(862, 400)
        Me.TabListado.TabIndex = 0
        Me.TabListado.Text = "Listado de categorias"
        Me.TabListado.UseVisualStyleBackColor = True
        '
        'BtnBuscar
        '
        Me.BtnBuscar.Location = New System.Drawing.Point(757, 20)
        Me.BtnBuscar.Name = "BtnBuscar"
        Me.BtnBuscar.Size = New System.Drawing.Size(99, 23)
        Me.BtnBuscar.TabIndex = 3
        Me.BtnBuscar.Text = "Buscar"
        Me.BtnBuscar.UseVisualStyleBackColor = True
        '
        'TxtBuscar
        '
        Me.TxtBuscar.Location = New System.Drawing.Point(447, 22)
        Me.TxtBuscar.Name = "TxtBuscar"
        Me.TxtBuscar.Size = New System.Drawing.Size(288, 20)
        Me.TxtBuscar.TabIndex = 2
        '
        'LblTotal
        '
        Me.LblTotal.AutoSize = True
        Me.LblTotal.Location = New System.Drawing.Point(704, 360)
        Me.LblTotal.Name = "LblTotal"
        Me.LblTotal.Size = New System.Drawing.Size(31, 13)
        Me.LblTotal.TabIndex = 1
        Me.LblTotal.Text = "Total"
        '
        'TabManteniento
        '
        Me.TabManteniento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TabManteniento.Controls.Add(Me.BtnEdit)
        Me.TabManteniento.Controls.Add(Me.TxtID)
        Me.TabManteniento.Controls.Add(Me.BtnSave)
        Me.TabManteniento.Controls.Add(Me.BtnCancel)
        Me.TabManteniento.Controls.Add(Me.TxtDescription)
        Me.TabManteniento.Controls.Add(Me.TxtName)
        Me.TabManteniento.Controls.Add(Me.Label2)
        Me.TabManteniento.Controls.Add(Me.Label1)
        Me.TabManteniento.Location = New System.Drawing.Point(4, 22)
        Me.TabManteniento.Name = "TabManteniento"
        Me.TabManteniento.Padding = New System.Windows.Forms.Padding(3)
        Me.TabManteniento.Size = New System.Drawing.Size(862, 400)
        Me.TabManteniento.TabIndex = 1
        Me.TabManteniento.Text = "Mantenimiento"
        Me.TabManteniento.UseVisualStyleBackColor = True
        '
        'BtnEdit
        '
        Me.BtnEdit.Location = New System.Drawing.Point(127, 289)
        Me.BtnEdit.Name = "BtnEdit"
        Me.BtnEdit.Size = New System.Drawing.Size(99, 45)
        Me.BtnEdit.TabIndex = 7
        Me.BtnEdit.Text = "Actualizar"
        Me.BtnEdit.UseVisualStyleBackColor = True
        '
        'TxtID
        '
        Me.TxtID.Location = New System.Drawing.Point(366, 69)
        Me.TxtID.Name = "TxtID"
        Me.TxtID.Size = New System.Drawing.Size(93, 20)
        Me.TxtID.TabIndex = 6
        Me.TxtID.Visible = False
        '
        'BtnSave
        '
        Me.BtnSave.Location = New System.Drawing.Point(127, 289)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(99, 45)
        Me.BtnSave.TabIndex = 5
        Me.BtnSave.Text = "Insertar"
        Me.BtnSave.UseVisualStyleBackColor = True
        '
        'BtnCancel
        '
        Me.BtnCancel.Location = New System.Drawing.Point(366, 289)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(93, 45)
        Me.BtnCancel.TabIndex = 4
        Me.BtnCancel.Text = "Cancelar"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'TxtDescription
        '
        Me.TxtDescription.Location = New System.Drawing.Point(127, 157)
        Me.TxtDescription.Multiline = True
        Me.TxtDescription.Name = "TxtDescription"
        Me.TxtDescription.Size = New System.Drawing.Size(332, 87)
        Me.TxtDescription.TabIndex = 3
        '
        'TxtName
        '
        Me.TxtName.Location = New System.Drawing.Point(127, 107)
        Me.TxtName.Name = "TxtName"
        Me.TxtName.Size = New System.Drawing.Size(332, 20)
        Me.TxtName.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(35, 160)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Descripcion"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(35, 110)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nombre (*)"
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'CkbSelect
        '
        Me.CkbSelect.AutoSize = True
        Me.CkbSelect.Location = New System.Drawing.Point(9, 356)
        Me.CkbSelect.Name = "CkbSelect"
        Me.CkbSelect.Size = New System.Drawing.Size(82, 17)
        Me.CkbSelect.TabIndex = 4
        Me.CkbSelect.Text = "Seleccionar"
        Me.CkbSelect.UseVisualStyleBackColor = True
        '
        'BtnDelete
        '
        Me.BtnDelete.Location = New System.Drawing.Point(129, 352)
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.Size = New System.Drawing.Size(75, 23)
        Me.BtnDelete.TabIndex = 5
        Me.BtnDelete.Text = "Eliminar"
        Me.BtnDelete.UseVisualStyleBackColor = True
        '
        'BtnEnable
        '
        Me.BtnEnable.Location = New System.Drawing.Point(283, 352)
        Me.BtnEnable.Name = "BtnEnable"
        Me.BtnEnable.Size = New System.Drawing.Size(75, 23)
        Me.BtnEnable.TabIndex = 6
        Me.BtnEnable.Text = "Activar"
        Me.BtnEnable.UseVisualStyleBackColor = True
        '
        'BtnDisable
        '
        Me.BtnDisable.Location = New System.Drawing.Point(388, 352)
        Me.BtnDisable.Name = "BtnDisable"
        Me.BtnDisable.Size = New System.Drawing.Size(75, 23)
        Me.BtnDisable.TabIndex = 7
        Me.BtnDisable.Text = "Desactivar"
        Me.BtnDisable.UseVisualStyleBackColor = True
        '
        'FrmCategory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(894, 450)
        Me.Controls.Add(Me.TabMain)
        Me.Name = "FrmCategory"
        Me.Text = "Categorias"
        CType(Me.DgvCategories, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabMain.ResumeLayout(False)
        Me.TabListado.ResumeLayout(False)
        Me.TabListado.PerformLayout()
        Me.TabManteniento.ResumeLayout(False)
        Me.TabManteniento.PerformLayout()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DgvCategories As DataGridView
    Friend WithEvents TabMain As TabControl
    Friend WithEvents TabListado As TabPage
    Friend WithEvents TabManteniento As TabPage
    Friend WithEvents Seleccionar As DataGridViewCheckBoxColumn
    Friend WithEvents LblTotal As Label
    Friend WithEvents TxtBuscar As TextBox
    Friend WithEvents BtnBuscar As Button
    Friend WithEvents BtnSave As Button
    Friend WithEvents BtnCancel As Button
    Friend WithEvents TxtDescription As TextBox
    Friend WithEvents TxtName As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents TxtID As TextBox
    Friend WithEvents ErrorProvider As ErrorProvider
    Friend WithEvents BtnEdit As Button
    Friend WithEvents BtnDisable As Button
    Friend WithEvents BtnEnable As Button
    Friend WithEvents BtnDelete As Button
    Friend WithEvents CkbSelect As CheckBox
End Class
