<%@ Page Title="" Language="C#" MasterPageFile="~/App/Home.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="PrintAdminWebApp.App.Usuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
    
     
    <div class="container">
        <h3>Usuarios</h3>
        <br />
        <div class="row">
            <div class="col-md-6">
                    <div class="form-group">
                        <label class="text-roboto-black" for="id">Cédula:</label>
                        <asp:TextBox class="form-control text-roboto-black" ID="txtId" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label class="text-roboto-black" for="name">Nombre:</label>
                        <asp:TextBox class="form-control text-roboto-black" ID="txtName" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label class="text-roboto-black" for="lastname">Apellido:</label>
                        <asp:TextBox class="form-control text-roboto-black" ID="txtLastname" runat="server"></asp:TextBox>
                    </div>                                
            </div>
            <div class="col-md-6">
                    <div class="form-group">
                        <label class="text-roboto-black" for="email">Email:</label>
                        <asp:TextBox class="form-control text-roboto-black" ID="txtEmail" runat="server"></asp:TextBox>
                    </div> 
                    <div class="form-group">
                        <label class="text-roboto-black" for="pwd">Contrase&ntilde;a:</label>
                        <asp:TextBox type="password" class="form-control text-roboto-black" ID="txtPassword" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label class="text-roboto-black" for="pwd">Confirmar Contrase&ntilde;a:</label>
                        <asp:TextBox type="password" class="form-control text-roboto-black" ID="txtxRepeatPwd" runat="server"></asp:TextBox>
                    </div>                                                     
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-12">
                <asp:Button type="button" class="btn btn-primary" ID="btnCreate" runat="server" Text="Agregar" OnClick="btnCreate_Click"/>
                <asp:Button type="button" class="btn btn-primary" ID="btnRead" runat="server" Text="Buscar" OnClick="btnRead_Click"/>
                <asp:Button type="button" class="btn btn-primary" ID="btnUpdate" runat="server" Text="Editar" OnClick="btnUpdate_Click"/>
                <asp:Button type="button" class="btn btn-primary" ID="btnDelete" runat="server" Text="Borrar" OnClick="btnDelete_Click"/>  
            </div>
        </div>
        <br/>
        <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
        <br /><br /><br />

        <asp:GridView 
            ID="gvUsers" 
            runat="server"
            OnRowDataBound="gvUsers_RowDataBound" 
            OnSelectedIndexChanged = "gvUsers_SelectedIndexChanged"
            autogeneratecolumns="False"
            selectedindex="1"

            CssClass="table table-striped table-responsive">

            <EmptyDataRowStyle forecolor="Red" CssClass="table table-striped" />
            <emptydatatemplate>
            ¡No hay clientes con los datos seleccionados!  
            </emptydatatemplate>

              	<Columns>
                     <asp:ButtonField Text="Detalle" CommandName="Select" ControlStyle-CssClass="btn btn-primary"/>
					<asp:BoundField DataField="id" HeaderText="Cédula" HTMLEncode="False" />
					<asp:BoundField DataField="name" HeaderText="Nombre" HTMLEncode="False" />
					<asp:BoundField DataField="lastname" HeaderText="Apellido" HTMLEncode="False" />
					<asp:BoundField DataField="email" HeaderText="Correo" HTMLEncode="False" />
					<asp:BoundField DataField="password" HeaderText="Contraseña" HTMLEncode="False" />
                    
				</Columns>

        </asp:GridView>
       

    </div>
    
                           

    
</asp:Content>
