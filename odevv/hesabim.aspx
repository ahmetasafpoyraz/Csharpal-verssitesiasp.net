<%@ Page Title="" Language="C#" MasterPageFile="~/Homepage.Master" AutoEventWireup="true" CodeBehind="hesabim.aspx.cs" Inherits="odevv.hasabim" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="registration-form">
        <div class="container">
            <ol class="breadcrumb">
                <li><a href="index.html">Home</a></li>
                <li class="active">Registration</li>
            </ol>
            <h2>ÜYE KAYIT FORMU</h2>
            <div class="col-md-6 reg-form">
                <div class="reg">
                    <form runat="server">
                        <ul>
                            <li class="text-info">*ADI: </li>
                            <li>
                                <asp:TextBox ID="tbadi" runat="server" /></li>
                        </ul>
                        <ul>
                            <li class="text-info">*SOYADI: </li>
                            <li>
                                <asp:TextBox ID="tbsadi" runat="server" /></li>
                        </ul>
                        <ul>
                            <li class="text-info">*E-MAİL: </li>
                            <li>
                                <asp:TextBox ID="tbmail" runat="server" /></li>
                        </ul>
                        <ul>
                            <li class="text-info">*ŞİFRE: </li>
                            <li>
                                <asp:TextBox ID="tbsifre" runat="server" /></li>
                        </ul>
                        <ul>
                            <li class="text-info">*ŞİFRE TEKRARI:</li>
                            <li>
                                <asp:TextBox ID="tbsifretk" runat="server" /></li>
                        </ul>
                        <ul>
                            <li class="text-info">*TELEFON NO:</li>
                            <li>
                                <asp:TextBox ID="tbcep" runat="server" /></li>
                        </ul>
                        <ul>
                            <li class="text-info">DOĞUM TARİHİ:</li>
                            <li>
                                <asp:TextBox ID="tbdt" runat="server" /></li>
                        </ul>
                        <ul>
                            <li class="text-info">CİNSİYET:</li>
                            <li>
                                <asp:DropDownList ID="drpdvn" Width="400px" Height="40px"  runat="server">
                                    <asp:ListItem Text="ERKEK" />
                                    <asp:ListItem Text="KADIN" />
                                </asp:DropDownList></li>
                        </ul>
                        <ul>
                            <li class="text-info">İL:</li>
                            <li>
                                <asp:TextBox ID="tbil" runat="server" /></li>
                        </ul>
                        <ul>
                            <li class="text-info">İLÇE:</li>
                            <li>
                                <asp:TextBox ID="tbilce" runat="server" /></li>
                        </ul>
                          <ul>
                            <li class="text-info">POSTAKODU:</li>
                            <li>
                                <asp:TextBox ID="tbpk" runat="server" /></li>
                        </ul>
                        <ul>
                            <li class="text-info">AÇIK ADRES:</li>
                            <li>
                                <asp:TextBox ID="tbadres" runat="server" TextMode="MultiLine"  Width="400px" Height="100px" /></li>
                        </ul>
                        <asp:Button ID="btnkyt" Text="GÜNCELLEMEYİ KAYDET" type="submit" value="Register Now" runat="server" OnClick="Unnamed1_Click" />
                        <asp:Button ID="btndz" Text="BİLGİLERİMİ GÜNCELLE" type="submit" value="Register Now" runat="server" OnClick="btndz_Click"  />
                       
                    </form>
                </div>
            </div>
            <div class="clearfix"></div>
        </div>
    </div>

</asp:Content>
