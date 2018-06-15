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
    public class IngredientViewModel : BaseViewModel
    {
        private ObservableCollection<Ingredient> _ingredients;


        public ObservableCollection<Ingredient> Ingredients
        {
            get => _ingredients;
            set
            {
                _ingredients = value;
                NotifyPropertyChanged();
            }
        }

        public ICommand DeleteIngredientCommand
        {
            get => new RelayCommand(p => DeleteIngredient((Ingredient)p), p => true);
        }
        public ICommand SaveIngredientsCommand
        {
            get => new RelayCommand(p => SaveIngredients(), p => true);
        }        
        public ICommand AddNewIngredientCommand
        {
            get => new RelayCommand(
                p => AddNewIngredient(new Ingredient((string) p)),
                p => IsNoDuplication(new Ingredient((string) p)));
        }



        public IngredientViewModel()
            : base("Ingredients")
        {
            _showView = new ShowIngredientView
            {
                DataContext = this
            };
            _addView = new AddIngredientView
            {
                DataContext = this
            };

            Ingredients = new ObservableCollection<Ingredient>();

            LoadIngredients();

            CurrentView = _showView;
        }



        private void LoadIngredients()
        {
            Ingredients = new ObservableCollection<Ingredient>(ShellViewModel.Data.Ingredients);
        }
        private void SaveIngredients()
        {
            ShellViewModel.Data.Ingredients = new List<Ingredient>(Ingredients);
        }
                
        private bool IsNoDuplication(Ingredient ingredient)
        {
            return ingredient.Name.Length > 2 && !Ingredients.Contains(ingredient);
        }

        private void AddNewIngredient(Ingredient ingredient)
        {
            Ingredients.Add(ingredient);

            CurrentView = _showView;
        }
        private void DeleteIngredient(Ingredient ingredient)
        {
            Ingredients.Remove(Ingredients.Where(i => i.Name == ingredient.Name).Single());
        }
    }
}
