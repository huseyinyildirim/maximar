<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="slider.ascx.cs" Inherits="maximar_com_tr.WebUI.ascx.slider" %>

<section class="carousel-section">
    <div id="carousel-example-generic" class="carousel carousel-razon slide" data-ride="carousel" data-interval="5000">
        <ol class="carousel-indicators">
            <asp:Literal runat="server" ID="lit_manset_sira"></asp:Literal>
        </ol>

        <div class="carousel-inner">
            <asp:Literal runat="server" ID="lit_manset"></asp:Literal>
        </div>
        <a class="left carousel-control" href="#carousel-example-generic" data-slide="prev">
            <span class="glyphicon glyphicon-chevron-left"></span>
        </a>
        <a class="right carousel-control" href="#carousel-example-generic" data-slide="next">
            <span class="glyphicon glyphicon-chevron-right"></span>
        </a>
    </div>
</section>