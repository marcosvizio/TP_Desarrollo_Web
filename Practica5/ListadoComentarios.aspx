<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListadoComentarios.aspx.cs" Inherits="Practica5.ListadoComentarios" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Comentarios registrados</h1>

        <asp:GridView ID="gvComentarios" runat="server" AutoGenerateColumns="False" 
                      DataKeyNames="IdComentario" OnRowEditing="gvComentarios_RowEditing" 
                      OnRowCancelingEdit="gvComentarios_RowCancelingEdit"
                      OnRowUpdating="gvComentarios_RowUpdating" 
                      OnRowDeleting="gvComentarios_RowDeleting">
            <Columns>
                <asp:BoundField DataField="DNI" HeaderText="DNI" ReadOnly="True" />
                <asp:BoundField DataField="NombreCompleto" HeaderText="Nombre" ReadOnly="True" />
                <asp:BoundField DataField="Comentario" HeaderText="Comentario" />
                <asp:BoundField DataField="Actividad" HeaderText="Actividad" ReadOnly="True" />

                <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>
        </div>
    </form>
</body>
</html>
