using System.Windows.Threading;

namespace TopazTest;

public class SomeSource
{
	private readonly GetDataWindow _popup;

	public SomeSource()
	{
		_popup = new();
	}

	public string GetData()
	{
		_popup.input.Text = "";

		DispatcherFrame dispatcherFrame = new();
		EventHandler handler = (ss, ee) => dispatcherFrame.Continue = false;
		_popup.Closed += handler;
		_popup.Show();
		_popup.Focus();
		Dispatcher.PushFrame(dispatcherFrame);
		_popup.Closed -= handler;

		return _popup.input.Text;
	}
}