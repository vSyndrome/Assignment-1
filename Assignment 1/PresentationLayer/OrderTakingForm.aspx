<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderTakingForm.aspx.cs" Inherits="Assignment_1.PresentationLayer.OrderTakingForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>
                        <asp:Button ID="btnFirst" runat="server" Text="First" OnClick="btnFirst_Click" />
                    </td>
                    <td></td>
                    <td></td>
                    <td>
                        <asp:Button ID="btnPrev" runat="server" Text="Prev" OnClick="btnPrev_Click" />
                    </td>
                    <td></td>
                    <td></td>
                    <td>
                        <asp:Button ID="btnNext" runat="server" Text="Next" OnClick="btnNext_Click" />
                    </td>
                    <td></td>
                    <td></td>
                    <td>
                        <asp:Button ID="btnLast" runat="server" Text="Last" OnClick="btnLast_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <table>
                <tr>
                    <td>
                        <asp:Label runat="server" Text="Customer ID"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="tbCustomerID" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label runat="server" Text="Name"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="tbName" runat="server" ReadOnly="False"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label runat="server" Text="Address"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="tbAddress" runat="server" TextMode="MultiLine" ReadOnly="False"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label runat="server" Text="CompanyName"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="tbCompanyName" runat="server" ReadOnly="False"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label runat="server" Text="Contact Title"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="tbContactTitle" runat="server" ReadOnly="False"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label runat="server" Text="City"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="tbCity" runat="server" ReadOnly="False"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label runat="server" Text="Region"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="tbRegion" runat="server" ReadOnly="False"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label runat="server" Text="Postal Code"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="tbPostalCode" runat="server" ReadOnly="False"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label runat="server" Text="Country"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="tbCountry" runat="server" ReadOnly="False"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label runat="server" Text="Phone"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="tbPhone" runat="server" ReadOnly="False"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label runat="server" Text="Fax"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="tbFax" runat="server" ReadOnly="False"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <br/>
            <asp:GridView ID="gvOrders" runat="server">
                <Columns>
                    <asp:BoundField DataField="ProductName" HeaderText="Orders"/>
                </Columns>
            </asp:GridView>
        </div>
        <br/>
        <div>
            <table>
                <tr>
                    <td>
                        <asp:Button ID="btnNew" runat="server" Text="New" OnClick="btnNew_Click" />
                    </td>
                    <td></td>
                    <td></td>
                    <td>
                        <asp:Button ID="btnEdit" runat="server" Text="Edit" OnClick="btnEdit_Click" />
                    </td>
                    <td></td>
                    <td></td>
                    <td>
                        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                    </td>
                    <td></td>
                    <td></td>
                    <td>
                        <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <br/>
            <br/>
            <asp:Label runat="server" Text="Select Products"></asp:Label>
            <br/>
            <asp:DropDownList ID="ddlProducts" runat="server"></asp:DropDownList>
            <asp:Button ID="btnPlaceOrder" runat="server" Text="Place Order" OnClick="btnPlaceOrder_Click" />
        </div>
    </form>
</body>
</html>
