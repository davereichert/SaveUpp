using Microsoft.Maui.Controls;
using SaveUpp.ViewModel;

namespace SaveUpp.View
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = ((AppShell)Shell.Current).MainViewModel;
        }
    }
}
