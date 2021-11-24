using System;
using System.Collections.Generic;
using System.Text;

namespace APILayer.Shared.Models
{
    public class EpisodesResponse
    {
        public bool Success { get; set; }
        public List<string> ErrorMessages { get; set; } = new List<string>();
        public List<Episode> Episodes { get; set; }
    }
}
