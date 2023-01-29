<%@ Page Title="" Language="C#" MasterPageFile="~/Homepage.Master" AutoEventWireup="true" CodeBehind="sepet.aspx.cs" Inherits="odevv.sepet" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="cart">
	 <div class="container">
			 <ol class="breadcrumb">
		 </ol>
          <script>
              function condel() {
                  var onay = confirm("ÜRÜNÜ SİLMEK İSTEDİĞİNİZE EMİNMİSİNİZ?");
                  if (onay) {
                      return true;
                  }
                  else { return false };
              }
        </script>
		 <div class="col-md-9 cart-items">
			 <h2> SEPETİM (<%Response.Write(t); %>)</h2>
			<%Response.Write(spt); %>	
			
		 </div>
		 
		 <div class="col-md-3 cart-total">
			 <a class="continue" href="#">Continue to basket</a>
			 <div class="price-details">
				 <h3>Price Details</h3>
				 <span>Total</span>
				 <span class="total">350.00</span>
				 <span>Discount</span>
				 <span class="total">---</span>
				 <span>Delivery Charges</span>
				 <span class="total">100.00</span>
				 <div class="clearfix"></div>				 
			 </div>	
			 <h4 class="last-price">TOTAL</h4>
			 <span class="total final"><%Response.Write(total); %></span>
			 <div class="clearfix"></div>
			 <a class="order" href="#">Place Order</a>
			 <div class="total-item">
				 <h3>OPTIONS</h3>
				 <h4>COUPONS</h4>
				 <a class="cpns" href="#">Apply Coupons</a>
				 <p><a href="#">Log In</a> to use accounts - linked coupons</p>
			 </div>
			</div>
	 </div>
</div>
</asp:Content>
