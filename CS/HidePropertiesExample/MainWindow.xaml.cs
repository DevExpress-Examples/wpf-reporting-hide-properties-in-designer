using System;
using System.ComponentModel;
using System.Windows;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.UserDesigner;

namespace HidePropertiesExample {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();

            var report = new XtraReport();
            XtraReport.FilterComponentProperties += XtraReport_FilterComponentProperties;
            reportDesigner.OpenDocument(report);
        }

        static void XtraReport_FilterComponentProperties(object sender, FilterComponentPropertiesEventArgs e) {
            // The following line hides the Scripts property for all report elements.
            HideProperty("Scripts", e);

            // The following code hides the ReportSource property, 
            // for subreports to always contain only the pre-defined reports.
            if(e.Component is XRSubreport) {
                HideProperty("ReportSource", e);
                HideProperty("ReportSourceUrl", e);
            }

            // The following code hides the Text property for XRLabel
            if(e.Component is XRLabel) {
                HideProperty("Text", e);
            }
        }

        static void HideProperty(String propertyName,
            FilterComponentPropertiesEventArgs filterComponentProperties) {
            PropertyDescriptor oldPropertyDescriptor =
                filterComponentProperties.Properties[propertyName] as PropertyDescriptor;
            if(oldPropertyDescriptor != null) {
                // Substitute the current property descriptor 
                // with a custom one with the BrowsableAttribute.No attribute.
                filterComponentProperties.Properties[propertyName] = TypeDescriptor.CreateProperty(
                    oldPropertyDescriptor.ComponentType,
                    oldPropertyDescriptor,
                    new Attribute[] { BrowsableAttribute.No });
            } else {
                // If the property descriptor can not be substituted, 
                // remove it from the Properties collection.
                filterComponentProperties.Properties.Remove(propertyName);
            }
        }
    }
}
