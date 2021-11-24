using System;
using System.Collections.Generic;
using System.Text;

namespace APILayer.Shared.Models
{
    public class EpisodeResponse
    {
        public bool Success { get; set; }
        public List<string> ErrorMessages { get; set; } = new List<string>();
        public Episode Episode { get; set; }
    }
}
