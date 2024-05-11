using System;

namespace LegacyApp.Services
{
    public interface IUserValidationService
    {
        /// <summary>
        /// Checks if the user's credit limit meets the minimum requirement.
        /// </summary>
        /// <param name="user">The user whose credit limit needs to be checked.</param>
        /// <param name="minimumCreditLimit">The minimum credit limit required.</param>
        /// <returns>True if the user's credit limit meets the minimum requirement; otherwise, false.</returns>
        bool CheckCreditLimit(User user, int minimumCreditLimit);

        /// <summary>
        /// Validates user information including first name, surname, email, and age.
        /// </summary>
        /// <param name="firstName">The first name of the user.</param>
        /// <param name="surname">The surname of the user.</param>
        /// <param name="email">The email address of the user.</param>
        /// <param name="dateOfBirth">The date of birth of the user.</param>
        /// <returns>True if all user information is valid; otherwise, false.</returns>
        bool ValidateUser(string firstName, string surname, string email, DateTime dateOfBirth);
    }
}
