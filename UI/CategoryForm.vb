Imports System.Security.Authentication.ExtendedProtection
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




        DgvCategories.Columns.Item("Seleccionar").Visible = False

        BtnDelete.Visible = False

        BtnEnable.Visible = False

        BtnDisable.Visible = False

        CkbSelect.CheckState = False


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
            Me.Clear()

        Catch ex As Exception
            MessageBox.Show("Error al cargar las categorias: " & ex.Message)
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
        BtnEdit.Visible = False
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

        BtnSave.Visible = False

        BtnEdit.Visible = True


        TabMain.SelectedIndex = 1 'Paso al tab de mantenimiento

    End Sub




    Private Sub BtnEdit_Click(sender As Object, e As EventArgs) Handles BtnEdit.Click


        If Me.ValidateChildren = True And TxtName.Text.Trim() <> "" And TxtID.Text <> "" Then

            Dim category As New Category()

            category.CategoryId = TxtID.Text.Trim()
            category.Name = TxtName.Text.Trim()
            category.Description = TxtDescription.Text.Trim()
            category.State = True


            If _categoryBLL.UpdateCategory(category) Then

                MsgBox("Se ha actualizado la categoria ", vbOKOnly + vbInformation, "Actualizacion correcta")

                LoadCategoryData() 'Cargo la lista con las categorias

                TabMain.SelectedIndex = 0

            Else

                MsgBox("No se ha actualizado la categoria ", vbOKOnly + vbCritical, "Actualizacion incorrecta")

            End If

        Else

            MsgBox("Los campos que tiene (*) son obligatorios", vbOKOnly + vbCritical, "Falta ingresar datos")

        End If


    End Sub



    Private Sub CkbSelect_CheckedChanged(sender As Object, e As EventArgs) Handles CkbSelect.CheckedChanged


        If CkbSelect.CheckState = CheckState.Checked Then 'Si el check esta seleccionado

            DgvCategories.Columns.Item("Seleccionar").Visible = True

            BtnDelete.Visible = True

            BtnEnable.Visible = True

            BtnDisable.Visible = True

        Else

            DgvCategories.Columns.Item("Seleccionar").Visible = False

            BtnDelete.Visible = False

            BtnEnable.Visible = False

            BtnDisable.Visible = False

        End If

    End Sub



    'Evento de dar click en una celda del datagridview
    Private Sub DgvCategories_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvCategories.CellContentClick


        'e.ColumnIndex = me devuelve el indice de la columan en donde se encuentra la celda clickeada

        'DgvCategories.Columns.Item("Seleccionar").Index = Obteno el indice de la columna click


        If e.ColumnIndex = DgvCategories.Columns.Item("Seleccionar").Index Then

            Dim chkCell As DataGridViewCheckBoxCell = DgvCategories.Rows(e.RowIndex).Cells("Seleccionar")

            chkCell.Value = Not chkCell.Value

        End If

    End Sub



    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click

        If (MsgBox("Estas seguro de eliminar los registros seleccionados?", vbYesNo + vbQuestion, "Eliminar registros") = vbYes) Then

            Try

                For Each row As DataGridViewRow In DgvCategories.Rows

                    Dim marked As Boolean = Convert.ToBoolean(row.Cells("Seleccionar").Value)

                    If marked Then

                        Dim oneKey As Integer = Convert.ToInt32(row.Cells("CategoryID").Value)

                        _categoryBLL.DeleteCategory(oneKey)

                    End If

                Next

                Me.LoadCategoryData()

            Catch ex As Exception

                MsgBox(ex.Message())

            End Try

        End If

    End Sub




    Private Sub BtnEnable_Click(sender As Object, e As EventArgs) Handles BtnEnable.Click
        If (MsgBox("Estas seguro de activar los registros seleccionados?", vbYesNo + vbQuestion, "Activar registros") = vbYes) Then

            Try

                For Each row As DataGridViewRow In DgvCategories.Rows

                    Dim marked As Boolean = Convert.ToBoolean(row.Cells("Seleccionar").Value)

                    If marked Then

                        Dim oneKey As Integer = Convert.ToInt32(row.Cells("CategoryID").Value)

                        _categoryBLL.EnableCategory(oneKey)

                    End If

                Next

                Me.LoadCategoryData()

            Catch ex As Exception

                MsgBox(ex.Message())

            End Try

        End If
    End Sub




    Private Sub BtnDisable_Click(sender As Object, e As EventArgs) Handles BtnDisable.Click
        If (MsgBox("Estas seguro de desactivar los registros seleccionados?", vbYesNo + vbQuestion, "Desactivar registros") = vbYes) Then

            Try

                For Each row As DataGridViewRow In DgvCategories.Rows

                    Dim marked As Boolean = Convert.ToBoolean(row.Cells("Seleccionar").Value)

                    If marked Then

                        Dim oneKey As Integer = Convert.ToInt32(row.Cells("CategoryID").Value)

                        _categoryBLL.DisableCategory(oneKey)

                    End If

                Next

                Me.LoadCategoryData()

            Catch ex As Exception

                MsgBox(ex.Message())

            End Try

        End If
    End Sub
End Class
