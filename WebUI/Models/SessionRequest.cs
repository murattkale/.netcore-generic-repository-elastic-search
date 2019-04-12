
using Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
public static class SessionRequest
{
    public static string Title = "Demo";
    public static string StartPage = "User";
    public static string StartAction = "Index";
    public static int StyleVersion = 1;
    public static string Copyright = $"{DateTime.Now.Year} © Tasarım&Yazılım (Design&Software)  <a target='_blank' href='https://www.muratkale.com.tr'>www.muratkale.com.tr </a>";
    public static string baseUrl = "https://muratkale.com.tr";
    public static string filesPath = "~/files/";
    public static string filesPathUrl = "~/files/";
    public static string defaultImage = "logo.png";

	public static ISession _ISession { get; set; }

	#region SessionRequestInfo
	public static UserModel _User
	{
		get
		{
			return _ISession.GetString("_User").Cast<UserModel>().FirstOrDefault();
		}
	}


	#endregion

	public static string Trans(this string keyword)
	{
		return keyword;

	}
}


