<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="odevv.admin" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Admin | Anasayfa</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Content Wrapper. Contains page content -->
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <div class="content-header">
            <div class="container-fluid">

                <!-- /.row -->
            </div>
            <!-- /.container-fluid -->
        </div>
        <!-- /.content-header -->

        <!-- Main content -->
        <div class="content">
            <div class="container-fluid">
                <div class="row">
                    <div class="col-lg-3 col-6">
                        <div class="small-box bg-info">
                            <div class="inner">
                                <h3><%Response.Write(j); %></h3>

                                <p>Ürünler</p>
                            </div>
                            <div class="icon">
                                <i class="fas fa-shopping-cart"></i>
                            </div>
                            <a href="urunler.aspx" class="small-box-footer">More info <i class="fas fa-arrow-circle-right"></i>
                            </a>
                        </div>
                    </div>
                    <div class="col-lg-3 col-6">
                        <div class="small-box bg-warning">
                            <div class="inner">
                                <h3>YENİ SİPARİŞLER= <%Response.Write(n); %></h3>
                                <h4>TOPLAM SİPARİŞ SAYISI= <%Response.Write(m); %> </h4>
                            </div>
                            <div class="icon">
                                <i class="fas fa-shopping-basket"></i>
                            </div>
                            <a href="SİPARİSdurumu.aspx?drm=yeni" class="small-box-footer">More info <i class="fas fa-arrow-circle-right"></i></a>

                        </div>

                        <!-- /.card -->
                    </div>
                    <div class="col-lg-3 col-6">
                        <div class="small-box bg-maroon">
                            <div class="inner">
                                <h3><%Response.Write(h); %></h3>

                                <p>Hazırlanan Siparişler</p>
                            </div>
                            <div class="icon">
                                <i class="fas fa-hourglass-half"></i>
                            </div>
                            <a href="SİPARİSdurumu.aspx?drm=hazırlanıyor" class="small-box-footer">More info <i class="fas fa-arrow-circle-right"></i></a>

                        </div>
                        <!-- /.card -->
                    </div>
                    <div class="col-lg-3 col-6">
                        <div class="small-box bg-lime">
                            <div class="inner">
                                <h3><%Response.Write(t); %></h3>

                                <p>Tamamlanan Siparişler</p>
                            </div>
                            <div class="icon">
                                <i class="fas fa-user-check"></i>
                            </div>
                            <a href="SİPARİSdurumu.aspx?drm=tamamlandı" class="small-box-footer">More info <i class="fas fa-arrow-circle-right"></i>
                            </a>
                        </div>
                        <!-- /.card -->
                    </div>
                    <div class="col-lg-3 col-6">
                        <div class="small-box bg-teal">
                            <div class="inner">
                                <h3><%Response.Write(p); %></h3>

                                <p>Paketlenen Siparişler</p>
                            </div>
                            <div class="icon">
                                <i class="fas fa-box"></i>
                            </div>
                            <a href="SİPARİSdurumu.aspx?drm=paketlendi" class="small-box-footer">More info <i class="fas fa-arrow-circle-right"></i>
                            </a>
                        </div>
                        <!-- /.card -->
                    </div>
                    <!-- /.col-md-3 -->
                    <div class="col-lg-3 col-6">
                        <div class="small-box bg-success">
                            <div class="inner">
                                <h3><%Response.Write(y); %></h3>

                                <p>Kargolanan Siparişler</p>
                            </div>
                            <div class="icon">
                                <i class="fas fa-truck-loading"></i>
                            </div>
                            <a href="SİPARİSdurumu.aspx?drm=yolda" class="small-box-footer">More info <i class="fas fa-arrow-circle-right"></i>
                            </a>
                        </div>
                        <!-- /.card -->
                    </div>
                    <div class="col-lg-3 col-6">
                        <div class="small-box bg-orange">
                            <div class="inner">
                                <h3><%Response.Write(i);%></h3>

                                <p>Üyeler</p>
                            </div>
                            <div class="icon">
                                <i class="fas fa-users"></i>
                            </div>
                            <a href="uyeler.aspx" class="small-box-footer">More info <i class="fas fa-arrow-circle-right"></i>
                            </a>
                        </div>
                        <!-- /.card -->
                    </div>
                    <div class="col-lg-3 col-6">
                        <div class="small-box bg-fuchsia">

                            <div class="inner">
                                <h3><%Response.Write(k); %></h3>
                                <%--<h4><%Response.Write(l); %></h4>--%>
                                <p>DUYURULAR </p>
                            </div>
                            <div class="icon">
                                <i class="fas fa-bullhorn"></i>
                            </div>
                            <a href="ck.aspx" class="small-box-footer">More info <i class="fas fa-arrow-circle-right"></i>
                            </a>
                        </div>
                    </div>
                </div>
                <!-- /.row -->
            </div>
            <!-- /.container-fluid -->
        </div>
        <!-- /.content -->
        <strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <span class="auto-style1">ONLINE ZİYARETÇİ SAYISI:</span></strong><span><%=Application["online"]%></span></>

        <%--    <%Response.Write("Toplam ziyaretci sayısı : " + Application["toplamziyaretci"]); %>  
           <%Response.Write(" <br/>"); %>   
            <% Response.Write("<br/> Online ziyaretci sayısı : " + Application["online"]); %>--%>
                       
       <strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <span class="auto-style1">TOPLAM ZİYARETÇİ SAYISI:</span></strong> <span><%Response.Write(ip); %></span></>
       
    </div>
    <!-- /.content-wrapper -->


</asp:Content>
