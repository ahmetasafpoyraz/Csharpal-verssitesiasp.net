<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="duzenle.aspx.cs" Inherits="odevv.duzenle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Admin | Duzenleme</title>

    <style>
        .frm {
            height: auto;
            width: 300px;
            margin-left: 35%;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <form runat="server">
        <div class="content-wrapper">
            <div class="dznl">
                <div class="frm">
                    <br />
                    <span>&nbsp;*ADI : </span>
                    <br />
                    <asp:TextBox ID="tbadi" CssClass="form-control" runat="server" placeholder="ADI" />
                    <br />
                    <br />
                    <span>&nbsp;*SOY ADI : </span>
                    <br />
                    <asp:TextBox ID="tbsadi" CssClass="form-control" runat="server" placeholder="SOY ADI" />
                    <br />
                    <br />
                    <span>*DOĞUM TARİHİ : </span>
                    <br />
                    <asp:TextBox ID="tbdt" CssClass="form-control" runat="server" placeholder="GG.AA.YYYY" />
                    <br />
                    <br />
                    <span>*CİNSİYET : </span>
                    <br />
                    <asp:DropDownList ID="drpdvn" CssClass="form-control" runat="server">
                        <asp:ListItem>KADIN</asp:ListItem>
                        <asp:ListItem>ERKEK</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <span>&nbsp;* E-MAİL : </span>
                    <br />
                    <asp:TextBox ID="tbmail" CssClass="form-control" runat="server" placeholder="birisi@exeample.com" />
                    <br />
                    <span>&nbsp;* ŞİFRE : </span>
                    <br />
                    <asp:TextBox ID="tbsifre" CssClass="form-control" runat="server" placeholder="ŞİFRE" />
                    <br />
                    <span>&nbsp;*TEL NO : </span>
                    <br />
                    <asp:TextBox ID="tbcep" CssClass="form-control" runat="server" TextMode="Phone" placeholder="555 xxx xx xx" />
                    <br />
                    <span>&nbsp;&nbsp;&nbsp; ADRES BİLGİLERİ</span><br />
                    <br />
                    <span>&nbsp;*İL : </span>
                    <br />
                    <asp:TextBox ID="tbil" CssClass="form-control" runat="server" placeholder="İL" />
                    <br />
                    <span>&nbsp;*İLÇE : </span>
                    <br />
                    <asp:TextBox ID="tbilce" CssClass="form-control" runat="server" placeholder="İLÇE" />
                    <br />
                    <span>&nbsp;*POSTA KODU:</span>
                    <br />
                    <asp:TextBox ID="tbpk" CssClass="form-control" runat="server" placeholder="POSTA KODU" />
                    <br />
                    <span>&nbsp;*AÇIK ADRES: </span>
                    <br />
                    <asp:TextBox ID="tbadres" CssClass="form-control" runat="server" Rows="4" placeholder="AÇIK ADRES" />
                    <br />
                    <div class="col-8">
                        <div class="icheck-primary">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </div>
                        <asp:CheckBox ID="chbadmn" runat="server" />
                        <label for="remember">
                            ADMİN YAP
                        </label>
                        </div>
               

                    <br />
                    * DOLDURULMASI ZORUNLU ALAN&nbsp;&nbsp;&nbsp;

          &nbsp;&nbsp;&nbsp; 
                    <asp:Button ID="btndznle" class="btn btn-block btn-success btn-lg" runat="server" Text="DÜZENLE" Height="37px" Width="163px" OnClick="btndznle_Click" />
                </div>
            </div>
        </div>
    </form>
</asp:Content>
