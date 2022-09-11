using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using online_shop.Exceptions;
using online_shop.Models;
using online_shop.Repositories;

namespace online_shop.Services
{
    public class CategoryServices
    {
        private CategoryRepository repository;

        public CategoryServices()
        {
            repository = new CategoryRepository();
        }

        public List<Category> GetAll()
        {
            if (repository.getAll().Count == 0)
            {
                throw new EntryDatabaseException();
            }

            return repository.getAll();
        }

        public Category GetById(int id)
        {
            if (id > repository.getAll().Count - 1)
            {
                throw new ObjectNotFoundException();
            }

            return repository.getById(id);
        }

        public Category GetByName(String name)
        {
            if (repository.getAll().Exists(cat => cat.Name.Equals(name)))
            {
                return repository.getByName(name);
            }

            throw new ObjectNotFoundException();
        }

    }
}
