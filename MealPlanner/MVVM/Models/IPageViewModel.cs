using System.Windows.Controls;

namespace MealPlanner.MVVM.Models
{
    public interface IPageViewModel
    {
        string Name { get; }
        UserControl CurrentView { get; }
    }
}
