using System;
using System.Collections.Generic;
using System.Net;

namespace DestinyClanData
{
	public class Character
	{
		string baseurl = "http://www.bungie.net/Platform/Destiny/1/Account/";
		public Character ()
		{
		}
		#region UserCharacterIds
		public List<string> getUserCharacterIds(string ID)
		{
			List<string> characters = new List<string> ();
			WebClient webClient = new WebClient ();
			string json = webClient.DownloadString (baseurl + ID + "/summary");
			characterBaseResponse character = new System.Web.Script.Serialization.JavaScriptSerializer ().Deserialize<characterBaseResponse> (json);
			foreach (var item in character.Response.data.characters) {
				characters.Add (item.characterBase.characterId);
			}
			return characters;
		}
		public characterBaseResponse getUserCharacterInfo(string ID)
		{
			WebClient webClient = new WebClient();
			string json= webClient.DownloadString(baseurl+ID+"/summary");
			characterBaseResponse character = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<characterBaseResponse>(json);
			return character;
		}
		public class characterBaseResponse
		{
			public characterBaseInfo Response {get;set;}
		}
		public class characterBaseInfo
		{
			public characterData data {get;set;}
		}
		public class characterData
		{
			public characterSets[] characters {get;set;}
			public string clanName{get;set;}
			public string clanTag{get;set;}
			public string grimoireScore{get;set;}
			public string membershipType{get;set;}

		}
		public class characterSets
		{
			public character characterBase {get;set;}
			public string emblemPath{get;set;}
			public string backgroundPath{get;set;}
			public string emblemHash{get;set;}
			public string characterLevel{get;set;}
			public string percentToNextLevel{ get; set;}
		}
		public class character
		{
			public string characterId{get;set;}
			public DateTime dateLastPlayed{get;set;}
			public string minutesPlayedThisSession{get;set;}
			public string minutesPlayedTotal{get;set;}
			public string powerLevel{get;set;}
			public string raceHash{get;set;}
			public string genderHash{get;set;}
			public string classHash{get;set;}
			public string currentActivityHash{get;set;}
		}
		#endregion
		#region UserCharacterInfo
		public List<string> getUserCharacter(string membershipId, string characterId)
		{
			List<string> character = new List<string> ();
			WebClient webClient = new WebClient ();
			string json = webClient.DownloadString ("http://www.bungie.net/Platform/Destiny/1/Account/" + membershipId + "/Character/" + characterId + "/");
			singleCharacterBaseResponse characterInfo = new System.Web.Script.Serialization.JavaScriptSerializer ().Deserialize<singleCharacterBaseResponse> (json);
			character.Add (characterInfo.Response.data.characterBase.characterId);
			character.Add (characterInfo.Response.data.characterBase.dateLastPlayed.ToString());
			character.Add (characterInfo.Response.data.characterBase.minutesPlayedThisSession);
			character.Add (characterInfo.Response.data.characterBase.minutesPlayedTotal);
			character.Add (characterInfo.Response.data.characterBase.powerLevel);
			character.Add (characterInfo.Response.data.characterBase.raceHash);
			character.Add (characterInfo.Response.data.characterBase.genderHash);
			character.Add (characterInfo.Response.data.characterBase.classHash);
			character.Add (characterInfo.Response.data.characterBase.currentActivityHash);
			character.Add (characterInfo.Response.data.emblemPath);
			character.Add (characterInfo.Response.data.backgroundPath);
			character.Add (characterInfo.Response.data.emblemHash);
			character.Add (characterInfo.Response.data.characterLevel);
			character.Add (characterInfo.Response.data.percentToNextLevel);
			return character;
		}
		public class singleCharacterBaseResponse
		{
			public singleCharacterBaseInfo Response {get;set;}
		}
		public class singleCharacterBaseInfo
		{
			public singleCharacterSets data {get;set;}
		}
		public class singleCharacterSets
		{
			public singleCharacter characterBase {get;set;}
			public string emblemPath{get;set;}
			public string backgroundPath{get;set;}
			public string emblemHash{get;set;}
			public string characterLevel{get;set;}
			public string percentToNextLevel{get;set;}
		}
		public class singleCharacter
		{
			public string characterId{get;set;}
			public DateTime dateLastPlayed{get;set;}
			public string minutesPlayedThisSession{get;set;}
			public string minutesPlayedTotal{get;set;}
			public string powerLevel{get;set;}
			public string raceHash{get;set;}
			public string genderHash{get;set;}
			public string classHash{get;set;}
			public string currentActivityHash{get;set;}
		}
		#endregion
		#region UserMemberId
		public string getUserMemberId(string userId)
		{
			string memberid = "";
			WebClient webClient = new WebClient ();
			string json1 = webClient.DownloadString ("http://www.bungie.net/Platform/Destiny/SearchDestinyPlayer/TigerXbox/" + userId + "/");
			BasicUserInfo user = new System.Web.Script.Serialization.JavaScriptSerializer ().Deserialize<BasicUserInfo> (json1);
			foreach (var item in user.Response) {
				memberid = item.membershipId;
			}
			return memberid;
		}
		public class BasicUserInfo
		{
			public List<BasicInfo> Response {get;set;}
		}
		public class BasicInfo
		{
			public string membershipId{get;set;}
			public string displayName{get;set;}
		}
		#endregion
	}
}

