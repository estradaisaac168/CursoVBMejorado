Imports System.Data.SqlClient

Public Class ConnectionManager

    Private Shared _connection As SqlConnection 'Declaro una variable de tipo SqlConnection


    Public Shared Function GetConnection() As SqlConnection

        If _connection Is Nothing Then



            'Dim connectionString As String = "Data Source=DESKTOP-JSC6DST\SQLEXPRESS;Initial Catalog=db_sistemas;User ID=sa;Password=Coco14.negrita90;TrustServerCertificate=True"
            Dim connectionString As String = "Data Source=PC01548;Initial Catalog=db_sistemas;User ID=sa;Password=Coco14.negrita90;TrustServerCertificate=True"

            _connection = New SqlConnection(connectionString)

        End If


        If _connection.State <> ConnectionState.Open Then _connection.Open() 'Abro conexion si no esta abierta

        Return _connection 'Retorno la conexion abierta

    End Function


    Public Shared Sub CloseConnection()

        If _connection IsNot Nothing AndAlso _connection.State <> ConnectionState.Closed Then
            _connection.Close()
            _connection = Nothing
        End If

    End Sub


End Class
