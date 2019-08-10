using System;
using System.Collections.Generic;

namespace Shared
{
    public enum Genre
    {
        Drama,
        Thriller,
        Horror,
        Action,
        SciFi,
        Documentary
    }

    public class Movie
    {
        public string Title { get; set; }

        public int Runtime { get; set; }

        public ISet<Genre> Genres { get; set; }

        public string Director { get; set; }
    }
}