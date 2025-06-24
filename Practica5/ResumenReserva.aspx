<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResumenReserva.aspx.cs" Inherits="Practica5.ResumenReserva" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Resumen de Reserva</title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Resumen de tu reserva</h1>

        <asp:Literal ID="litTabla" runat="server" />

        <br /><br />

        <asp:Label ID="lblComentario" runat="server" Text="Comentario adicional:"></asp:Label><br />
        <asp:TextBox ID="txtComentario" runat="server" TextMode="MultiLine" Rows="5" Columns="50"></asp:TextBox><br /><br />
        <asp:Button ID="btnEnviarComentario" runat="server" Text="Enviar comentario" OnClick="btnEnviarComentario_Click" />
    </form>
</body>
</html>

