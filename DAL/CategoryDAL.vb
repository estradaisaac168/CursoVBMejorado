Imports System.Data.SqlClient
Imports Entities
Imports Interfaces

Public Class CategoryDAL
    Implements ICategoryDAL

    Public Function GetAll() As List(Of Category) Implements ICategoryDAL.GetAll

        Dim categoryList As New List(Of Category)
        Dim conn As SqlConnection = Nothing
        Dim cmd As SqlCommand = Nothing
        Dim reader As SqlDataReader = Nothing


        Try

            conn = ConnectionManager.GetConnection()


            Dim query As String = "SELECT idcategoria, nombre, descripcion, estado FROM categoria"

            cmd = New SqlCommand(query, conn)


            reader = cmd.ExecuteReader()


            While reader.Read()

                Dim category = New Category()

                category.CategoryId = reader("idcategoria").ToString()
                category.Name = reader("nombre").ToString()
                category.Description = reader("descripcion").ToString()
                category.State = reader("estado").ToString()

                categoryList.Add(category)

            End While


        Catch ex As Exception

            Throw New ApplicationException("Error al obtener los datos de las categorias", ex)

        Finally

            If reader IsNot Nothing AndAlso Not reader.IsClosed Then reader.Close()

            If cmd IsNot Nothing Then cmd.Dispose()

        End Try


        Return categoryList

    End Function



    Public Function SearchCategory(name As String) As List(Of Category) Implements ICategoryDAL.SearchCategory


        Dim categoryList As New List(Of Category)
        Dim conn As SqlConnection = Nothing
        Dim cmd As SqlCommand = Nothing
        Dim reader As SqlDataReader = Nothing


        Try

            Dim query As String = "SELECT idcategoria, nombre, descripcion, estado 
                                    FROM categoria 
                                    WHERE nombre LIKE @nombre OR descripcion LIKE @descripcion"

            conn = ConnectionManager.GetConnection()

            cmd = New SqlCommand(query, conn)

            cmd.Parameters.AddWithValue("@nombre", "%" & name & "%") 'name es el parametro
            cmd.Parameters.AddWithValue("@descripcion", "%" & name & "%") 'name es el parametro

            reader = cmd.ExecuteReader()


            While reader.Read()

                Dim category = New Category()

                category.CategoryId = reader("idcategoria").ToString()
                category.Name = reader("nombre").ToString()
                category.Description = reader("descripcion").ToString()
                category.State = reader("estado").ToString()

                categoryList.Add(category)

            End While

        Catch ex As Exception

            Throw New ApplicationException("Error al buscar categoria por nombre.", ex)

        Finally

            If reader IsNot Nothing AndAlso Not reader.IsClosed Then reader.Close()
            If cmd IsNot Nothing Then cmd.Dispose()

        End Try

        Return categoryList

    End Function



    Public Sub InsertCategory(category As Category) Implements ICategoryDAL.InsertCategory

        Dim conn As SqlConnection = Nothing

        Dim cmd As SqlCommand = Nothing


        Try

            Dim query As String = "INSERT INTO categoria (nombre, descripcion, estado)
                                    VALUES (@name, @description, @state)"

            conn = ConnectionManager.GetConnection()

            cmd = New SqlCommand(query, conn)

            'Importante pasar como parametros los valores que se van a insertar en la base de datos

            cmd.Parameters.AddWithValue("@name", category.Name)
            cmd.Parameters.AddWithValue("@description", category.Description)
            cmd.Parameters.AddWithValue("@state", category.State)


            cmd.ExecuteNonQuery()

        Catch ex As Exception

            Throw New ApplicationException("Error al guardar la categoria", ex)

        Finally

            If cmd IsNot Nothing Then cmd.Dispose()

        End Try


    End Sub
End Class
