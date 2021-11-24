using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace APILayer.Shared.Models
{
    public interface IEpisodeDataManager
    {
        Task<List<Episode>> GetAllEpisodes();
        Task<Episode> GetEpisode(int Id);
        Task<List<Episode>> SearchEpisodes(string Title);
        Task<Episode> AddEpisode(Episode Episode);
        Task<Episode> UpdateEpisode(Episode Episode);
        Task DeleteEpisode(string Title);
    }
}
