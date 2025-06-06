Imports Entities

Public Interface IArticleBLL

    Function GetAll() As List(Of Article)

    Function SearchArticle(name As String) As List(Of Article)


    Function InsertArticle(category As Article) As Boolean


    Function UpdateArticle(category As Article) As Boolean


    Function DeleteArticle(id As Integer) As Boolean


    Function EnableArticle(id As Integer) As Boolean



    Function DisableArticle(id As Integer) As Boolean

End Interface
