﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;

namespace maximar_com_tr.WebUI.yonetim
{
    public partial class kullanici_ekle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Class.Yonetim.Fonksiyonlar.OturumIslemleri.CookieKontrol();
        }

        protected void btn_kayitekle_Click(object sender, EventArgs e)
        {
            try
            {
                using (BaglantiCumlesi db = new BaglantiCumlesi())
                {
                    tbl_admin tbl = new tbl_admin();
                    tbl.ad = txt_ad.Text;
                    tbl.soyad = txt_soyad.Text;
                    tbl.mail = txt_mail.Text;
                    tbl.sifre = Class.Fonksiyonlar.Sifrele(txt_sifre.Text);
                    tbl.admin_id_ek = int.Parse(HttpContext.Current.Request.Cookies[Class.Fonksiyonlar.Ayar(Class.Sabitler.Ayar.GuvenlikKodu) + "KullaniciID"].Value);
                    tbl.onay = Class.Fonksiyonlar.StringToBool(Request.Form["ddl_onay"].ToString());
                    db.AddTotbl_admin(tbl);
                    db.SaveChanges();
                }

                Class.Fonksiyonlar.JavaScript.MesajKutusuVeYonlendir("Başarıyla eklenmiştir.", "kullanici.aspx");
            }
            catch (Exception ex)
            {
                Class.Fonksiyonlar.JavaScript.MesajKutusuVeYonlendir(ex.Message, "kullanici.aspx");
            }
        }
    }
}