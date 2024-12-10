using System;
using System.Web.UI;

namespace SurprisingSparrows_FinalProject
{
    public partial class Index : Page
    {
        protected void SolveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Step 1: Get the input from the user (comma-separated stock prices)
                string[] inputPrices = pricesInput.Text.Split(','); // Get values from the TextBox
                int[] prices = Array.ConvertAll(inputPrices, int.Parse); // Convert the strings to integers

                // Step 2: Call the function to compute the maximum profit
                int maxProfit = MaxProfit(prices);

                // Step 3: Display the result
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

        // Function to calculate the maximum profit with at most two transactions
        public int MaxProfit(int[] prices)
        {
            if (prices == null || prices.Length <= 1)
                return 0;

            // DP array to store profits for up to two transactions
            int[,] dp = new int[3, prices.Length];

            // Iterate over the transactions (1 or 2)
            for (int k = 1; k <= 2; k++)
            {
                int maxDiff = -prices[0]; // Max profit if we buy on day 0 for the current transaction

                for (int i = 1; i < prices.Length; i++)
                {
                    // Update dp[k, i] with the best profit possible for `k` transactions up to day `i`
                    dp[k, i] = Math.Max(dp[k, i - 1], prices[i] + maxDiff);

                    // Update maxDiff for future calculations
                    maxDiff = Math.Max(maxDiff, dp[k - 1, i] - prices[i]);
                }
            }

            // The maximum profit with at most 2 transactions on the last day
            return dp[2, prices.Length - 1];
        }
    }
}
