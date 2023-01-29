<%@ Page Title="" Language="C#" MasterPageFile="~/Homepage.Master" AutoEventWireup="true" CodeBehind="products.aspx.cs" Inherits="odevv.products" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .tb {
            height: 50px;
            width: 79%;
            
        }

        .bt {
            height: 50px;
            width: 18%;
            background-color:black;
            color:white;
        }
        .bt:hover{
            color:black;
            background-color:white;
        }
    </style>
    <form runat="server">
        <div class="breadcrumb" style="width: 60%; margin-left: 20%">
            <asp:TextBox ID="tbara" CssClass="tb" runat="server" />
            <asp:Button ID="btnara" Text="ara" CssClass="bt" runat="server" OnClick="btnara_Click" />
        </div>


        <div class="product-model">
            <div class="container">
                <ol class="breadcrumb">
                </ol>
                <div class="col-md-9 product-model-sec">
                    <%Response.Write(urun);%>
                </div>
                <div class="rsidebar span_1_of_left">
                    <section class="sky-form">
                        <div class="product_right">
                            <h3 class="m_2">KATEGORİLER</h3>
                            <%Response.Write(kategori); %>
                        </div>
                </div>
                <div class="clearfix"></div>

            </div>
        </div>
    </form>
</asp:Content>
