using System.Collections.Generic;
using Model = StoreModel;
using Entity = StoreData.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using StoreModel;
using System;

namespace StoreData
{
    public class OrderItemRepoDB : IOrderItemRepoDB
    {

        private Entity.P0Context _context;

        private IMapper _mapper;

        public OrderItemRepoDB(Entity.P0Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        public void AddOrderItem(OrderItem newOrderItem)
        {
            _context.Orderitems.Add(_mapper.ParseOrderItem(newOrderItem));
            _context.SaveChanges();
        }

        public List<OrderItem> GetOrderItems(int orderID)
        {
            List<Entity.Orderitem> orderitemsE = _context.Orderitems.Where(x => x.OrderId == orderID ).ToList();
            List<Model.OrderItem> orderitemsM = new List<Model.OrderItem>();
            foreach(Entity.Orderitem o in orderitemsE){
                Model.OrderItem addedItem = _mapper.ParseOrderItem(o);
                orderitemsM.Add(addedItem);
            }
            return orderitemsM;
        }
    }
}