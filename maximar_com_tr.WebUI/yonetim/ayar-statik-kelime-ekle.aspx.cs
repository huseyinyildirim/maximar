﻿using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;

namespace maximar_com_tr.WebUI.yonetim
{
    public partial class statik_kelime_ekle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Class.Yonetim.Fonksiyonlar.OturumIslemleri.CookieKontrol();

            Kayit();
        }

        protected void Kayit()
        {
            using (BaglantiCumlesi db = new BaglantiCumlesi())
            {
                var SQL = (from p in db.tbl_dil
                           select new
                           {
                               p.id,
                               p.dil,
                               p.dosya_ad
                           }).AsEnumerable();

                if (SQL.Any())
                {
                    Literal lbl1 = new Literal();
                    lbl1.Text = "<div id=\"tabs\">\r\n<ul>\r\n";
                    lit_icerik.Controls.Add(lbl1);

                    Literal lbl2 = new Literal();
                    foreach (var i in SQL)
                    {
                        lbl2.Text += "<li><a href=\"#" + i.dil + "\"><img src=\"/upload/flag/" + i.dosya_ad + "\" alt=\"" + i.dil + "\" /> " + i.dil + "</a></li>\r\n";
                    }
                    lit_icerik.Controls.Add(lbl2);

                    Literal lbl3 = new Literal();
                    lbl3.Text = "</ul>\r\n";
                    lit_icerik.Controls.Add(lbl3);

                    foreach (var i in SQL)
                    {
                        Literal lbl4 = new Literal();
                        lbl4.Text = "<div id=\"" + i.dil + "\"><strong>Başlık:</strong><br />";
                        lit_icerik.Controls.Add(lbl4);

                        TextBox baslik = new TextBox();
                        baslik.ID = "txt_baslik_" + i.id;
                        baslik.Width = Unit.Pixel(500);
                        lit_icerik.Controls.Add(baslik);
                    }

                    Literal lbl10 = new Literal();
                    lbl10.Text = "</div>\r\n";
                    lit_icerik.Controls.Add(lbl10);
                }
                else
                {
                    Class.Fonksiyonlar.JavaScript.MesajKutusuVeYonlendir("Sistemde oluşturulmuş dil yoktur!", "default.aspx");
                }
            }
        }

        protected void btn_kayitekle_Click(object sender, EventArgs e)
        {
            try
            {
                using (BaglantiCumlesi db = new BaglantiCumlesi())
                {
                    tbl_text tbl2 = new tbl_text();
                    tbl2.baslik = txt_tanimlama_baslik.Text.Trim();
                    tbl2.admin_id = int.Parse(HttpContext.Current.Request.Cookies[Class.Fonksiyonlar.Ayar(Class.Sabitler.Ayar.GuvenlikKodu) + "KullaniciID"].Value);
                    db.AddTotbl_text(tbl2);
                    db.SaveChanges();

                    var SQL = (from p in db.tbl_dil
                               select new
                               {
                                   p.id
                               }).AsEnumerable();

                    if (SQL.Any())
                    {
                        StringBuilder sb = new StringBuilder();
                        foreach (var i in SQL)
                        {
                            tbl_text_detay tbl = new tbl_text_detay();
                            tbl.text_id = tbl2.id;
                            tbl.dil_id = i.id;
                            tbl.baslik = Request.Form["txt_baslik_" + i.id.ToString()].ToString().Trim();
                            db.AddTotbl_text_detay(tbl);

                        }
                    }

                    db.SaveChanges();
                }
                Class.Fonksiyonlar.JavaScript.MesajKutusuVeYonlendir("Başarıyla eklenmiştir.", "ayar_statik_kelime.aspx");
            }
            catch (Exception ex)
            {
                Class.Fonksiyonlar.JavaScript.MesajKutusuVeYonlendir(ex.Message, "ayar_statik_kelime.aspx");
            }
        }
    }
}