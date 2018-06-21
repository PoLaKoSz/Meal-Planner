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
        private MealWithRepastType _newMeal;
        private List<RepastType> _repastTypes;
        private List<Repast> _repast;
        private List<Repast> Repast
        {
            get
            {
                if (_repast == null)
                    return ShellViewModel.Data.Repast;

                return _repast;
            }
            set => _repast = value;
        }


        public ObservableCollection<Meal> Meals
        {
            get => _meals;
            set
            {
                _meals = value;
                NotifyPropertyChanged();
            }
        }
        public MealWithRepastType NewMeal
        {
            get => _newMeal;
            set
            {
                _newMeal = value;
                NotifyPropertyChanged();
            }
        }

        public List<RepastType> RepastTypes
        {
            get
            {
                if (_repastTypes != null)
                    return _repastTypes;

                _repastTypes = new List<RepastType>();

                foreach (Repast repast in ShellViewModel.Data.Repast)
                    _repastTypes.Add(new RepastType(repast.Name));

                return _repastTypes;
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
            get => new RelayCommand(p => AddMeal(), p => true);
        }
        public ICommand SaveMealsCommand
        {
            get => new RelayCommand(p => SaveMeals(), p => true);
        }


        public ICommand EditMealCommand
        {
            // TODO
            get;
        }
        public ICommand DeleteMealCommand
        {
            get => new RelayCommand(p => DeleteMeal((Meal)p), p => true);
        }



        public MealViewModel()
            : base("Meals")
        {
            Meals = new ObservableCollection<Meal>(ShellViewModel.Data.Meals);
            NewMeal = new MealWithRepastType(RepastTypes);

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
        


        private void AddMeal()
        {
            for (int i = 0; i < RepastTypes.Count; i++)
            {
                RepastType repastType = RepastTypes[i];

                if (repastType.IsCheched && Repast[i].Name.Equals(repastType.Name))
                    Repast[i].Meals.Add(new Meal(NewMeal.Name, NewMeal.Ingredients));
            }

            Meals.Add(NewMeal);

            NewMeal = new MealWithRepastType(RepastTypes);
        }
        private void DeleteMeal(Meal meal)
        {
            Meals.Remove(Meals.Where(m => m.Name == meal.Name).FirstOrDefault());
        }
        private void SaveMeals()
        {
            ShellViewModel.Data.Repast = Repast;
            ShellViewModel.Data.Meals = new List<Meal>(Meals);
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
