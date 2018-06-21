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
    public class RepastViewModel : BaseViewModel
    {
        private ObservableCollection<Repast> _repast;


        public ObservableCollection<Repast> Repast
        {
            get => _repast;
            set
            {
                _repast = value;
                NotifyPropertyChanged();
            }
        }
        public Repast NewRepast { get; set; }


        public ICommand DeleteRepastCommand
        {
            get => new RelayCommand(r => DeleteRepast((Repast)r), r => true);
        }
        public ICommand SaveRepastCommand
        {
            get => new RelayCommand(p => SaveRepast(), p => true);
        }        
        public ICommand AddNewRepastCommand
        {
            get => new RelayCommand(
                r => AddNewRepast(new Repast((string) r)),
                r => IsNoDuplication(new Repast((string) r)));
        }

        public ICommand MoveUpCommand
        {
            get => new RelayCommand(r => MoveUpRepast((Repast)r), r => CanMoveUp((Repast)r));
        }
        public ICommand MoveDownCommand
        {
            get => new RelayCommand(r => MoveDownRepast((Repast)r), r => CanMoveDown((Repast)r));
        }



        public RepastViewModel()
            : base("Repast")
        {
            _showView = new ShowRepastView
            {
                DataContext = this
            };
            _addView = new AddRepastView
            {
                DataContext = this
            };

            Repast = new ObservableCollection<Repast>();

            LoadRepast();

            CurrentView = _showView;
        }



        private void LoadRepast()
        {
            Repast = new ObservableCollection<Repast>(ShellViewModel.Data.Repast);
        }
        private void SaveRepast()
        {
            ShellViewModel.Data.Repast = new List<Repast>(Repast);
        }

        private bool IsNoDuplication(Repast repast)
        {
            return repast.Name.Length > 2 && !Repast.Contains(repast);
        }

        private void AddNewRepast(Repast repast)
        {
            Repast.Add(repast);

            CurrentView = _showView;
        }
        private void DeleteRepast(Repast repast)
        {
            Repast.Remove(Repast.Where(i => i.Name == repast.Name).Single());
        }

        private void MoveUpRepast(Repast repast)
        {
            int currentIndex = Repast.IndexOf(repast);

            Repast[currentIndex] = Repast[currentIndex - 1];
            Repast[currentIndex - 1] = repast;
        }
        private bool CanMoveUp(Repast repast)
        {
            return Repast.IndexOf(repast) != 0;
        }

        private void MoveDownRepast(Repast repast)
        {
            int currentIndex = Repast.IndexOf(repast);

            Repast[currentIndex] = Repast[currentIndex + 1];
            Repast[currentIndex + 1] = repast;
        }
        private bool CanMoveDown(Repast repast)
        {
            return Repast.IndexOf(repast) != Repast.Count - 1;
        }
    }
}
