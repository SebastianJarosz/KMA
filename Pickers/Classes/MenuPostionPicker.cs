using AutoMapper;
using KMA.Database;
using KMA.DTOS.OrderManagerDTO;
using KMA.Pickers.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KMA.Pickers.Classes
{
    public class MenuPostionPicker : IPicker<OrderPostion, string>
    {
        private readonly IMapper _mapper;
        protected readonly KMADbContext _context;
        public MenuPostionPicker(IMapper mapper, KMADbContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<ICollection<OrderPostion>> AsyncGetAllItems(string key)
        {
            var postionList = await(from m in _context.OrderToMenuPostion
                                    from p in _context.MenuPostion
                                    where m.OrderGuid == key 
                                    && m.MenuPostionCode == p.MenuPostionCode
                                    select new
                                    {
                                        name = p.Name,
                                        code = p.MenuPostionCode,
                                        quantity = m.QuantityOfMenuPostion,
                                        status = m.IsReady
                                    }).ToListAsync();
            var orderPostionList = postionList.Select(order => new OrderPostion()
            {
                MenuPostionName = order.name,
                MenuPostionCode = order.code,
                QuantityOfMenuPostion = order.quantity,
                IsReady = order.status
            }).ToList();
            return orderPostionList;
        }

        public Task<OrderPostion> AsyncGetItem(string key)
        {
            throw new NotImplementedException();
        }
    }
}
