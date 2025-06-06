Imports BLL
Imports Entities

Public Class ArticleForm

    Private _articleBLL As New ArticleBLL


    Private Sub Format()
        'DgvArticles.Columns(0).Visible = False
        'DgvArticles.Columns(2).Visible = False
        'DgvArticles.Columns(0).Width = 100
        'DgvArticles.Columns(1).Width = 100
        'DgvArticles.Columns(3).Width = 100
        'DgvArticles.Columns(4).Width = 100
        'DgvArticles.Columns(5).Width = 150
        'DgvArticles.Columns(6).Width = 100
        'DgvArticles.Columns(7).Width = 100
        'DgvArticles.Columns(8).Width = 200
        'DgvArticles.Columns(9).Width = 100
        'DgvArticles.Columns(10).Width = 100

    End Sub


    Private Sub ArticleForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadArticleData()
    End Sub



    Private Sub LoadArticleData()

        Try

            Dim articles As List(Of Article) = _articleBLL.GetAll()

            DgvArticles.DataSource = articles 'DataSource asigno el listado de las categorias

            LblTotal.Text = "Total de registros: " & articles.Count


            Me.Format() 'Metodo que me da el formato
            'Me.Clear()

        Catch ex As Exception
            MessageBox.Show("Error al cargar los articulos: " & ex.Message)
        End Try

    End Sub


End Class