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
        private ObservableCollection<IMeal> _meals;
        private MealWithRepastType _newMeal;
        private List<RepastType> _repastTypes;
        private List<Repast> _availableRepasts;
        private List<Repast> AvailableRepasts
        {
            get
            {
                if (_availableRepasts == null)
                    return ShellViewModel.Data.Repast;

                return _availableRepasts;
            }
            set => _availableRepasts = value;
        }


        public ObservableCollection<IMeal> Meals
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
            Meals = new ObservableCollection<IMeal>(ShellViewModel.Data.Meals);
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

                if (repastType.IsCheched && AvailableRepasts[i].Name.Equals(repastType.Name))
                    AvailableRepasts[i].Meals.Add(new Meal(NewMeal.Name, NewMeal.Ingredients));
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
            ShellViewModel.Data.Repast = AvailableRepasts;
            ShellViewModel.Data.Meals = new List<IMeal>(Meals);
        }
    }
}
