Imports System
Imports System.ComponentModel
Imports System.Windows
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraReports.UserDesigner

Namespace HidePropertiesExample
    ''' <summary>
    ''' Interaction logic for MainWindow.xaml
    ''' </summary>
    Partial Public Class MainWindow
        Inherits Window

        Public Sub New()
            InitializeComponent()

            Dim report = New XtraReport()
            AddHandler XtraReport.FilterComponentProperties, AddressOf XtraReport_FilterComponentProperties
            reportDesigner.OpenDocument(report)
        End Sub

        Private Shared Sub XtraReport_FilterComponentProperties(ByVal sender As Object, ByVal e As FilterComponentPropertiesEventArgs)
            ' The following line hides the Scripts property for all report elements.
            HideProperty("Scripts", e)

            ' The following code hides the ReportSource property, 
            ' for subreports to always contain only the pre-defined reports.
            If TypeOf e.Component Is XRSubreport Then
                HideProperty("ReportSource", e)
                HideProperty("ReportSourceUrl", e)
            End If

            ' The following code hides the Text property for XRLabel
            If TypeOf e.Component Is XRLabel Then
                HideProperty("Text", e)
            End If
        End Sub

        Private Shared Sub HideProperty(ByVal propertyName As String, ByVal filterComponentProperties As FilterComponentPropertiesEventArgs)
            Dim oldPropertyDescriptor As PropertyDescriptor = TryCast(filterComponentProperties.Properties(propertyName), PropertyDescriptor)
            If oldPropertyDescriptor IsNot Nothing Then
                ' Substitute the current property descriptor 
                ' with a custom one with the BrowsableAttribute.No attribute.
                filterComponentProperties.Properties(propertyName) = TypeDescriptor.CreateProperty(oldPropertyDescriptor.ComponentType, oldPropertyDescriptor, New Attribute() { BrowsableAttribute.No })
            Else
                ' If the property descriptor can not be substituted, 
                ' remove it from the Properties collection.
                filterComponentProperties.Properties.Remove(propertyName)
            End If
        End Sub
    End Class
End Namespace
