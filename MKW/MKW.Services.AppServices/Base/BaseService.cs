using MKW.Domain.Entities.Base;
using MKW.Domain.Interface.Repository.Base;
using MKW.Domain.Interface.Services.AppServices.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKW.Services.AppServices.Base
{
    public class BaseService<T> : IBaseService<T> where T : BaseEntity
    {
        protected readonly IBaseRepository<T> _repository;

        public BaseService(IBaseRepository<T> repository)
        {
            _repository = repository;
        }

        public virtual async Task<IEnumerable<T>> Get() => (await _repository.GetAll())!;

        public virtual async Task<T> GetById(int id) => (await _repository.GetById(id))!;

        public virtual async Task<T> Add(T entity) => (await _repository.Add(entity))!;
        public virtual async Task<T> Update(T entity) => (await _repository.Update(entity))!;

        public virtual async Task<bool> Delete(int id)
        {
            await _repository.DeleteById(id);
            return true;
        }
    }
}
