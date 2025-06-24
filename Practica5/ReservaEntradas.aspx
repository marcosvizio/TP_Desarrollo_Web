<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReservaEntradas.aspx.cs" Inherits="Practica5.ReservaEntradas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Reserva de Entradas</title>
    <link href="CSS/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="form-container">

                <div>
                    <h1>RESERVA DE ENTRADAS</h1>
                </div>

               <div class="seccion-form">
                   <div>
                       <h2>Información<br />Obligatoria</h2>
                   </div>
                   <div class="div-labels">
                       <div>
                             <label class="obligatorio">Nombre completo</label>
                             <asp:TextBox ID="txtNombre" runat="server" class="textbox"></asp:TextBox>
                        </div>
                       <br />
                        <div>
                             <label class="obligatorio">DNI</label>
                             <asp:TextBox ID="txtDNI" runat="server" class="textbox"></asp:TextBox>
                        </div>
                       <br />
                        <div>
                            <label class="obligatorio">E-Mail</label>
                            <asp:TextBox ID="txtEmail" runat="server" class="textbox"></asp:TextBox>
                        </div>
                    </div>

                </div>

                <div class="seccion-form">
                    <div>
                        <h2>Información<br />Opcional</h2>
                    </div>
                    <div class="div-labels">
                        <div>
                              <label class="opcional">Número de teléfono</label>
                              <asp:TextBox ID="txtTelefono" runat="server" class="textbox"></asp:TextBox>
                        </div>
                        <br />
                        <div>
                              <label class="opcional">Fecha de nacimiento</label>
                              <asp:TextBox ID="txtNacimiento" runat="server" class="textbox" TextMode="Date"></asp:TextBox>
                        </div>
                     </div>
                 </div>          

                <div class="seccion-form">
                    <div>
                        <h2>Actividad</h2>
                    </div>
                    <div class="div-labels">
                        <asp:DropDownList ID="ddlActividad" runat="server" AppendDataBoundItems="true" class="textbox">
                            <asp:ListItem Text="-- Seleccioná una actividad --" Value="0" />
                        </asp:DropDownList>
                    </div>
                </div>          

                <div class="botones">
                    <asp:Button ID="btnReservar" runat="server" Text="Reservar" OnClick="btnReservar_Click" Width="85px" />
                    <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" OnClick="btnLimpiar_Click" Width="85px" />
                </div>

                <div>
                    <asp:Label ID="lblMensaje" runat="server" ForeColor="Green" Font-Bold="true"></asp:Label>
                </div>
            </div>
        </div>
        <div>
            <asp:Button Text="Login Admin" runat="server" OnClick="btnAdmin_Page" Width="85px" />
        </div>
    </form>
    <script src="JS/ReservaEntradas.js" type="text/javascript"></script>
    </body>
</html>
