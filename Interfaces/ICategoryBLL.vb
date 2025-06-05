Imports Entities

Public Interface ICategoryBLL

    Function GetAll() As List(Of Category)

    Function SearchCategory(name As String) As List(Of Category)


    Function InsertCategory(category As Category) As Boolean

End Interface
