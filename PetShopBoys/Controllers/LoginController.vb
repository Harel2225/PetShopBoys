Imports System.Web.Mvc

Namespace Controllers
    Public Class LoginController
        Inherits Controller

        ' GET: Login
        Function Index() As ActionResult
            Return View()
        End Function
        <HttpPost>
        Function Index(ByVal collection As FormCollection) As ActionResult
            Dim user = New UserVM(collection)
            'Dim email = collection("Email")
            Dim tempUser = SessionManager.Users.Find(Function(u) u.Email = user.Email)
            SessionManager.User = tempUser
            If SessionManager.IsConnect Then
                Return RedirectToAction("index", "Home")
            Else
                ViewBag.error = "User is not exist"
                Return View()
            End If
        End Function
    End Class
End Namespace