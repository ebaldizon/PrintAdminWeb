<%@ Page Title="" Language="C#" MasterPageFile="~/App/Home.Master" AutoEventWireup="true" CodeBehind="Ordenes.aspx.cs" Inherits="PrintAdminWebApp.App.Ordenes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <h3>Ordenes</h3>
        <br />
        <div class="row">
            <div class="col-md-3">
                    <div class="form-group">
                        <label class="text-roboto-black">Orden #:</label>
                        <asp:TextBox class="form-control text-roboto-black" ID="txtNumberOrder" runat="server"></asp:TextBox>
                    </div>                    
            </div>
            <div class="col-md-3">
                    <div class="form-group">
                        <label class="text-roboto-black">Fecha:</label>
                        <asp:TextBox class="form-control text-roboto-black" ID="txtDateOrder" runat="server"></asp:TextBox>
                    </div>                    
            </div>
            <div class="col-md-3">
                    <div class="form-group">
                        <label class="text-roboto-black" for="email">Cédula:</label>
                        <asp:TextBox class="form-control text-roboto-black" ID="txtCustomerID" runat="server"></asp:TextBox>
                    </div>                    
            </div>
            <div class="col-md-3">
                    <div class="form-group">
                        <label class="text-roboto-black">Nombre:</label>
                        <asp:TextBox class="form-control text-roboto-black" ID="txtCustomerName" runat="server"></asp:TextBox>
                    </div>                    
            </div>
        </div>

        <div class="row">
            <div class="col-md-3">
                    <div class="form-group">
                        <label class="text-roboto-black">Fecha de Entrega:</label>
                        <asp:TextBox class="form-control text-roboto-black" ID="txtDeliveryDate" runat="server"></asp:TextBox>
                    </div>                    
            </div>
            <div class="col-md-3">
                    <div class="form-group">
                        <label class="text-roboto-black">Entregado por:</label>
                        <asp:TextBox class="form-control text-roboto-black" ID="txtDeliveredBy" runat="server"></asp:TextBox>
                    </div>                    
            </div>
        </div>

        <div class="row">
            <div class="col-md-3">
                <div class="form-group">
                        <label class="text-roboto-black">Plancha:&nbsp;</label><asp:CheckBox class="text-roboto-black" ID="chkIron" runat="server" />
                </div>      
            </div>
            <div class="col-md-3">
                <div class="form-group">
                        <label class="text-roboto-black">Papel:&nbsp;</label><asp:CheckBox class="text-roboto-black" ID="chkPaper" runat="server" />
                </div>      
            </div>
            <div class="col-md-3">
                <div class="form-group">
                    <label class="text-roboto-black">Clase de Trabajo:</label>
                    <asp:TextBox class="form-control" id="txtWorkType" TextMode="multiline" Columns="50" Rows="3" runat="server" />
                </div>      
            </div>
            <div class="col-md-3">
                <div class="form-group">
                    <label class="text-roboto-black">Computadora:</label>
                    <asp:TextBox class="form-control" id="txtComputer" TextMode="multiline" Columns="50" Rows="3" runat="server" />
                </div>      
            </div>
        </div>


        <div class="row">
            <div class="col-md-2">
                    <div class="form-group">
                        <label class="text-roboto-black">1:</label>
                        <asp:TextBox class="form-control text-roboto-black" ID="txtTrait1" runat="server"></asp:TextBox>
                    </div>                    
            </div>
            <div class="col-md-2">
                    <div class="form-group">
                        <label class="text-roboto-black">2:</label>
                        <asp:TextBox class="form-control text-roboto-black" ID="txtTrait2" runat="server"></asp:TextBox>
                    </div>                    
            </div>
            <div class="col-md-2">
                    <div class="form-group">
                        <label class="text-roboto-black">3:</label>
                        <asp:TextBox class="form-control text-roboto-black" ID="txtTrait3" runat="server"></asp:TextBox>
                    </div>                    
            </div>
            <div class="col-md-2">
                    <div class="form-group">
                        <label class="text-roboto-black">4:</label>
                        <asp:TextBox class="form-control text-roboto-black" ID="txtTrait4" runat="server"></asp:TextBox>
                    </div>                    
            </div>
            <div class="col-md-2">
                    <div class="form-group">
                        <label class="text-roboto-black">5:</label>
                        <asp:TextBox class="form-control text-roboto-black" ID="txtTrait5" runat="server"></asp:TextBox>
                    </div>                    
            </div>
            <div class="col-md-2">
                    <div class="form-group">
                        <label class="text-roboto-black">6:</label>
                        <asp:TextBox class="form-control text-roboto-black" ID="txtTrait6" runat="server"></asp:TextBox>
                    </div>                    
            </div>
        </div>

        <div class="row">
            <div class="col-md-3">
                    <div class="form-group">
                        <label class="text-roboto-black">Cantidad:</label>
                        <asp:TextBox class="form-control text-roboto-black" ID="txtQuantity" runat="server"></asp:TextBox>
                    </div>                    
            </div>
            <div class="col-md-3">
                    <div class="form-group">
                        <label class="text-roboto-black">Tamaño:</label>
                        <asp:TextBox class="form-control text-roboto-black" ID="txtSize" runat="server"></asp:TextBox>
                    </div>                    
            </div>
            <div class="col-md-3">
                    <div class="form-group">
                        <label class="text-roboto-black">Tinta:</label>
                        <asp:TextBox class="form-control text-roboto-black" ID="txtInk" runat="server"></asp:TextBox>
                    </div>                    
            </div>
            <div class="col-md-3">
                    <div class="form-group">
                        <label class="text-roboto-black">Pliegos:</label>
                        <asp:TextBox class="form-control text-roboto-black" ID="txtSheets" runat="server"></asp:TextBox>
                    </div>                    
            </div>
        </div>

        <div class="row">
            <div class="col-md-3">
                    <div class="form-group">

                        <label class="text-roboto-black">Encolado:&nbsp;</label><asp:CheckBox class="text-roboto-black" ID="chkGlued" runat="server" />
                    </div>                    
            </div>
            <div class="col-md-3">
                    <div class="form-group">
                        <label class="text-roboto-black">Perforado:&nbsp;</label><asp:CheckBox class="text-roboto-black" ID="chkPerforated" runat="server" />
                    </div>                    
            </div>
            <div class="col-md-3">
                    <div class="form-group">
                        <label class="text-roboto-black">Cambios:&nbsp;</label><asp:CheckBox class="text-roboto-black" ID="chkChanges" runat="server" />
                    </div>                    
            </div>
            <div class="col-md-3">
                    <div class="form-group">
                        <label class="text-roboto-black">Huecos:&nbsp;</label><asp:CheckBox class="text-roboto-black" ID="chkHoles" runat="server" />
                    </div>                    
            </div>
        </div>

        <div class="row">
            <div class="col-md-3">
                    <div class="form-group">
                        <label class="text-roboto-black">Del número:</label>
                        <asp:TextBox class="form-control text-roboto-black" ID="txtInitialNum" runat="server"></asp:TextBox>
                    </div>                    
            </div>
            <div class="col-md-3">
                    <div class="form-group">
                        <label class="text-roboto-black">Al número:</label>
                        <asp:TextBox class="form-control text-roboto-black" ID="txtEndNum" runat="server"></asp:TextBox>
                    </div>                    
            </div>
        </div>

        <div class="row">
            <div class="col-md-6">
                    <div class="form-group">
                        <label class="text-roboto-black">Observaciones:</label>
                        <asp:TextBox class="form-control" id="txtObservations" TextMode="multiline" Columns="50" Rows="3" runat="server" />
                    </div>                    
            </div>
            <div class="col-md-6">
                    <div class="form-group">
                        <br /><br />
                        <asp:TextBox class="form-control text-roboto-black" ID="txtFileName" runat="server"></asp:TextBox><br />
                        <asp:FileUpload ID="fuDesign" runat="server" />
                    </div>                    
            </div>
        </div>

        <div class="row">
            <div class="col-md-4">
                    <div class="form-group">
                        <label class="text-roboto-black">Valor:</label>
                        <asp:TextBox class="form-control text-roboto-black" ID="txtPrice" runat="server"></asp:TextBox>
                    </div>                    
            </div>
            <div class="col-md-4">
                    <div class="form-group">
                        <label class="text-roboto-black">Adelanto:</label>
                        <asp:TextBox class="form-control text-roboto-black" ID="txtPayment" runat="server"></asp:TextBox>
                    </div>                    
            </div>

            <div class="col-md-4">
                    <div class="form-group">
                        <label class="text-roboto-black">Saldo:</label>
                        <asp:TextBox class="form-control text-roboto-black" ID="txtBalance" runat="server"></asp:TextBox>
                    </div>                    
            </div>
        </div>


        <br />
        <div class="row">
            <div class="col-md-12">
                <asp:Button type="button" class="btn btn-primary" ID="btnCreate" runat="server" Text="Agregar" OnClick="btnCreate_Click"/>
                <asp:Button type="button" class="btn btn-primary" ID="btnUpdate" runat="server" Text="Editar" OnClick="btnUpdate_Click"/>
                <asp:Button type="button" class="btn btn-primary" ID="btnDelete" runat="server" Text="Borrar" OnClick="btnDelete_Click"/>
            </div>
        </div>
        <br />
        <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
        <br /><br /><br />
        <div class="row">
            <div class="col-md-4">
                <div class="form-group">
                        <label class="text-roboto-black">Cédula:</label>
                        <asp:TextBox class="form-control text-roboto-black" ID="txtCustomerIDSearch" runat="server"></asp:TextBox><br />
                        <asp:Button type="button" class="btn btn-primary" ID="btnCustomerIDSearch" runat="server" Text="Buscar Ordenes" OnClick="btnCustomerIDSearch_Click"/>
                        <br />
                        <asp:Label ID="msgCustomerSearch" runat="server" Text=""></asp:Label>
                    </div>  
            </div>
        </div>
        <asp:GridView 
            ID="gvOrders" 
            runat="server"
            OnRowDataBound="gvOrders_RowDataBound" 
            OnSelectedIndexChanged = "gvOrders_SelectedIndexChanged"
            onrowcommand="gvOrders_RowCommand"
            autogeneratecolumns="False"
            selectedindex="1"

            CssClass="table table-striped table-responsive">

            <EmptyDataRowStyle forecolor="Red" CssClass="table table-striped" />
            <emptydatatemplate>
            No se encontraron ordenes relacionadas con el cliente ingresado  
            </emptydatatemplate>

              	<Columns>
                    <asp:ButtonField Text="Detalle" CommandName="Select" ControlStyle-CssClass="btn btn-primary"/>
					<asp:BoundField DataField="number" HeaderText="Número" HTMLEncode="False" />
					<asp:BoundField DataField="dateOrder" HeaderText="Fecha" HTMLEncode="False" />
					<asp:BoundField DataField="customerID" HeaderText="Cédula" HTMLEncode="False" />
                    <asp:BoundField DataField="customerName" HeaderText="Nombre" HTMLEncode="False" />
					<asp:BoundField DataField="dateDelivery" HeaderText="Entrega" HTMLEncode="False" />
                    <asp:BoundField DataField="deliveredBy" HeaderText="Entregado por" HTMLEncode="False" />
                    <asp:BoundField DataField="workType" HeaderText="Clase de Trabajo" HTMLEncode="False" />
                    <asp:BoundField DataField="initialNum" HeaderText="Del número" HTMLEncode="False" />
                    <asp:BoundField DataField="endNum" HeaderText="Al número" HTMLEncode="False" />
                    <asp:BoundField DataField="nameDesign" HeaderText="Nombre del diseño" HTMLEncode="False" />
                    <asp:TemplateField HeaderText="Diseño">
                    <ItemTemplate>
                        <asp:Button ID="btnDownloadDesign"  
                        CommandArgument="<%# ((GridViewRow) Container).RowIndex %>
                        " CommandName="Design" runat="server" Text="Diseño" class="btn btn-primary"/>
                    </ItemTemplate>
                    </asp:TemplateField> 
				</Columns>

        </asp:GridView>


</asp:Content>
