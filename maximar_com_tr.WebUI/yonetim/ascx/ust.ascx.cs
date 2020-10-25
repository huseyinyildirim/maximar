using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace maximar_com_tr.WebUI.yonetim.ascx
{
    public partial class ust : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Kayitlar();
        }

        protected void Kayitlar()
        {
            int ID = int.Parse(HttpContext.Current.Request.Cookies[Class.Fonksiyonlar.Ayar(Class.Sabitler.Ayar.GuvenlikKodu) + "KullaniciID"].Value);

            using (BaglantiCumlesi db = new BaglantiCumlesi())
            {
                var SQL = (from a in db.tbl_admin
                           where a.id == ID
                           select new
                           {
                               a.ad,
                               a.soyad,
                               a.mail
                           }).AsEnumerable();

                if (SQL.Any())
                {
                    kullaniciadi.Text = SQL.Select(p => p.ad).FirstOrDefault() + " " + SQL.Select(p => p.soyad).FirstOrDefault() + " (" + SQL.Select(p => p.mail).FirstOrDefault() + ")";
                }
            }
        }
    }
}