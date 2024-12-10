<!-- Name: Anthony Walsh
 * email: walshat @mail.uc.edu
 * Assignment Number: Final Project
 * Due Date: 2024_12_05
 * Course #/Section: IS3050-001
 * Semester / Year: Fall 2024
 * Brief Description of the assignment: Demonstrate a mastery of basic C# programming and ASP.Net web sites.
 * Brief Description of what this module does: Final Exam Module
 * Citations: https://chatgpt.com/, https://leetcode.com/
 * Anything else that's relevant:
-->
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="SurprisingSparrows_FinalProject.Index" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Best Time to Buy and Sell Stock III</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Stock Profit Calculator</h2>
            
            <label for="pricesInput">Enter Stock Prices (comma-separated):</label>
            <asp:TextBox id="pricesInput" runat="server"></asp:TextBox>
            
            <asp:Button ID="SolveBtn" runat="server" Text="Solve" OnClick="SolveBtn_Click" />
            
            <br />
            
            <asp:Label ID="result" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
