Imports System.Windows
Imports DevExpress.XtraReports.Expressions
Imports DevExpress.XtraReports.UI

Namespace HidePropertiesExample
    Partial Public Class App
        Inherits Application

        Protected Overrides Sub OnStartup(ByVal e As StartupEventArgs)
            ' For XRLabel controls, hide the Background Color and Tag properties from the Expressions tab.
            ExpressionBindingDescriptor.HidePropertyDescriptions(GetType(XRLabel), "BackColor", "Tag")
            MyBase.OnStartup(e)
        End Sub
    End Class
End Namespace
