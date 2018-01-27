Imports System
Imports System.Collections.Generic
Imports System.Net.Http
Imports System.Text
Imports System.Web.Http
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports WebAPI

<TestClass()> Public Class ValuesControllerTest
    <TestMethod()> Public Sub GetValues()
        'Organiser
        Dim controller As New ValuesController()

        'Agir
        Dim result As IEnumerable(Of String) = controller.GetValues()

        'Déclarer
        Assert.IsNotNull(result)
        Assert.AreEqual(2, result.Count())
        Assert.AreEqual("value1", result.ElementAt(0))
        Assert.AreEqual("value2", result.ElementAt(1))
    End Sub

    <TestMethod()> Public Sub GetValueById()
        'Organiser
        Dim controller As New ValuesController()

        'Agir
        Dim result As String = controller.GetValue(5)

        'Déclarer
        Assert.AreEqual("value", result)
    End Sub

    <TestMethod()> Public Sub PostValue()
        'Organiser
        Dim controller As New ValuesController()

        'Agir
        controller.PostValue("value")

        'Déclarer
    End Sub

    <TestMethod()> Public Sub PutValue()
        'Organiser
        Dim controller As New ValuesController()

        'Agir
        controller.PutValue(5, "value")

        'Déclarer
    End Sub

    <TestMethod()> Public Sub DeleteValue()
        'Organiser
        Dim controller As New ValuesController()

        'Agir
        controller.DeleteValue(5)

        'Déclarer
    End Sub
End Class
