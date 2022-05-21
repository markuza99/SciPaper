using Grpc.Core;
using Grpc.Net.Client;
using SciPaperMicroservice.Dtos;
using SciPaperMicroservice.Models;
using SciPaperMicroservice.Repositories;
using System;
using System.Collections.Generic;

namespace SciPaperMicroservice.Services
{
    public class SciPaperService : ISciPaperService
    {
        private readonly ISciPaperRepository _repository;

        public SciPaperService(ISciPaperRepository repository)
        {
            _repository = repository;
        }

        public string CreateSciPaper(SciPaperCreateDto sciPaperDto, string jwt)
        {
            SciPaper sciPaper = new SciPaper(sciPaperDto);
            var channel = GrpcChannel.ForAddress("http://localhost:5002");
            try
            {
                var client = new UserMicroservice.Greeter.GreeterClient(channel);
                bool isLoggedIn = client.CheckLogin(new UserMicroservice.isLoggedInRequest { Jwt = jwt }).IsLoggedIn;
                if(isLoggedIn)
                {
                    string name = client.GetName(new UserMicroservice.getNameRequest { Jwt = jwt }).Name;
                    sciPaper.Author = name;
                    _repository.CreateSciPaper(sciPaper);
                    _repository.SaveChanges();
                    return "SciPaper successfully created!";
                }
                return "Invalid token!";

            } catch (Exception ex)
            {
                return "UserMicroservice is down!";

            }

        }

        public IEnumerable<SciPaper> GetAllSciPapers()
        {
            return _repository.GetAllSciPapers();
        }

        public SciPaper GetSciPaperById(string id)
        {
            return _repository.GetSciPaperById(id);
        }
    }
}
