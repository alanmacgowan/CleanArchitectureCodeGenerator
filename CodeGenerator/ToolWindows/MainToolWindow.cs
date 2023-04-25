using Microsoft.VisualStudio.Imaging;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace CodeGenerator
{
    public class MainToolWindow : BaseToolWindow<MainToolWindow>
    {
        public override string GetTitle(int toolWindowId) => "My Tool Window";

        public override Type PaneType => typeof(Pane);

        public override async Task<FrameworkElement> CreateAsync(int toolWindowId, CancellationToken cancellationToken)
        {
			var projects = await VS.Solutions.GetAllProjectsAsync();

			return new MainToolWindowControl(projects);
			//return Task.FromResult<FrameworkElement>(new MyToolWindowControl());
        }

        [Guid("0e4e7ebb-f8e3-4b12-852e-b11e3da14392")]
        internal class Pane : ToolkitToolWindowPane
        {
            public Pane()
            {
                BitmapImageMoniker = KnownMonikers.ToolWindow;
            }
        }
    }
}