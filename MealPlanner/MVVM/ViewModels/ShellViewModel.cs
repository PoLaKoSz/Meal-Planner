using MealPlanner.DataAccessLayer;
using MealPlanner.MVVM.Models;
using MealPlanner.MVVM.Views;
using MealPlanner.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace MealPlanner.MVVM.ViewModels
{
    public class ShellViewModel : ObservableObject
    {
        private ICommand _changePageCommand;

        private IPageViewModel _currentPageViewModel;
        private List<IPageViewModel> _pageViewModels;

        private ShellView _view { get; set; }

        public ICommand ChangePageCommand
        {
            get
            {
                if (_changePageCommand == null)
                {
                    _changePageCommand = new RelayCommand(
                        p => ChangeViewModel((IPageViewModel)p),
                        p => p is IPageViewModel);
                }

                return _changePageCommand;
            }
        }

        public List<IPageViewModel> PageViewModels
        {
            get
            {
                if (_pageViewModels == null)
                    _pageViewModels = new List<IPageViewModel>();

                return _pageViewModels;
            }
        }
        public IPageViewModel CurrentPageViewModel
        {
            get
            {
                return _currentPageViewModel;
            }
            set
            {
                if (_currentPageViewModel != value)
                {
                    _currentPageViewModel = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public static DataManager Data { get; set; }



        public ShellViewModel()
        {
            Data = new DataManager();

            PageViewModels.Add(new MenuViewModel());
            PageViewModels.Add(new RepastViewModel());
            PageViewModels.Add(new MealViewModel());
            PageViewModels.Add(new IngredientViewModel());

            CurrentPageViewModel = PageViewModels[0];

            _view = new ShellView(this);

            ShowUI();
        }



        public void ShowUI()
        {
            _view.Show();
        }

        private void ChangeViewModel(IPageViewModel viewModel)
        {
            CurrentPageViewModel = PageViewModels
                .FirstOrDefault(vm => vm == viewModel);
        }
    }
}
