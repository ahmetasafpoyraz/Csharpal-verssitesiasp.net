<%@ Page Title="" Language="C#" MasterPageFile="~/Homepage.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="odevv.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="login">
	 <div class="container">
			<ol class="breadcrumb">
		 </ol>
		 <h2>GİRİŞ YAP</h2>
		 <div class="col-md-6 log">			 
				 
				 <form runat="server" >
					 <h5>*E-MAİL:</h5>	
                     <asp:TextBox ID="tbmail" runat="server" /> 
					 <h5>ŞİFRE:</h5>
				    <asp:TextBox ID="tbsf" runat="server" TextMode="Password" /> 				
                     <asp:Button ID="btngrs" Text="GİRİŞ YAP" type="submit" value="Login" runat="server" OnClick="btngrs_Click" />
					  <a href="#">Forgot Password ?</a>
				 </form>				 
		 </div>
		  <div class="col-md-6 login-right">
			  	<h3>YENİ KAYIT</h3>
				<p>By creating an account with our store, you will be able to move through the checkout process faster, store multiple shipping addresses, view and track your orders in your account and more.</p>
				<a class="acount-btn" href="registration.aspx">YENİ BİR HESAP OLUŞTUR</a>
		 </div>
		 <div class="clearfix"></div>		 
		 
	 </div>
</div>
</asp:Content>
