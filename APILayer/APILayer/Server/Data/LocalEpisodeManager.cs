using APILayer.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APILayer.Server.Data
{
    public class LocalEpisodeManager : IEpisodeDataManager
    {
        List<Episode> episodes = new List<Episode>();
        public LocalEpisodeManager()
        {
            episodes.Add(new Episode
            {
                Id = 1,
                Title = "Introducing Blazor",
                Description = "In this episode of Blazor Train, we’ll take a first look at Microsoft Blazor.",
                Duration = "19:45",
                PublishDate = "May 26, 2020",
                ImageUrl = "/images/01-introducing-blazor.png",
                YouTubeUrl = "https://youtu.be/1FYhpL-JFY0"
            });

            episodes.Add(new Episode
            {
                Id = 2,
                Title = "Blazor Server vs. WASM",
                Description = "In this episode of Blazor Train, we’ll compare the two hosting models: Blazor Server and Blazor WebAssembly.",
                Duration = "20.39",
                PublishDate = "May 26, 2020",
                ImageUrl = "/images/02-server-vs-wasm.png",
                YouTubeUrl = "https://youtu.be/CUJP82uAU5Y"
            });

            episodes.Add(new Episode
            {
                Id = 3,
                Title = "WebAssembly",
                Description = "In this episode of Blazor Train, we’ll dive into WebAssembly.",
                Duration = "12:21",
                PublishDate = "May 26, 2020",
                ImageUrl = "/images/03-webassembly.png",
                YouTubeUrl = "https://youtu.be/zUgyq4zpgIU"
            });

            episodes.Add(new Episode
            {
                Id = 4,
                Title = "Synchronicity",
                Description = "Develop a Blazor WASM and Server app at the same time.",
                Duration = "16:59",
                PublishDate = "May 26, 2020",
                ImageUrl = "/images/04-synchronicity.png",
                YouTubeUrl = "https://youtu.be/SkYQDPXw__c"
            });

            episodes.Add(new Episode
            {
                Id = 5,
                Title = "Steve Sanderson and David Fowler",
                Description = "Carl Interviews Steve Sanderson and David Fowler about the evolution of Blazor.",
                Duration = "20:58",
                PublishDate = "June 1, 2020",
                ImageUrl = "/images/05-interview.png",
                YouTubeUrl = "https://youtu.be/4je1gmH6G7w"
            });

            episodes.Add(new Episode
            {
                Id = 6,
                Title = "Anatomy of a Blazor Project",
                Description = "Carl takes you on a tour of a Blazor project file by file.",
                Duration = "26:41",
                PublishDate = "June 11, 2020",
                ImageUrl = "/images/06-projects.png",
                YouTubeUrl = "https://youtu.be/3gJoO6RFVkQ",
                MaterialsZipFileName = "http://blazordeskshow.com/blazortrainfiles/projectoverview.zip"
            });

            episodes.Add(new Episode
            {
                Id = 7,
                Title = "Routing and Navigation",
                Description = "Carl and guest Chris Sainty cover the ins and outs of routing in Blazor.",
                Duration = "42:25",
                PublishDate = "June 18, 2020",
                ImageUrl = "/images/07-routing.png",
                YouTubeUrl = "https://youtu.be/Rp-UDNLqZEc",
            });

            episodes.Add(new Episode
            {
                Id = 8,
                Title = "Blazor Component Life Cycle",
                Description = "What is a Blazor Component? How long does it live? How can we hook it?",
                Duration = "18:44",
                PublishDate = "June 26, 2020",
                ImageUrl = "/images/08-lifecycle.png",
                YouTubeUrl = "https://youtu.be/dpyUcRdbAcc",
                MaterialsZipFileName = "http://blazordeskshow.com/blazortrainfiles/lifecycle.zip"
            });

            episodes.Add(new Episode
            {
                Id = 9,
                Title = "Binding and Event Handling",
                Description = "Carl brings in a C#/JavaScript developer for his reaction to seeing Blazor binding for the first time.",
                Duration = "34:07",
                PublishDate = "July 2, 2020",
                ImageUrl = "/images/09-binding.png",
                YouTubeUrl = "https://youtu.be/kg6JBEFu_kc",
                MaterialsZipFileName = "http://blazordeskshow.com/blazortrainfiles/binding.zip"
            });

            episodes.Add(new Episode
            {
                Id = 10,
                Title = "Configuration and Dependency Injection",
                Description = "Carl shows you how to incorporate configuration files in Blazor WebAssembly and Blazor Server projects using Dependency Injection.",
                Duration = "19:25",
                PublishDate = "July 9, 2020",
                ImageUrl = "/images/10-config.jpg",
                YouTubeUrl = "https://youtu.be/hIfjjOsD4ic",
                MaterialsZipFileName = "http://blazordeskshow.com/blazortrainfiles/ConfigAndDI.zip"
            });

            var topics = new List<string>();
            topics.Add("Creating an API Layer");
            topics.Add("JavaScript Interop");
            topics.Add("Input Controls");
            topics.Add("Modal Dialogs");
            topics.Add("Building and Sharing Components");
            topics.Add("From WebForms to Blazor");
            topics.Add("Blazor CSS Part 1");
            topics.Add("Blazor CSS Part 2");
            topics.Add("MVVM in Blazor");
            topics.Add("Managing State Part 1");
            topics.Add("Managing State Part 2");
            topics.Add("Scaling Blazor Server Apps");
            topics.Add("Authentication Part 1");
            topics.Add("Authentication Part 2");
            topics.Add("Authorization");
            topics.Add("Authorization: Roles");
            topics.Add("Mobile Bindings");
            topics.Add("Add Blazor to an Existing MVC Application");
            topics.Add("Use SignalR for cross - page communication");
            topics.Add("Using SignalR to Synchronize CRUD operations");
            topics.Add("Serverless Apps with Blazor");
            topics.Add("Progressive Web Apps Part 1");
            topics.Add("Progressive Web Apps Part 2");
            topics.Add("Testing Blazor Components");

            foreach (var topic in topics)
            {
                episodes.Add(new Episode
                {
                    Id = 0,
                    Title = topic,
                    Description = "",
                    Duration = "",
                    PublishDate = "",
                    ImageUrl = "",
                    YouTubeUrl = ""
                }); ;
            }
        }

        public async Task<List<Episode>> GetAllEpisodes()
        {
            await Task.Delay(1);
            return episodes;
        }

        public async Task<Episode> GetEpisode(int Id)
        {
            await Task.Delay(1);
            return (from x in episodes
                    where x.Id == Id
                    select x).FirstOrDefault();
        }

        public async Task<List<Episode>> SearchEpisodes(string Title)
        {
            await Task.Delay(1);
            return (from x in episodes
                    where x.Title.ToLower().Contains(Title.ToLower())
                    select x).ToList();
        }

        public async Task<Episode> AddEpisode(Episode Episode)
        {
            await Task.Delay(1);
            episodes.Add(Episode);
            return Episode;
        }

        public async Task<Episode> UpdateEpisode(Episode Episode)
        {
            await Task.Delay(1);
            var thisEpisode = (from x in episodes
                               where x.Id == Episode.Id
                               select x).FirstOrDefault();

            if (thisEpisode != null)
            {
                // update just the Title field
                thisEpisode.Title = Episode.Title;
            }
            return thisEpisode;
        }

        public async Task DeleteEpisode(string Title)
        {
            await Task.Delay(1);
            var thisEpisode = (from x in episodes
                               where x.Title == Title
                               select x).FirstOrDefault();
            if (thisEpisode != null)
            {
                episodes.Remove(thisEpisode);
            }
        }

    }
}
