using System;

namespace maximar_com_tr.WebUI
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            System.Web.Routing.RouteTable.Routes.Add("sayfa", new System.Web.Routing.Route("sayfa/{sayfa_id}/{sayfa_ad}", new System.Web.Routing.PageRouteHandler("~/sayfa.aspx")));
            System.Web.Routing.RouteTable.Routes.Add("foto-galeri", new System.Web.Routing.Route("foto-galeri/{foto_galeri_id}/{foto_galeri_ad}", new System.Web.Routing.PageRouteHandler("~/foto-galeri-detay.aspx")));
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            #region Sitenin varsayilan dilini kontrol ediyor
            Class.Fonksiyonlar.DilAyarlari.Kontrol();
            #endregion

            #region Online kullanıcı sayısı arttırma
            Application.Lock();
            Application["OnlineUser"] = Convert.ToInt32(Application["OnlineUser"]) + 1;
            Application.UnLock();
            #endregion
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {
            #region Online kullanıcı sayısı eksiltme
            Application.Lock();
            Application["OnlineUser"] = Convert.ToInt32(Application["OnlineUser"]) - 1;
            Application.UnLock();
            #endregion
        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}