using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace TestApp.ViewModels
{
    public class Grouping : ObservableCollection<DisplayItem>, INotifyPropertyChanged
    {
        private bool isExpanded;
        public bool IsExpanded
        {
            get => isExpanded;
            set
            {
                if (isExpanded != value)
                {
                    isExpanded = value;

                    foreach (var item in this)
                    {
                        item.IsDisplayed = isExpanded;
                    }

                    OnPropertyChanged();
                    OnPropertyChanged("StateIcon");
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]
                                      string name = "")
        {
            var changed = PropertyChanged;

            if (changed == null)
            {
                return;
            }

            changed(this, new PropertyChangedEventArgs(name));
        }

        protected override void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
            OnPropertyChanged("LocalCount");
        }
    }
}
