using System;
using System.Linq;
using System.Text;

namespace maximar_com_tr.WebUI
{
    public partial class _foto_galeri_detay : System.Web.UI.Page
    {
        int DilID = Class.Fonksiyonlar.DilAyarlari.ID();

        protected void Page_Load(object sender, EventArgs e)
        {
            Veriler();
        }

        void FotoGaleriVeriler(int ID)
        {
            using (BaglantiCumlesi db = new BaglantiCumlesi())
            {
                var SQL = (from p in db.tbl_resimler
                           where p.tip == 1 && p.tip_id == ID && p.onay == true
                           select new
                           {
                               p.id,
                               p.dosya_ad,
                               baslik = (db.tbl_foto_galeri_detay.Where(k => k.galeri_id == ID && k.dil_id == DilID).Select(k => k.baslik).FirstOrDefault())
                           }).AsEnumerable();

                lv_foto_veriler.DataSource = SQL;
                lv_foto_veriler.DataBind();
            }
        }

        void Veriler()
        {
            if (RouteData.Values["foto_galeri_id"] != null)
            {
                if (Class.Fonksiyonlar.NumerikKontrol(RouteData.Values["foto_galeri_id"].ToString()))
                {
                    int photo_gallery_id = int.Parse(RouteData.Values["foto_galeri_id"].ToString());

                    FotoGaleriVeriler(photo_gallery_id);

                    using (BaglantiCumlesi db = new BaglantiCumlesi())
                    {
                        var SQL = (from p in db.tbl_foto_galeri
                                   where p.id == photo_gallery_id && p.onay == true
                                   select new
                                   {
                                       baslik = (db.tbl_foto_galeri_detay.Where(k => k.galeri_id == p.id && k.dil_id == DilID).Select(k => k.baslik).FirstOrDefault()),
                                       seo_aciklama = (db.tbl_foto_galeri_detay.Where(k => k.galeri_id == p.id && k.dil_id == DilID).Select(k => k.seo_aciklama).FirstOrDefault()),
                                       seo_anahtar = (db.tbl_foto_galeri_detay.Where(k => k.galeri_id == p.id && k.dil_id == DilID).Select(k => k.seo_anahtar).FirstOrDefault()),
                                       resim = (db.tbl_resimler.Where(k => k.tip == 4 && k.tip_id == p.id && k.varsayilan == true && k.onay == true).Select(k => k.dosya_ad).FirstOrDefault())
                                   }).AsEnumerable();

                        if (SQL.Any())
                        {
                            foreach (var i in SQL)
                            {
                                #region Saha özet bilgileri
                                StringBuilder sb = new StringBuilder();

                                #endregion

                                //lit_sayfa_baslik.Text = i.baslik;

                                #region Sayfa seo ayarları
                                Class.Fonksiyonlar.HeaderText("head", "Title", i.baslik + " | " + Class.Fonksiyonlar.Ayar(Class.Sabitler.Ayar.SeoBaslik));

                                if (!string.IsNullOrEmpty(i.seo_anahtar))
                                {
                                    Class.Fonksiyonlar.HeaderText("head", "lit_anahtar", "<meta http-equiv=\"Keywords\" content=\"" + i.seo_anahtar + "\" />");
                                }
                                else
                                {
                                    Class.Fonksiyonlar.HeaderText("head", "lit_anahtar", "<meta http-equiv=\"Keywords\" content=\"" + Class.Fonksiyonlar.Ayar(Class.Sabitler.Ayar.SeoAnahtar) + "\" />");
                                }

                                if (!string.IsNullOrEmpty(i.seo_aciklama))
                                {
                                    Class.Fonksiyonlar.HeaderText("head", "lit_aciklama", "<meta http-equiv=\"Description\" content=\"" + i.seo_aciklama + "\" />");
                                }
                                else
                                {
                                    Class.Fonksiyonlar.HeaderText("head", "lit_aciklama", "<meta http-equiv=\"Description\" content=\"" + Class.Fonksiyonlar.Ayar(Class.Sabitler.Ayar.SeoAciklama) + "\" />");
                                }
                                #endregion
                            }
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