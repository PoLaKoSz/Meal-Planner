using MealPlanner.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MealPlanner.DataAccessLayer
{
    public class DataManager
    {
        private readonly SQLiteDB _db;
        private List<Ingredient> _ingredients;
        private ObservableCollection<MealWithRepastType> _meals;
        private List<Day> _menu;
        private List<Repast> _repast;

        public List<Ingredient> Ingredients
        {
            get
            {
                if (_ingredients == null)
                    _ingredients = _db.Ingredient().All();

                return _ingredients;
            }
        }
        public ObservableCollection<MealWithRepastType> Meals
        {
            get
            {
                if (_meals == null)
                    _meals = new ObservableCollection<MealWithRepastType>(_db.Meal().All());

                return _meals;
            }
        }
        public List<Day> Menu
        {
            get
            {
                if (_menu == null)
                    _menu = _db.Menu().All();

                return _menu;
            }
        }
        public List<Repast> Repast
        {
            get
            {
                if (_repast == null)
                    _repast = _db.Repast().All();

                return _repast;
            }
        }



        public DataManager(string path)
        {
            _db = new SQLiteDB(path);
            new SQLiteMigrator(_db).UpdateDatabase();
        }
    }
}
