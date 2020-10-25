using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace maximar_com_tr.WebUI.yonetim
{
    public partial class statik_kelime_duzenle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Class.Yonetim.Fonksiyonlar.OturumIslemleri.CookieKontrol();

            Kayit();
        }

        protected void Kayit()
        {
            if (Request.QueryString["ID"] != null && Class.Fonksiyonlar.NumerikKontrol(Request.QueryString["ID"].ToString()))
            {
                int ID = int.Parse(Request.QueryString["ID"]);

                using (BaglantiCumlesi db = new BaglantiCumlesi())
                {
                    var SQL = (from p in db.tbl_text
                               where p.id == ID
                               select new
                               {
                                   p.id
                               }).AsEnumerable();

                    if (!SQL.Any())
                    {
                        Response.Redirect("ayar-statik-kelime.aspx");
                    }
                }

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
                        txt_tanimlama_baslik.Text = Class.Yonetim.Fonksiyonlar.Kelime(ID).Select(p => p.baslik).FirstOrDefault();

                        lit_ekleyen.Text = Class.Yonetim.Fonksiyonlar.AdminAd(int.Parse(Class.Yonetim.Fonksiyonlar.Kelime(ID).Select(p => p.admin_id).FirstOrDefault().ToString()));
                        lit_kayit_tarih.Text = Class.Yonetim.Fonksiyonlar.Kelime(ID).Select(p => p.tarih).FirstOrDefault().ToString();

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
                            baslik.Text = Class.Yonetim.Fonksiyonlar.KelimeDetay(ID, i.id).Select(p => p.baslik).FirstOrDefault();
                            baslik.Width = Unit.Pixel(500);
                            lit_icerik.Controls.Add(baslik);

                            Literal lbl8 = new Literal();
                            lbl8.Text = "</div>\r\n";
                            lit_icerik.Controls.Add(lbl8);
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
        }

        protected void btn_kayitekle_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["ID"] != null && Class.Fonksiyonlar.NumerikKontrol(Request.QueryString["ID"].ToString()))
            {
                int ID = int.Parse(Request.QueryString["ID"]);

                try
                {
                    using (BaglantiCumlesi db = new BaglantiCumlesi())
                    {
                        var SQL = (from p in db.tbl_dil
                                   select new
                                   {
                                       p.id
                                   }).AsEnumerable();

                        if (SQL.Any())
                        {
                            foreach (var i in SQL)
                            {
                                KayitEkle(ID, i.id);
                            }
                        }
                    }
                    Class.Fonksiyonlar.JavaScript.MesajKutusuVeYonlendir("Başarıyla düzenlenmiştir.", "ayar-statik-kelime-duzenle.aspx?ID=" + ID + "");
                }
                catch (Exception ex)
                {
                    Class.Fonksiyonlar.JavaScript.MesajKutusuVeYonlendir(ex.Message, "ayar-statik-kelime.aspx");
                }
            }
        }

        protected void KayitEkle(int text_id, int dil_id)
        {
            using (BaglantiCumlesi db = new BaglantiCumlesi())
            {
                var SQL = (from t in db.tbl_text_detay
                           where t.text_id == text_id && t.dil_id == dil_id
                           select new
                           {
                               t.id
                           }).AsEnumerable();

                if (SQL.Any())
                {
                    tbl_text_detay tbl = db.tbl_text_detay.Where(p => p.text_id == text_id && p.dil_id == dil_id).First();
                    tbl.baslik = Request.Form["txt_baslik_" + dil_id].ToString().Trim();
                }
                else
                {
                    tbl_text_detay tbl = new tbl_text_detay();
                    tbl.text_id = text_id;
                    tbl.dil_id = dil_id;
                    tbl.baslik = Request.Form["txt_baslik_" + dil_id].ToString().Trim();
                    db.AddTotbl_text_detay(tbl);
                }

                db.SaveChanges();
            }
        }
    }
}