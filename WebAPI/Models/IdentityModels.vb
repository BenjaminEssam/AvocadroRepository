Imports System.Security.Claims
Imports System.Threading.Tasks
Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.EntityFramework
Imports Microsoft.AspNet.Identity.Owin

' Vous pouvez ajouter des données de profil pour l'utilisateur en ajoutant d'autres propriétés à votre classe ApplicationUser, consultez http://go.microsoft.com/fwlink/?LinkID=317594 pour en savoir davantage.
Public Class ApplicationUser
    Inherits IdentityUser

    Public Async Function GenerateUserIdentityAsync(manager As UserManager(Of ApplicationUser), authenticationType As String) As Task(Of ClaimsIdentity)
        ' Notez que authenticationType doit correspondre à l'instance définie dans CookieAuthenticationOptions.AuthenticationType
        Dim userIdentity = Await manager.CreateIdentityAsync(Me, authenticationType)
        ' Ajouter des revendications d’utilisateur personnalisées ici
        Return userIdentity
    End Function
End Class

Public Class ApplicationDbContext
    Inherits IdentityDbContext(Of ApplicationUser)
    Public Sub New()
        MyBase.New("DefaultConnection", throwIfV1Schema:=False)
    End Sub

    Public Shared Function Create() As ApplicationDbContext
        Return New ApplicationDbContext()
    End Function
End Class
