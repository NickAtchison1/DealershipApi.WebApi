using DealershipApi.Data.DataModels;
using DealershipApi.Models.DisplayModels.Dealership;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealershipApi.Services.Services
{
    public class InventoryListItemService
    {
        private readonly string _userId;
        public InventoryListItemService(string userId)
        {
            _userId = userId;
        }
        public IEnumerable<InventoryListItem> GetInventoryInStock()
        {
            using (var ctx = new ApplicationDbContext()) 
            {                             
                var query = ctx.Vehicles.Select(
                    s => new InventoryListItem
                    {
                        VehicleId = s.Id,
                        VehicleName = s.VehicleName,
                        DealershipLocation = s.Dealership.Name,
                        InStock = s.InStock

                    }).Where(i => i.InStock == true);

               return query.ToList();            
                
            }            
        }

        public IEnumerable<InventoryListItem> GetInventoryNotInStock()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Vehicles.Select(
                    s => new InventoryListItem
                    {
                        VehicleId = s.Id,
                        VehicleName = s.VehicleName,
                        DealershipLocation = s.Dealership.Name,
                        InStock = s.InStock

                    }).Where(i => i.InStock == false);

                return query.ToList();
            }
        }

        public IEnumerable<InventoryListItem> GetInventoryAllAvailableStock()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Vehicles.Select(
                    s => new InventoryListItem
                    {
                        VehicleId = s.Id,
                        VehicleName = s.VehicleName,
                        DealershipLocation = s.Dealership.Name,
                        InStock = s.InStock

                    });

                return query.ToList();
            }
        }
    }
}
