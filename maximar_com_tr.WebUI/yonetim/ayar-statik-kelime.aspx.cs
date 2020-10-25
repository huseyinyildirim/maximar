using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace maximar_com_tr.WebUI.yonetim
{
    public partial class statik_kelime : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Class.Yonetim.Fonksiyonlar.OturumIslemleri.CookieKontrol();

            if (!IsPostBack)
            {
                YuklenecekAlanlar();
                Sayfalama();
                KayitYukle("");
            }
        }

        protected void YuklenecekAlanlar()
        {
            kayitsayi.Items.Clear();
            kayitsayi.Items.Add(new ListItem("10", "10"));
            kayitsayi.Items.Add(new ListItem("20", "20"));
            kayitsayi.Items.Add(new ListItem("30", "30"));
            kayitsayi.Items.Add(new ListItem("50", "50"));
            kayitsayi.Items.Add(new ListItem("75", "75"));
            kayitsayi.Items.Add(new ListItem("100", "100"));
            kayitsayi.Items.Add(new ListItem("125", "125"));
            kayitsayi.Items.Add(new ListItem("150", "150"));

            kayitsayi.Text = Class.Yonetim.Sabitler.YoneticiListeKayitSayi;
        }

        protected void Sayfalama()
        {
            sayfa.Items.Clear();

            int ToplamKayitSayisi = 0;
            using (BaglantiCumlesi db = new BaglantiCumlesi())
            {
                var SQL = db.tbl_text.Count();
                ToplamKayitSayisi = SQL;
            }

            int ToplamSayfaSayisi = 0;

            if ((ToplamKayitSayisi % int.Parse(kayitsayi.Text)) == 0)
            {
                ToplamSayfaSayisi = ToplamKayitSayisi / int.Parse(kayitsayi.Text);
            }
            else
            {
                ToplamSayfaSayisi = (ToplamKayitSayisi / int.Parse(kayitsayi.Text)) + 1;
            }

            for (int i = 1; i <= ToplamSayfaSayisi; i++)
            {
                sayfa.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
        }

        protected void KayitYukle(string SqlCumle)
        {
            System.Threading.Thread.Sleep(1000);

            int Limit;
            if (sayfa.Text == "1")
            {
                Limit = 0;
            }
            else if (sayfa.SelectedValue == "")
            {
                Limit = 0;
            }
            else
            {
                Limit = (int.Parse(sayfa.Text) - 1) * int.Parse(kayitsayi.Text);
            }

            using (BaglantiCumlesi db = new BaglantiCumlesi())
            {
                var SQL = (from a in db.tbl_text
                           select new
                           {
                               a.id,
                               a.baslik,
                               kelime = "TR / " + db.tbl_text_detay.Where(b => b.text_id == a.id && b.dil_id == 1).Select(b => b.baslik).FirstOrDefault() + "<br />RU / " + db.tbl_text_detay.Where(b => b.text_id == a.id && b.dil_id == 2).Select(b => b.baslik).FirstOrDefault() + "<br />EN / " + db.tbl_text_detay.Where(b => b.text_id == a.id && b.dil_id == 3).Select(b => b.baslik).FirstOrDefault() + "<br />DE / " + db.tbl_text_detay.Where(b => b.text_id == a.id && b.dil_id == 4).Select(b => b.baslik).FirstOrDefault() + "<br />FR / " + db.tbl_text_detay.Where(b => b.text_id == a.id && b.dil_id == 5).Select(b => b.baslik).FirstOrDefault(),
                               a.tarih,
                               ekleyen = db.tbl_admin.Where(b => b.id == a.admin_id).Select(b => b.ad).FirstOrDefault() + " " + db.tbl_admin.Where(b => b.id == a.admin_id).Select(b => b.soyad).FirstOrDefault()
                           }).OrderBy(p => p.baslik).Skip(Limit).Take(int.Parse(kayitsayi.Text));

                Cache["icerik"] = SQL;

                kayitlar.DataSource = SQL;
                kayitlar.DataBind();
            }
        }

        protected void kayitlar_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[4].Text = "<a href=\"ayar-statik-kelime-duzenle.aspx?ID=" + e.Row.Cells[1].Text + "\"><img src=\"img/komut-duzenle.png\" /></a>";
            }
        }

        protected void kayitsayisec(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(1000);
            Sayfalama();
            KayitYukle("");
        }

        protected void sayfasec(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(1000);
            KayitYukle("");
        }

        protected void secilenlerisil_Click(object sender, EventArgs e)
        {
            KayitYukle("");
        }

        protected void yeniekle_Click(object sender, EventArgs e)
        {
            Response.Redirect("ayar-statik-kelime-ekle.aspx");
        }

        protected void kayitlar_RowCommand(object sender, GridViewCommandEventArgs e)
        {
        }
    }
}