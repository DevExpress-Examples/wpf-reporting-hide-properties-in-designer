using System;
using System.ComponentModel;
using System.Windows;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.UserDesigner;


namespace HidePropertiesExample {

    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            var report = new XtraReport();
            // Handle the static FilterComponentProperties event to filter the Properties panel.
            XtraReport.FilterComponentProperties += XtraReport_FilterComponentProperties;
            reportDesigner.OpenDocument(report);
        }

        static void XtraReport_FilterComponentProperties(object sender, FilterComponentPropertiesEventArgs e) {
            // Hide the Scripts property for all report elements.
            HideProperty("Scripts", e);

            // Hide the ReportSource and ReportSourceUrl properties for subreports. 
            if (e.Component is XRSubreport) {
                HideProperty("ReportSource", e);
                HideProperty("ReportSourceUrl", e);
            }

            // Hide the Name property for XRLabel controls.
            if(e.Component is XRLabel) {
                HideProperty("Name", e);
            }
        }

        static void HideProperty(String propertyName,
            FilterComponentPropertiesEventArgs filterComponentProperties) {
            PropertyDescriptor oldPropertyDescriptor =
                filterComponentProperties.Properties[propertyName] as PropertyDescriptor;
            if(oldPropertyDescriptor != null) {
                // Substitute the current property descriptor with a custom one with the BrowsableAttribute.No attribute.
                filterComponentProperties.Properties[propertyName] = TypeDescriptor.CreateProperty(
                    oldPropertyDescriptor.ComponentType,
                    oldPropertyDescriptor,
                    new Attribute[] { BrowsableAttribute.No });
            } else {
                // If the property descriptor cannot be substituted, remove it from the Properties collection.
                filterComponentProperties.Properties.Remove(propertyName);
            }
        }
    }
}
