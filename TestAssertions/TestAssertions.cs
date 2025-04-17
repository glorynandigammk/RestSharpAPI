using RestSharpAPI.Models;
using System;

namespace RestSharpAPI.TestAssertions
{
    public static class TestAssertions
    {
        public static void AssertEqual<T>(T expected, T actual, string fieldName)
        {
            if (!EqualityComparer<T>.Default.Equals(expected, actual))
            {
                Console.WriteLine($"❌ {fieldName} mismatch: Expected = {expected}, Actual = {actual}");
            }
            else
            {
                Console.WriteLine($"✅ {fieldName} matches: {actual}");
            }
        }

        public static void AssertPetEqual(Pet expected, Pet actual)
        {
            Console.WriteLine("🔍 Verifying Pet...");
            AssertEqual(expected.id, actual.id, "Id");
            AssertEqual(expected.name, actual.name, "Name");
            AssertEqual(expected.status, actual.status, "Status");
        }

        public static void AssertOrderEqual(Order expected, Order actual)
        {
            Console.WriteLine("🔍 Verifying Order...");
            AssertEqual(expected.Id, actual.Id, "Id");
            AssertEqual(expected.PetId, actual.PetId, "PetId");
            AssertEqual(expected.Quantity, actual.Quantity, "Quantity");
            AssertEqual(expected.Status, actual.Status, "Status");
            AssertEqual(expected.Complete, actual.Complete, "Complete");
        }

        public static void AssertUserEqual(User expected, User actual)
        {
            Console.WriteLine("🔍 Verifying User...");
            AssertEqual(expected.Id, actual.Id, "Id");
            AssertEqual(expected.Username, actual.Username, "Username");
            AssertEqual(expected.FirstName, actual.FirstName, "FirstName");
            AssertEqual(expected.LastName, actual.LastName, "LastName");
            AssertEqual(expected.Email, actual.Email, "Email");
            AssertEqual(expected.Phone, actual.Phone, "Phone");
            AssertEqual(expected.UserStatus, actual.UserStatus, "UserStatus");
        }
    }

}
