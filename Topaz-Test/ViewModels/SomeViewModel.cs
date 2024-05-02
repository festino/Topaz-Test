using Microsoft.TeamFoundation.MVVM;
using System.Windows.Input;

namespace TopazTest.ViewModels;

public class SomeViewModel : ViewModelBase
{
	public string Data { get; set; }
	public ICommand GetDataCommand
	{
		get
		{
			return new RelayCommand(() =>
			{
				var ds = new SomeSource();
				Data = ds.GetData();
				RaisePropertyChanged(nameof(Data));
			});
		}
	}
}
