using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace maximar_com_tr.WebUI.ascx
{
    public partial class footer : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (var db = new BaglantiCumlesi())
            {
                var sql = (from p in db.tbl_resimler
                           where p.tip==1
                           select new
                           {
                               p.dosya_ad
                           }).AsEnumerable().OrderBy(k => Guid.NewGuid()).Take(2);

                if (sql.Any())
                {
                    StringBuilder sb = new StringBuilder();

                    foreach (var i in sql)
                    {
                        sb.Append(
                            "<div class=\"col-lg-6 col-md-6 col-sm-3 col-xs-6\"><a href=\"#\" class=\"thumbnail\"><img src=\"/ashx/image-view.ashx?i=upload/photo-gallery/" +
                            i.dosya_ad + "&w=360&h=240&k=t\" class=\"img-responsive\" alt=\"Image\"></a></div>");
                    }

                    lit_resim.Text = sb.ToString();
                }
            }
        }
    }
}