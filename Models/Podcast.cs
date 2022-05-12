using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaloriesCount.Models
{
    // Podcast Model holds the model name and the filepath of the podcasts.
    public class Podcast
    {
        public string Name { get; set; }
        public string FilePath { get; set; }

    }
}