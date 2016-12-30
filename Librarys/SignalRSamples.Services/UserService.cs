using System.Collections.Generic;
using System.Linq;
using SignalRSamples.Data.Models;
using SignalRSamples.Infrastructure.Data;

namespace SignalRSamples.Services
{
    public class UserService
    {
        private readonly IRepository<User> _repository;

        public UserService(IRepository<User> repository)
        {
            _repository = repository;
        }

        public void Add(User entity)
        {
            _repository.Add(entity);
        }

        public List<Message> GetSendMessages(string id)
        {
            var user = _repository.GetById(id);
            if (user!=null)
            {
                return user.Messages.ToList();
            }
            return new List<Message>();
        }

        public List<Message> GetReceiveMessages(string id)
        {
            var user = _repository.GetById(id);
            if (user != null)
            {
                return user.MessageRelations.Select(m=>m.Message).ToList();
            }
            return new List<Message>();
        }
    }
}
