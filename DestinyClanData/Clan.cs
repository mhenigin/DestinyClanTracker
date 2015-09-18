using System;
using System.Collections.Generic;
using System.Net;

namespace DestinyClanData
{
	public class Clan
	{
		public Clan ()
		{
		}
		#region ClanUserList
		public List<string> getClanUsers(string clanid)
		{
			List<string> users = new List<string> ();
			WebClient webClient = new WebClient();
			int page = 1;
			bool getMore = false;
			string json1;

			do {
				json1 = webClient.DownloadString ("http://www.bungie.net/platform/group/"+clanid+"/Members/?currentPage=" + page + "&platformType=1");
				clanResponse clanuserInfo = new System.Web.Script.Serialization.JavaScriptSerializer ().Deserialize<clanResponse> (json1);
				foreach (var item in clanuserInfo.Response.results) {
					if(item.user.xboxDisplayName !=null)
					{
						users.Add(item.user.xboxDisplayName);
					}
				}
				getMore = clanuserInfo.Response.hasMore;
				page++;
			} while(getMore == true);
			return users;
		}
		public class clanResponse
		{
			public clan Response {get;set;}
		}
		public class clan
		{
			public results[] results {get;set;}
			public bool hasMore {get;set;}
		}
		public class results
		{
			public user user{get;set;}
		}
		public class user
		{
			public string xboxDisplayName{get;set;}
			public string displayName{get;set;}
			public string membershipId{get;set;}
			public string profilePicturePath{get;set;}
		}
		#endregion
		#region getClanInfo
		public List<string> getClanInfo(string clanName)
		{
			List<string> info = new List<string> ();
			WebClient webClient = new WebClient();
			string json1 = webClient.DownloadString ("http://www.bungie.net/platform/Group/Name/"+clanName);
			clanInfoResponse clanuserInfo = new System.Web.Script.Serialization.JavaScriptSerializer ().Deserialize<clanInfoResponse> (json1);
			info.Add (clanuserInfo.Response.detail.groupId);
			return info;
		}
		public class clanInfoResponse
		{
			public clanInfo Response {get;set;}
		}
		public class clanInfo
		{
			public clanInforesults detail {get;set;}
		}
		public class clanInforesults
		{
			public string groupId{get;set;}
		}
		#endregion
	}
}

