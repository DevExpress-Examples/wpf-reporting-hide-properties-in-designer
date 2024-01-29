<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128605270/22.2.2%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T568088)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
# WPF Report Designer - How to hide properties of reports and their elements

This example shows how to hide properties of a report, its bands, and controls from the End-User Report Designer's **Properties panel** by handling the [`XtraReport.FilterComponentProperties`](https://documentation.devexpress.com/XtraReports/DevExpress.XtraReports.UI.XtraReport.FilterComponentProperties.event) event. 

> [!NOTE]
> Starting with v17.2, reports use [binding expressions](https://documentation.devexpress.com/XtraReports/119236/Creating-Reports-in-Visual-Studio/Detailed-Guide-to-DevExpress-Reporting/Providing-Data-to-Reports/Data-Binding-Overview/Data-Binding-Modes), which you can specify in the **Properties panel**'s **Expression** tab. To hide properties from this tab, use the <strong>ExpressionBindingDescriptor.HidePropertyDescriptions </strong>method.</p>

## Files to Review

* [App.xaml.cs](./CS/HidePropertiesExample/App.xaml.cs)
* [MainWindow.xaml](./CS/HidePropertiesExample/MainWindow.xaml) (VB: [MainWindow.xaml](./VB/HidePropertiesExample/MainWindow.xaml))
* [MainWindow.xaml.cs](./CS/HidePropertiesExample/MainWindow.xaml.cs) (VB: [MainWindow.xaml.vb](./VB/HidePropertiesExample/MainWindow.xaml.vb))

## Documentation

* [Hide Properties from the Report Designer](https://docs.devexpress.com/XtraReports/119459/desktop-reporting/wpf-reporting/end-user-report-designer-for-wpf/api-and-customization/hide-properties-from-the-report-designer)
