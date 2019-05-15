using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASP_NET_MVC_Q3.Data;

namespace ASP_NET_MVC_Q3.Infrastructure
{
    public interface IProductRepository<T> where T : Product
    {
        IEnumerable<T> List { get; }
        T ReadById(int? Id);
        void Update(T entity);
        void Insert(T entity);
        void Delete(T entity);
    }
}
