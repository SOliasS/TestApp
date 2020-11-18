using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestApp.Views
{

    public partial class SecondPage : ContentPage
    {
        public SecondPage()
        {
            BindingContext = new MainPageVM();
            InitializeComponent();
        }
    }
}