using System;
using PDMI6_TP_Final.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PDMI6_TP_Final
{
    public partial class App : Application
    {
        public App()
        {
            // The root page of your application
            MainPage = new NavigationPage(new
            View.Mercadorias.MainPage());
        }

        static Mercadoria mercadoriaModel;
        public static Mercadoria MercadoriaModel
        {
            get
            {
                if (mercadoriaModel == null)
                {
                    mercadoriaModel = new Mercadoria();
                }
                return mercadoriaModel;
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
