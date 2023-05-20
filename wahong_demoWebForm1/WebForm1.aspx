<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="wahong_demoWebForm1.WebForm1" enableSessionState="True"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="./Scripts/jquery-ui-1.13.2/jquery-ui.css">
    <script src="./Scripts/jquery-3.7.0.js"></script>
    <script src="./Scripts/jquery-ui-1.13.2/jquery-ui.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="姓名："></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:Label ID="Label2" runat="server" Text="年齡："></asp:Label>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <asp:Label ID="Label3" runat="server" Text="生日："></asp:Label>
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <asp:TextBox ID="TextBox4" runat="server" type="hidden"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" Text="創建帳號" OnClick="Button1_Click" />
        </div>
        <div>
            <asp:GridView ID="GridView1" runat="server" CssClass="table" AutoGenerateColumns="False" DataKeyNames="id">
                <Columns>
                <asp:BoundField DataField="name" HeaderText="姓名"     />
                <asp:BoundField DataField="age" HeaderText="年齡"       />
                <asp:BoundField DataField="birthday" HeaderText="生日"     />
                <asp:TemplateField HeaderText = "" ItemStyle-HorizontalAlign ="Center" >
                    <ItemTemplate>
                    <asp:Button ID="editBut" runat="server" Text="修改" CssClass="btn" OnClick="edit_Click" />
                    <asp:Button ID="delBut" runat="server" Text="刪除" CssClass="btn" OnClick="del_Click"/>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            </asp:GridView>
        </div>
    </form>
    <script>
      $( function() {
          $( "#TextBox3" ).datepicker();
      } );
    </script>
</body>
</html>
