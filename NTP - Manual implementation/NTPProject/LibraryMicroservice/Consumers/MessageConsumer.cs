using MassTransit;
using System.Threading.Tasks;
using System;
using SharedModels;
using Newtonsoft.Json;
using LibraryMicroservice.Repositories;

namespace LibraryMicroservice.Consumers
{
    public class SciPaperPublishedConsumer : IConsumer<SciPaperPublished>
    {
        private readonly ILibraryRepository _repository;

        public SciPaperPublishedConsumer(ILibraryRepository repository)
        {
            _repository = repository;
        }
        public async Task Consume(ConsumeContext<SciPaperPublished> context)
        {
            await Task.Run(() => { var obj = context.Message;
                if (_repository.GetSciPaperPublishedById(obj.Id.ToString()) == null)
                {
                    _repository.CreateSciPaperPublished(obj);
                    _repository.SaveChanges();
                    Console.WriteLine("SciPaper with id " + obj.Id + " successfully published!");
                }
                else
                {
                    Console.WriteLine("SciPaper with id " + obj.Id + " already published!");
                }


            });
        }
    }
}
