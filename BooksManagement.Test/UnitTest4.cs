using NUnit.Framework;
using System.Collections.Generic;

// [TestFixture]
public class LinearExpansionTests
{
    // Define the straight-through or default test data
    // private static readonly TestCaseData DefaultData = new TestCaseData("User", "Standard", "USD").SetName("StraightThrough_Default");

    public static IEnumerable<TestCaseData> TestCases()
    {
        // 1. Straight-through test case
        yield return DefaultData;

        // 2. Linear Expansion: change just the Role (User -> Admin)
        yield return new TestCaseData("Admin", "Standard", "USD").SetName("LinearExpansion_AdminRole");

        // 3. Linear Expansion: change just the Tier (Standard -> Premium)
        yield return new TestCaseData("User", "Premium", "USD").SetName("LinearExpansion_PremiumTier");
    }

    // [Test, TestCaseSource(nameof(TestCases))]
    public void ProcessTransaction_WithLinearExpansion(string role, string tier, string currency)
    {
        // Execute the test using the expanded data
        var result = ExecuteTransaction(role, tier, currency);
        Assert.IsTrue(result);
    }
}
