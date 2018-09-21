using MealPlanner.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

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
            set
            {
                _ingredients = value;

                _db.Ingredient().Update(value);
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
            set
            {
                _meals = value;

                _db.Meal().Update(new List<MealWithRepastType>(value));
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
            set
            {
                _menu = value;

                // TODO: Hiányzik az UPDATE
                //_db.Menu().Update(value);
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
            set
            {
                _repast = value;

                // TODO: Hiányzik az UPDATE
                //_db.Repast().Update(value);
            }
        }



        public DataManager(string path)
        {
            _db = new SQLiteDB(path);
            new SQLiteMigrator(_db).UpdateDatabase();
        }
    }
}
