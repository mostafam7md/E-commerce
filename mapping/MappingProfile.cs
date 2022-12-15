using AutoMapper;
using ECommerce.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.mapping
{
    
        public class MappingProfile : Profile
        {
            public MappingProfile()
            {
                CreateMap<CustomerRegister, Customer>();
                CreateMap<NewProduct, Product>();
               CreateMap<VendorRegister, Vendor>();
            CreateMap<OrderItemDto, OrderItem>(); 
            CreateMap<OrderDTO, Order>(); 

            }
    }
    
}
