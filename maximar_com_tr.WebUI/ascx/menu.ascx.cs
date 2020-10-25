using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace maximar_com_tr.WebUI.ascx
{
    public partial class menu : System.Web.UI.UserControl
    {
        int DilID = Class.Fonksiyonlar.DilAyarlari.ID();

        protected void Page_Load(object sender, EventArgs e)
        {
            AnaMenu();
        }

        private void AnaMenu()
        {
            #region Üst ana menü

            using (BaglantiCumlesi db = new BaglantiCumlesi())
            {
                var SQL = (from p in db.tbl_menu
                    where p.ust_menu_id == 0 && p.onay == true
                    orderby p.sira
                    select new
                    {
                        p.id,
                        baslik =
                            db.tbl_menu_detay.Where(k => k.menu_id == p.id && k.dil_id == DilID)
                                .Select(k => k.baslik)
                                .FirstOrDefault(),
                        p.tur,
                        p.url,
                        alt_menu_sayi = (db.tbl_menu.Where(k => k.ust_menu_id == p.id).Count())
                    }).AsEnumerable();

                if (SQL.Any())
                {
                    StringBuilder sb = new StringBuilder();

                    foreach (var i in SQL)
                    {
                        if (i.alt_menu_sayi == 0)
                        {
                            switch (i.tur)
                            {
                                case 1:
                                    sb.Append("<li><a href=\"" +
                                              Class.Fonksiyonlar.SeoLink("sayfa", i.id.ToString(), i.baslik) +
                                              "\">" + i.baslik +
                                              "</a></li>\r\n");
                                    break;
                                case 2:
                                    sb.Append("<li><a href=\"" + i.url + "?sayfa_id=" + i.id +
                                              "\">" + i.baslik +
                                              "</a></li>\r\n");
                                    break;
                            }
                        }
                        else
                        {
                            sb.Append(
                                "<li class=\"dropdown\"><a href=\"#\" class=\"dropdown-toggle\" data-toggle=\"dropdown\">" +
                                i.baslik + "</a>\r\n");
                            sb.Append("<ul class=\"dropdown-menu dropdown-menu-left\">\r\n");
                            sb.Append(AltMenu(i.id));
                            sb.Append("</ul>\r\n");
                            sb.Append("</li>\r\n");
                        }
                    }

                    lit_menu.Text = sb.ToString();
                }
            }

            #endregion
        }

        protected static string AltMenu(int id)
        {
            int DilID = Class.Fonksiyonlar.DilAyarlari.ID();

            using (BaglantiCumlesi db = new BaglantiCumlesi())
            {
                StringBuilder sb = new StringBuilder();

                var SQL = (from a in db.tbl_menu
                           where a.ust_menu_id == id
                           select new
                           {
                               a.id,
                               a.tur,
                               baslik = (db.tbl_menu_detay.Where(k => k.menu_id == a.id && k.dil_id == DilID).Select(k => k.baslik).FirstOrDefault()),
                               a.url
                           }).AsEnumerable();

                if (SQL.Any())
                {
                    foreach (var i in SQL)
                    {
                        switch (i.tur)
                        {
                            case 1:
                                sb.Append("<li><a href=\"" + Class.Fonksiyonlar.SeoLink("sayfa", i.id.ToString(), i.baslik) + "\">" + i.baslik + "</a></li>\r\n");
                                break;
                            case 2:
                                sb.Append("<li><a href=\"" + i.url + "\">" + i.baslik + "</a></li>\r\n");
                                break;
                        }
                    }

                    return sb.ToString();
                }
                else
                {
                    return sb.ToString();
                }
            }
        }
    }
}