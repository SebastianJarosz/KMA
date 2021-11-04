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
    public class OrdersMenagmentController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Order, string> _orderRepository;
        private readonly IRepository<MenuPostion, string> _menuPostionRepository;
        private readonly IRepository<OrderToMenuPostion, string> _orderToMenuPostionRepository;
        private readonly IPicker<OrderPostion, string> _orderPostionPicker;
        public OrdersMenagmentController(IMapper mapper, IRepository<Order, string> orderRepository,
            IRepository<OrderToMenuPostion, string> orderToMenuPostionRepository,
            IRepository<MenuPostion, string> menuPostionRepository,
            IPicker<OrderPostion, string> orderPostionPicker)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
            _menuPostionRepository = menuPostionRepository;
            _orderToMenuPostionRepository = orderToMenuPostionRepository;
            _orderPostionPicker = orderPostionPicker;
        }
        // GET: api/<ProductsMenagmentController>/v1/Order/{orderGuid}
        [HttpGet("Order/{orderGuid}")]
        public async Task<Object> GetOrder(string orderGuid)
        {
            try
            {
                var order = await _orderRepository.GetAsync(orderGuid);
                if (order != null)
                {
                    var orderDTO = _mapper.Map<OrderDTO>(order);
                    var orderPostion = await _orderPostionPicker.AsyncGetAllItems(orderDTO.OrderGuid);
                    orderDTO.OrderPostion = orderPostion.ToList();
                    return orderDTO;
                }    
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
        // GET: api/<ProductsMenagmentController>/v1/Orders
        [HttpGet("Orders")]
        public async Task<Object> GetOpenOrders()
        {
            try
            {
                var orderList = await _orderRepository.GetAllAsync();
                if (orderList != null)
                {
                    var orderListDTO = orderList
                        .Select(order => _mapper.Map<OrderDTO>(order))
                        .Where(order => order.Status == Status.Ready.ToString()
                               || order.Status == Status.InProgress.ToString())
                        .OrderBy(order => order.CreationTime)
                        .ToList();

                    foreach (var orderDTO in orderListDTO)
                    {
                        var orderPostion = await _orderPostionPicker.AsyncGetAllItems(orderDTO.OrderGuid);
                        orderDTO.OrderPostion = orderPostion.ToList();
                    }
                    return orderListDTO;
                }
                return StatusCode(204);
            }
            catch(Exception ex)
            {
                return StatusCode(500);
            }
        }
        // GET: api/<ProductsMenagmentController>/v1/ReadyOrders
        [HttpGet("ReadyOrders")]
        public async Task<Object> GetReadyOrders()
        {
            try
            {
                var orderList = await _orderRepository.GetAllAsync();
                if (orderList != null)
                {
                    var orderListDTO = orderList
                        .Select(order => _mapper.Map<OrderDTO>(order))
                        .Where(order => order.Status == Status.Ready.ToString())
                        .OrderByDescending(order => order.ModificationTime)
                        .ToList();

                    foreach (var orderDTO in orderListDTO)
                    {
                        var orderPostion = await _orderPostionPicker.AsyncGetAllItems(orderDTO.OrderGuid);
                        orderDTO.OrderPostion = orderPostion.ToList();
                    }
                    return orderListDTO;
                }
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
        // GET: api/<ProductsMenagmentController>/v1/OrdersInProgress
        [HttpGet("OrdersInProgress")]
        public async Task<Object> GetOrdersInProgres()
        {
            try
            {
                var orderList = await _orderRepository.GetAllAsync();
                if (orderList != null)
                {
                    var orderListDTO = orderList
                        .Select(order => _mapper.Map<OrderDTO>(order))
                        .Where(order => order.Status == Status.InProgress.ToString())
                        .OrderBy(order => order.CreationTime)
                        .ToList();

                    foreach (var orderDTO in orderListDTO)
                    {
                        var orderPostion = await _orderPostionPicker.AsyncGetAllItems(orderDTO.OrderGuid);
                        orderDTO.OrderPostion = orderPostion.ToList();
                    }
                    return orderListDTO;
                }
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
        // GET: api/<ProductsMenagmentController>/v1/ClosedOrders
        [HttpGet("ClosedOrders")]
        public async Task<Object> GetClosedOrders()
        {
            try
            {
                var orderList = await _orderRepository.GetAllAsync();
                if (orderList != null)
                  {
                    var orderListDTO = orderList
                        .Select(order => _mapper.Map<OrderDTO>(order))
                        .Where(order => order.Status == Status.Closed.ToString()
                               || order.Status == Status.Aborted.ToString())
                        .OrderByDescending(order => order.ModificationTime)
                        .ToList();

                    foreach (var orderDTO in orderListDTO)
                    {
                        var orderPostion = await _orderPostionPicker.AsyncGetAllItems(orderDTO.OrderGuid);
                        orderDTO.OrderPostion = orderPostion.ToList();
                    }
                    return orderListDTO;
                }       
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
        // POST api/<ProductsMenagmentController>/v1/AddOrder
        [HttpPost]
        [Route("AddOrder")]
        public async Task<Object> PostAddOrder(List<OrderPostion> orderPostions)
        {
            try
            {
                var result = await _orderRepository.AddAsync(new Order());
                if (result != null)
                {
                    foreach (var item in orderPostions)
                    {
                        if(await _menuPostionRepository.GetAsync(item.MenuPostionCode) == null)
                        {
                            return StatusCode(400);
                        }
                    }
                    foreach (var item in orderPostions)
                    {
                        var orderToMenuPostion = new OrderToMenuPostion();
                        orderToMenuPostion = _mapper.Map<OrderToMenuPostion>(item);
                        orderToMenuPostion.OrderGuid = result.OrderGuid;
                        await _orderToMenuPostionRepository.AddAsync(orderToMenuPostion);
                    }
                    return Ok(result);
                }
                return StatusCode(500);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
        // PUT api/<ProductsMenagmentController>/v1/EditOrder/{orderGuid}
        [HttpPatch]
        [Route("EditOrder/{orderGuid}")]
        public async Task<Object> PutEditOrder(OrderDTO model, string orderGuid)
        {
            try
            {
                var order = await _orderRepository.GetAsync(model.OrderGuid);
                if (order != null)
                {
                    var editOrder = _mapper.Map<Order>(model);
                    editOrder.ModificationTime = DateTime.Now;
                    var updatedOrder = await _orderRepository.UpdateAsync(editOrder, orderGuid);
                    if (updatedOrder != null && model.OrderGuid == orderGuid)
                    {
                        foreach (var orderPostion in await _orderToMenuPostionRepository.FindAllAsync(updatedOrder.OrderGuid))
                        {
                            await _orderToMenuPostionRepository.DeleteAsync(orderPostion);
                        }
                        foreach (var item in model.OrderPostion)
                        {
                            var orderToMenuPostion = new OrderToMenuPostion();
                            orderToMenuPostion = _mapper.Map<OrderToMenuPostion>(item);
                            orderToMenuPostion.OrderGuid = model.OrderGuid;
                            await _orderToMenuPostionRepository.AddAsync(orderToMenuPostion);
                        }
                    }
                    var returnedOrder = await this.GetOrder( orderGuid);
                    return Ok(returnedOrder);
                }
                return StatusCode(409);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
        // PUT api/<ProductsMenagmentController>/v1/ChangeOrderStatusOnReady/{orderGuid}
        [HttpPut]
        [Route("ChangeOrderStatusOnReady/{orderGuid}")]
        public async Task<Object> PutChangeOrderStatusRready(string orderGuid)
        {
            try
            {
                var editOrder = await _orderRepository.GetAsync(orderGuid);
                if (editOrder != null)
                {
                    editOrder.Status = Status.Ready;
                    editOrder.ModificationTime = DateTime.Now;
                    var updatedOrder = await _orderRepository.UpdateAsync(editOrder, orderGuid);
                    return Ok(updatedOrder);
                }
                return StatusCode(409);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
        // PUT api/<ProductsMenagmentController>/v1/ChangeOrderStatusOnClosed/{orderGuid}
        [HttpPut]
        [Route("ChangeOrderStatusOnClosed/{orderGuid}")]
        public async Task<Object> PutChangeOrderStatusOnClosed(string orderGuid)
        {
            try
            {
                var editOrder = await _orderRepository.GetAsync(orderGuid);
                if (editOrder != null)
                {
                    editOrder.Status = Status.Closed;
                    editOrder.ModificationTime = DateTime.Now;
                    var updatedOrder = await _orderRepository.UpdateAsync(editOrder, orderGuid);
                    return Ok(updatedOrder);
                }
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
                var editOrder = await _orderRepository.GetAsync(orderGuid);
                if (editOrder != null)
                {
                    editOrder.Status = Status.Aborted;
                    var updatedOrder = await _orderRepository.UpdateAsync(editOrder, orderGuid);
                    return Ok(updatedOrder);
                }
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
                var editOrder = await _orderRepository.GetAsync(orderGuid);
                if (editOrder != null)
                {
                    editOrder.Status = Status.InProgress;
                    var updatedOrder = await _orderRepository.UpdateAsync(editOrder, orderGuid);
                    return Ok(updatedOrder);
                }
                return StatusCode(409);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
    }
}
