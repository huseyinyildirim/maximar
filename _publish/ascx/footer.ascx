<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="footer.ascx.cs" Inherits="maximar_com_tr.WebUI.ascx.footer" %>

<aside id="footer-widgets">
    <div class="container">
        <div class="row">
            <!--<div class="col-md-4">
                <h3 class="footer-widget-title">Site Haritası</h3>
                <ul class="list-unstyled three_cols">
                    <li><a href="#">Ana Sayfa</a></li>
                    <li><a href="#">Hakkımızda</a></li>
                    <li><a href="#">Ürünler</a></li>
                    <li><a href="#">Ocaklar</a></li>
                    <li><a href="#">Projeler</a></li>
                    <li><a href="#">Galeri</a></li>
                    <li><a href="#">İletişim</a></li>
                </ul>
            </div>-->
            <div class="col-md-4">
                <h3 class="footer-widget-title">Haber List</h3>
                <p>Proje, ürün ve hakkımızda son gelişmeleri öğrenmek için e-posta adresinizi kayıt ediniz.</p>
                <div class="input-group">
                    <input type="text" class="form-control" placeholder="e-posta adresiniz">
                    <span class="input-group-btn">
                        <button class="btn btn-ar btn-primary" type="button">Kayıt Et</button>
                    </span>
                </div>
            </div>
            <div class="col-md-4"></div>
            <div class="col-md-4">
                <div class="footer-widget">
                    <h3 class="footer-widget-title">Foto Galeri</h3>
                    <div class="row">
                        <asp:Literal runat="server" ID="lit_resim"></asp:Literal>
                    </div>
                </div>
            </div>
        </div>
    </div>
</aside>
<footer id="footer">
    <p>&copy; 2014 <a href="#">Maximar Mermercilik</a>, Bütün hakları saklıdır.</p>
</footer>