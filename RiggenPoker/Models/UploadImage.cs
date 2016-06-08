using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
/// <summary>
/// Are model for Uploaded Images
/// </summary>
namespace RiggenPoker.Models
{
    public class UploadImage
    {
        public int Id { get; set; }
        public string Image_url { get; set; }
        public string ImageName { get; set; }
    }
}