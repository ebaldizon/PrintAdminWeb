<%@ Page Title="" Language="C#" MasterPageFile="~/App/Default.Master" AutoEventWireup="true" CodeBehind="Recuperar.aspx.cs" Inherits="PrintAdminWebApp.App.Recuperar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderDefaultMaster" runat="server">

    <div class="container vertical-center">
        <div class="row">
            <div class="col-md-6">
                <div class="form-group">
                    <h3>Te enviaremos una nueva clave temporal al correo electrónico asociado a la cuenta</h3>
                    <br />
                </div>
            
                <div class="form-group">
                    <label class="text-roboto-black">Cédula:</label>
                    <asp:TextBox class="form-control text-roboto-black" ID="txtCustomerID" runat="server"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label class="text-roboto-black">Email:</label>
                    <asp:TextBox class="form-control text-roboto-black" ID="txtEmail" runat="server"></asp:TextBox>
                </div>      
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <asp:Button type="button" class="btn btn-primary" ID="btnRecoverPassword" runat="server" Text="Enviar" OnClick="btnRecoverPassword_Click"/>
            </div>
        </div>
        <br />
        <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>
