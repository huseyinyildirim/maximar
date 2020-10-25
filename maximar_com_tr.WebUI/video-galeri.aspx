<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="video-galeri.aspx.cs" Inherits="maximar_com_tr.WebUI._video_galeri" %>

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
    <link href="/css/colorbox.css" rel="stylesheet" type="text/css" />
    <include:js runat="server" ID="js" />
    <script src="/js/jquery.colorbox-min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            /* Colorbox */
            $(".youtube").colorbox({ iframe: true, innerWidth: 425, innerHeight: 344 });
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
        <h1 class="page-title">Video Galeri</h1>

        <ol class="breadcrumb pull-right">
            <li><a href="#">Ana Sayfa</a></li>
            <li class="active">Video Galeri</li>
        </ol>
    </div>
</header>

<div class="container">
    <div class="row">
        <br />
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
                            <a class="youtube" href="<%#Eval("video")%>">
                                <img src="/ashx/image-view.ashx?i=upload/video-gallery/<%#Eval("dosya_ad")%>&amp;w=150&amp;h=150&amp;k=t"
                                    class="img-thumbnail" alt="<%#Eval("baslik")%>" /><br />
                                <%#Eval("baslik")%></a>
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
    
    </form>
</body>
</html>
