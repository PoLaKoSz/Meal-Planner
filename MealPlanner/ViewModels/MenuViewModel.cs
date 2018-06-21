using MealPlanner.Models;
using MealPlanner.MVVM;
using MealPlanner.MVVM.ViewModels;
using MealPlanner.Views;
using MealPlanner.Workers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MealPlanner.ViewModels
{
    public class MenuViewModel : BaseViewModel
    {
        private DateTime _endDate;
        private DateTime _startDate;
        private List<RepastType> _availableRepasts;

        public MenuGenerator MenuGenerator { get; set; }

        public DateTime StartDate
        {
            get => _startDate;
            set
            {
                _startDate = value;
                NotifyPropertyChanged();
            }
        }
        public DateTime EndDate
        {
            get => _endDate;
            set
            {
                _endDate = value;
                NotifyPropertyChanged();
            }
        }

        public List<RepastType> AvailableRepasts
        {
            get => _availableRepasts;
            set
            {
                _availableRepasts = value;
                NotifyPropertyChanged();
            }
        }


        public ICommand GenereteMenuCommand
        {
            get => new RelayCommand(m => GenerateMenu(), m => true);
        }



        public MenuViewModel()
            : base("Menu")
        {
            _showView = new ShowMenuView()
            {
                DataContext = this
            };

            CurrentView = _showView;

            AvailableRepasts = GetRepastTypes();

            MenuGenerator = new MenuGenerator(ShellViewModel.Data.Repast, new ObservableCollection<Day>());

            StartDate = DateTime.Now;
            EndDate = DateTime.Now.AddDays(7);
        }



        private List<RepastType> GetRepastTypes()
        {
            var repastTypes = new List<RepastType>();

            foreach (Repast repast in ShellViewModel.Data.Repast)
                repastTypes.Add(new RepastType(repast.Name));

            return repastTypes;
        }

        private void GenerateMenu()
        {
            MenuGenerator.ChangeDateRange(StartDate, EndDate);
            MenuGenerator.RepastTypes = AvailableRepasts;
            ShellViewModel.Data.Menu = new List<Day>(MenuGenerator.GenerateMenu(10, new RandomGenerator(), new MealComparer()));
        }
    }
}
