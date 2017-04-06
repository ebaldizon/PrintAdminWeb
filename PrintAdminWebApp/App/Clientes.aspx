<%@ Page Title="" Language="C#" MasterPageFile="~/App/Home.Master" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="PrintAdminWebApp.App.Clientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="container">
        <h3>Clientes</h3>
        <br />
        <div class="row">
            <div class="col-md-6">
                    <div class="form-group">
                        <label class="text-roboto-black">Cédula:</label>
                        <asp:TextBox class="form-control text-roboto-black" ID="txtId" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label class="text-roboto-black">Nombre:</label>
                        <asp:TextBox class="form-control text-roboto-black" ID="txtName" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label class="text-roboto-black">Télefono:</label>
                        <asp:TextBox class="form-control text-roboto-black" ID="txtTelephone1" runat="server"></asp:TextBox>
                    </div>                                
            </div>
            <div class="col-md-6">
                    <div class="form-group">
                        <label class="text-roboto-black">Celular:</label>
                        <asp:TextBox class="form-control text-roboto-black" ID="txtTelephone2" runat="server"></asp:TextBox>
                    </div> 
                    <div class="form-group">
                        <label class="text-roboto-black">Email:</label>
                        <asp:TextBox class="form-control text-roboto-black" ID="txtEmail" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label class="text-roboto-black">Dirección:</label>
                        <asp:TextBox class="form-control text-roboto-black" ID="txtAddress" runat="server"></asp:TextBox>
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
        <br />
        <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
        <br /><br /><br />

        <asp:GridView 
            ID="gvCustomers" 
            runat="server"
            OnRowDataBound="gvCustomers_RowDataBound" 
            OnSelectedIndexChanged = "gvCustomers_SelectedIndexChanged"
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
					<asp:BoundField DataField="telephone1" HeaderText="Télefono" HTMLEncode="False" />
					<asp:BoundField DataField="telephone2" HeaderText="Celular" HTMLEncode="False" />
					<asp:BoundField DataField="email" HeaderText="Correo" HTMLEncode="False" />
					<asp:BoundField DataField="address" HeaderText="Dirección" HTMLEncode="False" />
                    
				</Columns>

        </asp:GridView>

                    

    </div>


</asp:Content>
