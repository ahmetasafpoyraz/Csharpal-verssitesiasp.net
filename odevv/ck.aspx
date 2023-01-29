<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" ValidateRequest="false" CodeBehind="ck.aspx.cs" Inherits="odevv.ck" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">




    <script type="text/javascript" src="../ckfinder/ckfinder.js"></script>
    <script type="text/javascript" src="../ckeditor/ckeditor.js"></script>
    <script type="text/javascript">
        window.onload = function () {
            var editor = CKEDITOR.replace('<%=tbicerik.ClientID%>');
            CKFinder.setupCKEditor(editor, '../ckfinder');

        };
    </script>
    <link href="admin_sekil.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            width: 88%;
        }

        .auto-style2 {
            width: 376px;
        }

        .auto-style3 {
            width: 378px;
        }

        .auto-style4 {
            width: 100%;
        }

        .divdiv {
            border: 2px solid #ff0000;
        }

        .tba {
            margin-top: 2px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="content-wrapper">

        <!-- Content Header (Page header) -->
        <div class="content-header">
            <div class="container-fluid">
                <div class="row mb-2">
                    <div class="col-sm-6">
                    </div>

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
                            <h3 class="card-title">KAYITLI DUYURULAR </h3>

                            <div class="card-tools">
                                <div class="input-group input-group-sm" style="width: 150px;">
                                    

                                    <div class="input-group-append">
                                       
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!-- /.card-header -->
                        <div class="card-body table-responsive p-0" style="max-height: 600px;">
                            <table class="table table-head-fixed">
                                <thead>
                                    <tr>
                                        <th>Duyuru Başlığı</th>
                                        <th>Duyuru İçeriği</th>
                                        <th>Başlangıç Tarihi</th>
                                        <th>Bitiş Tarihi</th>
                                        <th>Yayınlanma Durumu</th>
                                        <th>Düzenle</th>
                                        <th>Sil</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <%Response.Write(tablo2); %>
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

        <br />
        <table class="auto-style4">
            <tr>
                <td>&nbsp;&nbsp;&nbsp;&nbsp;
                    <form runat="server">

                        <asp:Button ID="bbtn" class="btn btn-block btn-info btn-lg" runat="server" OnClick="Button2_Click" Text="Yeni Duyuru Oluştur" />



                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button runat="server" class="btn btn-block btn-success btn-lg" OnClick="Button1_Click" Text="KAYDET" ID="btnkyt" Visible="False" />

                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                     <asp:Button ID="btndznl" class="btn btn-block btn-primary btn-lg" runat="server" Text="Düzenlemeyi Kaydet" Visible="False" OnClick="btndznl_Click" />
                  
                </td>
            </tr>
        </table>
        <br />
        <div class="divdiv">

            <span>&nbsp;<asp:Label ID="lbl1" runat="server" Text="DUYURU BAŞLIĞI :" Visible="False"></asp:Label>
            </span>
            <link href="/admiin_sekil.css" rel="stylesheet" />
            <asp:TextBox ID="tbbaslik" CssClass="tba" runat="server" placeholder="Duyuru Başlığı" Visible="False" />
            <br />
            <br />
            <asp:Label ID="lbl2" runat="server" Text="DUYURU İÇERİĞİ :" Visible="False"></asp:Label>
            <br />
            <asp:TextBox ID="tbicerik" TextMode="MultiLine" runat="server" Visible="False" />
            <br />
            <br />
            <br />
            <div class="tarih">
                <table class="auto-style1">
                    <tr>
                        <td class="auto-style2">&nbsp;<asp:Label ID="lbl3" runat="server" Text="BAŞLANGIÇ TARİHİ :" Visible="False"></asp:Label>
                            &nbsp;<asp:Calendar ID="bastar" runat="server" BackColor="#FFFFCC" BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="200px" ShowGridLines="True" Width="220px" Visible="False">
                                <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
                                <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                                <OtherMonthDayStyle ForeColor="#CC9966" />
                                <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
                                <SelectorStyle BackColor="#FFCC66" />
                                <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
                                <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
                            </asp:Calendar>
                            <br />
                        </td>
                        <td class="auto-style3">
                            <asp:Label ID="lbl4" runat="server" Text="BİTİŞ TARİHİ :" Visible="False"></asp:Label>
                            &nbsp;<asp:Calendar ID="bittar" runat="server" BackColor="#FFFFCC" BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="200px" ShowGridLines="True" Width="220px" Visible="False">
                                <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
                                <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                                <OtherMonthDayStyle ForeColor="#CC9966" />
                                <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
                                <SelectorStyle BackColor="#FFCC66" />
                                <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
                                <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
                            </asp:Calendar>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:CheckBox ID="cbyayinlansin" runat="server" Text="YAYINLANSIN" Visible="False" />
                            &nbsp;&nbsp;&nbsp;&nbsp;<br />
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
            </div>
            <br />
        </div>
    </div>
      </form>
</asp:Content>
