using MealPlanner.MVVM.ViewModels;
using MealPlanner.Views;
using MealPlanner.Workers;

namespace MealPlanner.ViewModels
{
    public class ShoppingListViewModel : BaseViewModel
    {
        public ShoppingListGenerator ListGenerator { get; private set; }



        public ShoppingListViewModel()
            : base("Shopping List")
        {
            _showView = new ShowShoppingListVew()
            {
                DataContext = this
            };

            CurrentView = _showView;

            ListGenerator = new ShoppingListGenerator();
            ListGenerator.AddMenu(ShellViewModel.Data.Menu);
        }
    }
}
