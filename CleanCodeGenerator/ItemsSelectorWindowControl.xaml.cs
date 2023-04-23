using EnvDTE;
using EnvDTE80;
using Microsoft.VisualStudio.Shell;
using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Windows.Controls;

namespace CleanCodeGenerator
{
	public partial class ItemsSelectorWindowControl : UserControl
	{
		public ItemsSelectorWindowControl()
		{
			this.InitializeComponent();
		}

		[SuppressMessage("Microsoft.Globalization", "CA1300:SpecifyMessageBoxOptions", Justification = "Sample code")]
		[SuppressMessage("StyleCop.CSharp.NamingRules", "SA1300:ElementMustBeginWithUpperCaseLetter", Justification = "Default event handler naming pattern")]
		private void button1_Click(object sender, RoutedEventArgs e)
		{
			ThreadHelper.ThrowIfNotOnUIThread();
			var dte = ServiceProvider.GlobalProvider.GetService(typeof(DTE)) as DTE2;

			MessageBox.Show(dte.ActiveSolutionProjects.ToString(),	"ItemsSelectorWindow");
		}
	}
}