using MealPlanner.MVVM.Helpers;
using MealPlanner.MVVM.ViewModels;
using System.Diagnostics;
using System.Windows;

namespace MealPlanner
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
        protected override void OnStartup(StartupEventArgs e)
        {
            PresentationTraceSources.Refresh();
            PresentationTraceSources.DataBindingSource.Listeners.Add(new ConsoleTraceListener());
            PresentationTraceSources.DataBindingSource.Listeners.Add(new DebugTraceListener());
            PresentationTraceSources.DataBindingSource.Switch.Level = SourceLevels.Warning | SourceLevels.Error;

            base.OnStartup(e);

            var mainViewModel = new ShellViewModel();
        }
    }
}
