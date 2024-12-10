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
<!--
Name: Alisha Siddiqui
email: Siddiqas@mail.uc.edu
Assignment Title: Assignment final
Due Date: 12/10/2024
Course: IS 3050 -001
Semester/Year:Fall 2024
Brief Description: This project 
Citations: W3Schools chatGPT
-->
<!--
# Name: Vanshika Rana
# email: ranava@mail.uc.edu
# Assignment Title: Final Project
# Due Date: December 10th 2024 at 7 am
# Course: IS 3050
# Semester/Year: Fall 2024
# Brief Description: This assignment is about solving a problem taken from the website "Leetcode". I chose the problem 42: Trapping Rain Water: Given n non-negative integers representing an elevation map where the width of each bar is 1, compute how much water it can trap after raining.
# Citations: https://leetcode.com/problems/trapping-rain-water/description/ , AI was used to develop code for the problem as instructed by the professor.
# Anything else that's relevant: n/a
-->
<!--Name: Vishwaja Painjane
email: painjavv@mail.uc.edu
Assignment Number: Final Group Project
Due Date: Tuesday, December 10th, 2024
Course #/Section: IS3050-001
Semester/Year: Fall 2024
Brief Description of the assignment: This is our final group assignment. We had to solve one leetcode problem each.
Brief Description of what this module does: This is a final group project
Citations: Used https://leetcode.com/problems/first-missing-positive/editorial/ for the problem and https://chatgpt.com for the solution.
Anything else that's relevant: N/A
-->
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CombinedPage.aspx.cs" Inherits="WebApplication2.CombinedPage" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Combined Functionality</title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Select a Problem to Solve</h1>
        <asp:DropDownList ID="ddlProblemSelector" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlProblemSelector_SelectedIndexChanged" ForeColor="#FF3300">
            <asp:ListItem Text="Select a problem" Value="None" />
            <asp:ListItem Text="Stock Profit Calculator" Value="StockProfit" />
            <asp:ListItem Text="Basic Calculator" Value="BasicCalculator" />
            <asp:ListItem Text="Rainwater Trapping" Value="RainwaterTrapping" />
            <asp:ListItem Text="First Missing Positive" Value="FirstMissingPositive" />
        </asp:DropDownList>
        <hr />

        <!-- Problem Panels -->
        <asp:Panel ID="pnlStockProfit" runat="server" Visible="false">
            <h2>123. Best Time to Buy and Sell Stock III</h2>
            <label for="pricesInput">Enter Stock Prices (comma-separated):</label>
            <asp:TextBox ID="pricesInput" runat="server"></asp:TextBox>
            <asp:Button ID="SolveBtn" runat="server" Text="Solve" OnClick="SolveBtn_Click" BackColor="#33CCFF" />
            <br />
            <asp:Label ID="result" runat="server" Text=""></asp:Label>
        </asp:Panel>

        <asp:Panel ID="pnlBasicCalculator" runat="server" Visible="false">
            <h2>Basic Calculator</h2>
            <label for="expressionInput">Enter Expression:</label>
            <asp:TextBox ID="expressionInput" runat="server" TextMode="SingleLine" Placeholder="e.g. 3 + (2 - 5)"></asp:TextBox>
            <asp:Button ID="CalculateButton" runat="server" Text="Calculate" OnClick="CalculateButton_Click" BackColor="#FF9966" />
            <br />
            <asp:Label ID="ResultLabel" runat="server" Text=""></asp:Label>
        </asp:Panel>

        <asp:Panel ID="pnlRainwaterTrapping" runat="server" Visible="false">
            <h2>Rainwater Trapping Calculator</h2>
            <asp:Label ID="lblPrompt" runat="server" Text="Enter heights (comma-separated):"></asp:Label>
            <br />
            <asp:TextBox ID="txtHeights" runat="server" Width="300"></asp:TextBox>
            <br /><br />
            <asp:Button ID="btnCalculate" runat="server" Text="Calculate" OnClick="btnCalculate_Click" BackColor="#FF66CC" />
            <br /><br />
            <asp:Label ID="lblResult" runat="server" Font-Bold="True"></asp:Label>
        </asp:Panel>

        <asp:Panel ID="pnlFirstMissingPositive" runat="server" Visible="false">
            <h2>LeetCode Problem: First Missing Positive</h2>
            <p><strong>Description:</strong> Given an unsorted integer array, return the smallest positive integer that is not present in the array.</p>
            <p>Example: Input: [3, 4, -1, 1]</p>
            <asp:Button ID="btnSolveProblem" runat="server" Text="Solve Problem" OnClick="btnSolveProblem_Click" BackColor="#99FF99" />
            <br /><br />
            <asp:Label ID="lblFirstMissingPositiveResult" runat="server" Text="Result will appear here." Font-Bold="True"></asp:Label>
        </asp:Panel>
    </form>
</body>
</html>

