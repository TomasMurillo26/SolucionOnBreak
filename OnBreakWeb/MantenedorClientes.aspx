<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="MantenedorClientes.aspx.cs" Inherits="OnBreakWeb.MantenedorClientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        body {
            font-family: Arial, sans-serif;
        }
        
        .container {
            max-width: 800px;
            margin: 0 auto;
            padding: 20px;
        }
        
        .form-group {
            margin-bottom: 20px;
        }

        label {
            display: block;
            margin-bottom: 5px;
            font-weight: bold;
        }
        
        .form-control {
            width: 100%;
            padding: 5px;
            font-size: 14px;
            border: 1px solid #ccc;
            border-radius: 3px;
        }
        
        .error-message {
            color: red;
            font-size: 12px;
        }
        
        .btn {
            display: inline-block;
            padding: 8px 16px;
            font-size: 14px;
            font-weight: bold;
            text-align: center;
            text-decoration: none;
            cursor: pointer;
            color: #fff;
            background-color: #007bff;
            border: 1px solid #007bff;
            border-radius: 3px;
        }
        
        .table {
            width: 100%;
            border-collapse: collapse;
        }
        
        .table th,
        .table td {
            padding: 8px;
            border: 1px solid #ccc;
        }
        
        .table th {
            background-color: #f2f2f2;
            font-weight: bold;
        }

        .table-container {
            margin: 0 auto;
            text-align: center;
        }

    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        
        <div class="content">
            <div class="inner-content">
                <h2>Mantenedor de Clientes</h2>
        
        <div class="form-group">
            <label for="txtRut">Rut:</label>
            <asp:TextBox ID="txtRut" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtRut" ErrorMessage="*Obligatorio" CssClass="error-message"></asp:RequiredFieldValidator>
        </div>
        
        <div class="form-group">
            <label for="txtRazSocial">Razón Social:</label>
            <asp:TextBox ID="txtRazSocial" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtRazSocial" ErrorMessage="*Obligatorio" CssClass="error-message"></asp:RequiredFieldValidator>
        </div>
        
        <div class="form-group">
            <label for="txtNombre">Nombre:</label>
            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtNombre" ErrorMessage="*Obligatorio" CssClass="error-message"></asp:RequiredFieldValidator>
        </div>
        
        <div class="form-group">
            <label for="txtEmail">Correo:</label>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="Error de formato" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" CssClass="error-message"></asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtEmail" ErrorMessage="*Obligatorio" CssClass="error-message"></asp:RequiredFieldValidator>
        </div>
        
        <div class="form-group">
            <label for="txtDireccion">Dirección:</label>
            <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtDireccion" ErrorMessage="*Obligatorio" CssClass="error-message"></asp:RequiredFieldValidator>
        </div>
        
        <div class="form-group">
            <label for="txtTelefono">Teléfono:</label>
            <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        
        <div class="form-group">
            <label for="cboEmpresa">Empresa:</label>
            <asp:DropDownList ID="cboEmpresa" runat="server" CssClass="form-control"></asp:DropDownList>
        </div>
        
        <div class="form-group">
            <label for="cboActEmpresa">Actividad Empresa:</label>
            <asp:DropDownList ID="cboActEmpresa" runat="server" CssClass="form-control"></asp:DropDownList>
        </div>
        
        <div class="form-group">
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" CssClass="btn" />
            <asp:Label ID="lblMsg" runat="server"></asp:Label>
        </div>
        <div class="form-group">
            <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" OnClick="btnLimpiar_Click" CssClass="btn" />
        </div>
      </div>
     </div>
   </div>
    <div class="table-container">
        <table class="table">
            <tbody>
                <asp:GridView ID="gdClientes" runat="server" CssClass="table"></asp:GridView>
            </tbody>
        </table>
    </div>



</asp:Content>
