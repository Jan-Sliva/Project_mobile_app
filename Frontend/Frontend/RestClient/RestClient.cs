using Frontend.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Frontend.RestClient.Resources.GameResources.FullGame;

namespace Frontend.RestClient
{
    public class RestClient
    {
        private const string WebServiceUrl = "http://10.0.0.142:52721/api/";

        public async Task<GameResource> GetFullGameByIdAsync(int id)
        {
            var httpClient = new HttpClient();

            var json = await httpClient.GetStringAsync(WebServiceUrl + "Game/FullGame" + id);

            var GameModel = JsonConvert.DeserializeObject<GameResource>(json);

            return GameModel;
        }
    }
}
