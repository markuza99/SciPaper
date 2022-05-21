using Grpc.Core;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using UserMicroservice.Authentication;
using UserMicroservice.Models;
using UserMicroservice.Repositories;

namespace UserMicroservice.Services
{
    public class UserService : Greeter.GreeterBase, IUserService
    {
        private readonly IUserRepository _repository;

        private readonly IJwtAuthenticationManager _jwtAuthManager;

        public override Task<getNameResponse> GetName(getNameRequest request, ServerCallContext context)
        {
            return Task.FromResult(new getNameResponse
            {
                Name = _jwtAuthManager.ValidateManualy(request.Jwt) != "" ? _jwtAuthManager.ValidateManualy(request.Jwt) : ""
            });
        }

        public override Task<isLoggedInResponse> CheckLogin(isLoggedInRequest request, ServerCallContext context)
        {
            return Task.FromResult(new isLoggedInResponse
            {
                IsLoggedIn = _jwtAuthManager.ValidateManualy(request.Jwt) != "" ? true : false
        });
        }


        public UserService(IUserRepository repository, IJwtAuthenticationManager jwtAuthManager)
        {
            _repository = repository;
            _jwtAuthManager = jwtAuthManager;
        }


        public IEnumerable<User> GetAllUsers()
        {
            return (_repository.GetAllUsers());
        }

        public User GetUserById(string id)
        {
            return (_repository.GetUserById(id));
        }


        public string login(string username, string password)
        {
            if (_repository.GetUserByUsernameAndPassword(username, password) == null)
            {
                return null;
            }
            return _jwtAuthManager.Authenticate(username, password);


        }

        public void RegisterUser(User user)
        {
            _repository.RegisterUser(user);
            _repository.SaveChanges();

        }
    }
}
