Imports DAL
Imports Entities
Imports Interfaces

Public Class ArticleBLL
    Implements IArticleBLL

    Private ReadOnly _articleDal As IArticleDAL


    Public Sub New()

        _articleDal = New ArticleDAL

    End Sub

    Public Function GetAll() As List(Of Article) Implements IArticleBLL.GetAll

        Return _articleDal.GetAll()

    End Function

    Public Function SearchArticle(name As String) As List(Of Article) Implements IArticleBLL.SearchArticle
        Throw New NotImplementedException()
    End Function

    Public Function InsertArticle(category As Article) As Boolean Implements IArticleBLL.InsertArticle
        Throw New NotImplementedException()
    End Function

    Public Function UpdateArticle(category As Article) As Boolean Implements IArticleBLL.UpdateArticle
        Throw New NotImplementedException()
    End Function

    Public Function DeleteArticle(id As Integer) As Boolean Implements IArticleBLL.DeleteArticle
        Throw New NotImplementedException()
    End Function

    Public Function EnableArticle(id As Integer) As Boolean Implements IArticleBLL.EnableArticle
        Throw New NotImplementedException()
    End Function

    Public Function DisableArticle(id As Integer) As Boolean Implements IArticleBLL.DisableArticle
        Throw New NotImplementedException()
    End Function
End Class
