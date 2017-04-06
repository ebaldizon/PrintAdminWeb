<%@ Page Title="" Language="C#" MasterPageFile="~/App/Default.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PrintAdminWebApp.App.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderDefaultMaster" runat="server">
    
    <div class="container vertical-center">
        
        <div class="row">
            <div class="col-md-3"></div>
            <div class="col-md-6">
                <img class="img-responsive" src="Images/logotipo.jpg"/>
                <div class="panel panel-default">
                  <div class="panel-body background-light-green">
                          <div class="form-group">
                            <label class="text-roboto-black" for="email">Usuario:</label>
                            <asp:TextBox class="form-control text-roboto-black" ID="txtUser" runat="server"></asp:TextBox>
                          </div>
                          <div class="form-group">
                            <label class="text-roboto-black" for="pwd">Contrase&ntilde;a:</label>
                            <asp:TextBox type="password" class="form-control text-roboto-black" ID="txtPassword" runat="server"></asp:TextBox>
                          </div>
                          <asp:Button type="button" class="btn btn-primary text-roboto-white" ID="btnLogin" runat="server" Text="Iniciar Sesión" OnClick="btnLogin_Click" />
                          <asp:Button type="button" class="btn btn-primary text-roboto-white" ID="btnRecoverPassword" runat="server" Text="Recuperar Contraseña" OnClick="btnLogin_Click" />
                  </div>
                </div>
                <asp:Label class="text-roboto" ID="lblMsg" runat="server" Text=""></asp:Label>
            </div>
            <div class="col-md-3">
            </div>
            
        </div>
    </div>
    
</asp:Content>

