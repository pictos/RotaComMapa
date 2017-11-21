using RouteMap.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms.Maps;
using System.Threading.Tasks;
using Xamarin.Forms;

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
        public static Map myMap;
        public Command PesquisarCommand { get; }
        private DirecaoServico servico;
        private readonly string key = "AIzaSyAJ4OGKbN0pMehElNTIn7jpu2-KSFqlRj4";

        #endregion

        public MapaViewModel()
        {
            PesquisarCommand = new Command(async () => await ExecutePesquisarCommand(), () => !IsBusy);
            servico = new DirecaoServico(key);
            myMap = new Map();
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
                        foreach (var legs in rotas.Legs)
                        {

                            foreach (var steps in legs.Steps)
                            {
                                var localizacao = steps.EndLocation;
                                var posicao = new Position(localizacao.Latitude, localizacao.Longitude);
                                var pin = new Pin
                                {
                                    Type = PinType.Place,
                                    Position = posicao,
                                    Label = $"Latitude:{localizacao.Latitude}",
                                    Address = $"Longitude:{localizacao.Longitude}"
                                };

                                myMap.Pins.Add(pin);
                            }                           
                        }
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
