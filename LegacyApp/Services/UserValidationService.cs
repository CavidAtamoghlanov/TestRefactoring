using System;
using System.Text.RegularExpressions;

namespace LegacyApp.Services
{
    public class UserValidationService : IUserValidationService
    {
        private const string Pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+.[a-zA-Z]{2,}$";
        private readonly int _minimumAgeRequirement;

        // <summary>
        /// Initialized a new instance of <see cref="UserValidationService"/>
        /// </summary>
        public UserValidationService(int minimumAgeRequirement = 21) =>
            _minimumAgeRequirement = minimumAgeRequirement;

        /// <inheritdoc />
        public bool ValidateUser(string firstName, string surname, string email, DateTime dateOfBirth) =>
            IsNameValid(firstName, surname) &&
            IsEmailValid(email) &&
            IsOlderThanTheGivenAge(dateOfBirth);

        private bool IsNameValid(string firstName, string surname) =>
            !string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(surname);

        private bool IsEmailValid(string email) => Regex.IsMatch(email, Pattern);

        private bool IsOlderThanTheGivenAge(DateTime dateOfBirth) =>
            CalculateAge(dateOfBirth) < _minimumAgeRequirement;

        private int CalculateAge(DateTime dob)
        {
            var now = DateTime.Now;
            int age = now.Year - dob.Year;

            if (now.Month < dob.Month || (now.Month == dob.Month && now.Day < dob.Day))
                age--;

            return age;
        }

        /// <inheritdoc />
        public bool CheckCreditLimit(User user, int minimumCreditLimit)
            => !(user.HasCreditLimit && user.CreditLimit < minimumCreditLimit);
    }
}
