using Microsoft.Maui.Controls;
using SaveUpp.ViewModel;

namespace SaveUpp.View
{
    public partial class NewProductPage : ContentPage
    {
        public NewProductPage()
        {
            InitializeComponent();
            BindingContext = ((AppShell)Shell.Current).MainViewModel;
        }
    }
}
