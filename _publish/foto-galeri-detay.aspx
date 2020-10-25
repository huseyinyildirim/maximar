<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="foto-galeri-detay.aspx.cs" Inherits="maximar_com_tr.WebUI._foto_galeri_detay" %>

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
    
    <include:js runat="server" ID="js" />

     <link href="/css/colorbox.css" rel="stylesheet" type="text/css" />
    <script src="/js/jquery.colorbox-min.js" type="text/javascript"></script>
    <script>
        $(document).ready(function () {
            /* Colorbox */
            $(".foto-galeri").colorbox({ rel: 'foto-galeri', iframe: true, slideshow: false, innerWidth: 620, innerHeight: 420, speed: 900 });
            /* Colorbox */
        })
    </script>
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
        <h1 class="page-title">Foto Galeri</h1>

        <ol class="breadcrumb pull-right">
            <li><a href="#">Ana Sayfa</a></li>
            <li class="active">Foto Galeri</li>
        </ol>
    </div>
</header>


<div class="container">
    <div class="row">
        <br/>
        <div class="col-md-12">
  <asp:ListView runat="server" ID="lv_foto_veriler" GroupItemCount="4">
                    <LayoutTemplate>
                        <table width="100%" cellpadding="10">
                            <asp:PlaceHolder runat="server" ID="groupPlaceHolder" />
                        </table>
                    </LayoutTemplate>
                    <GroupTemplate>
                        <tr>
                            <asp:PlaceHolder runat="server" ID="itemPlaceHolder" />
                        </tr>
                    </GroupTemplate>
                    <ItemTemplate>
                        <td valign="top" style="text-align: center; padding-bottom:10px;">
                            <a class="foto-galeri" href="/ashx/image-view.ashx?i=upload/photo-gallery/<%#Eval("dosya_ad")%>&amp;w=600&amp;h=400&amp;k=t"
                                title="<%#Eval("baslik")%>">
                                <img src="/ashx/image-view.ashx?i=upload/photo-gallery/<%#Eval("dosya_ad")%>&amp;w=200&amp;h=200&amp;k=t"
                                    class="img-thumbnail" alt="<%#Eval("baslik")%>" /></a>
                        </td>
                    </ItemTemplate>
                    <EmptyDataTemplate>
                        <p>
                            <div class="alert alert-info">
                                Eklenmiş fotoğraf bulunmuyor!</div>
                        </p>
                    </EmptyDataTemplate>
                </asp:ListView>
        </div>
    </div>
</div> 
            <include:footer runat="server" ID="footer" />
        </div>
    </div>
    <div id="back-top">
        <a href="#header"><i class="fa fa-chevron-up"></i></a>
    </div>
    
    </form>
</body>
</html>
