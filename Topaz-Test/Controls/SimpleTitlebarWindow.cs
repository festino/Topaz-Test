using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;

namespace TopazTest.Controls;

public class SimpleTitlebarWindow : Window
{
	#region Win32 imports
	private const int GWL_STYLE = -16;
	private const int WS_SYSMENU = 0x00080000;

	[DllImport("user32.dll", SetLastError = true)]
	private static extern int GetWindowLongPtr(IntPtr hWnd, int nIndex);

	[DllImport("user32.dll")]
	private static extern int SetWindowLongPtr(IntPtr hWnd, int nIndex, int dwNewLong);
	#endregion

	public SimpleTitlebarWindow()
	{
		Loaded += (s, e) => RemoveTitlebarButtons();
	}

	private void RemoveTitlebarButtons()
	{
		var hwnd = new WindowInteropHelper(this).Handle;
		int result = SetWindowLongPtr(hwnd, GWL_STYLE, GetWindowLongPtr(hwnd, GWL_STYLE) & ~WS_SYSMENU);
		if (result == 0)
		{
			Environment.Exit(1);
		}
	}
}
