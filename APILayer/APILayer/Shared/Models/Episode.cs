using System;
using System.Collections.Generic;
using System.Text;

namespace APILayer.Shared.Models
{
    public class Episode
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public string Duration { get; set; } = "";
        public string YouTubeUrl { get; set; } = "";
        public string ImageUrl { get; set; } = "";
        public string PublishDate { get; set; } = "";
        public string MaterialsZipFileName { get; set; } = "";
    }
}
