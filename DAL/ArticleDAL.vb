Imports System.Data.SqlClient
Imports Entities
Imports Interfaces

Public Class ArticleDAL
    Implements IArticleDAL

    Public Sub InsertArticle(article As Article) Implements IArticleDAL.InsertArticle

        Dim conn As SqlConnection = Nothing

        Dim cmd As SqlCommand = Nothing


        Try

            Dim query As String = "INSERT INTO articulo (idcategoria, codigo, nombre, precio_venta, stock, descripcion, imagen, estado)
                       VALUES (@idcategoria, @codigo, @nombre, @precio_venta, @stock, @descripcion, @imagen, @estado)"

            conn = ConnectionManager.GetConnection()

            cmd = New SqlCommand(query, conn)

            ' Asignar parámetros desde la entidad Article
            cmd.Parameters.AddWithValue("@idcategoria", article.CategoryId)
            cmd.Parameters.AddWithValue("@codigo", article.Code)
            cmd.Parameters.AddWithValue("@nombre", article.Name)
            cmd.Parameters.AddWithValue("@precio_venta", article.SalePrice)
            cmd.Parameters.AddWithValue("@stock", article.Stock)
            cmd.Parameters.AddWithValue("@descripcion", article.Description)
            cmd.Parameters.AddWithValue("@imagen", article.Image)
            cmd.Parameters.AddWithValue("@estado", article.Status)

            cmd.ExecuteNonQuery()


        Catch ex As Exception

            Throw New ApplicationException("Error al guardar el articulo", ex)

        Finally

            If cmd IsNot Nothing Then cmd.Dispose()

        End Try

    End Sub

    Public Sub UpdateArticle(article As Article) Implements IArticleDAL.UpdateArticle

        Dim conn As SqlConnection = Nothing

        Dim cmd As SqlCommand = Nothing

        Try
            conn = ConnectionManager.GetConnection()

            Dim query As String = "UPDATE articulo SET
                               idcategoria = @categoryId,
                               codigo = @code,
                               nombre = @name,
                               precio_venta = @salePrice,
                               stock = @stock,
                               descripcion = @description,
                               imagen = @image,
                               estado = @status
                           WHERE idarticulo = @articleId"

            cmd = New SqlCommand(query, conn)

            ' Parámetros del artículo
            cmd.Parameters.AddWithValue("@articleId", article.ArticleId)
            cmd.Parameters.AddWithValue("@categoryId", article.CategoryId)
            cmd.Parameters.AddWithValue("@code", article.Code)
            cmd.Parameters.AddWithValue("@name", article.Name)
            cmd.Parameters.AddWithValue("@salePrice", article.SalePrice)
            cmd.Parameters.AddWithValue("@stock", article.Stock)
            cmd.Parameters.AddWithValue("@description", article.Description)
            cmd.Parameters.AddWithValue("@image", article.Image)
            cmd.Parameters.AddWithValue("@status", article.Status)

            cmd.ExecuteNonQuery()

        Catch ex As Exception
            Throw New ApplicationException("Ocurrió un error al actualizar el artículo", ex)

        Finally
            If cmd IsNot Nothing Then cmd.Dispose()
        End Try


    End Sub

    Public Sub DeleteArticle(id As Integer) Implements IArticleDAL.DeleteArticle

        Dim conn As SqlConnection = Nothing
        Dim cmd As SqlCommand = Nothing

        Try
            conn = ConnectionManager.GetConnection()

            Dim query As String = "DELETE FROM articulo WHERE idarticulo = @articleId"

            cmd = New SqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@articleId", id)

            cmd.ExecuteNonQuery()

        Catch ex As Exception
            Throw New ApplicationException("Error al eliminar el artículo.", ex)

        Finally
            If cmd IsNot Nothing Then cmd.Dispose()
        End Try

    End Sub

    Public Sub EnableArticle(id As Integer) Implements IArticleDAL.EnableArticle

        Dim conn As SqlConnection = Nothing
        Dim cmd As SqlCommand = Nothing

        Try
            conn = ConnectionManager.GetConnection()

            Dim query As String = "UPDATE articulo SET estado = @state WHERE idarticulo = @articleId"

            cmd = New SqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@articleId", id)
            cmd.Parameters.AddWithValue("@state", 1)

            cmd.ExecuteNonQuery()

        Catch ex As Exception
            Throw New ApplicationException("Ocurrió un error al habilitar el artículo.", ex)

        Finally
            If cmd IsNot Nothing Then cmd.Dispose()
        End Try

    End Sub

    Public Sub DisableArticle(id As Integer) Implements IArticleDAL.DisableArticle

        Dim conn As SqlConnection = Nothing
        Dim cmd As SqlCommand = Nothing

        Try
            conn = ConnectionManager.GetConnection()

            Dim query As String = "UPDATE articulo SET estado = @state WHERE idarticulo = @articleId"

            cmd = New SqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@articleId", id)
            cmd.Parameters.AddWithValue("@state", 0)

            cmd.ExecuteNonQuery()

        Catch ex As Exception
            Throw New ApplicationException("Ocurrió un error al deshabilitar el artículo.", ex)

        Finally
            If cmd IsNot Nothing Then cmd.Dispose()
        End Try

    End Sub

    Public Function GetAll() As List(Of Article) Implements IArticleDAL.GetAll

        Dim articleList As New List(Of Article)
        Dim conn As SqlConnection = Nothing
        Dim cmd As SqlCommand = Nothing
        Dim reader As SqlDataReader = Nothing


        Try

            conn = ConnectionManager.GetConnection()


            Dim query As String = "SELECT idarticulo, idcategoria, codigo, nombre, precio_venta, stock, descripcion, imagen, estado FROM articulo"

            cmd = New SqlCommand(query, conn)


            reader = cmd.ExecuteReader()

            While reader.Read()

                Dim article = New Article()

                article.ArticleId = Convert.ToInt32(reader("idarticulo"))
                article.CategoryId = Convert.ToInt32(reader("idcategoria"))
                article.Code = reader("codigo").ToString()
                article.Name = reader("nombre").ToString()
                article.SalePrice = Convert.ToDecimal(reader("precio_venta"))
                article.Stock = Convert.ToInt32(reader("stock"))
                article.Description = reader("descripcion").ToString()
                article.Image = reader("imagen").ToString()
                article.Status = Convert.ToBoolean(reader("estado"))

                articleList.Add(article)

            End While



        Catch ex As Exception

            Throw New ApplicationException("Error al obtener los datos de los articulos", ex)

        Finally

            If reader IsNot Nothing AndAlso Not reader.IsClosed Then reader.Close()

            If cmd IsNot Nothing Then cmd.Dispose()

        End Try


        Return articleList

    End Function

    Public Function SearchArticle(name As String) As List(Of Article) Implements IArticleDAL.SearchArticle

        Dim articleList As New List(Of Article)
        Dim conn As SqlConnection = Nothing
        Dim cmd As SqlCommand = Nothing
        Dim reader As SqlDataReader = Nothing


        Try

            Dim query As String = "SELECT idarticulo, idcategoria, codigo, nombre, precio_venta, stock, descripcion, imagen, estado
                       FROM articulo 
                       WHERE nombre LIKE @nombre OR descripcion LIKE @descripcion"

            conn = ConnectionManager.GetConnection()

            cmd = New SqlCommand(query, conn)

            cmd.Parameters.AddWithValue("@nombre", "%" & name & "%")
            cmd.Parameters.AddWithValue("@descripcion", "%" & name & "%")

            reader = cmd.ExecuteReader()

            While reader.Read()

                Dim article = New Article()

                article.ArticleId = Convert.ToInt32(reader("idarticulo"))
                article.CategoryId = Convert.ToInt32(reader("idcategoria"))
                article.Code = reader("codigo").ToString()
                article.Name = reader("nombre").ToString()
                article.SalePrice = Convert.ToDecimal(reader("precio_venta"))
                article.Stock = Convert.ToInt32(reader("stock"))
                article.Description = reader("descripcion").ToString()
                article.Image = reader("imagen").ToString()
                article.Status = Convert.ToBoolean(reader("estado"))

                articleList.Add(article)

            End While


        Catch ex As Exception

            Throw New ApplicationException("Error al buscar articulo por nombre.", ex)

        Finally

            If reader IsNot Nothing AndAlso Not reader.IsClosed Then reader.Close()
            If cmd IsNot Nothing Then cmd.Dispose()

        End Try

        Return articleList

    End Function
End Class
