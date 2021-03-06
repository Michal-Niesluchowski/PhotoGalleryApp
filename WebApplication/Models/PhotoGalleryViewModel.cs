using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class PhotoGalleryViewModel
    {
        private readonly int _azureWaitingTime = 3000; //Waiting time for Azure to create thumbnail

        public PhotoItemViewModel[] Photos { get; set; }

        public PhotoGalleryViewModel()
        {
            Photos = new PhotoItemViewModel[0];
        }

        public string[] GetTagsFromPhoto(PhotoItemViewModel photo)
        {
            string[] result;

            result = photo.Tags.Split(",");

            result = result.Select(tag => tag.Trim()).ToArray();

            return result;
        }

        public string[] GetAllUniqueTags()
        {
            //Put all tags into one list
            IEnumerable<string> allTags = this.Photos.SelectMany(photo => photo.Tags.Split(","));
            allTags = allTags.Select(tag => tag.Trim());

            //Get unique tags
            var uniqueTags = allTags.GroupBy(tag => tag).Select(tag => tag.Key);

            return uniqueTags.ToArray();
        }

    }
}
