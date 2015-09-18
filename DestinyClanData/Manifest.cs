using System;
using System.Collections.Generic;
using System.Net;

namespace DestinyClanData
{
	public class Manifest
	{
		public Manifest ()
		{
		}
		#region ActivityInfo
		public List<string> getActivity(string activityId)
		{
			List<string> activity = new List<string> ();
			WebClient webClient = new WebClient ();
			string json = webClient.DownloadString ("http://www.bungie.net/Platform/Destiny/Manifest/Activity/" + activityId + "/");
			ActivityResponse activityInfo = new System.Web.Script.Serialization.JavaScriptSerializer ().Deserialize<ActivityResponse> (json);
			activity.Add (activityInfo.Response.data.activity.activityhash);
			activity.Add (activityInfo.Response.data.activity.activityName);
			activity.Add (activityInfo.Response.data.activity.activityDescription);
			activity.Add (activityInfo.Response.data.activity.icon);
			activity.Add (activityInfo.Response.data.activity.realeaseIcon);
			return activity;
		}
		public class ActivityResponse
		{
			public ActivityResponseInfo Response {get;set;}
		}
		public class ActivityResponseInfo
		{
			public activitySet data {get;set;}
		}
		public class activitySet
		{
			public activity activity {get;set;}
		}
		public class activity
		{
			public string activityhash{get;set;}
			public string activityName{get;set;}
			public string activityDescription{get;set;}
			public string icon{get;set;}
			public string realeaseIcon{get;set;}
		}
		#endregion
		#region hashLookups
		public string race_class_lookup(string hash)
		{
			//Race/Class Hash
			string race_class = "";
			switch (hash) {
			case "898834093":
				race_class = "exo";
				break;
			case "3887404748":
				race_class = "human";
				break;
			case "2803282938":
				race_class = "awoken";
				break;
			case "671679327":
				race_class = "hunter";
				break;
			case "3655393761":
				race_class = "titan";
				break;
			case "2271682572":
				race_class = "warlock";
				break;
			}
			return race_class;
		}
		#endregion
	}
}

