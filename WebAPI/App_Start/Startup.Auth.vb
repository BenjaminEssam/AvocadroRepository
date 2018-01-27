Imports System.Collections.Generic
Imports System.Linq
Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.EntityFramework
Imports Microsoft.Owin
Imports Microsoft.Owin.Security.Cookies
Imports Microsoft.Owin.Security.Google
Imports Microsoft.Owin.Security.OAuth
Imports Owin

Public Partial Class Startup
    Private Shared _OAuthOptions As OAuthAuthorizationServerOptions
    Private Shared _PublicClientId As String

    Public Shared Property OAuthOptions() As OAuthAuthorizationServerOptions
        Get
            Return _OAuthOptions
        End Get
        Private Set
            _OAuthOptions = Value
        End Set
    End Property

    Public Shared Property PublicClientId() As String
        Get
            Return _PublicClientId
        End Get
        Private Set
            _PublicClientId = Value
        End Set
    End Property

    ' Pour plus d'informations sur la configuration de l'authentification, consultez http://go.microsoft.com/fwlink/?LinkId=301864
    Public Sub ConfigureAuth(app As IAppBuilder)
        ' Configurer le contexte de base de données et le gestionnaire des utilisateurs pour utiliser une instance unique par demande
        app.CreatePerOwinContext(AddressOf ApplicationDbContext.Create)
        app.CreatePerOwinContext(Of ApplicationUserManager)(AddressOf ApplicationUserManager.Create)

        ' Activer l'application pour utiliser un cookie afin de stocker les informations de l'utilisateur connecté
        ' et utiliser un cookie pour stocker temporairement des informations sur un utilisateur qui se connecte avec un fournisseur de connexion tiers
        app.UseCookieAuthentication(New CookieAuthenticationOptions())
        app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie)

        ' Configurer l'application pour le flux basé sur OAuth
        ' Jeu de modes en production AllowInsecureHttp = False
        PublicClientId = "self"
        OAuthOptions = New OAuthAuthorizationServerOptions() With {
          .TokenEndpointPath = New PathString("/Token"),
          .Provider = New ApplicationOAuthProvider(PublicClientId),
          .AuthorizeEndpointPath = New PathString("/api/Account/ExternalLogin"),
          .AccessTokenExpireTimeSpan = TimeSpan.FromDays(14),
          .AllowInsecureHttp = True
        }

        ' Activer l'application pour utiliser les jetons du porteur afin d'authentifier les utilisateurs
        app.UseOAuthBearerTokens(OAuthOptions)

        ' Décommenter les lignes suivantes pour activer la connexion avec des fournisseurs de connexion tiers
        'app.UseMicrosoftAccountAuthentication(
        '    clientId:="",
        '    clientSecret:="")

        'app.UseTwitterAuthentication(
        '    consumerKey:="",
        '    consumerSecret:="")

        'app.UseFacebookAuthentication(
        '    appId:="",
        '    appSecret:="")

        'app.UseGoogleAuthentication(New GoogleOAuth2AuthenticationOptions() With {
        '    .ClientId = "",
        '    .ClientSecret = ""})
    End Sub
End Class
