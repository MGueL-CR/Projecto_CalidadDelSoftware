<%@ Page Title="Datos del Evento" MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" CodeBehind="EventoForm.aspx.cs" Inherits="EventosCSW.WEB.Pages.EventoForm" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="contenido d-flex flex-row">
        <div class="col-3">
            <div class="mb-6">
                <asp:LinkButton ID="btnBack" runat="server" PostBackUrl="~/Pages/Eventos.aspx" CssClass="btn btn-light">
                <i class="fa-solid fa-chevron-left"></i>
                </asp:LinkButton>
                <asp:Label ID="lblTitle" runat="server" CssClass="fs-4 fw-bold"></asp:Label>
            </div>
            <div class="mb-3">
                <asp:Label ID="Label1" CssClass="form-label" runat="server" Text="Número del Evento"></asp:Label>
                <asp:TextBox ID="txtId" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <asp:Label ID="Label2" CssClass="form-label" runat="server" Text="Nombre del Evento"></asp:Label>
                <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <asp:Label ID="Label3" CssClass="form-label" runat="server" Text="Fecha del Evento"></asp:Label>
                <asp:TextBox ID="txtFecha" CssClass="form-control" runat="server" TextMode="Date" format="dd/MM/aaaa"></asp:TextBox>
            </div>
            <div class="mb-3">
                <asp:Label ID="Label4" CssClass="form-label" runat="server" Text="Cantidad de Miembros"></asp:Label>
                <asp:TextBox ID="txtCantidad" CssClass="form-control" runat="server" TextMode="Number"></asp:TextBox>
            </div>
            <div class="mb-3">
                <asp:Label ID="Label5" CssClass="form-label" runat="server" Text="Estado"></asp:Label>
                <asp:CheckBox ID="chkEstado" runat="server" />
            </div>
        </div>
        <div class="col-9">
            <div class="container-fluid mt-5">
                <div class="card">
                    <div class="card-header">
                        <span>Agregar los integrantes</span>
                    </div>
                    <div class="card-body">
                        <div class="row">
                            <div class="col-sm-12">
                                <div class="form-row">
                                    <div class="form-group col-sm-10">
                                        <label for="FileUpload1">Buscar:</label>
                                        <asp:FileUpload ID="FileUpload1" CssClass="form-control-file" runat="server"/>
                                    </div>
                                    <div class="form-group col-sm-2">
                                        <asp:Button ID="Button1" runat="server" Text="Mostrar Miembros" CssClass="btn btn-block btn-success mt-4" OnClick="LeerArchivo" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <hr />
                        <div class="row">
                            <div class="col-sm-12">
                                <div class="card">
                                    <div class="card-header p-1">
                                        <span>Integrantes agregados.</span>                       
                                    </div>
                                    <div class="card-body">
                                        <asp:GridView ID="gvListaMiembros" runat="server" CssClass="table table-striped table-hover"></asp:GridView>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </div>
        <div class="row mt-4 col-12">
            <div class="d-flex flex-row-reverse">
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="GuardarEvento" />
            </div>
        </div>
</asp:Content>
