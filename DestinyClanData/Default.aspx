<%@ Page Language="C#" CodeBehind="Default.aspx.cs" Inherits="DestinyClanData.Default"%>
<!DOCTYPE html>
<html>
<head runat="server">
	<title>Default</title>
		<link rel="stylesheet" href="http://code.jquery.com/mobile/1.4.5/jquery.mobile-1.4.5.min.css" />
		<script src="http://code.jquery.com/jquery-1.11.1.min.js"></script>
		<script src="http://code.jquery.com/mobile/1.4.5/jquery.mobile-1.4.5.min.js"></script>

		<!-- Latest compiled and minified CSS -->
		<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css">

		<!-- Optional theme -->
		<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap-theme.min.css">

		<!-- Latest compiled and minified JavaScript -->
		<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js"></script>
</head>
<body>
	<form id="form1" runat="server">
	<asp:TextBox ID="tbSearch" type="search" AutoPostBack = "false" runat="server"></asp:TextBox>
	<asp:Button ID="btnSearch" type="text" runat="server" onclick="btnSearch_Click" Text="Search User"/>
	<asp:Button ID="btnSearchClan" type="text" runat="server" onclick="btnSearchClan_Click" Text="Search Active Clan Members"/>

	<!--<asp:TextBox ID="tbMemberId" type="text" AutoPostBack = "false" runat="server"></asp:TextBox>-->

	<br>
	<br>
	<asp:ListView ID="ListView1" runat="server" EnableTheming="false" EnableViewState="false">
	<ItemTemplate>
		<li><asp:Image id="Image1" runat="server" AlternateText="Image text"
           ImageAlign="left"
           ImageUrl='<%# Eval("emblem") %>'/>
		<b>User: </b><asp:Label ID="lblUser" runat="server" Text='<%# Eval("User") %>'/>
		<!--<li><asp:Label ID="lblMemberId" runat="server" Text='<%# Eval("MemberId") %>'/></li>-->
		<!--<li><asp:Label ID="lblCharacterId" runat="server" Text='<%# Eval("CharacterId") %>'/></li>-->
		<b>Class: </b><asp:Label ID="lblCharacterClass" runat="server" Text='<%# Eval("CharacterClass") %>'/>
		<b>Light: </b><asp:Label ID="lblPowerLevel" runat="server" Text='<%# Eval("powerLevel") %>'/>
		<b>Last Played: </b><asp:Label ID="lblDataLastPlayed" runat="server" Text='<%# Eval("dateLastPlayed") %>'/><br><br>
		<b>Current Activity: </b><asp:Label ID="lblCurrentActivity" runat="server" Text='<%# Eval("CurrentActivity") %>'/>
		<asp:Label ID="lblCurrentActivityDescription" runat="server" Text='<%# Eval("CurrentActivityDescription") %>'/></li>
		<br>
	</ItemTemplate>
	<LayoutTemplate>
		<ul id="listViewLayout" runat="server" data-role="listview"  data-inset="true">
		<asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
		</ul>
	</LayoutTemplate>
	</asp:ListView>
	</form>
</body>
</html>

