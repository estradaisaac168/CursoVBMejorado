Imports Entities

Public Interface ICategoryDAL

    Function GetAll() As List(Of Category)


    Function SearchCategory(name As String) As List(Of Category)


    Sub InsertCategory(category As Category)

End Interface
