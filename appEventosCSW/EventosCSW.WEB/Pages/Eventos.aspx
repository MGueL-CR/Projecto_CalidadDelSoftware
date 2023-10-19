<%@ Page Title="Eventos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Eventos.aspx.cs" Inherits="EventosCSW.WEB.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="contenido">
        <div class="row">
            <div class="col-12">
                <asp:LinkButton ID="lbtnBackEvento" CssClass="btn btn-light" runat="server" OnClick="RegresarInicio"><i class="fa-solid fa-chevron-left"></i></asp:LinkButton>
                <asp:Label ID="lblTitleEvento" runat="server" Text="Eventos registrados"></asp:Label>
                <asp:LinkButton ID="lbtnNewEvento" CssClass="btn btn-primary" runat="server" OnClick="CrearEvento">Nuevo Evento</asp:LinkButton>
            </div>
        </div>

        <div class="row">
            <div class="col-12">
                <asp:GridView ID="gvListaEventos" CssClass="table table-striped table-hover table-borderless" BorderWidth="0" AutoGenerateColumns="false" runat="server">
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="Evento" />
                        <asp:BoundField DataField="Nombre" HeaderText="Descripción" />
                        <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                        <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                        <asp:TemplateField HeaderText="Opciones">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbtnEditar" runat="server" CssClass="btn btn-secondary" OnClick="EditarEvento" CommandArgument='<%# Eval("Id") %>'>
                                <i class="fa-solid fa-pen"></i>
                                </asp:LinkButton>
                                <asp:LinkButton ID="lbtnDetalles" runat="server" CssClass="btn btn-secondary" OnClick="VerEvento" CommandArgument='<%# Eval("Id") %>'>
                                <i class="fa-regular fa-rectangle-list"></i>
                                </asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>

        <!-- Modal -->
        <div class="modal fade" id="ModalDetalles" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h1 class="modal-title fs-5" id="staticBackdropLabel">Detalles del Evento.</h1>
                        <button id="btnTitle" type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div class="modal-body">
                        <div class="mb-2">
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
                            <asp:TextBox ID="txtFecha" CssClass="form-control" runat="server" TextMode="DateTime"></asp:TextBox>
                        </div>
                        <div class="mb-3">
                            <asp:Label ID="Label4" CssClass="form-label" runat="server" Text="Cantidad de Miembros"></asp:Label>
                            <asp:TextBox ID="txtCantidad" CssClass="form-control" runat="server" TextMode="Number"></asp:TextBox>
                        </div>
                        <div class="mb-3">
                            <asp:Label ID="Label5" CssClass="form-label" runat="server" Text="Activo:"></asp:Label>
                            <asp:CheckBox ID="chkEstado" runat="server"/>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button id="btnClose" type="button" class="btn btn-primary" data-bs-dismiss="modal">Cerrar</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script>

        document.getElementById('btnClose').addEventListener('click', HideDetails, true);
        document.getElementById('btnTitle').addEventListener('click', HideDetails, true);
        

        function ShowDetails() {
            $('body').addClass("modal-open").css("overflow", "hidden").css("padding-right", "0px");
            $('<div id="backModal" class="modal-backdrop fade show"></div>').appendTo('body');
            $('#ModalDetalles').addClass('show');
            $('#ModalDetalles').css("display","block");
            $('#ModalDetalles').attr("aria-modal", true).attr("role","dialog").removeAttr("aria-hidden");

        }

        function HideDetails() {
            $('body').removeClass("modal-open").removeAttr('style');
            $('#backModal').removeClass("modal-backdrop fade show");
            $('#ModalDetalles').removeClass('show');
            $('#ModalDetalles').css("display","none");
            $('#ModalDetalles').attr("aria-hidden", true).removeAttr("aria-modal").removeAttr("role");
        }
    </script>
</asp:Content>
