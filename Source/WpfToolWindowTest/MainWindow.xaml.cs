using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Interop;

namespace WpfToolWindowTest;

public partial class MainWindow : Window
{
	public MainWindow()
	{
		InitializeComponent();

		var windowHandle = new WindowInteropHelper(this).EnsureHandle();
		HwndSource source = HwndSource.FromHwnd(windowHandle);
		source.AddHook(new HwndSourceHook(WndProc));
	}

	const int WM_DPICHANGED = 0x02E0;

	private nint WndProc(nint hwnd, int msg, nint wParam, nint lParam, ref bool handled)
	{
		switch (msg)
		{
			case WM_DPICHANGED:
				Trace.WriteLine($"WM_DPICHANGED");
				break;
		}
		return IntPtr.Zero;
	}

	protected override void OnDpiChanged(DpiScale oldDpi, DpiScale newDpi)
	{
		base.OnDpiChanged(oldDpi, newDpi);

		Trace.WriteLine($"DpiChanged {oldDpi.PixelsPerDip} -> {newDpi.PixelsPerDip}");
	}
}
