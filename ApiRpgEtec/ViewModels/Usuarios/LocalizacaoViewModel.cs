using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;
using System;
using System.Collections.Generic;
using System.Text;
using Map = Microsoft.Maui.Controls.Maps.Map;

namespace ApiRpgEtec.ViewModels.Usuarios
{ 
    public class LocalizacaoViewModel : BaseViewModel
    {
        private Map meuMapa;
        public Map MeuMapa
        {
            get => meuMapa;
            set
            {
               if (value != null)
                {
                    meuMapa = value;
                    OnPropertyChanged();
                }
            }

        }
        public async void InicializarMapa()
        {
            try
            {
                //coodernadas geográficas
                Location location = new Location(-23.5200241d, -46.596498d);
                Pin pinEtec = new Pin()
                {
                    Type = PinType.Place,
                    Label = "Etec Horácio",
                    Address = "Rua alcântra, 113, Vila Guilherme",
                    Location = location
                };
                Map map = new Map();
                MapSpan mapSpan = MapSpan
                    .FromCenterAndRadius(location, Distance.FromKilometers(5));
                map.Pins.Add(pinEtec);
                map.MoveToRegion(mapSpan);

                MeuMapa = map;
            }
            catch (Exception ex)  
            {
                await Application.Current.MainPage.DisplayAlert("Erro", ex.Message, "OK");
            }
        }

    }
}
