<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="urunler.aspx.cs" Inherits="odevv.urunler" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style>
        .urunn {
            height: auto;
            width: 300px;
            margin-left: 35%;
        }

        .kategori {
            margin-top:10px;
            Height: 100px;
            Width: 240px;
            margin-left: 35%;
        }

        .btns {
            width: 50%;
            float: left;
        }

        .btns2 {
            width: 50%;
            float: right;
        }

        .kategorisil{
             Height: 100px;
            Width: 240px;
            
        }

    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Content Wrapper. Contains page content -->
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <div class="content-header">
            <div class="container-fluid">
                <div class="row mb-2">

                    <div class="col-sm-6">
                        <ol class="breadcrumb float-sm-right">
                            <li class="breadcrumb-item"><a href="#">Home</a></li>
                            <li class="breadcrumb-item active">Starter Page</li>
                        </ol>
                    </div>
                    <!-- /.col -->
                </div>
                <!-- /.row -->
            </div>
            <!-- /.container-fluid -->
        </div>
        <!-- /.content-header -->

        <script>
            function condel() {
                var onay = confirm("Silmek istediğinize emin misiniz?");
                if (onay) {
                    return true;
                }
                else { return false };
            }
        </script>
        <!-- Main content -->
        <div class="content">
            <div class="container-fluid">
                <div class="col-12">
                    <div class="card">
                        <div class="card-header">
                            <h3 class="card-title">ÜRÜNLER</h3>

                            <div class="card-tools">
                                <div class="input-group input-group-sm" style="width: 150px;">
                                    <form style="position: relative; top: 5px" class="input-group input-group-sm" action="urunler.aspx">
                                        <input type="text" name="s" class="form-control float-right" placeholder="Ara">
                                        <div class="input-group-append">
                                            <button type="submit" class="btn btn-default"><i class="fas fa-search"></i></button>
                                        </div>
                                    </form>
                                </div>
                            </div>
                        </div>
                        <form id="form1" runat="server">
                            <!-- /.card-header -->
                            <div class="card-body table-responsive p-0" style="max-height: 600px;">
                                <table class="table table-head-fixed">
                                    <thead>
                                        <tr>
                                            <th>Adı</th>
                                            <th>Ürün Açıklaması</th>
                                            <th>Stok Miktarı</th>
                                            <th>Alış Fiyatı"TL"</th>
                                            <th>Satış Fiyatı"TL"</th>
                                            <th>Düzenle</th>
                                            <th>Sil <a href="islem=sil"></a></th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <%Response.Write(tablo1);%>
                                    </tbody>
                                </table>
                            </div>
                            <!-- /.card-body -->
                    </div>
                </div>
            </div>
            <!-- /.container-fluid -->
        </div>
        <!-- /.content -->

        <div class="btns">
            <asp:Button ID="btnyni" Text="YENİ ÜRÜN EKLE" runat="server" class="btn btn-block btn-success btn-lg" OnClick="btnyni_Click" />
        </div>
        <div class="btns2">
            <asp:Button ID="btnynktgr" Text="YENİ KATEGORİ EKLE" runat="server" class="btn btn-block btn-success btn-lg" OnClick="btnynktgr_Click" />
        </div>
        <br />
        <br />
        <div class="kategori">
            <asp:TextBox ID="tbkategri" CssClass="form-control" runat="server" Width="208px" />
            <br />
            <asp:Button ID="btnkategri" Text="KATOGORİ EKLE" class="btn btn-block btn-success btn-lg" runat="server" Width="208px" OnClick="btnkategri_Click" />
            <br />

        </div>
        <div class="kategorisil">
            <asp:DropDownList ID="drpkt" CssClass="form-control" runat="server">
            </asp:DropDownList>
            <asp:Button  ID="btnsil" Text="KATEGORİ SİL" class="btn btn-block btn-danger btn-lg" runat="server" OnClick="btnsil_Click" />
        </div>
        <br />
        <div class="urunn">
            <div>
                <img src="images/<%Response.Write(a); %> " height="200px" width="200px">
                <br />
                <br />
                <asp:Label ID="lbl" Text="ÜRÜN RESMİ" runat="server" /><br />
                <asp:FileUpload ID="flup" runat="server" />
                <br />
                <br />
                <asp:Label ID="lbl1" Text="ÜRÜN ADI" runat="server" /><br />
                <asp:TextBox ID="tbadi" CssClass="form-control" runat="server" />
                <br />
                <asp:Label ID="lbl2" Text="ÜRÜN AÇIKLAMASI" runat="server" /><br />
                <asp:TextBox ID="tbaciklama" CssClass="form-control" runat="server" />
                <br />
                <asp:Label ID="lbl3" Text="STOK MİKTARI" runat="server" /><br />
                <asp:TextBox ID="tbmik" CssClass="form-control" runat="server" />
                <br />
                <asp:Label ID="llbb" Text="SATIŞ TÜRÜ" runat="server" />
                <asp:DropDownList ID="drpdvnst" CssClass="form-control" runat="server">
                    <asp:ListItem Text="KG" />
                    <asp:ListItem Text="ADET" />
                    <asp:ListItem Text="BAĞ" />
                    <asp:ListItem Text="KAVANOZ" />
                </asp:DropDownList>
                <br />
                <asp:Label ID="lbl4" Text="ALIŞ FİYATI-'TL'" runat="server" /><br />
                <asp:TextBox ID="tbalis" CssClass="form-control" runat="server" />
                <br />
                <asp:Label ID="lbl5" Text="SATIŞ FİYATI-'TL'" runat="server" /><br />
                <asp:TextBox ID="tbsat" CssClass="form-control" runat="server" />
                <br />
                <asp:Label ID="lbl6" Text="KATEGORİ" runat="server" /><br />
                <asp:DropDownList ID="tbkat" CssClass="form-control" runat="server">
                </asp:DropDownList>
                <br />
                <asp:Button runat="server" class="btn btn-block btn-success btn-lg" Text="KAYDET" ID="btnkytt" OnClick="btnkytt_Click" />
                <br />
                <asp:Button ID="btndznl" class="btn btn-block btn-info btn-lg" Text="DÜZENLEMEYİ KAYDET" runat="server" OnClick="btndznl_Click" />
            </div>
        </div>
    </div>
    <!-- /.content-wrapper -->
    </form>
</asp:Content>
