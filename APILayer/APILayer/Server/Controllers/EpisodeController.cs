using System;
using System.Threading.Tasks;
using APILayer.Server.Data;
using APILayer.Shared.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace APILayer.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EpisodesController : ControllerBase
    {
        private LocalEpisodeManager episodeManager;

        // Versioning: most common is in the url, but it breaks REST.
        // Best practice (for rolling your own) is to add a header
        // Consider Azure API Management Service

        public EpisodesController(LocalEpisodeManager _episodeManager)
        {
            episodeManager = _episodeManager;
        }

        // GET: episode
        [HttpGet]
        [EnableCors("MyAllowSpecificOrigins")]

        public async Task<ActionResult<EpisodesResponse>> Get()
        {
            try
            {
                var Episodes = await episodeManager.GetAllEpisodes();
                return Ok(new EpisodesResponse()
                {
                    Success = true,
                    Episodes = Episodes
                });
            }
            catch (Exception ex)
            {
                // log exception here
                return StatusCode(500);
            }
            
        }

        // GET: episode/Id
        [HttpGet("{Id}")]
        [EnableCors("MyAllowSpecificOrigins")]

        public async Task<ActionResult<EpisodeResponse>> Get(int Id)
        {
            try
            {
                // Validate the incoming data here.
                bool validRequest = true;
                if (!validRequest)
                {
                    return BadRequest("Reason for the bad request");
                }

                var Episode = await episodeManager.GetEpisode(Id);
                return Ok(new EpisodeResponse()
                {
                    Success = true,
                    Episode = Episode
                });
            }
            catch (Exception ex)
            {
                // log exception here
                return StatusCode(500);
            }

        }

        // GET: episode/Title/search        
        [HttpGet("{Title}/search")]
        [EnableCors("MyAllowSpecificOrigins")]

        public async Task<ActionResult<EpisodesResponse>> Search(string Title)
        {
            try
            {
                // Validate the incoming data here.
                bool validRequest = true;
                if (!validRequest)
                {
                    return BadRequest("Reason for the bad request");
                }

                var Episodes = await episodeManager.SearchEpisodes(Title);
                return Ok(new EpisodesResponse()
                {
                    Success = true,
                    Episodes = Episodes
                });
            }
            catch (Exception ex)
            {
                // log exception here
                return StatusCode(500);
            }
        }

        // POST: episode
        [HttpPost]
        public async Task<ActionResult<EpisodeResponse>> AddEpisode(Episode Episode)
        {
            try
            {
                // Validate the incoming data here.
                bool validRequest = true;
                if (!validRequest)
                {
                    return BadRequest("Reason for the bad request");
                }

                Episode = await episodeManager.AddEpisode(Episode);
                return Ok(new EpisodeResponse()
                {
                    Success = true,
                    Episode = Episode
                });
            }
            catch (Exception ex)
            {
                // log exception here
                return StatusCode(500);
            }
        }

        // PUT: episode
        [HttpPut]
        public async Task<ActionResult<EpisodeResponse>> UpdateEpisode(Episode Episode)
        {
            try
            {
                // Validate the incoming data here.
                bool validRequest = true;
                if (!validRequest)
                {
                    return BadRequest("Reason for the bad request");
                }

                Episode = await episodeManager.UpdateEpisode(Episode);
                return Ok(new EpisodeResponse()
                {
                    Success = true,
                    Episode = Episode
                });
            }
            catch (Exception ex)
            {
                // log exception here
                return StatusCode(500);
            }
        }

        // DELETE: episode/title
        [HttpDelete("{Title}")]
        public async Task<IActionResult> DeleteEpisode(string Title)  
        {
            try
            {
                await episodeManager.DeleteEpisode(Title);
            }
            catch (Exception ex)
            {
                // log exception here
            }
            return NoContent();
        }
    }
}
