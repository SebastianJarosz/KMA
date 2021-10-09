using AutoMapper;
using KMA.DTOS.OrderManagerDTO;
using KMA.Models.OrderManager;
using KMA.Models.ProductManager;
using KMA.Pickers.Interfaces;
using KMA.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KMA.Controllers
{
    [Route("api/[controller]/v1")]
    [ApiController]
    public class StocksMenagmentController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Order, string> _orderRepository;

        public StocksMenagmentController(IMapper mapper, 
            IRepository<Order, string> orderRepository)
        {
            _mapper = mapper;
        }
        // GET: api/<StocksMenagmentController>/v1/Stocks
        [HttpGet("Stocks")]
        public async Task<Object> GetStocks()
        {
            try
            {
                return StatusCode(204);
            }
            catch(Exception ex)
            {
                return StatusCode(500);
            }
        }
        // GET: api/<ProductsMenagmentController>/v1/ClosedOrders
        [HttpGet("")]
        public async Task<Object> GetClosedOrders()
        {
            try
            {
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
        // POST api/<ProductsMenagmentController>/v1/AddOrder
        [HttpPost]
        [Route("AddProductStock")]
        public async Task<Object> PostAddOrder(List<OrderPostion> orderPostions)
        {
            try
            {
                return StatusCode(500);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
        // PUT api/<ProductsMenagmentController>/v1/EditOrder/{orderGuid}
        [HttpPut]
        [Route("")]
        public async Task<Object> PutEditOrder(OrderDTO model, string orderGuid)
        {
            try
            {
                return StatusCode(409);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
        // PUT api/<ProductsMenagmentController>/v1/ChangeOrderStatusOnClosed/{orderGuida
        [HttpPut]
        [Route("ChangeOrderStatusOnClosed/{orderGuid}")]
        public async Task<Object> PutChangeOrderStatusOnClosed(string orderGuid)
        {
            try
            {
                return StatusCode(409);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
        // PUT api/<ProductsMenagmentController>/v1/ChangeOrderStatusOnAborted/{orderGuid}
        [HttpPut]
        [Route("ChangeOrderStatusOnAborted/{orderGuid}")]
        public async Task<Object> PutChangeOrderStatusOnAborted(string orderGuid)
        {
            try
            {
                return StatusCode(409);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
        // PUT api/<ProductsMenagmentController>/v1/ChangeOrderStatusOnActive/{orderGuid}
        [HttpPut]
        [Route("ChangeOrderStatusOnActive/{orderGuid}")]
        public async Task<Object> PutChangeOrderStatusOnActive(string orderGuid)
        {
            try
            {
                return StatusCode(409);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
    }
}
