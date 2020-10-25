<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="maximar_com_tr.WebUI._default" %>

<%@ Register TagPrefix="include" TagName="menu" Src="~/ascx/menu.ascx" %>
<%@ Register TagPrefix="include" TagName="head" Src="~/ascx/head.ascx" %>
<%@ Register TagPrefix="include" TagName="header" Src="~/ascx/header.ascx" %>
<%@ Register TagPrefix="include" TagName="js" Src="~/ascx/js.ascx" %>
<%@ Register TagPrefix="include" TagName="footer" Src="~/ascx/footer.ascx" %>
<%@ Register TagPrefix="include" TagName="slider" Src="~/ascx/slider.ascx" %>
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
            <include:slider ID="slider" runat="server" />
            
            <!-- Özet Bloklar -->
            <asp:Literal runat="server" ID="lit_ozet_blok"></asp:Literal>
            <!-- Özet Bloklar -->

            <!-- İkonlu başlıklar -->
            <asp:Literal runat="server" ID="lit_ikon_baslik"></asp:Literal>
            <!-- İkonlu başlıklar -->

            <div class="container">
                <section class="margin-bottom">
       <h2 class="section-title">Son Eklenen Fotoğraflar</h2>
       <div class="bxslider-controls">
            <span id="bx-prev4"></span>
            <span id="bx-next4"></span>
        </div>
        <ul class="bxslider" id="latest-works">
            <asp:Literal runat="server" ID="lit_son_resim"></asp:Literal>
        </ul>
   </section>
                <section>
                    
       <asp:Literal runat="server" ID="lit_anasayfa_slogan"></asp:Literal>
        
        <!--
        <h2 class="section-title">Müşterilerimiz</h2>
        <div class="row">
            <div class="col-md-6">
                <div class="bxslider-controls">
                     <span id="bx-prev5"></span>
                     <span id="bx-next5"></span>
                 </div>
                 <ul class="bxslider" id="home-block">
                    <li>
                        <blockquote class="blockquote-color">
                            <p>Maximar Mermercilik kalitesinden ödün vermeyen bir şirkettir. Ürünlerinden yüksek düzeyde memnunum.</p>
                            <footer>Hüseyin Yıldırım, Yıldırım İnşaat</footer>
                        </blockquote>
                    </li>
                </ul>
            </div>
            <div class="col-md-6">
                <div class="row">
                    <div class="col-md-3 col-sm-3 col-xs-6"><img src="/Upload/musteri/logo.png" alt="" class="img-responsive"></div>
                    <div class="col-md-3 col-sm-3 col-xs-6"><img src="/Upload/musteri/logo.png" alt="" class="img-responsive"></div>
                    <div class="col-md-3 col-sm-3 col-xs-6"><img src="/Upload/musteri/logo.png" alt="" class="img-responsive"></div>
                    <div class="col-md-3 col-sm-3 col-xs-6"><img src="/Upload/musteri/logo.png" alt="" class="img-responsive"></div>
                </div>
                <div class="row">
                    <div class="col-md-3 col-sm-3 col-xs-6"><img src="/Upload/musteri/logo.png" alt="" class="img-responsive"></div>
                    <div class="col-md-3 col-sm-3 col-xs-6"><img src="/Upload/musteri/logo.png" alt="" class="img-responsive"></div>
                    <div class="col-md-3 col-sm-3 col-xs-6"><img src="/Upload/musteri/logo.png" alt="" class="img-responsive"></div>
                    <div class="col-md-3 col-sm-3 col-xs-6"><img src="/Upload/musteri/logo.png" alt="" class="img-responsive"></div>
                </div>
            </div>
        </div>
        -->
   </section>
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
