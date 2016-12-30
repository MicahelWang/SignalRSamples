using System;
using System.Linq;
using System.Threading.Tasks;
using SignalRSamples.Data.Models;
using SignalRSamples.Infrastructure.Data;
using SignalRSamples.Models.ViewModels;

namespace SignalRSamples.Services
{
    public class AccountService
    {
        private readonly IRepository<Account> _repository;

        public AccountService(IRepository<Account> repository)
        {
            _repository = repository;
        }
        public bool Login(string userName, string password)
        {
            var result = _repository.Table.Any(m => m.AccountName == userName && m.Password == password);
            return result;
        }

        public async Task<Account> Register(RegisterViewModel model)
        {
            var id = Guid.NewGuid().ToString("N").ToUpper();
            var user = new User
            {
                Id = id,
                Email = "",
                Phone = "",
                Name = model.UserName,
                CreateTime = DateTime.Now
            };
            var entity = new Account
            {
                User = user,
                AccountName = model.UserName,
                Password = model.Password,
                Id = id,
                CreateTime = DateTime.Now,
                LastLoginTime = DateTime.Now
            };

            await Task.Run(() => Add(entity));
            return entity;
        }

        protected void Add(Account entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            _repository.Add(entity);
        }
    }
}