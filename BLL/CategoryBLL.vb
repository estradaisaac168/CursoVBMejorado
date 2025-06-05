Imports DAL
Imports Entities
Imports Interfaces

Public Class CategoryBLL
    Implements ICategoryBLL

    Private ReadOnly _categoryDal As ICategoryDAL


    Public Sub New()
        _categoryDal = New CategoryDAL
    End Sub


    Public Function GetAll() As List(Of Category) Implements ICategoryBLL.GetAll
        Return _categoryDal.GetAll()
    End Function



    Public Function SearchCategory(name As String) As List(Of Category) Implements ICategoryBLL.SearchCategory
        Return _categoryDal.SearchCategory(name)
    End Function


    Public Function InsertCategory(category As Category) As Boolean Implements ICategoryBLL.InsertCategory

        If category Is Nothing Then Throw New ApplicationException("La categoria esta vacia")

        _categoryDal.InsertCategory(category)

        Return True

    End Function
End Class
