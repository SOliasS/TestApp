using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TestApp.ViewModels
{
    public class MainPageVM:BaseViewModel
    {
        private bool isHiding;
        public ICommand SelectionCommand { get; set; }
        public MainPageVM()
        {
            SelectionCommand = new AsyncCommand<Grouping>(item => ChangeGroup(item));
            ClickCommand = new AsyncCommand(()=>Change());
            Display = new List<DisplayItem>();
            int i = 0;
            Display.Add(new DisplayItem(""+i));
            i++;
            Display.Add(new DisplayItem("" + i));

            ActiveTodos = new ObservableCollection<Grouping> { new Grouping { new DisplayItem("" + i) , new DisplayItem("" + i+1) }, new Grouping { new DisplayItem("" + i+2) } };
        }
        private async Task ChangeGroup(Grouping item) => item.IsExpanded = !item.IsExpanded;
        private List<DisplayItem> display;
        public List<DisplayItem> Display
        {
            get { return display; }
            set { SetProperty(ref display, value); }
        }
        public ObservableCollection<Grouping> ActiveTodos
        {
            get { return activeTodos; }
            set { SetProperty(ref activeTodos, value); }
        }
        private ObservableCollection<Grouping> activeTodos;
        public bool IsHiding
        {
            get { return isHiding; }
            set { SetProperty(ref isHiding, value); }
        }
        private DisplayItem selected;
        public DisplayItem Selected
        {
            get { return selected; }
            set {
                value.IsDisplayed = !value.IsDisplayed;
                //SetProperty(ref selected, value);
                OnPropertyChanged("Selected");
            }
        }

        public ICommand ClickCommand { get; set; }
        public async Task Change()
        {
            IsHiding = !IsHiding;
        }
    }
}
