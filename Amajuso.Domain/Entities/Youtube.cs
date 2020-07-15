using System;
using System.Collections.Generic;
using System.Text;

namespace Amajuso.Domain.Entities
{
    public class Youtube : BaseEntity
    {
        public Youtube(string youtubeId, string title, string description, string imageUrl, DateTime publishedAt) {
            this.YoutubeId = youtubeId;
            this.Title = title;
            this.Description = description;
            this.ImageUrl = imageUrl;
            this.PublishedAt = publishedAt;
        }
     public string YoutubeId {get;set;}
     public string Title {get;set;}
     public string Description {get;set;}
     public string ImageUrl {get;set;}
     public DateTime PublishedAt {get;set;}

    }
}
