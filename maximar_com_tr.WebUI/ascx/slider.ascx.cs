using System;
using System.Linq;
using System.Text;

namespace maximar_com_tr.WebUI.ascx
{
    public partial class slider : System.Web.UI.UserControl
    {
        private int DilID = Class.Fonksiyonlar.DilAyarlari.ID();

        protected void Page_Load(object sender, EventArgs e)
        {
            using (BaglantiCumlesi db = new BaglantiCumlesi())
            {
                var a = (from p in db.tbl_manset
                    from t in db.tbl_manset_detay
                    where p.onay == true && t.manset_id == p.id && t.dil_id == DilID
                    orderby p.tarih_ek descending
                    select new
                    {
                        t.detay,
                        t.url,
                        p.dosya_ad
                    });

                if (a.Any())
                {
                    StringBuilder sb_manset = new StringBuilder();
                    StringBuilder sb_manset_sira = new StringBuilder();

                    int i = 0;

                    foreach (var item in a)
                    {
                        sb_manset.Append(i == 0 ? "<div class=\"item active\">" : "<div class=\"item\">");

                        sb_manset.Append("<div class=\"container\">");
                        sb_manset.Append("<div class=\"row\">");
                        sb_manset.Append("<div class=\"col-md-6 col-sm-7\">");
                        sb_manset.Append("<div class=\"carousel-caption\">");
                        sb_manset.Append("<div class=\"carousel-text\">");
                        sb_manset.Append(item.detay);
                        sb_manset.Append("</div>");
                        sb_manset.Append("</div>");
                        sb_manset.Append("</div>");
                        sb_manset.Append("<div class=\"col-md-6 col-sm-5 hidden-xs carousel-img-wrap\">");
                        sb_manset.Append("<div class=\"carousel-img\">");
                        sb_manset.Append(
                            "<img src=\"/ashx/image-view.ashx?i=upload/slider/" + item.dosya_ad +
                            "&amp;w=1000&amp;h=512&amp;k=t\" class=\"img-responsive animated bounceInUp animation-delay-3\" alt=\"Image\">");
                        sb_manset.Append("</div>");
                        sb_manset.Append("</div>");
                        sb_manset.Append("</div>");
                        sb_manset.Append("</div>");
                        sb_manset.Append("</div>");

                        if (i == 0)
                        {
                            sb_manset_sira.Append("<li data-target=\"#carousel-example-generic\" data-slide-to=\"" + i +
                                                  "\" class=\"active\"></li>");
                        }
                        else
                        {
                            sb_manset_sira.Append("<li data-target=\"#carousel-example-generic\" data-slide-to=\"" + i +
                                                  "\"></li>");
                        }

                        i++;
                    }

                    lit_manset.Text = sb_manset.ToString();
                    lit_manset_sira.Text = sb_manset_sira.ToString();
                }
            }
        }
    }
}