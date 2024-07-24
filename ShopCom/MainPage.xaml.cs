using Microsoft.Maui.Controls.Shapes;

namespace ShopCom
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
        {
            (sender as Rectangle)?.ScaleTo(2);
            (sender as Rectangle)?.TranslateTo(200, 200);
        }
    }

}
