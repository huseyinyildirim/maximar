using System;
using System.Linq;
using System.Text;

namespace maximar_com_tr.WebUI
{
    public partial class _default : System.Web.UI.Page
    {
        int DilID = Class.Fonksiyonlar.DilAyarlari.ID();

        protected void Page_Load(object sender, EventArgs e)
        {
            Icerik();
            SonResim();
        }

        private void SonResim()
        {
            using (BaglantiCumlesi db = new BaglantiCumlesi())
            {
                var a = (from p in db.tbl_resimler
                    from t in db.tbl_foto_galeri_detay
                    where p.tip == 1 && p.onay == true && t.galeri_id == p.tip_id && t.dil_id == DilID
                    orderby p.tarih_ek descending 
                    select new
                    {
                        t.galeri_id,
                        p.dosya_ad,
                        t.baslik
                    }).Take(12);

                if (a.Any())
                {
                    StringBuilder sb = new StringBuilder();

                    foreach (var item in a)
                    {
                        sb.Append("<li>");
                        sb.Append("<div class=\"img-caption-ar\">");
                        sb.Append("<img src=\"/ashx/image-view.ashx?i=upload/photo-gallery/" + item.dosya_ad +
                                  "&amp;w=360&amp;h=240&amp;k=t\" class=\"img-responsive\" alt=\"Image\">");
                        sb.Append("<div class=\"caption-ar\">");
                        sb.Append("<div class=\"caption-content\">");
                        sb.Append("<a href=\""+Class.Fonksiyonlar.SeoLink("foto-galeri",item.galeri_id.ToString(),item.baslik)+"\" class=\"animated fadeInDown\"><i class=\"fa fa-search\"></i>Detay</a>");
                        sb.Append("<h4 class=\"caption-title\">" + item.baslik + "</h4>");
                        sb.Append("</div>");
                        sb.Append("</div>");
                        sb.Append("</div>");
                        sb.Append("</li>");
                    }

                    lit_son_resim.Text = sb.ToString();
                }
            }
        }

        void Icerik()
        {
            #region Özet içerik
            using (BaglantiCumlesi db = new BaglantiCumlesi())
            {
                var a = (from p in db.tbl_blok_detay
                    where p.blok_id == 1 && p.dil_id == DilID
                    select new
                    {
                        p.detay
                    });

                lit_ozet_blok.Text = a.Select(k => k.detay).FirstOrDefault();
            }
            #endregion

            #region İkon başlık

            using (BaglantiCumlesi db=new BaglantiCumlesi())
            {
                var a = (from p in db.tbl_blok_detay
                         where p.blok_id == 2 && p.dil_id == DilID
                         select new
                         {
                             p.detay
                         });

                lit_ikon_baslik.Text = a.Select(k => k.detay).FirstOrDefault();
            }
            #endregion

            #region ana sayfa slogan

            using (BaglantiCumlesi db = new BaglantiCumlesi())
            {
                var a = (from p in db.tbl_blok_detay
                         where p.blok_id == 3 && p.dil_id == DilID
                         select new
                         {
                             p.detay
                         });

                lit_anasayfa_slogan.Text = a.Select(k => k.detay).FirstOrDefault();
            }
            #endregion
        }
    }
}