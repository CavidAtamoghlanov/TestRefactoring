using System;
using LegacyApp.Helpers;
using LegacyApp.Services;

namespace LegacyApp
{
    public class UserService
    {
        private readonly IUserValidationService _userValidationService;
        private readonly IClientRepository _clientRepository;

        public UserService()
        {
            _userValidationService = new UserValidationService();
            _clientRepository = new ClientRepository();
        }

        public bool AddUser(string firstname, string surname, string email, DateTime dateOfBirth, int clientId)
        {
            if (!_userValidationService.ValidateUser(firstname, surname, email, dateOfBirth))
                return false;

            var client = _clientRepository.GetById(clientId);

            var user = new User(client, dateOfBirth, email, firstname, surname);

            UserHelpers.AddCreditLimit(user);

            if (!_userValidationService.CheckCreditLimit(user, 500))
                return false;

            UserDataAccess.AddUser(user);
            return true;
        }
    }
}