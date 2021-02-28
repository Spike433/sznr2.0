<%@ Page Title="Input" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Input.aspx.cs" Inherits="WebApplication3.Input" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">&nbsp; <h3>Unos podataka</h3>
      <br />

     <h4>Odaberite početak radnog vremena</h4>  
      <div> 
    <asp:DropDownList ID="start" runat="server">  
    <asp:ListItem>8</asp:ListItem>
    <asp:ListItem>9</asp:ListItem>
    <asp:ListItem>10</asp:ListItem>
    <asp:ListItem>11</asp:ListItem>
    <asp:ListItem>12</asp:ListItem>
    <asp:ListItem>13</asp:ListItem>
    
    </asp:DropDownList>
          <br />
          <br />
          <h4>Odaberite kraj radnog vremena</h4>  
          <asp:DropDownList ID="stop" runat="server" >
            <asp:ListItem>14</asp:ListItem>
            <asp:ListItem>15</asp:ListItem>
            <asp:ListItem>16</asp:ListItem>
            <asp:ListItem>17</asp:ListItem>        
            <asp:ListItem>18</asp:ListItem>
            <asp:ListItem>19</asp:ListItem>

          </asp:DropDownList>
          
          <br />
          <br />
          
          <h4>Trajanje u minutama</h4>  
          <asp:DropDownList ID="delay" runat="server">
          <asp:ListItem>15</asp:ListItem>
          <asp:ListItem>30</asp:ListItem>
          <asp:ListItem>45</asp:ListItem>
          <asp:ListItem>60</asp:ListItem>
          </asp:DropDownList>
          
          <br />
          <br />
          <br />
          <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Pošalji" />
          
          <br />
          <br />
     </div>
          

</asp:Content>

