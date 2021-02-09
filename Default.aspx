<%@ Page Title="File Sharing" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FileSharing._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div style="margin-top:0px" class="jumbotron">
        <h1>File Sharing</h1>
        <p class="lead">Upload and Download files with peers</p>
    </div>
    <div>
        <asp:FileUpload ID="FileUpload1" runat="server" Height="25px" Width="206px" />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Upload" />
    </div>
    
    <br />
    <asp:GridView style="font-size:18px" ID="GridView1" CssClass="table" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" BackColor="White" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CellSpacing="2" ForeColor="Black" GridLines="Horizontal" Height="162px" HorizontalAlign="Left" Width="512px">
        <Columns>
            <asp:TemplateField HeaderText="File">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# Eval("File") %>' CommandName="Download" Text='<%# Eval("File") %>'></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Size" HeaderText="Size in Bytes" />
        </Columns>
        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F7F7F7" />
        <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
        <SortedDescendingCellStyle BackColor="#E5E5E5" />
        <SortedDescendingHeaderStyle BackColor="#242121" />
    </asp:GridView>
</asp:Content>
