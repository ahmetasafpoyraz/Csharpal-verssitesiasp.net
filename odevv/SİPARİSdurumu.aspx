<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="SİPARİSdurumu.aspx.cs" Inherits="odevv.urundurumu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style>
        .durum {
            height: auto;
            width: 300px;
            margin-left: 35%;
            border: 3px solid #c26cef;
            background-color: white;
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
                        <h1 class="m-0 text-dark">Starter Page</h1>
                    </div>
                    <!-- /.col -->
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

        <!-- Main content -->
        <div class="content">
            <div class="container-fluid">
                <div class="col-12">
                    <div class="card">
                        <div class="card-header">
                            <h3 class="card-title"><%Response.Write(bslk); %> SİPARİŞLER</h3>

                            <div class="card-tools">
                                <div class="input-group input-group-sm" style="width: 150px;">
                                    <form style="position: relative; top: 5px" class="input-group input-group-sm" action="SİPARİSdurumu.aspx">
                                        <input type="text" name="s" class="form-control float-right" placeholder="SİPARİŞ NO">
                                        <% if (Request.QueryString["drm"] != null)
                                           { %>
                                            <input type="hidden" name="drm" value="<% Response.Write(Request.QueryString["drm"]); %>" />
                                        <% } %>
                                        <div class="input-group-append">
                                            <button type="submit" class="btn btn-default"><i class="fas fa-search"></i></button>
                                        </div>
                                    </form>
                                </div>
                            </div>
                        </div>
                        <!-- /.card-header -->
                        <form runat="server">
                        <div class="card-body table-responsive p-0" style="max-height: 600px;">
                            <table class="table table-head-fixed">
                                <thead>
                                    <tr>
                                        <th>Sipariş No</th>
                                        <th>Siparişi Veren </th>
                                        <th>İçerik</th>
                                        <th>Sipariş Adresi</th>
                                        <th>Verilme Tarihi</th>
                                        <th>Durumu</th>
                                        <th>Güncelle</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <%Response.Write(tablodrm); %>
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
        
            <div class="durum">
                <asp:Label ID="bl" Text="SİPARİŞ NO " runat="server" Font-Size="X-Large" />
                <br />
                <asp:Label ID="lb" Text="Bir Sipariş Seçiniz" runat="server" />
                <br />
                <br />
                <asp:Label ID="bl1" Text="SİPARİŞİ VEREN" runat="server" Font-Size="X-Large" />
                <br />
                <asp:Label ID="L1" Text="Bir Sipariş Seçiniz" runat="server" />
                <br />
                <br />
                <asp:Label ID="bl2" Text="SİPARİŞ İÇERİĞİ" runat="server" Font-Size="X-Large" />
                <br />
                <asp:Label ID="L2" Text="Bir Sipariş Seçiniz" runat="server" />
                <br />
                <br />
                <asp:Label ID="Label1" Text="SİPARİŞ ADRESİ" runat="server" Font-Size="X-Large" />
                <br />
                <asp:Label ID="Label2" Text="Bir Sipariş Seçiniz" runat="server" />
                <br />
                <br />
                <asp:Label ID="bl3" Text="SİPARİŞ VERİLME TARİHİ" runat="server" Font-Size="X-Large" />
                <br />
                <asp:Label ID="L3" Text="Bir Sipariş Seçiniz" runat="server" />
                <br />
                <br />
                <asp:Label ID="bl4" Text="SİPARİŞ DURUMU" runat="server" Font-Size="X-Large" />
                <br />
                <asp:Label ID="L4" Text="Bir Sipariş Seçiniz" runat="server" />
                <br />
                <br />
                <asp:Button ID="pktl" class="btn btn-block btn-success btn-lg" Text="HAZIRLA" runat="server" OnClick="Unnamed1_Click" />
                <asp:Button ID="pktll" Text="PAKETLE" class="btn btn-block btn-success btn-lg" runat="server" OnClick="pktll_Click" />
                <asp:Button ID="krg" Text="KARGOLA" class="btn btn-block btn-success btn-lg" runat="server" OnClick="krg_Click" />
                <asp:Button ID="tmml" Text="TAMAMLA" class="btn btn-block btn-success btn-lg" runat="server" OnClick="tmml_Click" />
            </div>
        </form>
    </div>
    <!-- /.content-wrapper -->
</asp:Content>
