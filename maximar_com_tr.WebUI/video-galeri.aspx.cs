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
    public partial class _video_galeri : System.Web.UI.Page
    {
        int DilID = Class.Fonksiyonlar.DilAyarlari.ID();

        protected void Page_Load(object sender, EventArgs e)
        {
            lv_veriler.GroupItemCount = 4;

            using (BaglantiCumlesi db = new BaglantiCumlesi())
            {
                var SQL = (from p in db.tbl_video_galeri
                           from k in db.tbl_video_galeri_detay
                           where p.onay == true && k.video_galeri_id == p.id
                           && k.video_galeri_id == p.id && k.dil_id == DilID
                           select new
                           {
                               p.id,
                               p.dosya_ad,
                               k.baslik,
                               p.video,
                               p.tarih_ek
                           }).OrderByDescending(k => k.tarih_ek).AsEnumerable();

                lv_veriler.DataSource = SQL;
                lv_veriler.DataBind();
            }
        }
    }
}