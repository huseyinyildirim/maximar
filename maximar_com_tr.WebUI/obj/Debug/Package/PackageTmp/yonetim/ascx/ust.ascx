<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ust.ascx.cs" Inherits="maximar_com_tr.WebUI.yonetim.ascx.ust" %>

<div class="ust">
    <div class="sol"><img src="img/logo.png" /></div>
    <div class="sag" style="text-align:right;"><img src="img/kullanici.png" /> Hoşgeldiniz, <asp:Literal runat="server" ID="kullaniciadi" /> | <img src="img/profil.png" /> <a href="profil.aspx">Profiliniz</a><br /><br /><img src="img/site.png" /> <a href="/" target="_blank">Siteye git</a> | <img src="img/cikis.png" /> <a href="cikis.aspx">Güvenli çıkış</a></div>
</div>

<div class="clear"></div>

<div class="menu">
    <ul>
        <li id="panel"><a href="javascript:menusec('panel')">Panel</a></li>
        <li id="icerik"><a href="javascript:menusec('icerik')">İçerik Yönetimi</a></li>
        <li id="galeri"><a href="javascript:menusec('galeri')">Galeri Yönetimi</a></li>
        <li id="uye"><a href="javascript:menusec('uye')">Üye Yönetimi</a></li>
        <li id="kullanici"><a href="javascript:menusec('kullanici')">Kullanıcı Yönetimi</a></li>
        <li id="maillist"><a href="javascript:menusec('maillist')">Maillist Yönetimi</a></li>
        <li id="ayar"><a href="javascript:menusec('ayar')">Ayarlar</a></li>
        <!--<li id="istatistik"><a href="javascript:menusec('istatistik')">İstatistikler</a></li>-->
        
    </ul>
</div>

<div class="clear"></div>

<div class="menualt">
    <div class="menualtdetay" id="panel_detay" style="display:none;">
        <ul>
            <li><a href="default.aspx">Masaüstü</a></li>
            <li><a href="haber.aspx">Haberler</a></li>
        </ul>
    </div>
    <div class="clear"></div>
    <div class="menualtdetay" id="galeri_detay" style="display:none;">
        <ul>
            <li><a href="foto-galeri.aspx">Foto Galeriler</a></li>
            <li><a href="foto-galeri-ekle.aspx">Yeni Foto Galeri Ekle</a></li>
            <li><a href="video-galeri.aspx">Video Galeriler</a></li>
            <li><a href="video-galeri-ekle.aspx">Yeni Video Galeri Ekle</a></li>
        </ul>
    </div>
    <div class="clear"></div>
    <div class="menualtdetay" id="icerik_detay" style="display:none;">
        <ul>
            <li><a href="haber.aspx">Haberler</a></li>
            <li><a href="haber-ekle.aspx">Yeni Haber Ekle</a></li>
            <li><a href="manset.aspx">Manşetler</a></li>
            <li><a href="manset-ekle.aspx">Yeni Manşet Ekle</a></li>
            <li><a href="menu.aspx">Menüler</a></li>
        </ul>
    </div>
    <div class="clear"></div>
    <div class="menualtdetay" id="maillist_detay" style="display:none;">
        <ul>
            <li><a href="maillist.aspx">E-Posta Adresleri</a></li>
        </ul>
    </div>
    <div class="clear"></div>
    <div class="menualtdetay" id="kullanici_detay" style="display:none;">
        <ul>
            <li><a href="kullanici.aspx">Kullanıcılar</a></li>
            <li><a href="kullanici-ekle.aspx">Yeni Kullanıcı Ekle</a></li>
        </ul>
    </div>
    <div class="clear"></div>
    <div class="menualtdetay" id="ayar_detay" style="display:none;">
        <ul>
            <li><a href="ayar-genel.aspx">Genel Ayarlar</a></li>
            <li><a href="ayar-parametre.aspx">Parametreler</a></li>
            <li><a href="ayar-smtp.aspx">E-Posta Ayarları</a></li>
            <li><a href="ayar-dil.aspx">Dil Ayarları</a></li>
            <li><a href="ayar-statik-kelime.aspx">Statik Kelime Ayarları</a></li>
        </ul>
    </div>
    <div class="clear"></div>
</div>

<div class="clear"></div>