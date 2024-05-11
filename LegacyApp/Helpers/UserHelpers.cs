using LegacyApp.Constants;
using System;
using System.Text.RegularExpressions;

namespace LegacyApp.Helpers
{
    public static class UserHelpers
    {
        public static void AddCreditLimit(User user)
        {
            if (user.Client.Name == ClientConstants.VeryImportantClient)
            {
                user.HasCreditLimit = false;
                return;
            }

            user.HasCreditLimit = true;
            using (var userCreditService = new UserCreditServiceClient())
            {
                var creditLimit = userCreditService.GetCreditLimit(user.Firstname, user.Surname, user.DateOfBirth);
                if (user.Client.Name == ClientConstants.ImportantClient)
                    creditLimit = creditLimit * 2;
                user.CreditLimit = creditLimit;
            }
        }
    }
}
