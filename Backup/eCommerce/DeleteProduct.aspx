<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeleteProduct.aspx.cs" Inherits="eCommerce.DeleteProduct" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title></title>
 <script type="text/javascript" language="javascript">
     function ConfirmOnDelete() {
         if (confirm("Emin misiniz?") == true)
             return true;
         else
             return false;
     }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <asp:DropDownList ID="DropDownList1" runat="server" 
           
            AutoPostBack="True"> </asp:DropDownList>

        <asp:Button ID="Button1" runat="server" Text="Sil" OnClientClick="return ConfirmOnDelete()" onclick="Button1_Click" />
       

        
    </div>
    </form>
</body>
</html>
