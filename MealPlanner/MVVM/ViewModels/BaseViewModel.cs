using MealPlanner.MVVM.Models;
using System.Windows.Controls;
using System.Windows.Input;

namespace MealPlanner.MVVM.ViewModels
{
    public abstract class BaseViewModel : ObservableObject, IPageViewModel
    {
        private UserControl _currentView;

        public string Name { get; protected set; }

        protected UserControl _showView { get; set; }
        protected UserControl _addView { get; set; }
        protected UserControl _editView { get; set; }
        protected UserControl _deleteView { get; set; }

        public UserControl CurrentView
        {
            get => _currentView;
            protected set
            {
                _currentView = value;
                NotifyPropertyChanged();
            }
        }

        public ICommand NavigateToAddViewCommand
        {
            get => new RelayCommand(p => NavigateToView(_addView), p => true);
        }
        public ICommand NavigateToShowViewCommand
        {
            get => new RelayCommand(p => NavigateToView(_showView), p => true);
        }



        public BaseViewModel(string viewModelName)
        {
            Name = viewModelName;
        }



        protected void NavigateToView(UserControl newView)
        {
            CurrentView = newView;
        }
    }
}
