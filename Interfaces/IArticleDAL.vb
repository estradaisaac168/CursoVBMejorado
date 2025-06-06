Imports Entities

Public Interface IArticleDAL


    Function GetAll() As List(Of Article)


    Function SearchArticle(name As String) As List(Of Article)


    Sub InsertArticle(category As Article)


    Sub UpdateArticle(category As Article)



    Sub DeleteArticle(id As Integer)


    Sub EnableArticle(id As Integer)



    Sub DisableArticle(id As Integer)


End Interface
