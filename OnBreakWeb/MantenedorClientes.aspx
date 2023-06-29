<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="MantenedorClientes.aspx.cs" Inherits="OnBreakWeb.MantenedorClientes" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style6 {
            height: 30px;
        }
        .auto-style8 {
            height: 30px;
            width: 316px;
        }
        .auto-style9 {
    }
        .auto-style11 {
            height: 30px;
            width: 180px;
        }
        .auto-style12 {
            height: 23px;
            width: 180px;
        }
        .auto-style13 {
            width: 180px;
        }
    .auto-style14 {
            height: 23px;
            width: 316px;
        }
    .auto-style15 {
            width: 316px;
        }
        .auto-style16 {
            width: 180px;
            height: 33px;
        }
        .auto-style17 {
            width: 316px;
            height: 33px;
        }
        .auto-style18 {
            height: 33px;
        }
        .auto-style19 {
            width: 180px;
            height: 29px;
        }
        .auto-style20 {
            width: 316px;
            height: 29px;
        }
        .auto-style21 {
            height: 29px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:100%;">
        <tr>
            <td class="auto-style12"></td>
            <td class="auto-style14"></td>
            <td class="auto-style1"></td>
        </tr>
        <tr>
            <td class="auto-style11">Rut:</td>
            <td class="auto-style8">
                <asp:TextBox ID="txtRut" runat="server"></asp:TextBox>
                &nbsp;</td>
            <td class="auto-style6">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtRut">*Obligatorio</asp:RequiredFieldValidator>
&nbsp;&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style12">Razon Social:</td>
            <td class="auto-style14">
                <asp:TextBox ID="txtRazSocial" runat="server" Width="226px"></asp:TextBox>
            </td>
            <td class="auto-style1">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNombre" ErrorMessage="RequiredFieldValidator">*Obligatorio</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style13">Nombre:</td>
            <td class="auto-style15">
                <asp:TextBox ID="txtNombre" runat="server" Width="224px"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtApellido" ErrorMessage="RequiredFieldValidator">*Obligatorio</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style19">Correo:</td>
            <td class="auto-style20">
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style21">
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="RegularExpressionValidator" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">Error de formato</asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style19">Dirección:</td>
            <td class="auto-style20">
                <asp:TextBox ID="txtDireccion" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style21">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style19">Teléfono:</td>
            <td class="auto-style20">
                <asp:TextBox ID="txtTelefono" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style21">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style19">Empresa:</td>
            <td class="auto-style20">
                <asp:DropDownList ID="cboEmpresa" runat="server">
                </asp:DropDownList>
            </td>
            <td class="auto-style21">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style19">Actividad Empresa:</td>
            <td class="auto-style20">
                <asp:DropDownList ID="cboActEmpresa" runat="server">
                </asp:DropDownList>
            </td>
            <td class="auto-style21">
            </td>
        </tr>
        <tr>
            <td class="auto-style13">&nbsp;</td>
            <td class="auto-style15">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style16"></td>
            <td class="auto-style17">
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
            </td>
            <td class="auto-style18">
                <asp:Label ID="lblMsg" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style13">&nbsp;</td>
            <td class="auto-style15">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style13">&nbsp;</td>
            <td class="auto-style9" colspan="2">
                <asp:GridView ID="gdClientes" runat="server">
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td class="auto-style13">&nbsp;</td>
            <td class="auto-style15">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>






