﻿using Library.DAL.SQL.Entity;
using Library.DAL.SQL.Repositories;

namespace Library.Services
{
    public class LendingsProvider
    {
        private readonly IRepository<Lending> _repository;

        public LendingsProvider(IRepository<Lending> repository)
        {
            _repository = repository;
        }

        public void AddLending(Lending lending)
        {
            _repository.Add(lending);
        }

        public void AddLendings(List<Lending> lendings)
        {
            lendings.ForEach(lending => _repository.Add(lending));
        }

        public Lending GetLendingByID(int id)
        {
            return _repository.Get(id);
        }

        public IEnumerable<Lending> GetAllLendings()
        {
            return _repository.GetAll();
        }

        public void Remove(Lending lending)
        {
            _repository.Remove(lending);
        }

        public void Update(int id, Lending lending)
        {
            _repository.Update(id, lending);
        }

        public IEnumerable<User> GetOverdueUsers()
        {
            return GetAllLendings().Where(l => l.DueDate < DateTime.Now)
                                   .Select(l => l.User)
                                   .Distinct();
        }
    }
}
