using AutoMapper;
using KMA.DTOS.ProductManager;
using KMA.Models.ProductManager;
using KMA.Pickers.Interfaces;
using KMA.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KMA.Controllers
{
    [Route("api/[controller]/v1")]
    [ApiController]
    public class ProductsMenagmentController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Product, string> _productRepository;
        private readonly IRepository<MenuPostion, string> _menuPostionRepository;
        private readonly IRepository<MenuPostionToProduct, string> _menuPostionToProductRepository;
        private readonly IPicker<Igridient, string> _productPicker;

        public ProductsMenagmentController(IMapper mapper,
            IRepository<Product, string> productRepository,
            IRepository<MenuPostion, string> menuPostionRepository,
            IRepository<MenuPostionToProduct, string> menuPostionToProductRepository,
            IPicker<Igridient, string> productPicker)
        {
            _mapper = mapper;
            _productRepository = productRepository;
            _menuPostionRepository = menuPostionRepository;
            _menuPostionToProductRepository = menuPostionToProductRepository;
            _productPicker = productPicker;
        }

        // GET: api/<ProductsMenagmentController>/v1/Products
        [HttpGet("Products")]
        [Authorize]
        public async Task<Object> GetProducts()
        {
            string userId = User.Claims.First(c => c.Type == "UserID").Value;
            if(userId != "") {
                try
                {
                    var productsList = await _productRepository.GetAllAsync();
                    if (productsList != null)
                    {
                        var productsListDTO = productsList
                            .Select(product => _mapper.Map<ProductDTO>(product))
                            .OrderBy(product => product.Name)
                            .ToList();
                        return productsListDTO;
                    }
                    return StatusCode(204);
                }
                catch (Exception ex)
                {
                    return StatusCode(500);
                }
            }
            return StatusCode(403);
        }
        // GET: api/<ProductsMenagmentController>/v1/MenuPostions
        [HttpGet("MenuPostions")]
        [Authorize]
        public async Task<Object> GetMenuPostions()
        {
            string userId = User.Claims.First(c => c.Type == "UserID").Value;
            if (userId != "")
            {
                try
                {
                    var menuPostionsList = await _menuPostionRepository.GetAllAsync();

                    if (menuPostionsList != null)
                    {
                        var menuPostionsListDTO = menuPostionsList
                            .Select(menuPostion => _mapper.Map<MenuPostionDTO>(menuPostion))
                            .OrderBy(menuPostion => menuPostion.Name)
                            .ToList();

                        foreach (var menuPostionDTO in menuPostionsListDTO)
                        {
                            var products = await _productPicker.AsyncGetAllItems(menuPostionDTO.MenuPostionCode);
                            menuPostionDTO.Products = products.Select(product => _mapper
                                                  .Map<MenuPostionDTO.ProductsList>(product))
                                                   .ToList();
                        }
                        return menuPostionsListDTO;
                    }
                    return StatusCode(204);
                }
                catch (Exception ex)
                {
                    return StatusCode(500);
                }
            }
            return StatusCode(403);
        }
        // GET: api/<ProductsMenagmentController>/v1/Products/Product/{ProductCode}
        [HttpGet("Products/Product/{ProductCode}")]
        [Authorize]
        public async Task<Object> GetProduct(string ProductCode)
        {
            string userId = User.Claims.First(c => c.Type == "UserID").Value;
            if (userId != "")
            {
                try
                {
                    var product = await _productRepository.GetAsync(ProductCode);
                    if (product != null)
                    {
                        var productDTO = _mapper.Map<ProductDTO>(product);
                        return productDTO;
                    }
                    return StatusCode(404);
                }
                catch (Exception ex)
                {
                    return StatusCode(500);
                }
            }
            return StatusCode(403);
        }
        // GET: api/<ProductsMenagmentController>/v1/MenuPostions/MenuPostion/{MenuPostionCode}
        [HttpGet("MenuPostions/MenuPostion/{MenuPostionCode}")]
        [Authorize]
        public async Task<Object> GetMenuPostion(string MenuPostionCode)
        {
            string userId = User.Claims.First(c => c.Type == "UserID").Value;
            if (userId != "")
            {
                try 
                { 
                    var menuPostion = await _menuPostionRepository.GetAsync(MenuPostionCode);

                    if (menuPostion != null)
                    {
                        var menuPostionDTO = _mapper.Map<MenuPostionDTO>(menuPostion);
                        var products = await _productPicker.AsyncGetAllItems(menuPostion.MenuPostionCode);
                        menuPostionDTO.Products = products.Select(product => _mapper
                                              .Map<MenuPostionDTO.ProductsList>(product))
                                               .ToList();
                        return menuPostionDTO;
                    }
                    return StatusCode(404);
                }
                catch(Exception ex)
                {
                    return StatusCode(500);
                }
            }
            return StatusCode(403);
        }
    
        // POST api/<ProductsMenagmentController>/v1/AddProduct
        [HttpPost]
        [Route("AddProduct")]
        [Authorize]
        public async Task<Object> PostProduct(ProductDTO model)
        {
            string userId = User.Claims.First(c => c.Type == "UserID").Value;
            if (userId != "")
            {
                try
                {
                    var menuPostion = await _menuPostionRepository.GetAsync(model.ProductCode);
                    var product = await _productRepository.GetAsync(model.ProductCode);
                    if (menuPostion == null && product == null)
                    {
                        product = _mapper.Map<Product>(model);
                        return Ok(await _productRepository.AddAsync(product));
                    }
                    return StatusCode(409);
                }
                catch (Exception ex)
                {
                    return StatusCode(500);
                }
            }
            return StatusCode(403);
        }
        // POST api/<ProductsMenagmentController>/v1/AddMenuPostion
        [HttpPost]
        [Route("AddMenuPostion")]
        [Authorize]
        public async Task<Object> PostAddMenuPostion(MenuPostionDTO model)
        {
            string userId = User.Claims.First(c => c.Type == "UserID").Value;
            if (userId != "")
            {
                try
                {
                    var menuPostion = await _menuPostionRepository.GetAsync(model.MenuPostionCode);
                    var product = await _productRepository.GetAsync(model.MenuPostionCode);
                    if (menuPostion == null && product == null)
                    {
                        menuPostion = _mapper.Map<MenuPostion>(model);
                        try
                        {
                            var result = await _menuPostionRepository.AddAsync(menuPostion);
                            if (result != null)
                            {
                                foreach (var item in model.Products)
                                {
                                    var menuPostionToProduct = new MenuPostionToProduct();
                                    menuPostionToProduct = _mapper.Map<MenuPostionToProduct>(item);
                                    menuPostionToProduct.MenuPostionCode = model.MenuPostionCode;
                                    await _menuPostionToProductRepository.AddAsync(menuPostionToProduct);
                                }
                            }
                            return Ok(result);
                        }
                        catch (Exception ex)
                        {
                            return StatusCode(500);
                        }
                    }
                    return StatusCode(409);
                }
                catch(Exception ex)
                {
                    return StatusCode(500);
                }
            }
            return StatusCode(403);
        }
        // PUT api/<ProductsMenagmentController>/v1/EditProduct/{ProductCode}
        [HttpPut]
        [Route("EditProduct/{ProductCode}")]
        [Authorize]
        public async Task<Object> PutProduct(ProductDTO model, string ProductCode)
        {
            string userId = User.Claims.First(c => c.Type == "UserID").Value;
            if (userId != "")
            {
                try
                {
                    var menuPostion = await _menuPostionRepository.GetAsync(model.ProductCode);
                    var product = await _productRepository.GetAsync(model.ProductCode);
                    if ((menuPostion == null && product == null) || model.ProductCode == ProductCode)
                    {
                        var editProduct = _mapper.Map<Product>(model);
                        var productDTO = await GetProduct(ProductCode);
                        var result = await _productRepository.UpdateAsync(editProduct, ProductCode);
                        return Ok(result);
                    }
                    return StatusCode(409);
                }
                catch (Exception ex)
                {
                    return StatusCode(500);
                }
            }
            return StatusCode(403);
        }
        // PUT api/<ProductsMenagmentController>/v1/EditMenuPostion/{menuPostionCode}
        [HttpPut]
        [Route("EditMenuPostion/{menuPostionCode}")]
        [Authorize]
        public async Task<Object> PutMenuPostion(MenuPostionDTO model, string menuPostionCode)
        {
            string userId = User.Claims.First(c => c.Type == "UserID").Value;
            if (userId != "")
            {
                try
                {
                    var menuPostion = await _menuPostionRepository.GetAsync(model.MenuPostionCode);
                    var product = await _productRepository.GetAsync(model.MenuPostionCode);
                    if ((menuPostion != null && product == null) && model.MenuPostionCode == menuPostionCode)
                    {
                        var editMenuPostion = _mapper.Map<MenuPostion>(model);
                        try
                        {
                            var updatedMenuPostion = await _menuPostionRepository.UpdateAsync(editMenuPostion, menuPostionCode);
                            if (updatedMenuPostion != null)
                            {
                                foreach (var ingirdient in await _menuPostionToProductRepository.FindAllAsync(updatedMenuPostion.MenuPostionCode))
                                {
                                    await _menuPostionToProductRepository.DeleteAsync(ingirdient);
                                }
                                foreach (var item in model.Products)
                                {
                                    var menuPostionToProduct = new MenuPostionToProduct();
                                    menuPostionToProduct = _mapper.Map<MenuPostionToProduct>(item);
                                    menuPostionToProduct.MenuPostionCode = model.MenuPostionCode;
                                    await _menuPostionToProductRepository.AddAsync(menuPostionToProduct);
                                }
                            }
                            return Ok(updatedMenuPostion);
                        }
                        catch (Exception ex)
                        {
                            return StatusCode(500);
                        }
                    }
                    return StatusCode(409);
                }
                catch (Exception ex)
                {
                    return StatusCode(500);
                }
            }
            return StatusCode(403);
        }
        // DELETE: api/<ProductsMenagmentController>/v1/DeleteProduct/{ProductCode}
        [HttpDelete("DeleteProduct/{ProductCode}")]
        [Authorize]
        public async Task<Object> DeleteProduct(string ProductCode)
        {
            string userId = User.Claims.First(c => c.Type == "UserID").Value;
            if (userId != "")
            {
                try
                {
                    var product = await _productRepository.GetAsync(ProductCode);
                    if (product != null)
                    {
                        await _productRepository.DeleteAsync(product);
                        var menuPostionToProductList = (from x in await _menuPostionToProductRepository.GetAllAsync()
                                                       where x.ProductCode == product.ProductCode
                                                       select x).ToList();

                        foreach(var menuPostionToProduct in menuPostionToProductList)
                        {
                            await _menuPostionToProductRepository.DeleteAsync(menuPostionToProduct);
                        }
                        return StatusCode(204);
                    }
                    return StatusCode(409);
                }
                catch (Exception ex)
                {
                    return StatusCode(500);
                }
            }
            return StatusCode(403);
        }
        // DELETE: api/<ProductsMenagmentController>/v1/DeleteMenuPostion/{MenuPostionCode}
        [HttpDelete]
        [Route("DeleteMenuPostion/{MenuPostionCode}")]
        [Authorize]
        public async Task<Object> DeleteMenuPostion(string MenuPostionCode)
        {
            string userId = User.Claims.First(c => c.Type == "UserID").Value;
            if (userId != "")
            {
                try
                {
                    var menuPostion = await _menuPostionRepository.GetAsync(MenuPostionCode);
                    if (menuPostion != null)
                    {
                        foreach (var ingirdient in await _menuPostionToProductRepository.FindAllAsync(menuPostion.MenuPostionCode))
                        {
                            await _menuPostionToProductRepository.DeleteAsync(ingirdient);
                        }

                        await _menuPostionRepository.DeleteAsync(menuPostion);
                        return StatusCode(204);
                    }
                    return StatusCode(404);
                }
                catch (Exception ex)
                {
                    return StatusCode(500);
                }
            }
            return StatusCode(403);
        }
    }
}
