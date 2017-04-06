<%@ Page Title="" Language="C#" MasterPageFile="~/App/Home.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="PrintAdminWebApp.App.Home1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="container vertical-center">

        <div class="row">
          <div class="col-sm-6 col-md-4">
            <div class="thumbnail">
              <img class="img-responsive" src="Images/ordenes.png" alt="Ordenes-Pedido">
              <div class="caption">
                <h3 class="text-center">Ordenes de perdidos</h3>
                <p></p>
                <p class="text-center"><a href="Ordenes.aspx" class="btn btn-primary" role="button">Ingresar</a> <a href="#" class="btn btn-default" role="button">Información</a></p>
              </div>
            </div>
          </div>

          <div class="col-sm-6 col-md-4">
            <div class="thumbnail">
              <img src="Images/clientes.PNG" alt="Clientes"/>
              <div class="caption">
                <h3 class="text-center">Clientes</h3>
                <p></p>
                <p class="text-center"><a href="Clientes.aspx" class="btn btn-primary" role="button">Ingresar</a> <a href="#" class="btn btn-default" role="button">Información</a></p>
              </div>
            </div>
          </div>

          <div class="col-sm-6 col-md-4">
            <div class="thumbnail">
              <img src="Images/facturacion.PNG" alt="Facturas"/>
              <div class="caption">
                <h3 class="text-center">Facturas</h3>
                <p></p>
                <p class="text-center"><a href="Facturacion.aspx" class="btn btn-primary" role="button">Ingresar</a> <a href="#" class="btn btn-default" role="button">Información</a></p>
              </div>
            </div>
          </div>
        </div> 

        <div class="row">
          <div class="col-sm-6 col-md-4">
            <div class="thumbnail">
              <img src="Images/usuarios.PNG" alt="Usuarios"/>
              <div class="caption">
                <h3 class="text-center">Usuarios</h3>
                <p></p>
                <p class="text-center"><a href="Usuarios.aspx" class="btn btn-primary" role="button">Ingresar</a> <a href="#" class="btn btn-default" role="button">Información</a></p>
              </div>
            </div>
          </div>

          <div class="col-sm-6 col-md-4">
            <div class="thumbnail">
              <img src="Images/ayuda.PNG" alt="Ayuda"/>
              <div class="caption">
                <h3 class="text-center">Ayuda</h3>
                <p></p>
                <p class="text-center"><a href="Ayuda.aspx" class="btn btn-primary" role="button">Ingresar</a> <a href="#" class="btn btn-default" role="button">Información</a></p>
              </div>
            </div>
          </div>
        </div>
    </div>
</asp:Content>


