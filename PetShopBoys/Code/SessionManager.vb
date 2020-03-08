Public Class SessionManager
    Const _USER As String = "Usr"
    Const _USER_ROLE As String = "USER"
    Const _MANAGER_ROLE As String = "MANAGER"

    Private Shared _session As SessionState.HttpSessionState
    Private Shared _Pets As List(Of PetVM)
    Private Shared _users As List(Of UserVM)
    Private Shared ReadOnly Property Session() As SessionState.HttpSessionState
        Get

            If _session Is Nothing Then
                _session = HttpContext.Current.Session

            End If


            Return _session
        End Get

    End Property


    Public Shared Property Pets() As List(Of PetVM)
        Get

            If _Pets Is Nothing Then
                _Pets = New List(Of PetVM) From {
        New PetVM(123, "Dog", 1500, "https://cellcomshop.cellcom.co.il/pub/media/catalog/product/cache/b8e43b67ccbb6ff8f872deb3a434a8cc/s/a/samsungs10_-white-front_1_2.png"),
        New PetVM(142, "Cat", 1670, "https://cellcomshop.cellcom.co.il/pub/media/catalog/product/cache/b8e43b67ccbb6ff8f872deb3a434a8cc/i/p/iphone_11_pro_s_2.png"),
        New PetVM(144, "Parrot", 1200, "https://cellcomshop.cellcom.co.il/pub/media/catalog/product/cache/b8e43b67ccbb6ff8f872deb3a434a8cc/8/_/8_1.png"),
        New PetVM(147, "Dolphin", 2100, "https://store.storeimages.cdn-apple.com/4982/as-images.apple.com/is/iphone-11-pro-select-2019-family?wid=441&amp;hei=529&amp;fmt=jpeg&amp;qlt=95&amp;op_usm=0.5,0.5&amp;.v=1567812930312"),
        New PetVM(148, "Horse", 2066, "https://cellcomshop.cellcom.co.il/pub/media/catalog/product/cache/b8e43b67ccbb6ff8f872deb3a434a8cc/s/a/samsungs10e-black-angle_2.png"),
        New PetVM(150, "Hampster", 1800, "https://image01.oneplus.net/ebp/201904/29/122/d36a14233fc973a4c012d6e369b1821c.png"),
        New PetVM(152, "Snake", 3000, "https://cdn.tmobile.com/content/dam/t-mobile/en-p/cell-phones/Google/Google-Pixel-4-XL/Just-Black/Google-Pixel-4-XL-Just-Black-frontimage.jpg"),
        New PetVM(153, "Fish", 2550, "https://static-www.o2.co.uk/sites/default/files/huawei-p30-pro-aurora-sku-header-180319.png"),
        New PetVM(156, "Rabbit", 1510, "https://sahek-ota.co.il/media/catalog/product/cache/10/image/9df78eab33525d08d6e5fb8d27136e95/8/2/820.jpg"),
        New PetVM(157, "Rhino", 2000, "https://images.macrumors.com/t/OzAj4wUmCpwhzkH9KMOfbXK1Y9Q=/400x0/article-new/2018/09/littleiphonexr.jpg"),
        New PetVM(159, "Lion", 2100, "https://www.idigital.co.il/files/iPhone_XS/shop_product/iPhoneXs-Family-3Up-Angled-US-EN-SCREEN.png"),
        New PetVM(160, "Pig", 1900, "https://fdn2.gsmarena.com/vv/pics/google/google-pixel-3xl-4.jpg")
    }

            End If


            Return _Pets
        End Get
        Set(ByVal pets As List(Of PetVM))
            _Pets = pets
        End Set

    End Property

    Public Shared ReadOnly Property Users() As List(Of UserVM)
        Get
            Dim userRole = New List(Of String) From {_USER_ROLE}
            Dim managerRole = New List(Of String) From {_USER_ROLE, _MANAGER_ROLE}
            If _users Is Nothing Then
                _users = New List(Of UserVM) From {
          New UserVM(1, "Yonatan", "Yonatan@Epr.co.il", 38, userRole),
          New UserVM(2, "Harel", "Harel@Epr.co.il", 38, userRole),
          New UserVM(3, "Orya", "Orya@Epr.co.il", 38, managerRole)
                }


            End If


            Return _users
        End Get

    End Property

    Public Shared Property User() As UserVM
        Get
            Return Session(_USER)
        End Get
        Set(ByVal usr As UserVM)
            'usr.Age = 40

            Session(_USER) = usr
        End Set
    End Property

    Public Shared ReadOnly Property IsConnect() As Boolean
        Get
            Return User IsNot Nothing
        End Get

    End Property
    Public Shared ReadOnly Property IsManager() As Boolean
        Get
            If User Is Nothing Then Return False
            Return User.Roles.Contains(_MANAGER_ROLE)
        End Get

    End Property

End Class