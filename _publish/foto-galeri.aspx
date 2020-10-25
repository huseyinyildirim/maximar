<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="foto-galeri.aspx.cs" Inherits="maximar_com_tr.WebUI._foto_galeri" %>

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
  <asp:ListView runat="server" ID="lv_veriler">
                    <LayoutTemplate>
                        <table width="100%" cellpadding="10" style="text-align: center;">
                            <asp:PlaceHolder runat="server" ID="groupPlaceHolder" />
                        </table>
                    </LayoutTemplate>
                    <GroupTemplate>
                        <tr>
                            <asp:PlaceHolder runat="server" ID="itemPlaceHolder" />
                        </tr>
                    </GroupTemplate>
                    <ItemTemplate>
                        <td valign="top" style="width: 25%;">
                            <p>
                                <a href="<%# maximar_com_tr.WebUI.Class.Fonksiyonlar.SeoLink("foto-galeri", DataBinder.Eval(Container.DataItem, "id").ToString(), DataBinder.Eval(Container.DataItem, "baslik").ToString())%>">
                                    <img src="/ashx/image-view.ashx?i=upload/photo-gallery/<%#Eval("resim")%>&amp;w=150&amp;h=100&amp;k=t"
                                        class="img-thumbnail" alt="<%#Eval("baslik")%>" /></a><br />
                                <a href="<%# maximar_com_tr.WebUI.Class.Fonksiyonlar.SeoLink("foto-galeri", DataBinder.Eval(Container.DataItem, "id").ToString(), DataBinder.Eval(Container.DataItem, "baslik").ToString())%>">
                                    <%#Eval("baslik")%></a></p>
                        </td>
                    </ItemTemplate>
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
    <include:js runat="server" ID="js" />
    </form>
</body>
</html>
