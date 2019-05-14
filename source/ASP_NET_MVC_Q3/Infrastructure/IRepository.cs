using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASP_NET_MVC_Q3.Data;

namespace ASP_NET_MVC_Q3.Infrastructure
{
    public interface IRepository<T> where T : Product
    {
        IEnumerable<T> Delete(T entity);
        IEnumerable<T> Insert(T entity);
        IEnumerable<T> List { get; }
        T ReadById(int? Id);
        IEnumerable<T> Update(T entity);
    }
}
