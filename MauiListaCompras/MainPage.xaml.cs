﻿using System.Collections.ObjectModel;
using MauiListaCompras.Models;

namespace MauiListaCompras
{
    public partial class MainPage : ContentPage
    {
        ObservableCollection<Produto> lista_produtos =
            new ObservableCollection<Produto>();

        public MainPage()
        {
            InitializeComponent();
            lst_produtos.ItemsSource = lista_produtos;
        }

        private void ToolbarItem_Somar(object sender, EventArgs e)
        {
            double soma = lista_produtos.Sum(i => (i.Preco * i.Quantidade));
            string msg = $"o total é {soma:C}";
            DisplayAlert("Somatória", msg, "Fechar");
        }

        protected override void OnAppearing()
        {
            if (lista_produtos.Count == 0)
            {
                Task.Run(async () =>
                {
                    List<Produto> tmp = await App.Db.GetAll();
                    foreach (Produto p in tmp)
                    {
                        lista_produtos.Add(p);
                    }
                });
            }
        }

        private void ToolbarItem_Clicked_Add(object sender, EventArgs e)
        {

        }

        private void txt_search_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ref_carregando_Refreshing(object sender, EventArgs e)
        {
            lista_produtos.Clear();
            Task.Run(async () =>
            {
                List<Produto> tmp = await App.Db.GetAll();
                foreach (Produto p in tmp)
                {
                    lista_produtos.Add(p);
                }
            });
            ref_carregando.IsRefreshing = false;
        }

        private void lst_produtos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }

        private void MenuItem_Clicked_Remover(object sender, EventArgs e)
        {

        }
    }

}
