﻿Imports System.Data.SqlClient
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



    Public Sub UpdateCategory(category As Category) Implements ICategoryDAL.UpdateCategory

        Dim conn As SqlConnection = Nothing

        Dim cmd As SqlCommand = Nothing

        Try

            conn = ConnectionManager.GetConnection()

            Dim query As String = "UPDATE categoria SET
                                        nombre = @name,
                                        descripcion = @description
                                   WHERE idcategoria = @categoryId"

            cmd = New SqlCommand(query, conn)


            'Params
            cmd.Parameters.AddWithValue("@categoryId", category.CategoryId)
            cmd.Parameters.AddWithValue("@name", category.Name)
            cmd.Parameters.AddWithValue("@description", category.Description)


            cmd.ExecuteNonQuery()

        Catch ex As Exception

            Throw New ApplicationException("Ocurrio un error al actualizar la categoria", ex)

        Finally

            If cmd IsNot Nothing Then cmd.Dispose()

        End Try

    End Sub



    Public Sub DeleteCategory(id As Integer) Implements ICategoryDAL.DeleteCategory

        Dim conn As SqlConnection = Nothing

        Dim cmd As SqlCommand = Nothing

        Try

            conn = ConnectionManager.GetConnection()

            Dim query As String = "DELETE FROM categoria WHERE idcategoria = @categoryId"

            cmd = New SqlCommand(query, conn)

            cmd.Parameters.AddWithValue("@categoryId", id)

            cmd.ExecuteNonQuery()

        Catch ex As Exception

            Throw New ApplicationException("Error al eliminar la categoria.", ex)

        Finally

            If cmd IsNot Nothing Then cmd.Dispose()

        End Try


    End Sub



    Public Sub EnableCategory(id As Integer) Implements ICategoryDAL.EnableCategory

        Dim conn As SqlConnection = Nothing

        Dim cmd As SqlCommand = Nothing

        Try

            conn = ConnectionManager.GetConnection()

            Dim query As String = "UPDATE categoria SET
                                        estado = @state
                                   WHERE idcategoria = @categoryId"

            cmd = New SqlCommand(query, conn)


            'Params
            cmd.Parameters.AddWithValue("@categoryId", id)
            cmd.Parameters.AddWithValue("@state", 1)


            cmd.ExecuteNonQuery()

        Catch ex As Exception

            Throw New ApplicationException("Ocurrio un error al actualizar la categoria", ex)

        Finally

            If cmd IsNot Nothing Then cmd.Dispose()

        End Try

    End Sub



    Public Sub DisableCategory(id As Integer) Implements ICategoryDAL.DisableCategory


        Dim conn As SqlConnection = Nothing

        Dim cmd As SqlCommand = Nothing

        Try

            conn = ConnectionManager.GetConnection()

            Dim query As String = "UPDATE categoria SET
                                        estado = @state
                                   WHERE idcategoria = @categoryId"

            cmd = New SqlCommand(query, conn)


            'Params
            cmd.Parameters.AddWithValue("@categoryId", id)
            cmd.Parameters.AddWithValue("@state", 0)


            cmd.ExecuteNonQuery()

        Catch ex As Exception

            Throw New ApplicationException("Ocurrio un error al actualizar la categoria", ex)

        Finally

            If cmd IsNot Nothing Then cmd.Dispose()

        End Try

    End Sub



End Class
