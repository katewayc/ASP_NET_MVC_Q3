using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASP_NET_MVC_Q3.Data;

namespace ASP_NET_MVC_Q3.Infrastructure
{
    public class ProductRepository : IRepository<Product>
    {
        public IEnumerable<Product> List
        {
            get
            {
                return DataSource.ProductList;
            }
        }

        public Product ReadById(int? Id)
        {
            var product = DataSource.ProductList
                  .Where(n => n.Id == Id).FirstOrDefault();

            return product;
        }

        public IEnumerable<Product> Insert(Product data)
        {
            DataSource.ProductList.Add(new Product
            {
                Id = DataSource.GetNewId(),
                Name = data.Name,
                Locale = data.Locale,
                CreateDate = DateTime.Now
            });

            return DataSource.ProductList;
        }

        public IEnumerable<Product> Update(Product data)
        {
            var product = DataSource.ProductList
               .Where(n => n.Id == data.Id)
               .FirstOrDefault();

            if (product != null)
            {
                product.Name = data.Name;
                product.Locale = data.Locale;
                product.UpdateDate = DateTime.Now;
            }
            return DataSource.ProductList;
        }

        public IEnumerable<Product> Delete(Product data)
        {
            DataSource.ProductList.RemoveAll(p => p.Id == data.Id);

            return DataSource.ProductList;
        }
    }
}