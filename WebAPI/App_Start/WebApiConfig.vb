Imports System.Net.Http
Imports System.Web.Http
Imports Microsoft.Owin.Security.OAuth
Imports Newtonsoft.Json.Serialization

Public Module WebApiConfig
    Public Sub Register(config As HttpConfiguration)
      ' Configuration et services de l'API Web
      ' Configurer l'API Web pour utiliser uniquement l'authentification de jeton du porteur.
      config.SuppressDefaultHostAuthentication()
      config.Filters.Add(New HostAuthenticationFilter(OAuthDefaults.AuthenticationType))

      ' Itinéraires de l'API Web
      config.MapHttpAttributeRoutes()

      config.Routes.MapHttpRoute(
          name:="DefaultApi",
          routeTemplate:="api/{controller}/{id}",
          defaults:=New With { .id = RouteParameter.Optional }
      )
    End Sub
End Module
