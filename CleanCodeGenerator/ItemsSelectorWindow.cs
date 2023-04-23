using Microsoft.VisualStudio.Imaging;
using Microsoft.VisualStudio.Shell;
using System;
using System.Runtime.InteropServices;

namespace CleanCodeGenerator
{
	[Guid("2db3cf18-0f40-4b55-895e-52549ec636fc")]
	public class ItemsSelectorWindow : ToolWindowPane
	{
		public ItemsSelectorWindow() : base(null)
		{
			this.Caption = "Clean Code Generator";
			this.BitmapImageMoniker = KnownMonikers.Code;
			this.Content = new ItemsSelectorWindowControl();
		}
	}
}
