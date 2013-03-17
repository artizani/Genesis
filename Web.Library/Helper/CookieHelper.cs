using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Web;
using System.Web.Mvc;

namespace Web.Library.Helper
{
 public static class CookieHelper
{

public static string CookieName {get;set;}

 public static void SetCookie(string cookieName, int cookieExpireDate = 30)
{
    var myCookie= new HttpCookie(CookieName);
    myCookie["Us"] = "";
    myCookie.Expires = DateTime.Now.AddDays(cookieExpireDate);
    HttpContext.Current.Response.Cookies.Add(myCookie);
 }

public static void DeleteCookie(this Controller controller, string cookieName)
{
    if (controller.HttpContext.Request.Cookies[cookieName] == null)
            return; //cookie doesn't exist

    var c = new HttpCookie(cookieName)
                {
                    Expires = DateTime.Now.AddDays(-1)
                };
    controller.HttpContext.Response.Cookies.Add(c);
}
 }
}