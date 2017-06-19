<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ASPEncDec._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

<h3> File Upload with Encryption and Download with Decryption using ASP.NET </h3>

    <div>
        <table>
            <tr>
                <td>Select File : </td>
                <td>
                    <asp:FileUpload ID="FileUpload1" runat="server" />

                </td>
                <td> <asp:Button ID="btnUpload" runat="server" Text="Upload & Encrypt" /></td>
                
            </tr>
        </table>
        
        <div>
            <asp:DataList ID="DataList1" runat="server" RepeatColumns="4" RepeatDirection="Horizontal">
            <ItemTemplate>
                <table>
                    <tr>
                        <td>
                            <img src='<%#Eval("ICon") %>'  />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <%#Eval("FileName") %>
                        </td>
                    </tr>
                                        <tr>
                        <td>
                            <%#Eval("Size","{0} KB") %>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
            </asp:DataList>
        </div>
    </div>

</asp:Content>
