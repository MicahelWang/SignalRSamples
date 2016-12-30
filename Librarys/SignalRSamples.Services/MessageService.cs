using System;
using SignalRSamples.Data.Models;
using SignalRSamples.Infrastructure.Data;

namespace SignalRSamples.Services
{
    public class MessageService
    {
        private readonly IRepository<Message> _repository;


        public MessageService(IRepository<Message> repository)
        {
            _repository = repository;
        }

        public Message Get(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException(nameof(id));
            }
            return _repository.GetById(id);
        }
    }
}