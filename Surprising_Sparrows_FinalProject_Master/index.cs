/*Name: Anthony Walsh
 * email: walshat @mail.uc.edu
 * Assignment Number: Final Project
 * Due Date: 2024_12_05
 * Course #/Section: IS3050-001
 * Semester / Year: Fall 2024
 * Brief Description of the assignment: Demonstrate a mastery of basic C# programming and ASP.Net web sites.
 * Brief Description of what this module does: Final Exam Module
 * Citations: https://chatgpt.com/, https://leetcode.com/
*Anything else that's relevant:
*/
using System;
using System.Web.UI;
using System.Collections.Generic;

namespace WebApplication2
{
    public partial class CombinedPage : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Hide all panels initially
                HideAllPanels();
            }
        }

        protected void ddlProblemSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Show the selected problem panel
            HideAllPanels();
            string selectedProblem = ddlProblemSelector.SelectedValue;

            switch (selectedProblem)
            {
                case "StockProfit":
                    pnlStockProfit.Visible = true;
                    break;
                case "BasicCalculator":
                    pnlBasicCalculator.Visible = true;
                    break;
                case "RainwaterTrapping":
                    pnlRainwaterTrapping.Visible = true;
                    break;
                case "FirstMissingPositive":
                    pnlFirstMissingPositive.Visible = true;
                    break;
            }
        }

        private void HideAllPanels()
        {
            pnlStockProfit.Visible = false;
            pnlBasicCalculator.Visible = false;
            pnlRainwaterTrapping.Visible = false;
            pnlFirstMissingPositive.Visible = false;
        }

        // Stock Profit Calculator Logic
        protected void SolveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string[] inputPrices = pricesInput.Text.Split(',');
                int[] prices = Array.ConvertAll(inputPrices, int.Parse);
                int maxProfit = MaxProfit(prices);
                result.Text = $"Maximum Profit: {maxProfit}";
            }
            catch (FormatException)
            {
                result.Text = "Error: Please enter valid numeric stock prices, separated by commas.";
            }
            catch (Exception ex)
            {
                result.Text = $"An unexpected error occurred: {ex.Message}";
            }
        }

        public int MaxProfit(int[] prices)
        {
            if (prices == null || prices.Length <= 1) return 0;

            int[,] dp = new int[3, prices.Length];
            for (int k = 1; k <= 2; k++)
            {
                int maxDiff = -prices[0];
                for (int i = 1; i < prices.Length; i++)
                {
                    dp[k, i] = Math.Max(dp[k, i - 1], prices[i] + maxDiff);
                    maxDiff = Math.Max(maxDiff, dp[k - 1, i] - prices[i]);
                }
            }
            return dp[2, prices.Length - 1];
        }

        // Basic Calculator Logic
        protected void CalculateButton_Click(object sender, EventArgs e)
        {
            try
            {
                string expression = expressionInput.Text.Trim();
                var solution = new Solution();
                int resultValue = solution.Calculate(expression);
                ResultLabel.Text = "Result: " + resultValue.ToString();
            }
            catch (Exception ex)
            {
                ResultLabel.Text = $"Error: {ex.Message}";
            }
        }

        public class Solution
        {
            public int Calculate(string s)
            {
                s = s.Replace(" ", "");
                Stack<int> stack = new Stack<int>();
                int currentNumber = 0;
                int result = 0;
                int sign = 1;

                for (int i = 0; i < s.Length; i++)
                {
                    char ch = s[i];
                    if (char.IsDigit(ch))
                    {
                        currentNumber = currentNumber * 10 + (ch - '0');
                    }
                    else if (ch == '+')
                    {
                        result += sign * currentNumber;
                        currentNumber = 0;
                        sign = 1;
                    }
                    else if (ch == '-')
                    {
                        result += sign * currentNumber;
                        currentNumber = 0;
                        sign = -1;
                    }
                    else if (ch == '(')
                    {
                        stack.Push(result);
                        stack.Push(sign);
                        result = 0;
                        sign = 1;
                    }
                    else if (ch == ')')
                    {
                        result += sign * currentNumber;
                        currentNumber = 0;
                        result *= stack.Pop();
                        result += stack.Pop();
                    }
                }

                result += sign * currentNumber;
                return result;
            }
        }

        // Rainwater Trapping Calculator Logic
        protected void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                string[] inputHeights = txtHeights.Text.Split(',');
                int[] heights = Array.ConvertAll(inputHeights, int.Parse);
                var rainWater = new RainWaterTrapping();
                int trappedWater = rainWater.Trap(heights);
                lblResult.Text = $"Trapped Rainwater: {trappedWater}";
            }
            catch (FormatException)
            {
                lblResult.Text = "Error: Please enter valid numeric heights, separated by commas.";
            }
            catch (Exception ex)
            {
                lblResult.Text = $"An unexpected error occurred: {ex.Message}";
            }
        }

        public class RainWaterTrapping
        {
            public int Trap(int[] height)
            {
                if (height == null || height.Length == 0) return 0;

                int n = height.Length;
                int[] leftMax = new int[n];
                int[] rightMax = new int[n];
                int waterTrapped = 0;

                leftMax[0] = height[0];
                for (int i = 1; i < n; i++)
                {
                    leftMax[i] = Math.Max(leftMax[i - 1], height[i]);
                }

                rightMax[n - 1] = height[n - 1];
                for (int i = n - 2; i >= 0; i--)
                {
                    rightMax[i] = Math.Max(rightMax[i + 1], height[i]);
                }

                for (int i = 0; i < n; i++)
                {
                    waterTrapped += Math.Min(leftMax[i], rightMax[i]) - height[i];
                }

                return waterTrapped;
            }
        }

        // First Missing Positive Logic
        protected void btnSolveProblem_Click(object sender, EventArgs e)
        {
            try
            {
                int[] testCase = new int[] { 3, 4, -1, 1 };
                Class1 solution = new Class1();
                int result = solution.FirstMissingPositive(testCase);
                lblFirstMissingPositiveResult.Text = "Smallest Missing Positive Integer: " + result;
            }
            catch (Exception ex)
            {
                lblFirstMissingPositiveResult.Text = $"An unexpected error occurred: {ex.Message}";
            }
        }

        public class Class1
        {
            public int FirstMissingPositive(int[] nums)
            {
                int n = nums.Length;

                for (int i = 0; i < n; i++)
                {
                    if (nums[i] <= 0 || nums[i] > n)
                    {
                        nums[i] = n + 1;
                    }
                }

                for (int i = 0; i < n; i++)
                {
                    int num = Math.Abs(nums[i]);
                    if (num <= n)
                    {
                        nums[num - 1] = -Math.Abs(nums[num - 1]);
                    }
                }

                for (int i = 0; i < n; i++)
                {
                    if (nums[i] > 0)
                    {
                        return i + 1;
                    }
                }

                return n + 1;
            }
        }
    }
}
