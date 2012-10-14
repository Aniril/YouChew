using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YouChew.Models
{
	public class POSTRequest
	{
		public string categoryUrl = "https://api.foursquare.com/v2/venues/categories";
        public string searchUrl = "https://api.foursquare.com/v2/venues/explore";
		public string authUrl = "https://foursquare.com/oauth2/authenticate";
		public string apiUrl = "https://api.foursquare.com/";
		public string authUrlClient = "&client_id=JK2MVQ3FRVPYDXOFCJMXECVA3OLWI3LTDF4UNUW3BLW40DKT";
		public string authUrlRedirect = "redirect_uri=";
		public string authUrlReddirectValue = "http://localhost:1423/Restaurant_Admin/RestaurantViewer";
		public string authUrlClientSecret = "&client_secret=XXOPKU0GEHQFH3MKPDOEK1L24OM0ICNAX1GRXWCB5JOEWL5P";
		
	}
}