using MealPlanner.MVVM.ViewModels;
using System.Windows;

namespace MealPlanner.MVVM.Views
{
	public partial class ShellView : Window
	{
		public ShellView(ShellViewModel viewModel)
		{
            DataContext = viewModel;

			InitializeComponent();
		}
	}
}
