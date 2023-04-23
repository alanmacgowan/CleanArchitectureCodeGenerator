using Microsoft.VisualStudio.Shell;
using System;
using System.Runtime.InteropServices;
using System.Threading;
using Task = System.Threading.Tasks.Task;

namespace CleanCodeGenerator
{
    [PackageRegistration(UseManagedResourcesOnly = true, AllowsBackgroundLoading = true)]
    [Guid(CleanCodeGeneratorPackage.PackageGuidString)]
    [ProvideMenuResource("Menus.ctmenu", 1)]
    [ProvideToolWindow(typeof(ItemsSelectorWindow), Orientation = ToolWindowOrientation.Left, Style = VsDockStyle.Tabbed)]
    public sealed class CleanCodeGeneratorPackage : AsyncPackage
    {
        public const string PackageGuidString = "5958e231-12e3-454c-9bed-7b1caf69c5ac";

        protected override async Task InitializeAsync(CancellationToken cancellationToken, IProgress<ServiceProgressData> progress)
        {
            await this.JoinableTaskFactory.SwitchToMainThreadAsync(cancellationToken);
            await ItemsSelectorWindowCommand.InitializeAsync(this);
        }

    }
}
