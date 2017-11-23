using RouteMap.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using RouteMap.CustomRender;
using Xamarin.Forms.Maps;

namespace RouteMap.ViewModels
{
    public class MapaViewModel : BaseViewModel
    {
        #region Propriedades
        private bool _isBusy;

        public bool IsBusy
        {
            get { return _isBusy; }
            set { _isBusy = value; OnPropertyChanged(); PesquisarCommand.ChangeCanExecute(); }
        }

        private string _origem;

        public string Origem
        {
            get { return _origem; }
            set { _origem = value; OnPropertyChanged(); }
        }

        private string _destino;

        public string Destino
        {
            get { return _destino; }
            set { _destino = value; OnPropertyChanged(); }
        }
        public static MapCustomRender myMap;
        public Command PesquisarCommand { get; }
        private DirecaoServico servico;
        private readonly string key = "SUA KEY";

        #endregion

        public MapaViewModel()
        {
            PesquisarCommand = new Command(async () => await ExecutePesquisarCommand(), () => !IsBusy);
            servico = new DirecaoServico(key);
            myMap = new MapCustomRender();
        }

        async Task ExecutePesquisarCommand()
        {
            //Garante que o botão ficara desabilitado até o fim deste bloco de código
            if(!IsBusy)
            {
                try
                {
                    
                    IsBusy = true;
                    var resultado = await servico.ObterRota(Origem, Destino);
                    
                    foreach (var rotas in resultado.Rotas)
                    {
                       var linhas = rotas.Polyline;
                       var polilyne = linhas.Positions.Select(l => new Position(l.Latitude, l.Longitude)).ToList();
                       myMap.CoordenadasRota = polilyne;
                    }
                    
                    
                }
                catch (Exception ex)
                {

                    await DisplayAlert("Algo de errado não está certo!", $"O erro é: {ex.Message}","Ok");
                }
                finally
                {
                    IsBusy = false;
                }
            }
        }
    }
}
