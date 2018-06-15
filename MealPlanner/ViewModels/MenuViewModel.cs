using MealPlanner.MVVM.ViewModels;
using MealPlanner.Views;

namespace MealPlanner.ViewModels
{
    public class MenuViewModel : BaseViewModel
    {
        public MenuViewModel()
            : base("Menu")
        {
            _showView = new ShowMenuView()
            {
                DataContext = this
            };

            CurrentView = _showView;
        }
    }
}
