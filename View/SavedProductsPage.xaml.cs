using Microsoft.Maui.Controls;
using SaveUpp.ViewModel;

namespace SaveUpp.View
{
    public partial class SavedProductsPage : ContentPage
    {
        public SavedProductsPage()
        {
            InitializeComponent();
            BindingContext = ((AppShell)Shell.Current).MainViewModel;
        }
    }
}
