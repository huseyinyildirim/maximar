<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sayfa.aspx.cs" Inherits="maximar_com_tr.WebUI._sayfa" %>

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

            <header class="main-header">
    <div class="container">
        <h1 class="page-title"><asp:Literal runat="server" ID="lit_baslik"></asp:Literal></h1>

        <ol class="breadcrumb pull-right">
            <li><a href="#">Ana Sayfa</a></li>
            <li class="active"><asp:Literal runat="server" ID="lit_baslik_2"></asp:Literal></li>
        </ol>
    </div>
</header>

<div class="container">
    <div class="row">
        <asp:Literal runat="server" ID="lit_ozet"></asp:Literal>
        <asp:Literal runat="server" ID="lit_detay"></asp:Literal>
        
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
