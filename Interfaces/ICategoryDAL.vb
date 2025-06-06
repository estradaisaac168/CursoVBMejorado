Imports Entities

Public Interface ICategoryDAL

    Function GetAll() As List(Of Category)


    Function SearchCategory(name As String) As List(Of Category)


    Sub InsertCategory(category As Category)


    Sub UpdateCategory(category As Category)



    Sub DeleteCategory(id As Integer)


    Sub EnableCategory(id As Integer)



    Sub DisableCategory(id As Integer)




End Interface
