using System.Windows;
using DevExpress.XtraReports.Expressions;
using DevExpress.XtraReports.UI;

namespace HidePropertiesExample {
    public partial class App : Application {
        protected override void OnStartup(StartupEventArgs e) {
            // For XRLabel controls, hide the Background Color and Tag properties from the Expressions tab.
            ExpressionBindingDescriptor.HidePropertyDescriptions(typeof(XRLabel), "BackColor", "Tag");
            base.OnStartup(e);
        }
    }
}
