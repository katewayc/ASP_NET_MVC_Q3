using ASP_NET_MVC_Q3.Data;
using ASP_NET_MVC_Q3.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_NET_MVC_Q3
{
    public class CRUD
    {
        public IEnumerable<Product> ReadAll()
        {
            return GlobalVariables.source;
        }

        public Product ReadById(int? Id)
        {
            var product = GlobalVariables.source
                  .Where(n => n.Id == Id).FirstOrDefault();

            return product;
        }

        public void Insert(Product addData)
        {
            GlobalVariables.source.Add(new Product
            {
                Id = GlobalVariables.Id++,
                Name = addData.Name,
                Locale = addData.Locale,
                CreateDate = DateTime.Now
            });
        }

        public void Update(Product modifyData)
        {
            var data = GlobalVariables.source
               .Where(n => n.Id == modifyData.Id)
               .FirstOrDefault();

            if (data != null)
            {
                data.Name = modifyData.Name;
                data.Locale = modifyData.Locale;
                data.UpdateDate = DateTime.Now;
            }
        }

        public void Delete(Product deleteData)
        {
            var data = GlobalVariables.source.RemoveAll(n => n.Id == deleteData.Id);
        }
    }
}