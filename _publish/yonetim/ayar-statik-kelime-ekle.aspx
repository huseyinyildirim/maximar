<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ayar-statik-kelime-ekle.aspx.cs" Inherits="maximar_com_tr.WebUI.yonetim.statik_kelime_ekle" ValidateRequest="false" %>

<%@ Register TagPrefix="include" TagName="Head" Src="~/yonetim/ascx/head.ascx" %>
<%@ Register TagPrefix="include" TagName="Ust" Src="~/yonetim/ascx/ust.ascx" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <include:Head runat="server" ID="head" />
    <script type="text/javascript">
        $(document).ready(function () {
            $(".menu ul #ayar").addClass("secili");
            $(".menualt #ayar_detay").css("display", "inline");
        });
        $(function () {
            $("#tabs").tabs();
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager runat="server" ID="sm">
    </asp:ScriptManager>
    <include:Ust runat="server" ID="ust" />
    <div class="icerik">
        <div class="blokbaslik">
            Ana Sayfa » Ayarlar » Statik Kelime Ayarları » Yeni Kelime Ekle</div>
        <div class="blokicerik">
            <asp:ValidationSummary CssClass="form_hata" ID="hatalar" runat="server" ForeColor="#CC0000"
                ValidationGroup="ekle" />
            <fieldset>
                <legend>Tanımlama</legend>
                <div>
                    Başlık:
                    <asp:TextBox ID="txt_tanimlama_baslik" runat="server" Width="300px"></asp:TextBox><asp:RequiredFieldValidator
                        ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_tanimlama_baslik"
                        Display="None" ErrorMessage="Lütfen tanımlama başlığını giriniz." ValidationGroup="ekle"></asp:RequiredFieldValidator></div>
            </fieldset>
            <br />
            <asp:PlaceHolder runat="server" ID="lit_icerik"></asp:PlaceHolder>
            <br />
            <fieldset>
                <legend>İşlemler</legend>
                <div>
                    <asp:Button ID="btn_kayitekle" runat="server" Text="Ekle" ValidationGroup="ekle"
                        OnClick="btn_kayitekle_Click" /></div>
            </fieldset>
        </div>
    </div>
    </form>
</body>
</html>
