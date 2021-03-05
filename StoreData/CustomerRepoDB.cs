using System.Collections.Generic;
using Model = StoreModel;
using Entity = StoreData.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using StoreModel;

namespace StoreData
{

    public class CustomerRepoDB : ICustomerRepository
    {
        private Entity.P0Context _context;
        private IMapper _mapper;

        public CustomerRepoDB(Entity.P0Context context, IMapper mapper){
            _context = context;
            _mapper = mapper;
        }
        public Model.Customer AddCustomer(Model.Customer newCustomer)
        {
            _context.Customers.Add(_mapper.ParseCustomer(newCustomer));
            _context.SaveChanges();
            return newCustomer;
        }

        public List<Model.Customer> GetCustomers()
        {
            //CONTINUE HERE
            return _context.Customers.Select(x => _mapper.ParseCustomer(x)).ToList();
        }


    }
}