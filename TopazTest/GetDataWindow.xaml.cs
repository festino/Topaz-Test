using System.Windows;
using TopazTest.Controls;

namespace TopazTest;

/// <summary>
/// Interaction logic for GetDataWindow.xaml
/// </summary>
public partial class GetDataWindow : SimpleTitlebarWindow
{
	public GetDataWindow()
	{
		InitializeComponent();
	}

	private void Button_Click(object sender, RoutedEventArgs e)
	{
		Close();
	}
}
