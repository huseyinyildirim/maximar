<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="menu.ascx.cs" Inherits="maximar_com_tr.WebUI.ascx.menu" %>

<nav class="navbar navbar-static-top navbar-default navbar-header-full navbar-dark" role="navigation" id="header">
    <div class="container">
        <div class="navbar-header">
            <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1">
                <span class="sr-only">navigation</span>
                <i class="fa fa-bars"></i>
            </button>
            <a class="navbar-brand hidden-lg hidden-md hidden-sm active" href="index.html">Maximar Mermercilik</a>
        </div>
        <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
            <ul class="nav navbar-nav">
                <asp:Literal runat="server" ID="lit_menu"></asp:Literal>
                <!--
                <li class="dropdown">
                    <a href="javascript:void(0);" class="dropdown-toggle" data-toggle="dropdown">Ürünler</a>
                     <ul class="dropdown-menu dropdown-menu-left">
                        <li><a href="javascript:void(0);" class="has_children">Mermer 1</a></li>
                        <li><a href="javascript:void(0);" class="has_children">Mermer 2</a></li>
                    </ul>
                </li>
                <li><a href="javascript:void(0);" class="dropdown-toggle" data-toggle="dropdown">İletişim</a></li>
                -->
             </ul>
        </div>
    </div>
</nav>