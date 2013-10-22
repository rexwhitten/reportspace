<%@ Page Language="C#" ClassName="Show" CodeBehind="Show.aspx.cs"
    Inherits="ReportSpace.CustomerDashboard.Web.ReportViewer.Show" AutoEventWireup="True" %>
<%@ Register TagPrefix="a" Namespace="Microsoft.Reporting.WebForms" Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="reportForm" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="container-fluid">
            <a:ReportViewer ID="mainReportViewer" runat="server" Width="100%" Height="100%" 
                SizeToReportContent="True" ProcessingMode="Remote" AsyncRendering="false" 
                ShowBackButton="False" ShowFindControls="False" 
                ShowCredentialPrompts="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CssClass="container" DocumentMapWidth="100%" InternalBorderStyle="None" ShowDocumentMapButton="False" ShowPageNavigationControls="False" ToolBarItemBorderStyle="None" WaitControlDisplayAfter="100"/>
        </div>
    </form>
    <script src="../Content/js/jquery-1.10.1.js"></script>
    <script type="text/javascript">
        $('#mainReportViewer').width(1600);

    </script>
</body>
</html>