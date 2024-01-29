Imports System
Imports System.ComponentModel
Imports System.Windows
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraReports.UserDesigner

Namespace HidePropertiesExample

    Public Partial Class MainWindow
        Inherits Window

        Public Sub New()
            Me.InitializeComponent()
            Dim report = New XtraReport()
            ' Handle the static FilterComponentProperties event to filter the Properties panel.
            AddHandler XtraReport.FilterComponentProperties, AddressOf HidePropertiesExample.MainWindow.XtraReport_FilterComponentProperties
            Me.reportDesigner.OpenDocument(report)
        End Sub

        Private Shared Sub XtraReport_FilterComponentProperties(ByVal sender As Object, ByVal e As FilterComponentPropertiesEventArgs)
            ' Hide the Scripts property for all report elements.
            Call HideProperty("Scripts", e)
            ' Hide the ReportSource and ReportSourceUrl properties for subreports. 
            If TypeOf e.Component Is XRSubreport Then
                Call HideProperty("ReportSource", e)
                Call HideProperty("ReportSourceUrl", e)
            End If

            ' Hide the Name property for XRLabel controls.
            If TypeOf e.Component Is XRLabel Then
                Call HideProperty("Name", e)
            End If
        End Sub

        Private Shared Sub HideProperty(ByVal propertyName As String, ByVal filterComponentProperties As FilterComponentPropertiesEventArgs)
            Dim oldPropertyDescriptor As PropertyDescriptor = TryCast(filterComponentProperties.Properties(propertyName), PropertyDescriptor)
            If oldPropertyDescriptor IsNot Nothing Then
                ' Substitute the current property descriptor with a custom one with the BrowsableAttribute.No attribute.
                filterComponentProperties.Properties(propertyName) = TypeDescriptor.CreateProperty(oldPropertyDescriptor.ComponentType, oldPropertyDescriptor, New Attribute() {BrowsableAttribute.No})
            Else
                ' If the property descriptor cannot be substituted, remove it from the Properties collection.
                filterComponentProperties.Properties.Remove(propertyName)
            End If
        End Sub
    End Class
End Namespace
