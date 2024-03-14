using MauiListaCompras.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MauiListaCompras.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NovoProduto : ContentPage
    {
        public NovoProduto()
        {
            InitializeComponent();
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            try
            {
                Produto p = new Produto
                {
                    Descricao = txt_descricao.Text,
                    Quantidade = Convert.ToDouble(txt_quantidade.Text),
                    Preco = Convert.ToDouble(txt_preco.Text),
                };

                await App.Db.Insert(p);
                await DisplayAlert("Sucesso!", "Produto inserido", "OK");
            } catch(Exception ex)
            {
                await DisplayAlert("Ops", ex.Message, "OK");
            }
        }

        private void ToolbarItem_Clicked_1(object sender, EventArgs e)
        {

        }
    }
}