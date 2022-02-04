using DealershipApi.Data.DataModels;
using DealershipApi.Models.DisplayModels.Supplier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealershipApi.Services.Services
{
    public class SupplierService
    {
        private readonly string _userId;
        public SupplierService(string userId)
        {
            _userId = userId;
        }

        public bool CreateSupplier(SupplierCreate model)
        {
            var entity = new Supplier()
            {
                Name = model.Name,
                SupplierType = model.SupplierType,
                Email = model.Email,
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Suppliers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<SupplierListItem> GetSuppliers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Suppliers.Select(
                    s => new SupplierListItem
                    {
                        Id = s.Id,
                        Name = s.Name,
                    });
                return query.ToArray();
            }
        }

        public SupplierDetail GetSupplierById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Suppliers
                        .Single(s => s.Id == id);

                return
                    new SupplierDetail
                    {
                        Id = entity.Id,
                        Name = entity.Name,
                        SupplierType = entity.SupplierType,
                        Email = entity.Email,
                    };
            }
        }

        public bool UpdateSupplier(SupplierEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Suppliers
                        .Single(s => s.Id == model.Id);

                entity.Id = model.Id;
                entity.Name = model.Name;
                entity.SupplierType = model.SupplierType;
                entity.Email = model.Email;

                return ctx.SaveChanges() > 0;
            }
        }

        public bool RemoveSupplier(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Suppliers
                        .Single(e => e.Id == id);
                ctx.Suppliers.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
