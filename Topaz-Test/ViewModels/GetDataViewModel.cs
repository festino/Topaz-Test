using Microsoft.TeamFoundation.MVVM;

namespace TopazTest.ViewModels;

public class GetDataViewModel : ViewModelBase

{
	private string _input = "";

	public string Input
	{
		get => _input;
		set
		{
			_input = value;
			RaisePropertyChanged(nameof(Input));
			RaisePropertyChanged(nameof(CanClose));
		}
	}

	public bool CanClose => Input.Length > 0;
}