Imports BLL
Imports Entities

Public Class FrmCategory

    Private _categoryBLL As New CategoryBLL



    Private Sub Format()

        DgvCategories.Columns(0).Visible = False
        DgvCategories.Columns(0).Width = 100
        DgvCategories.Columns(1).Width = 100
        DgvCategories.Columns(2).Width = 150
        DgvCategories.Columns(3).Width = 400
        DgvCategories.Columns(4).Width = 100

    End Sub



    Private Sub CategoryForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadCategoryData()
    End Sub

    Private Sub LoadCategoryData()

        Try

            Dim categories As List(Of Category) = _categoryBLL.GetAll()

            DgvCategories.DataSource = categories 'DataSource asigno el listado de las categorias

            LblTotal.Text = "Total de registros: " & categories.Count


            Me.Format() 'Metodo que me da el formato

        Catch ex As Exception
            MessageBox.Show("Error al cargar clientes: " & ex.Message)
        End Try

    End Sub



    Private Sub SearchCategory()

        Try
            Dim value As String = TxtBuscar.Text.Trim()

            If value Is Nothing OrElse value Is "" Then MessageBox.Show("Ingresa un nombre para buscar")

            Dim categories As List(Of Category) = _categoryBLL.SearchCategory(value)


            DgvCategories.DataSource = categories 'DataSource asigno el listado de las categorias

            LblTotal.Text = "Total de registros: " & categories.Count


            Me.Format() 'Metodo que me da el formato

        Catch ex As Exception
            MessageBox.Show("Error al cargar clientes: " & ex.Message)
        End Try

    End Sub



    Private Sub Clear()

        BtnSave.Visible = True
        TxtBuscar.Text = ""
        TxtID.Text = ""
        TxtName.Text = ""
        TxtDescription.Text = ""

    End Sub


    Private Sub BtnBuscar_Click(sender As Object, e As EventArgs) Handles BtnBuscar.Click

        SearchCategory()

    End Sub



    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click

        Clear() 'Con este metodo limpio las cajas de texto

        TabMain.SelectedIndex = 0 'Con esto me redirecciona al indice del primer tab

    End Sub



    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click


        If Me.ValidateChildren = True And TxtName.Text.Trim() <> "" Then

            Dim category As New Category()

            category.Name = TxtName.Text.Trim()
            category.Description = TxtDescription.Text.Trim()
            category.State = True


            If _categoryBLL.InsertCategory(category) Then

                MsgBox("Se ha guardado la categoria ", vbOKOnly + vbInformation, "Registro correcto")

                Clear() 'Limpiar los campos

                LoadCategoryData() 'Cargo la lista con las categorias

            Else

                MsgBox("Se ha guardado la categoria ", vbOKOnly + vbCritical, "Registro incorrecto")

            End If

        Else

            MsgBox("Los campos que tiene (*) son obligatorios", vbOKOnly + vbCritical, "Falta ingresar datos")

        End If

    End Sub



    Private Sub TxtName_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TxtName.Validating

        'Con este elemento podemos generar una alerta para que el usuario pueda ver cuales son los campos que debe de rellenar.
        'En los eventos del textbox seleccionar en validating y esto genera el metodo.

        If DirectCast(sender, TextBox).Text.Length > 0 Then
            Me.ErrorProvider.SetError(sender, "")

        Else
            Me.ErrorProvider.SetError(sender, "Ingrese el nombre de la categoria por favor")
        End If

    End Sub


    'Este metodo se genera en los eventos de DataGridView en la parte de CellDoubleClick
    Private Sub DgvCategories_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvCategories.CellDoubleClick

        'En los atributos de datagrid en SelectionMode = FullRowSelect para que seleccione toda la fila

        TxtID.Text = DgvCategories.SelectedCells.Item(1).Value 'Con esta instruccion obtengo los datos del datagrid y los asigno a mi variable.
        TxtName.Text = DgvCategories.SelectedCells.Item(2).Value
        TxtDescription.Text = DgvCategories.SelectedCells.Item(3).Value



    End Sub
End Class
