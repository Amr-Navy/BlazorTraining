using APILayer.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace APILayer.Client.Services
{
    public class ApiEpisodeManager : IEpisodeDataManager
    {
        private readonly HttpClient httpClient;

        public ApiEpisodeManager(HttpClient _httpClient)
        {
            httpClient = _httpClient;
        }

        public async Task<Episode> GetEpisode(int Id)
        {
            string Url = "episodes/" + Id.ToString();
            var result = await httpClient.GetAsync(Url);
            result.EnsureSuccessStatusCode();
            var response = await result.Content.ReadAsStringAsync();
            var EpisodeResponse = JsonConvert.DeserializeObject<EpisodeResponse>(response);
            if (EpisodeResponse.Success)
            {
                return EpisodeResponse.Episode;
            }
            else
            {
                return new Episode();
            }
        }

        public async Task<List<Episode>> GetAllEpisodes()
        {
            string Url = "episodes";
            var result = await httpClient.GetAsync(Url);
            result.EnsureSuccessStatusCode();
            var response = await result.Content.ReadAsStringAsync();
            var EpisodesResponse = JsonConvert.DeserializeObject<EpisodesResponse>(response);
            if (EpisodesResponse.Success)
            {
                return EpisodesResponse.Episodes;
            }
            else
            {
                return new List<Episode>();
            }
        }

        public async Task<List<Episode>> SearchEpisodes(string Title)
        {
            string Url = "episodes"
                + "/" + WebUtility.HtmlEncode(Title)
                + "/search";
            var result = await httpClient.GetAsync(Url);
            result.EnsureSuccessStatusCode();
            var response = await result.Content.ReadAsStringAsync();
            var EpisodesResponse = JsonConvert.DeserializeObject<EpisodesResponse>(response);
            if (EpisodesResponse.Success)
            {
                return EpisodesResponse.Episodes;
            }
            else
            {
                return new List<Episode>();
            }
        }

        public async Task<Episode> AddEpisode(Episode Episode)
        {
            string Url = "episodes";
            var result = await httpClient.PostAsJsonAsync(Url, Episode);
            result.EnsureSuccessStatusCode();
            var response = await result.Content.ReadAsStringAsync();
            var EpisodeResponse = JsonConvert.DeserializeObject<EpisodeResponse>(response);
            if (EpisodeResponse.Success)
            {
                return EpisodeResponse.Episode;
            }
            else
            {
                return new Episode();
            }
        }

        public async Task<Episode> UpdateEpisode(Episode Episode)
        {
            string Url = "episodes";
            var result = await httpClient.PutAsJsonAsync(Url, Episode);
            result.EnsureSuccessStatusCode();
            var response = await result.Content.ReadAsStringAsync();
            var EpisodeResponse = JsonConvert.DeserializeObject<EpisodeResponse>(response);
            if (EpisodeResponse.Success)
            {
                return EpisodeResponse.Episode;
            }
            else
            {
                return new Episode();
            }
        }

        public async Task DeleteEpisode(string Title)
        {
            string Url = "episodes"
                + "/" + WebUtility.HtmlEncode(Title);

            var result = await httpClient.DeleteAsync(Url);
            result.EnsureSuccessStatusCode();
        }
    }
}
