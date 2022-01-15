using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PDMI6_TP_Final.View.Mercadorias
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DadosMercadoriaView : ContentPage
    {
        private int mercadoriaId = 0;
        public DadosMercadoriaView()
        {
            Title = "Novo produto";
            InitializeComponent();
            btnDeletar.IsEnabled = false;
        }

        public DadosMercadoriaView(int Id)
        {
            Title = "Editar produto";
            InitializeComponent();
            btnDeletar.IsEnabled = true;
            var mercadoria = App.MercadoriaModel.GetMercadoria(Id);
            txtNome.Text = mercadoria.Nome;
            txtPeso.Text = mercadoria.Peso.ToString();
            txtNomeProdutor.Text = mercadoria.NomeProdutor;
            txtEmailProdutor.Text = mercadoria.EmailProdutor;
            txtNCM.Text = mercadoria.NCM.ToString();
            mercadoriaId = mercadoria.Id;
        }
        public void OnSalvar(object sender, EventArgs args)
        {
            if (string.IsNullOrEmpty(txtNome.Text) || string.IsNullOrWhiteSpace(txtNome.Text))
                DisplayAlert("ERRO", "Nome não pode estar em branco", "OK");
            else if (string.IsNullOrEmpty(txtNomeProdutor.Text) || string.IsNullOrWhiteSpace(txtNomeProdutor.Text))
                DisplayAlert("ERRO", "Nome do Produtor não pode estar em branco", "OK");
            else if (string.IsNullOrEmpty(txtNCM.Text) || string.IsNullOrWhiteSpace(txtNCM.Text))
                DisplayAlert("ERRO", "Código NCM não pode estar em branco", "OK");
            else
            {
                PDMI6_TP_Final.Model.Mercadoria mercadoria = new
                PDMI6_TP_Final.Model.Mercadoria()
                {
                    Nome = txtNome.Text,
                    Peso = (float)Convert.ToDouble(txtPeso.Text),
                    NomeProdutor = txtNomeProdutor.Text,
                    EmailProdutor = txtEmailProdutor.Text,
                    NCM = (int)Convert.ToDouble(txtNCM.Text),
                    Id = mercadoriaId
                };
                App.MercadoriaModel.SalvarMercadoria(mercadoria);
                Navigation.PopAsync();
            }
        }
        public void OnDeletar(object sender, EventArgs args)
        {
            App.MercadoriaModel.RemoverMercadoria(mercadoriaId);
            Navigation.PopAsync();
        }
        public void OnFechar(object sender, EventArgs args)
        {
            Navigation.PopAsync();
        }
        private void Limpar()
        {
            txtNome.Text = txtPeso.Text = txtNomeProdutor.Text = txtEmailProdutor.Text = txtNCM.Text = string.Empty;
        }
    }
}