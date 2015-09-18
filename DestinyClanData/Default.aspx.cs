using System;
using System.Web;
using System.Web.UI;
using System.Collections.Generic;
using System.Net;
using System.Data;
using System.IO;
using System.IO.Compression;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Reflection;
using Microsoft.CSharp;
using System.Data.SQLite;

namespace DestinyClanData
{
	
	public partial class Default : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack) {
			}
		}
		protected void btnSearch_Click(object sender, EventArgs e)
		{
			Manifest manifest = new Manifest ();
			Character character = new Character ();
			string membershipId = character.getUserMemberId (tbSearch.Text.ToString());
			List<string> characters = character.getUserCharacterIds (membershipId);
			List<string> characterData = new List<string> ();
			List<string> activityData = new List<string> ();
			string characterRace, characterClass, activity,emblem;
			DataTable dt = new DataTable ();
			DataRow dr = null;
			dt.Columns.Add (new DataColumn ("User", typeof(string)));
			dt.Columns.Add (new DataColumn ("MemberId", typeof(string)));
			dt.Columns.Add (new DataColumn ("CharacterId", typeof(string)));
			dt.Columns.Add (new DataColumn ("CharacterClass", typeof(string)));
			dt.Columns.Add (new DataColumn ("dateLastPlayed", typeof(string)));
			dt.Columns.Add (new DataColumn ("CurrentActivity", typeof(string)));
			dt.Columns.Add (new DataColumn ("CurrentActivityDescription", typeof(string)));
			dt.Columns.Add (new DataColumn ("emblem", typeof(string)));
			dt.Columns.Add (new DataColumn ("powerLevel", typeof(string)));

			foreach (string characterId in characters) {
				characterData = character.getUserCharacter (membershipId, characterId);
				characterRace = manifest.race_class_lookup (characterData [5].ToString ());
				characterClass = manifest.race_class_lookup (characterData [7].ToString ());
				emblem = "http://www.bungie.net"+characterData [9].ToString ();
				activity = characterData [8].ToString ();

				dr = dt.NewRow ();
				if (activity != "0")
					activityData = manifest.getActivity (activity);
				else
					activityData.Clear();
				dr ["User"] = tbSearch.Text.ToString();
				dr ["MemberId"] = membershipId;
				dr ["CharacterId"] = characterData [0].ToString ();
				dr ["CharacterClass"] = characterClass;
				dr ["dateLastPlayed"] = characterData [1].ToString ();
				dr ["emblem"] = emblem;
				dr ["powerLevel"] = characterData[4].ToString();

				if (activityData.Count > 1) {
					dr ["CurrentActivity"] = activityData [1].ToString ();
					dr ["CurrentActivityDescription"] = activityData [2].ToString ();
					dt.Rows.Add (dr);
				} else {
					dr ["CurrentActivity"] = "Not Active";
					dt.Rows.Add (dr);
				}
			}
			ListView1.DataSource = dt;
			ListView1.DataBind ();
		}
		protected void btnSearchClan_Click(object sender, EventArgs e)
		{
			Manifest manifest = new Manifest ();
			Character ch = new Character ();
			Clan cl = new Clan ();
			List<string> claninfo = cl.getClanInfo (tbSearch.Text.ToString());
			List<string> users = cl.getClanUsers (claninfo[0].ToString());
			string membershipId;
			//Get All Character Data for user
			List<string> characterData = new List<string> ();
			List<string> activityData = new List<string> ();
			string characterRace, characterClass, activity,emblem,compare;
			DataTable dt = new DataTable ();
			DataRow dr = null;
			dt.Columns.Add (new DataColumn ("User", typeof(string)));
			dt.Columns.Add (new DataColumn ("MemberId", typeof(string)));
			dt.Columns.Add (new DataColumn ("CharacterId", typeof(string)));
			dt.Columns.Add (new DataColumn ("CharacterClass", typeof(string)));
			dt.Columns.Add (new DataColumn ("dateLastPlayed", typeof(string)));
			dt.Columns.Add (new DataColumn ("CurrentActivity", typeof(string)));
			dt.Columns.Add (new DataColumn ("CurrentActivityDescription", typeof(string)));
			dt.Columns.Add (new DataColumn ("emblem", typeof(string)));
			dt.Columns.Add (new DataColumn ("powerLevel", typeof(string)));

			foreach (string user in users) {
				membershipId = ch.getUserMemberId (user);
				Character.characterBaseResponse character = ch.getUserCharacterInfo(membershipId);
				if (character != null) {
					foreach (var item in character.Response.data.characters) {			
						activity = item.characterBase.currentActivityHash;
						if (activity != "0") {
							activityData = manifest.getActivity (activity);
							if (activityData.Count > 1) {
									dr = dt.NewRow ();
									characterRace = manifest.race_class_lookup (item.characterBase.raceHash);
								characterClass = manifest.race_class_lookup (item.characterBase.classHash);
									emblem = "http://www.bungie.net" + item.emblemPath;
									dr ["User"] = user;
									dr ["MemberId"] = membershipId;
									dr ["CharacterId"] = item.characterBase.characterId;
									dr ["CharacterClass"] = characterClass;
									dr ["dateLastPlayed"] = item.characterBase.dateLastPlayed.ToString ();
									dr ["CurrentActivity"] = activityData [1].ToString ();
									dr ["CurrentActivityDescription"] = activityData [2].ToString ();
									dr ["emblem"] = emblem;
									dr ["powerLevel"] = item.characterBase.powerLevel;
									dt.Rows.Add (dr);
								}
								else
									dr ["CurrentActivity"] = "Not Active";
						} else
							activityData.Clear ();
					}
				}
			}
			compare = "";
			ListView1.DataSource = dt;
			ListView1.DataBind ();
		}
	}
}
