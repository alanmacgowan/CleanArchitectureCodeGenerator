﻿using Microsoft.VisualStudio.Shell;
using System;
using System.ComponentModel.Design;
using Task = System.Threading.Tasks.Task;

namespace CleanCodeGenerator
{
	internal sealed class ItemsSelectorWindowCommand
	{
		public const int CommandId = 0x0100;

		public static readonly Guid CommandSet = new Guid("1be5d7ed-3261-4fdf-be1b-8986b14f5a84");

		private readonly AsyncPackage package;

		private ItemsSelectorWindowCommand(AsyncPackage package, OleMenuCommandService commandService)
		{
			this.package = package ?? throw new ArgumentNullException(nameof(package));
			commandService = commandService ?? throw new ArgumentNullException(nameof(commandService));

			var menuCommandID = new CommandID(CommandSet, CommandId);
			var menuItem = new MenuCommand(this.Execute, menuCommandID);
			commandService.AddCommand(menuItem);
		}

		public static ItemsSelectorWindowCommand Instance {
			get;
			private set;
		}

		private Microsoft.VisualStudio.Shell.IAsyncServiceProvider ServiceProvider {
			get {
				return this.package;
			}
		}

		public static async Task InitializeAsync(AsyncPackage package)
		{
			await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync(package.DisposalToken);

			OleMenuCommandService commandService = await package.GetServiceAsync((typeof(IMenuCommandService))) as OleMenuCommandService;

			Instance = new ItemsSelectorWindowCommand(package, commandService);
		}

		private void Execute(object sender, EventArgs e)
		{
			this.package.JoinableTaskFactory.RunAsync(async delegate {
				ToolWindowPane window = await this.package.ShowToolWindowAsync(typeof(ItemsSelectorWindow), 0, true, this.package.DisposalToken);
				if ((null == window) || (null == window.Frame))
				{
					throw new NotSupportedException("Cannot create tool window");
				}
			});
		}
	}
}
