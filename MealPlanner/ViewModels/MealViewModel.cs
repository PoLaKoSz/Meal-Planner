using MealPlanner.Models;
using MealPlanner.MVVM;
using MealPlanner.MVVM.ViewModels;
using MealPlanner.Views;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace MealPlanner.ViewModels
{
    public class MealViewModel : BaseViewModel
    {
        private ObservableCollection<Meal> _meals;
        private Meal _newMeal;

        public ObservableCollection<Meal> Meals
        {
            get => _meals;
            set
            {
                _meals = value;
                NotifyPropertyChanged();
            }
        }
        public Meal NewMeal
        {
            get => _newMeal;
            set
            {
                _newMeal = value;
                NotifyPropertyChanged();
            }
        }

        public ICommand AddNewRowCommand
        {
            get => new RelayCommand(p => AddNewRow(), p => true);
        }
        public ICommand AddNewColumnCommand
        {
            get => new RelayCommand(p => AddNewColumn(), p => true);
        }
        public ICommand AddMealCommand
        {
            get => new RelayCommand(p => Meals.Add(NewMeal), p => true);
        }
        public ICommand SaveMealsCommand
        {
            get => new RelayCommand(p => ShellViewModel.Data.Meals = new List<Meal>(Meals), p => true);
        }
        public ICommand EditMealCommand
        {
            // TODO
            get;
        }
        public ICommand DeleteMealCommand
        {
            get => new RelayCommand(p => DeleteMeal((Meal) p), p => true);
    }
        public ICommand NavigateToShowViewCommand
        {
            get => new RelayCommand(p => NavigateToView(_showView), p => true);
        }



        public MealViewModel()
            : base("Meals")
        {
            Meals = new ObservableCollection<Meal>(ShellViewModel.Data.Meals);
            NewMeal = new Meal();

            _showView = new ShowMealView()
            {
                DataContext = this
            };
            _addView = new AddMealView()
            {
                DataContext = this
            };

            CurrentView = _showView;
        }



        private void DeleteMeal(Meal meal)
        {
            Meals.Remove(Meals.Where(m => m.Name == meal.Name).Single());
        }
        private void AddNewRow()
        {
            NewMeal.Ingredients.Add(new ObservableCollection<FoodIngredient>()
            {
                new FoodIngredient()
            });
        }
        private void AddNewColumn()
        {
            foreach (ObservableCollection<FoodIngredient> row in NewMeal.Ingredients)
            {
                row.Add(new FoodIngredient());
            }
        }
    }
}
