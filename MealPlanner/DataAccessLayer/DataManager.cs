using MealPlanner.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace MealPlanner.DataAccessLayer
{
    public class DataManager
    {
        private readonly SQLiteDB _db;
        private List<Ingredient> _ingredients;
        private List<IMeal> _meals;
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
        public List<IMeal> Meals
        {
            get
            {
                if (_meals == null)
                    _meals = LoadFile("meals", new List<IMeal>());

                return _meals;
            }
            set
            {
                _meals = value;

                SaveToFile("meals", value);
            }
        }
        public List<Day> Menu
        {
            get
            {
                if (_menu == null)
                    _menu = LoadFile("menu", new List<Day>());

                return _menu;
            }
            set
            {
                _menu = value;

                SaveToFile("menu", value);
            }
        }
        public List<Repast> Repast
        {
            get
            {
                if (_repast == null)
                    _repast = LoadFile("repast", new List<Repast>());

                return _repast;
            }
            set
            {
                _repast = value;

                SaveToFile("repast", value);
            }
        }



        public DataManager(string path)
        {
            _db = new SQLiteDB(path);
            new SQLiteMigrator(_db).UpdateDatabase();
        }



        private T LoadFile<T>(string path, T defaultValue)
        {
            path += ".json";

            if (!File.Exists(path))
                return defaultValue;

            string rawJson = File.ReadAllText(path);

            return JsonConvert.DeserializeObject<T>(rawJson);
        }

        private void SaveToFile<T>(string path, T collection)
        {
            string rawJson = JsonConvert.SerializeObject(collection, Formatting.None);

            File.WriteAllText(path += ".json", rawJson);
        }
    }
}
