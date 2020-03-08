Public Class HomeController
    Inherits System.Web.Mvc.Controller

    Function Index() As ActionResult
        If SessionManager.IsConnect Then Return View()
        Return RedirectToAction("Index", "Login")
    End Function

    Function Employee() As ActionResult
        If SessionManager.IsConnect Then Return View(SessionManager.Users)
        Return RedirectToAction("Index", "Login")

        Return View()
    End Function

    Function PetList() As ActionResult
        If SessionManager.IsConnect Then Return View(SessionManager.Pets)
        Return RedirectToAction("Index", "Login")
    End Function
    Function Create() As ActionResult
        Dim pet = New PetVM()
        Return View(pet)
    End Function

    <HttpPost>
    Function Create(collection As FormCollection) As ActionResult
        Dim id = collection("ID")

        Dim pet = SessionManager.Pets.Find(Function(e) e.Id = id)
        If pet IsNot Nothing Then
            ViewBag.error = "There is anoter pet with the same ID. select a different ID and try again"
            Return View()
        End If
        Dim name = collection("Name")
        Dim price = collection("Price")
        Dim image = collection("Image")
        Dim newPet = New PetVM(id, name, price, image)

        Dim tempPetList = SessionManager.Pets
        tempPetList.Add(newPet)
        SessionManager.Pets = tempPetList
        Return RedirectToAction("PetList")
    End Function
    Function Edit(id As Integer) As ActionResult
        Dim pet = SessionManager.Pets.Find(Function(e) e.Id = id)
        Return View(pet)
    End Function

    <HttpPost>
    Function Edit(collection As FormCollection) As ActionResult
        Dim id = collection("ID")

        Dim pet = SessionManager.Pets.Find(Function(e) e.Id = id)

        Dim name = collection("Name")
        Dim price = collection("Price")
        Dim image = collection("Image")
        Dim newPet = New PetVM(id, name, price, image)

        'Dim tempPetList = SessionManager.Pets
        SessionManager.Pets.Remove(pet)
        'tempPetList.Add(newPet)
        SessionManager.Pets.Add(newPet)
        Return RedirectToAction("PetList")
    End Function


    Function Delete(id As Integer) As ActionResult
        Dim pet = SessionManager.Pets.Find(Function(e) e.Id = id)

        SessionManager.Pets.Remove(pet)
        Return RedirectToAction("PetList")
    End Function
    Function LogOut() As ActionResult
        SessionManager.User = Nothing
        Return RedirectToAction("Index", "Login")
    End Function

    Function Search(name) As ActionResult
        Dim srcResult = SessionManager.Pets.Contains(name)
        Return View(srcResult)
    End Function
End Class
