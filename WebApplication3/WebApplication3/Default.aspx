<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication3._Default" %>

    <asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
        
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <br />
        <br />
      <asp:ListView ID="lv_Members" runat="server">

         <LayoutTemplate>
                <table>
                    <thead>
                    <tr style="background-color: #336699; color: White;">
                        <th>&nbsp;&nbsp;&nbsp;&nbsp;Info&nbsp;&nbsp;&nbsp;</th>
                        
                        <th>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Vrijeme &nbsp;&nbsp;</th>
                        
                    </tr>
                    </thead>
                    <tbody id ="itemPlaceholder" runat="server"></tbody>
                <tfoot>
                <tr>
                <th style="text-align:right" colspan="8">
                </th>
                </tr>
                </tfoot>
                </table>
            </LayoutTemplate>
        
         <ItemTemplate>
                        <tr>
                            <td>&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="param2" runat="server" Text='<%# Eval("param2") %>'></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;</td>                            
                            <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="ParsedParam1" runat="server" Text='<%# Eval("ParsedParam1") %>'></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;</td>
                        </tr>
            </ItemTemplate>


        
            
    
              </asp:ListView>


</asp:Content>

