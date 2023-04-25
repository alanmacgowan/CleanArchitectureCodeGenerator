using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CodeGenerator
{
    public partial class MainToolWindowControl : UserControl
    {
        public MainToolWindowControl(IEnumerable<Project> projects)
        {
            InitializeComponent();
			var projectsList = "Projects in solution: ";
			foreach(var project in projects)
			{
				projectsList += "* " + project.Name + Environment.NewLine;
			}
			projectsLabel.Content = projectsList;
		}

        private void button1_Click(object sender, RoutedEventArgs e)
        {
			VS.MessageBox.Show("CodeGenerator", "Button clicked");
        }
    }
}