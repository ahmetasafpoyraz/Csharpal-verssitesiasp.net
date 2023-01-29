<%@ Page Title="" Language="C#" MasterPageFile="~/Homepage.Master" AutoEventWireup="true" CodeBehind="productdetails.aspx.cs" Inherits="odevv.productdetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>

   .bt{
        margin-left:50px;
        width:140px;
        height:45px;
        background-color:#000000;
        text-decoration-color:white;
        color:white;
    }
   .bt:hover{
       background-color:white;
       color:black;
   }

</style>
    <div class="product-main">
        <div class="container">
            <ol class="breadcrumb">
                <li><a href="index.html">Home</a></li>
                <li class="active">Single</li>
            </ol>
            <div class="ctnt-bar cntnt">
                <div class="content-bar">
                    <div class="single-page">
                        <!--Include the Etalage files-->
                        <link rel="stylesheet" href="css/etalage.css">
                        <script src="js/jquery.etalage.min.js"></script>
                        <!-- Include the Etalage files -->
                    <script>
                        jQuery(document).ready(function ($) {

                            $('#etalage').etalage({
                                thumb_image_width: 300,
                                thumb_image_height: 400,
                                source_image_width: 700,
                                source_image_height: 800,
                                show_hint: true,
                                click_callback: function (image_anchor, instance_id) {
                                    alert('Callback example:\nYou clicked on an image with the anchor: "' + image_anchor + '"\n(in Etalage instance: "' + instance_id + '")');
                                }
                            });
                            // This is for the dropdown list example:
                            $('.dropdownlist').change(function () {
                                etalage_show($(this).find('option:selected').attr('class'));
                            });

                        });
                        </script>
                    
                        <div class="details-left-slider">
                            <ul id="etalage" class="etalage" style="display: block; width: 314px; height: 552px;">
                            
                                <li class="etalage_thumb thumb_2 etalage_thumb_active" style="background-image: none; display: list-item; opacity: 1;">
                                    <img class="etalage_thumb_image"  src="images/<%Response.Write(resim); %>" style="display: inline; width: 300px; height: 400px; opacity: 1;">
                                    <img class="etalage_source_image"  src="images/<%Response.Write(resim); %>"
                                </li>
                                
                        </div>
                        <div class="details-left-info">
                            <h3><%Response.Write(adi); %></h3>
                            <h4>Pellentesque pretium </h4>
                            <p><%Response.Write(fiyati); %> TL</p>                          
                            <form runat="server" >
                                <p class="qty">MİKTAR</p>
                            <asp:TextBox ID="tbmik" runat="server" class="form-control input-small" Height="25px" TextMode="Number" Width="60px" /><p class="qty"><%Response.Write(st); %></p>
                                <br />
                                <br />
                            
                            <div class="btn">
                                <asp:Button ID="btnekle" CssClass="bt" Text="SEPETE EKLE" runat="server" OnClick="btnekle_Click" />
                            </div>
                         </form>
                            <div class="flower-type">
                                 <h5>ÜRÜN AÇIKLAMASI:</h5>
                            <p class="desc"><%Response.Write(aciklama); %></p>
                            </div>
                          
                        </div>
                        
                    </div>
                </div>
            </div>

            
		 
	 

        </div>
        
    </div>






</asp:Content>
