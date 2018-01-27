Imports System.Web.Mvc
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports WebAPI

<TestClass()> Public Class HomeControllerTest
    <TestMethod()> Public Sub Index()
        'Disposer
        Dim controller As New HomeController()

        'Agir
        Dim result As ViewResult = DirectCast(controller.Index(), ViewResult)

        'Affirmer
        Assert.IsNotNull(result)
        Dim viewData As ViewDataDictionary = result.ViewData
        Assert.AreEqual("Home Page", viewData("Title"))
    End Sub
End Class
