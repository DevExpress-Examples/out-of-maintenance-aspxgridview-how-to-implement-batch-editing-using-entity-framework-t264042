Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Collections.Specialized

Public Class DataBaseHelper

    Private dataBase As northwindEntities

    Public ReadOnly Property CategoryList() As List(Of Category)
        Get
            Return dataBase.Categories.ToList()
        End Get
    End Property

    Public Sub New()
        dataBase = New northwindEntities()
    End Sub

    Public Sub InsertNewItem(ByVal newValues As OrderedDictionary)
        Dim category As New Category()
        LoadNewValues(category, newValues)
        dataBase.Categories.Add(category)
        dataBase.SaveChanges()
    End Sub
	
    Public Sub UpdateItem(ByVal keys As OrderedDictionary, ByVal newValues As OrderedDictionary)
        Dim id As Integer = Convert.ToInt32(keys("CategoryID"))
        Dim category As Category = dataBase.Categories.Where(Function(x) x.CategoryID = id).FirstOrDefault()
        LoadNewValues(category, newValues)
        dataBase.SaveChanges()
    End Sub
	
    Public Sub DeleteItem(ByVal keys As OrderedDictionary, ByVal values As OrderedDictionary)
        Dim id As Integer = Convert.ToInt32(keys("CategoryID"))
        Dim category As Category = dataBase.Categories.Where(Function(x) x.CategoryID = id).FirstOrDefault()
        dataBase.Categories.Remove(category)
        dataBase.SaveChanges()
    End Sub
	
    Protected Sub LoadNewValues(ByVal item As Category, ByVal values As OrderedDictionary)
        item.CategoryName = values("CategoryName").ToString()
        item.Description = values("Description").ToString()
    End Sub
	
End Class