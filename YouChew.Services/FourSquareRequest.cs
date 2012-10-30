using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using YouChew.Models;

namespace YouChew.Services
{
	public class FourSquareRequest
	{
		WebClient webClient = new WebClient();
		POSTRequest reqData = new POSTRequest();

		public string VenueById(string id)
		{
			string getRequest = reqData.venueUrl + id+ "?" +reqData.authUrlClient + reqData.authUrlClientSecret;
			webClient.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
			return webClient.DownloadString(getRequest);
		}

		public string VenuesOrByName(string longitude, string latitude, string name)
		{
			if(!string.IsNullOrEmpty(name))
			{
				string getRequest = reqData.searchUrl + "?ll=" + longitude + "," + latitude + "&query=" + name + reqData.authUrlClient + reqData.authUrlClientSecret;
				webClient.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
				return webClient.DownloadString(getRequest);
			}
			else
			{
				string getRequest = reqData.searchUrl + "?ll=" + longitude + "," + latitude + reqData.authUrlClient + reqData.authUrlClientSecret;
				webClient.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
				return webClient.DownloadString(getRequest);
			}

		}

		public string VenueCategories(string longitude, string latitude)
		{
			string getRequest = reqData.categoryUrl + "?ll=" + longitude + "," + latitude + reqData.authUrlClient + reqData.authUrlClientSecret;
			webClient.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
			return webClient.DownloadString(getRequest);
		}

		public string VenuesByCategory(string longitude, string latitude, string categoryId, string radius)
		{
			//can search using &intent=browse. Searches an entire region instead of only finding Venues closest to a point.
			string getRequest = reqData.searchUrl + "?ll=" + longitude + "," + latitude + "&radius=" + radius + "&categoryId=" +
			                    categoryId + reqData.authUrlClient + reqData.authUrlClientSecret;
			webClient.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
			return webClient.DownloadString(getRequest);
		}
	}
}
