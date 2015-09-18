using System;
using System.Net;

namespace DestinyClanData
{
	public class Triumphs
	{
		public Triumphs ()
		{
		}
		#region Triumphs
		public string getTriumph(string ID)
		{
			WebClient webClient = new WebClient();
			string triumphs = "";
			string json= webClient.DownloadString("http://www.bungie.net/Platform/Destiny/1/Account/"+ID+"/Triumphs/");
			try{
				TriumphData ResponseData = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<TriumphData>(json);
				foreach(var item in ResponseData.Response.data.triumphSets)
				{
					//userData.triumphData.name = item.
					foreach(var triumph in item.triumphs)
					{
						triumphs+=triumph.complete + ",";
					}
				}
				return triumphs;
			}
			catch(Exception ex) {
				return "";
			}
		}
		public class TriumphData
		{
			public TResponse Response {get;set;}
		}
		public class TResponse
		{
			//[DataMember(NameValue="data")]
			public data data {get;set;}
		}
		public class data
		{
			public triumphSets[] triumphSets {get;set;}
		}
		public class triumphSets
		{
			public string triumphSetHash{get;set;}
			public triumphs[] triumphs{get;set;}
		}
		public class triumphs
		{
			public string complete{get;set;}
			public string progress{get;set;}
			public string actual{get;set;}
		}
		#endregion
	}
}

