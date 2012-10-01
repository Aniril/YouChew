using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YouChew.Models
{
    public class FacebookUser
    {
        public string FBid { get; set; }
        public string accessToken { get; set; }
        public string FBuid { get; set; }
        public string FBemail { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string gender { get; set; }
        public string locale { get; set; }
        public string link { get; set; }
        public string FBusername { get; set; }
        public int timezone { get; set; }
        public FacebookLocation location { get; set; }
        public Picture picture { get; set; }
    }

    public class FacebookLocation
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class Picture
    {
        public PicureData data { get; set; }
    }

    public class PicureData
    {
        public string url { get; set; }
        public bool is_silhouette { get; set; }
    }
}