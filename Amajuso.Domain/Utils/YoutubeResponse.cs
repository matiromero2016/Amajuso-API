using System;
using System.Collections.Generic;
using System.Text;

namespace Amajuso.Domain.Utils
{
    public class YoutubeResponse
    {
        public string nextPageToken { get; set; }
        public PageInfo pageInfo { get; set; }
        public List<Item> items { get; set; }
    }
        public class PageInfo
        {
        public int totalResults { get; set; }
        public int resultsPerPage { get; set; }
        }

        public class Default
        {
            public string url { get; set; }
            public int width { get; set; }
            public int height { get; set; }
        }

        public class Thumbnails
        {
        public Default Default { get; set; }
        }

    public class Snippet
    {
        public DateTime publishedAt { get; set; }
        public string channelId { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public Thumbnails thumbnails { get; set; }
        public string channelTitle { get; set; }
        public DateTime publishTime { get; set; }
    }
        public class Id
        {
        public string videoId { get; set; }
        }

        public class Item
        {
        public Id id { get; set; }
        public Snippet snippet { get; set; }
        }


}

