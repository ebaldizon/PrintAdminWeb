<%@ Page Title="" Language="C#" MasterPageFile="~/App/Home.Master" AutoEventWireup="true" CodeBehind="Facturacion.aspx.cs" Inherits="PrintAdminWebApp.App.Facturacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="container">
        <h3>Facturación</h3>
        <br />
        <div class="row">
            <div class="col-md-6">
                    <div class="form-group">
                        <label class="text-roboto-black">Número:</label>
                        <asp:TextBox class="form-control text-roboto-black" ID="txtNumber" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label class="text-roboto-black">Fecha:</label>
                        <asp:TextBox class="form-control text-roboto-black" ID="txtDate" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label class="text-roboto-black">Cliente:</label>
                        <asp:TextBox class="form-control text-roboto-black" ID="txtCustomerName" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label class="text-roboto-black">Valor:</label>
                        <asp:TextBox class="form-control text-roboto-black" ID="txtPrice" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label class="text-roboto-black">Adelanto:</label>
                        <asp:TextBox class="form-control text-roboto-black" ID="txtPayment" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label class="text-roboto-black">Saldo:</label>
                        <asp:TextBox class="form-control text-roboto-black" ID="txtBalance" runat="server"></asp:TextBox>
                    </div>                                
            </div> 
        </div>

        <br />

        <div class="row">
            <div class="col-md-12">
                <asp:Button type="button" class="btn btn-primary" ID="btnSave" runat="server" Text="Guardar" OnClick="btnSave_Click"/>
                <asp:Button type="button" class="btn btn-primary" ID="btnDelete" runat="server" Text="Borrar" OnClick="btnDelete_Click"/>  
            </div>
        </div>
        <br />
        <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
        <br /><br /><br />
        <div class="row">
            <div class="col-md-6">
                <div class="form-group">
                        <label class="text-roboto-black">Cédula:</label>
                        <asp:TextBox class="form-control text-roboto-black" ID="txtId" runat="server"></asp:TextBox>
                        <br />
                        <asp:Button type="button" class="btn btn-primary" ID="btnSearchForID" runat="server" Text="Buscar" OnClick="btnSearchForID_Click"/>  
                        <br />
                        <asp:Label ID="lblMessage2" runat="server" Text=""></asp:Label>
                </div>   
            </div>
        </div>
        <asp:GridView 
            ID="gvInvoices" 
            runat="server"
            OnRowDataBound="gvInvoices_RowDataBound" 
            OnSelectedIndexChanged = "gvInvoices_SelectedIndexChanged"
            autogeneratecolumns="False"
            selectedindex="1"

            CssClass="table table-striped table-responsive">

            <EmptyDataRowStyle forecolor="Red" CssClass="table table-striped" />
            <emptydatatemplate>
            ¡No hay clientes con los datos seleccionados!  
            </emptydatatemplate>

              	<Columns>
                    <asp:ButtonField Text="Detalle" CommandName="Select" ControlStyle-CssClass="btn btn-primary"/>
					<asp:BoundField DataField="number" HeaderText="Número" HTMLEncode="False" />
                    <asp:BoundField DataField="dateOrder" HeaderText="Fecha" HTMLEncode="false"  DataFormatString="{0:d}" />
					<asp:BoundField DataField="customerID" HeaderText="Cédula" HTMLEncode="False" />
					<asp:BoundField DataField="name" HeaderText="Nombre" HTMLEncode="False" />
					<asp:BoundField DataField="workType" HeaderText="Clase de Trabajo" HTMLEncode="False" />
					<asp:BoundField DataField="initialNum" HeaderText="Del número" HTMLEncode="False" />
                    <asp:BoundField DataField="endNum" HeaderText="Al número" HTMLEncode="False" />
                    <asp:BoundField DataField="price" HeaderText="Valor" HTMLEncode="False" />
                    <asp:BoundField DataField="payment" HeaderText="Adelanto" HTMLEncode="False" />
                    <asp:BoundField DataField="balance" HeaderText="Saldo" HTMLEncode="False" />
				</Columns>

        </asp:GridView>

                    

    </div>



</asp:Content>
