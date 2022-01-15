using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PDMI6_TP_Final.MercadoriasViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PDMI6_TP_Final.View.Mercadorias
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        MercadoriaViewModel vmMercadoria;
        public MainPage()
        {
            vmMercadoria = new MercadoriaViewModel();
            BindingContext = vmMercadoria;
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            vmMercadoria = new MercadoriaViewModel();
            BindingContext = vmMercadoria;
            base.OnAppearing();
        }
        private void OnNovo(object sender, EventArgs args)
        {
            Navigation.PushAsync(new DadosMercadoriaView());
        }
        private void OnCreditos(object sender, EventArgs args)
        {
            Navigation.PushAsync(new Creditos());
        }
        private void OnMercadoriaTapped(object sender,
        ItemTappedEventArgs args)
        {
            var selecionado = args.Item as PDMI6_TP_Final.Model.Mercadoria;
            Navigation.PushAsync(new DadosMercadoriaView(selecionado.Id));
        }
    }
}