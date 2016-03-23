<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Fwtest3._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h3>Imports Records in SQl From EXCEL\CVS\tabdelimited File</h3>
        <div style="padding:10px 0px">
            <table>
                <tr>
                    
                        <td>Select File:</td>
                    <td> <asp:FileUpload ID="FileUpload1" runat="server" /> </td>
                    <td><asp:Button ID="btnImport" runat="server" /></td>
                </tr>
            </table>
        </div>
        <br />
        <asp:Label ID="lblMessage" runat="server" Font-Bold="true" />
        <br />
        <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="false">
      <Columns>
          <asp:BoundField HeaderText="ID" DataField="AddID" />
          <asp:BoundField HeaderText="Streetaddress" DataField="StreetAddress" />
          <asp:BoundField HeaderText="Cityname" DataField="CityName" />
          <asp:BoundField HeaderText="Zipcode" DataField="ZipCode" />


        </Columns>

        </asp:GridView>
    </div>

</asp:Content>
