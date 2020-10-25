using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Management;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace maximar_com_tr.WebUI
{
    public partial class _sayfa : System.Web.UI.Page
    {
        int DilID = Class.Fonksiyonlar.DilAyarlari.ID();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (RouteData.Values["sayfa_id"] != null)
            {
                if (Class.Fonksiyonlar.NumerikKontrol(RouteData.Values["sayfa_id"].ToString()))
                {
                    int sayfaId = int.Parse(RouteData.Values["sayfa_id"].ToString());

                    using (BaglantiCumlesi db = new BaglantiCumlesi())
                    {
                        var SQL = (from p in db.tbl_menu_detay
                                   where p.menu_id == sayfaId&&p.dil_id==DilID
                                   select new
                                   {
                                       p.baslik,
                                       p.ozet,
                                       p.detay,
                                       p.seo_aciklama,
                                       p.seo_anahtar
                                   }).AsEnumerable();

                        if (SQL.Any())
                        {
                            lit_baslik.Text = SQL.Select(p => p.baslik).FirstOrDefault();
                            lit_baslik_2.Text = SQL.Select(p => p.baslik).FirstOrDefault();
                            lit_ozet.Text = Server.HtmlDecode(SQL.Select(p => p.ozet).FirstOrDefault());
                            lit_detay.Text = Server.HtmlDecode(SQL.Select(p => p.detay).FirstOrDefault());

                            #region Sayfa seo ayarları
                            Class.Fonksiyonlar.HeaderText("head", "Title", SQL.Select(p => p.baslik).FirstOrDefault() + " | " + Class.Fonksiyonlar.Ayar(Class.Sabitler.Ayar.SeoBaslik));

                            if (!string.IsNullOrEmpty(SQL.Select(p => p.seo_anahtar).FirstOrDefault()))
                            {
                                Class.Fonksiyonlar.HeaderText("head", "lit_anahtar", "<meta http-equiv=\"Keywords\" content=\"" + SQL.Select(p => p.seo_anahtar).FirstOrDefault() + "\" />");
                            }
                            else
                            {
                                Class.Fonksiyonlar.HeaderText("head", "lit_anahtar", "<meta http-equiv=\"Keywords\" content=\"" + Class.Fonksiyonlar.Ayar(Class.Sabitler.Ayar.SeoAnahtar) + "\" />");
                            }

                            if (!string.IsNullOrEmpty(SQL.Select(p => p.seo_aciklama).FirstOrDefault()))
                            {
                                Class.Fonksiyonlar.HeaderText("head", "lit_aciklama", "<meta http-equiv=\"Description\" content=\"" + SQL.Select(p => p.seo_aciklama).FirstOrDefault() + "\" />");
                            }
                            else
                            {
                                Class.Fonksiyonlar.HeaderText("head", "lit_aciklama", "<meta http-equiv=\"Description\" content=\"" + Class.Fonksiyonlar.Ayar(Class.Sabitler.Ayar.SeoAciklama) + "\" />");
                            }
                            #endregion
                        }
                        else
                        {
                            Response.Redirect("/default.aspx");
                        }
                    }
                }
                else
                {
                    Response.Redirect("/default.aspx");
                }
            }
            else
            {
                Response.Redirect("/default.aspx");
            }
        }
    }
}