<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="iletisim.aspx.cs" Inherits="maximar_com_tr.WebUI._iletisim" %>

<%@ Register TagPrefix="include" TagName="menu" Src="~/ascx/menu.ascx" %>
<%@ Register TagPrefix="include" TagName="head" Src="~/ascx/head.ascx" %>
<%@ Register TagPrefix="include" TagName="header" Src="~/ascx/header.ascx" %>
<%@ Register TagPrefix="include" TagName="js" Src="~/ascx/js.ascx" %>
<%@ Register TagPrefix="include" TagName="footer" Src="~/ascx/footer.ascx" %>

<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <title>Maximar Mermercilik</title>
    <include:head runat="server" ID="head" />
</head>
<div id="preloader">
    <div id="status">
        &nbsp;</div>
</div>
<body>
    <form id="form1" runat="server">
    <div id="sb-site">
        <div class="boxed">
            <include:header runat="server" ID="header" />
            <include:menu ID="menu" runat="server" />

            <header class="main-header no-margin-bottom">
    <div class="container">
        <h1 class="page-title">İletişim</h1>

        <ol class="breadcrumb pull-right">
            <li><a href="#">Ana Sayfa</a></li>
            <li class="active">İletişim</li>
        </ol>
    </div>
</header>

<iframe class="margin-bottom" width="100%" height="350" src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d1596.3323583252477!2d30.761579000000005!3d36.85050515185714!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x14c39b1c4561e9fd%3A0x7b4335847e22d6e8!2sFener+Cd%2C+%C3%87a%C4%9Flayan+Mh.%2C+07100+Muratpa%C5%9Fa%2FAntalya%2C+Turkey!5e0!3m2!1sen!2sus!4v1421938136675"></iframe>

<div class="container">
    <div class="row">
        <div class="col-md-12">
            <h2 class="section-title">İletişim Formu</h2>
        </div>
        <div class="col-md-8">
            <section>
                <p>Aşağıdaki form ile istek, öneri ve şikayetlerinizi tarafımıza gönderebilirsiniz.</p>

                <form role="form">
                    <div class="form-group">
                        <label for="InputName">Adınız</label>
                        <input type="email" class="form-control" id="InputName">
                    </div>
                    <div class="form-group">
                        <label for="InputEmail1">E-posta Adresiniz</label>
                        <input type="email" class="form-control" id="InputEmail1">
                    </div>
                    <div class="form-group">
                        <label for="InputMessage">Mesajınız</label>
                        <textarea class="form-control" id="InputMessage" rows="8"></textarea>
                    </div>
                    <button type="submit" class="btn btn-ar btn-primary">Gönder</button>
                    <div class="clearfix"></div>
                </form>
            </section>
        </div>

        <div class="col-md-4">
            <section>
                <div class="panel panel-primary">
                    <div class="panel-heading"><i class="fa fa-envelope-o"></i> İletişim bilgileri</div>
                    <div class="panel-body">
                        <h4 class="section-title no-margin-top">Merkez</h4>
                        <address>
                            <strong>Maximar Mermercilik Ltd. Şti.</strong><br>
                        </address>
                        <address>
                            Fener Mh. 1964 Sk.<br />
                            Akanay Apt. A Blok K:1 D:3-4<br />
                            07320 Muratpaşa/Antalya<br/>
                            <abbr title="Telefon">P:</abbr> +90 242 323 72 00 <br />
                            <abbr title="Fax">F:</abbr> +90 242 323 18 07 <br />
                        </address>
                    </div>
                </div>
            </section>
        </div>
    </div>
</div> 
            <include:footer runat="server" ID="footer" />
        </div>
    </div>
    <div id="back-top">
        <a href="#header"><i class="fa fa-chevron-up"></i></a>
    </div>
    <include:js runat="server" ID="js" />
    </form>
</body>
</html>
