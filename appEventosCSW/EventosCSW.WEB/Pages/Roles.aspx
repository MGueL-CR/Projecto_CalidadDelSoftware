<%@ Page Title="Roles" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Roles.aspx.cs" Inherits="EventosCSW.WEB.Pages.Roles" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-12 d-flex flex-row align-items-center">
            <div class="col-1"><input class="col-6" type="button" name="return" id="return" value="<"></div>
			<div><span>Lista de Roles</span></div>
        </div>
    </div>
    <div class="row">
	<div class="col-12">
        <asp:GridView ID="gvListaRoles" runat="server" CssClass="table table-striped" AutoGenerateColumns="false">

<Columns>
    <asp:BoundField DataField="Id" HeaderText="ID" />
    <asp:BoundField DataField="Tipo" HeaderText="Nombre" />
    <asp:BoundField DataField="Estado" HeaderText="Estado" />

    
</Columns>

        </asp:GridView>
	</div>
</div>
</asp:Content>
