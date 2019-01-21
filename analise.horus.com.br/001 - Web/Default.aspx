<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="_001___Web._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <div class="col-md-12">
            <asp:TextBox ID="TxtFilial" runat="server"></asp:TextBox>
            <asp:TextBox ID="TxtData" runat="server" TextMode="DateTime"></asp:TextBox>

            <asp:Button ID="BtnListar" runat="server" Text="Notas de Devolução" OnClick="BtnListar_Click" />

            <div class="row">
                <div class="col-md-3">
                    <asp:Label ID="Label1" runat="server" Text="Filial"></asp:Label>
                    <br />
                    <asp:Label ID="LblFilial" runat="server" Text=""></asp:Label>
                </div>
                <div class="col-md-3">
                    <asp:Label ID="Label2" runat="server" Text="Data"></asp:Label>
                    <br />
                    <asp:Label ID="LblData" runat="server" Text=""></asp:Label>
                </div>
                <div class="col-md-3">
                    <asp:Label ID="Label3" runat="server" Text="Notas"></asp:Label>
                    <br />
                    <asp:Label ID="LblQtdeNotas" runat="server" Text=""></asp:Label>
                </div>
                <div class="col-md-3">
                    <asp:Label ID="Label4" runat="server" Text="Valor"></asp:Label>
                    <br />
                    <asp:Label ID="LblValorNotas" runat="server" Text=""></asp:Label>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
