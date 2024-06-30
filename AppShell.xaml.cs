using Microsoft.Maui.Controls;
using SaveUpp.ViewModel;
using SaveUpp.View;

namespace SaveUpp
{
    public partial class AppShell : Shell
    {
        public MainViewModel MainViewModel { get; private set; }

        public AppShell()
        {
            InitializeComponent();
            MainViewModel = new MainViewModel();
            BindingContext = MainViewModel;

            Routing.RegisterRoute(nameof(MainPage), typeof(View.MainPage));
            Routing.RegisterRoute(nameof(NewProductPage), typeof(View.NewProductPage));
            Routing.RegisterRoute(nameof(SavedProductsPage), typeof(View.SavedProductsPage));
        }
    }
}
