Imports Entities

Public Interface ICategoryBLL

    Function GetAll() As List(Of Category)

    Function SearchCategory(name As String) As List(Of Category)


    Function InsertCategory(category As Category) As Boolean


    Function UpdateCategory(category As Category) As Boolean


    Function DeleteCategory(id As Integer) As Boolean


    Function EnableCategory(id As Integer) As Boolean



    Function DisableCategory(id As Integer) As Boolean



End Interface
