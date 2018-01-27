Imports System.ComponentModel.DataAnnotations
Imports Newtonsoft.Json

' Modèles utilisés comme paramètres des actions AccountController.

Public Class AddExternalLoginBindingModel
    <Required>
    <Display(Name := "Jeton d'accès externe")>
    Public Property ExternalAccessToken As String
End Class

Public Class ChangePasswordBindingModel
    <Required>
    <DataType(DataType.Password)>
    <Display(Name := "Mot de passe actuel")>
    Public Property OldPassword As String

    <Required>
    <StringLength(100, ErrorMessage := "Le {0} doit comporter au moins {2} caractères.", MinimumLength := 6)>
    <DataType(DataType.Password)>
    <Display(Name := "Nouveau mot de passe")>
    Public Property NewPassword As String

    <DataType(DataType.Password)>
    <Display(Name := "Confirmer le nouveau mot de passe")>
    <Compare("NewPassword", ErrorMessage := "Le nouveau mot de passe et le mot de passe de confirmation ne correspondent pas.")>
    Public Property ConfirmPassword As String
End Class

Public Class RegisterBindingModel
    <Required>
    <Display(Name := "E-mail")>
    Public Property Email As String

    <Required>
    <StringLength(100, ErrorMessage := "Le {0} doit comporter au moins {2} caractères.", MinimumLength := 6)>
    <DataType(DataType.Password)>
    <Display(Name := "Mot de passe")>
    Public Property Password As String

    <DataType(DataType.Password)>
    <Display(Name := "Confirmer le mot de passe")>
    <Compare("Password", ErrorMessage := "Le mot de passe et le mot de passe de confirmation ne correspondent pas.")>
    Public Property ConfirmPassword As String
End Class

Public Class RegisterExternalBindingModel
    <Required>
    <Display(Name := "E-mail")>
    Public Property Email As String
End Class

Public Class RemoveLoginBindingModel
    <Required>
    <Display(Name := "Fournisseur de connexion")>
    Public Property LoginProvider As String

    <Required>
    <Display(Name := "Clé du fournisseur")>
    Public Property ProviderKey As String
End Class

Public Class SetPasswordBindingModel
    <Required>
    <StringLength(100, ErrorMessage := "Le {0} doit comporter au moins {2} caractères.", MinimumLength := 6)>
    <DataType(DataType.Password)>
    <Display(Name := "Nouveau mot de passe")>
    Public Property NewPassword As String

    <DataType(DataType.Password)>
    <Display(Name := "Confirmer le nouveau mot de passe")>
    <Compare("NewPassword", ErrorMessage := "Le nouveau mot de passe et le mot de passe de confirmation ne correspondent pas.")>
    Public Property ConfirmPassword As String
End Class
