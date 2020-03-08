Imports System.Web.Mvc

Public Class UserVM

    Private _id As Integer
    Private _email As String
    Public Name As String
    Public Age As String
    Public Roles As List(Of String)
    Public ReadOnly Property ID() As String
        Get

            Return _email
        End Get

    End Property
    Public Property Email() As String
        Get

            Return _email
        End Get
        Set(ByVal value As String)
            If value.Contains("@") Then
                _email = value
            End If

        End Set
    End Property



    Public Sub New()


    End Sub
    Public Sub New(id As Integer, name As String, email As String, age As String, roles As List(Of String))
        Me._id = id
        Me.Roles = roles
        Me.Name = name
        Me.Email = email
        Me.Age = age
    End Sub
    Public Sub New(collection As FormCollection)

        Me.Name = collection("Name")
        Me.Email = collection("Email")
        Me.Age = collection("Age")

    End Sub


    Public Overrides Function ToString() As String
        Return String.Format("Welcome {0}", Me.Name)
    End Function
End Class