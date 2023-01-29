<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="uyeler.aspx.cs" Inherits="odevv.uyeler" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Admin | Üyeler</title>
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
        <form runat="server">
       <div class="content">
            <div class="container-fluid">
                <div class="col-12">
                    <div class="card">
                        <div class="card-header">
                            <h3 class="card-title">ÜYELER</h3>

                            <div class="card-tools">
                                <div class="input-group input-group-sm" style="width: 150px;">
                                    <form style="position: relative; top: 5px" class="input-group input-group-sm" action="uyeler.aspx">
                                        <input type="text" name="s" class="form-control float-right" placeholder="Ara">
                                        <div class="input-group-append">
                                            <button type="submit" class="btn btn-default"><i class="fas fa-search"></i></button>
                                        </div>
                                    </form>
                                </div>
                            </div>
                        </div>
                        <!-- /.card-header -->
                        <div class="card-body table-responsive p-0" style="max-height: 600px;">
                            <table class="table table-head-fixed">
                                <thead>
                                    <tr>
                                        <th>Adı</th>
                                        <th>Soyadı</th>
                                        <th>Numara</th>
                                        <th>Email</th>
                                        <th>İl</th>
                                        <th>İlçe</th>
                                        <th>Açık Adres</th>
                                        <th>Yetki</th>
                                        <th>Düzenle</th>
                                        <th>Sil <a href="islem=sil"></a> </th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <%Response.Write(tablo);%>
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
    </div>
    <!-- /.content-wrapper -->
    </form>
</asp:Content>
