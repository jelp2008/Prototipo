﻿using AppClima.Clases;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AppClima.Servicios
{
    public static class ServicioClima
    {
        static string key = "9c26c915b667d51a289e25805b903c5b";

        public static async Task<Clima> ConsultarClima(string ciudad)
        {

            var conexion = $"https://api.openweathermap.org/data/2.5/weather?q={ciudad}&appid={key}";

            using (var cliente = new HttpClient())
            {

                var peticion = await cliente.GetAsync(conexion);

                if (peticion != null)
                {
                    var json = peticion.Content.ReadAsStringAsync().Result;

                    var datos = (JContainer)JsonConvert.DeserializeObject(json);

                    if (datos["weather"] != null)
                    {
                        var clima = new Clima();
                        clima.Titulo = (string)datos["name"];
                        clima.Temperatura = ((float)datos["main"]["temp"] - 273.15).ToString("N2") + " °C";
                        clima.Viento = (string)datos["wind"]["speed"] + " mph";
                        clima.Humedad = (string)datos["main"]["humidity"] + " %";
                        clima.Visibilidad = (string)datos["weather"][0]["main"];

                        var fechaBase = new DateTime(1970, 1, 1, 0, 0, 0, 0);
                        var amanecer = fechaBase.AddSeconds((double)datos["sys"]["sunrise"]);
                        var ocaso = fechaBase.AddSeconds((double)datos["sys"]["sunset"]);
                        clima.Amanecer = amanecer.ToString() + " UTC";
                        clima.Ocaso = ocaso.ToString() + " UTC";

                        return clima;
                    }
                }

            }

            return default(Clima);
        }

    }
}
