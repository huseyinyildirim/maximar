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
    public partial class _foto_galeri : System.Web.UI.Page
    {
        int DilID = Class.Fonksiyonlar.DilAyarlari.ID();

        protected void Page_Load(object sender, EventArgs e)
        {
            lv_veriler.GroupItemCount = 5;

            using (BaglantiCumlesi db = new BaglantiCumlesi())
            {
                var SQL = (from p in db.tbl_foto_galeri
                    where p.onay == true
                    orderby p.baslik ascending
                    select new
                    {
                        p.id,
                        baslik =
                            (db.tbl_foto_galeri_detay.Where(k => k.galeri_id == p.id && k.dil_id == DilID)
                                .Select(k => k.baslik)
                                .FirstOrDefault()),
                        resim =
                            (db.tbl_resimler.Where(
                                k => k.tip == 1 && k.tip_id == p.id && k.varsayilan == true && k.onay == true)
                                .Select(k => k.dosya_ad)
                                .FirstOrDefault()),
                        p.tarih_ek
                    }).OrderByDescending(k => k.tarih_ek).AsEnumerable();

                lv_veriler.DataSource = SQL;
                lv_veriler.DataBind();
            }
        }
    }
}