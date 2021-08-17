using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KMA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsMenagmentController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Product, string> _productRepository;
        private readonly IRepository<MenuPostion, string> _menuPostionRepository;
        private readonly IRepository<MenuPostionToProduct, string> _menuPostion_ProductRepository;

        public ProductsMenagmentController(IMapper mapper, IRepository<Product, string> productRepository,
            IRepository<MenuPostion, string> menuPostionRepository,
            IRepository<MenuPostionProduct, string> menuPostionToProductRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
            _menuPostionRepository = menuPostionRepository;
            _menuPostion_ProductRepository = menuPostionToProductRepository;
        }

        // GET: api/<ProductsMenagmentController>/Products
        [HttpGet("Products")]
        public async Task<Object> GetProducts()
        {
            var productsList = await _productRepository.GetAllAsync();

            if (productsList != null)
            {
                var productslistDTO = productsList.Select(product => _mapper.Map<ProductDTO>(product)).OrderBy(product => product.Name).ToList();
                return productslistDTO;
            }
            return StatusCode(404);
        }
        // GET: api/<ProductsMenagmentController>/MenuPostions
        [HttpGet("MenuPostions")]
        public async Task<Object> GetMenuPostions()
        {
            var menuPostionsList = await _menuPostionRepository.GetAllAsync();

            if (menuPostionsList != null)
            {
                var menuPostionsListDTO = menuPostionsList
                    .Select(menuPostion => _mapper.Map<MenuPostionDTO>(menuPostion))
                    .OrderBy(menuPostion => menuPostion.Name).ToList();
                foreach (var menuPostion in menuPostionsListDTO)
                {
                    var ingirdientsList = await _menuPostion_ProductRepository
                        .GetAllAsync(menuPostion.MenuPostionCode);                   
                    menuPostion.Products = ingirdientsList.Select(ingirdient => _mapper
                        .Map<MenuPostionDTO.ProductsList>(ingirdient)).ToList();
                    foreach (var item in menuPostion.Products)
                    {
                        var product = await _productRepository.GetAsync(item.ProductCode);
                        if(product != null)
                        {
                            item.ProductName = product.Name;
                        }   
                    }
                }
                return menuPostionsListDTO;
            }
            return StatusCode(404);
        }
        // GET: api/<ProductsMenagmentController>/SetMenuPostions
        [HttpGet("SetMenuPostions")]
        public async Task<Object> GetSetMenuPostions()
        {
            var setMenuPostionsList = await _setMenuPostionRepository.GetAllAsync();

            if (setMenuPostionsList != null)
            {
                var setMenuPostionsListDTO = setMenuPostionsList
                    .Select(setMenuPostion => _mapper.Map<SetMenuPostionDTO>(setMenuPostion))
                    .OrderBy(setMenuPostion => setMenuPostion.Name).ToList();
                foreach (var setMenuPostion in setMenuPostionsListDTO)
                {
                    var ingirdientsList = await _setMenuPostion_MenuPostionRepository
                        .GetAllAsync(setMenuPostion.SetMenuPostionCode);
                    setMenuPostion.MenuPostions = ingirdientsList.Select(ingirdient => _mapper
                        .Map<SetMenuPostionDTO.MenuPostionsList>(ingirdient)).ToList();
                    foreach (var item in setMenuPostion.MenuPostions)
                    {
                        var menuPostions = await _menuPostionRepository.GetAsync(item.MenuPostionCode);
                        if (menuPostions != null)
                        {
                            item.MenuPostionName = menuPostions.Name;
                        }  
                    }
                }
                return setMenuPostionsListDTO;
            }
            return StatusCode(404);
        }
        // GET: api/<ProductsMenagmentController>/Products/Product/{ProductCode}
        [HttpGet("Products/Product/{ProductCode}")]
        public async Task<Object> GetProduct(string ProductCode) 
        {
            var product = await _productRepository.GetAsync(ProductCode);

            if (product != null)
            {
                var productDTO = _mapper.Map<ProductDTO>(product);
                return productDTO;
            }
            return StatusCode(404);
        }
        // GET: api/<ProductsMenagmentController>/MenuPostions/MenuPostion/{MenuPostionCode}
        [HttpGet("MenuPostions/MenuPostion/{MenuPostionCode}")]
        public async Task<Object> GetMenuPostion(string MenuPostionCode)
        {
            var menuPostion = await _menuPostionRepository.GetAsync(MenuPostionCode);

            if (menuPostion != null)
            {
                var menuPostionsDTO =  _mapper.Map<MenuPostionDTO>(menuPostion);
                var ingirdientsList = await _menuPostion_ProductRepository.GetAllAsync(menuPostion.MenuPostionCode);
                menuPostionsDTO.Products = ingirdientsList
                    .Select(ingirdient => _mapper.Map<MenuPostionDTO.ProductsList>(ingirdient)).ToList();
                foreach (var item in menuPostionsDTO.Products)
                {
                    var product = await _productRepository.GetAsync(item.ProductCode);
                    if (product != null)
                    {
                        item.ProductName = product.Name;
                    }
                }
                return menuPostionsDTO;
            }
            return StatusCode(404);
        }
        // GET: api/<ProductsMenagmentController>/SetMenuPostions/SetMenuPostion/{SetMenuPostionCode}
        [HttpGet("SetMenuPostions/SetMenuPostion/{SetMenuPostionCode}")]
        public async Task<Object> GetSetMenuPostion(string SetMenuPostionCode)
        {
            var setMenuPostion = await _setMenuPostionRepository.GetAsync(SetMenuPostionCode);

            if (setMenuPostion != null)
            {
                var setMenuPostionDTO = _mapper.Map<SetMenuPostionDTO>(setMenuPostion);
                var ingirdientsList = await _setMenuPostion_MenuPostionRepository
                    .GetAllAsync(setMenuPostion.SetMenuPostionCode);
                setMenuPostionDTO.MenuPostions = ingirdientsList.Select(ingirdient => _mapper
                        .Map<SetMenuPostionDTO.MenuPostionsList>(ingirdient)).ToList();
                foreach (var item in setMenuPostionDTO.MenuPostions)
                {
                    var menuPostions = await _menuPostionRepository.GetAsync(item.MenuPostionCode);
                    if (menuPostions != null)
                    {
                        item.MenuPostionName = menuPostions.Name;
                    }
                }
                return setMenuPostionDTO;
            }
            return StatusCode(404);
        }
        // POST api/<ProductsMenagmentController>/AddProduct
        [HttpPost]
        [Route("AddProduct")]
        public async Task<Object> PostProduct(ProductDTO model)
        {
            var setMenuPostion = await _setMenuPostionRepository.GetAsync(model.ProductCode);
            var menuPostion = await _menuPostionRepository.GetAsync(model.ProductCode);
            var product = await _productRepository.GetAsync(model.ProductCode);
            if (setMenuPostion == null && menuPostion == null && product == null)
            {
                product = _mapper.Map<Product>(model);
                try
                {
                    var itemsModyficationHistory = _mapper.Map<ItemsModyficationHistory>(product);
                    await _itemsModyficationHistoryRepository.AddAsync(itemsModyficationHistory);
                    var result = await _productRepository.AddAsync(product);
                    return Ok(result);
                }
                catch (Exception ex)
                {
                    return ex.ToString();
                }
            }
            return StatusCode(409);
        }
        // POST api/<ProductsMenagmentController>/AddMenuPostion
        [HttpPost]
        [Route("AddMenuPostion")]
        public async Task<Object> PostMenuPostion(MenuPostionDTO model)
        {
            var setMenuPostion = await _setMenuPostionRepository.GetAsync(model.MenuPostionCode);
            var menuPostion = await _menuPostionRepository.GetAsync(model.MenuPostionCode);
            var product = await _productRepository.GetAsync(model.MenuPostionCode);
            if (setMenuPostion == null && menuPostion == null && product == null)
            {
                menuPostion = _mapper.Map<MenuPostion>(model);
                try
                {
                    var itemsModyficationHistory = _mapper.Map<ItemsModyficationHistory>(menuPostion);
                    await _itemsModyficationHistoryRepository.AddAsync(itemsModyficationHistory);
                    var result = await _menuPostionRepository.AddAsync(menuPostion);
                    if (result != null)
                    {
                        foreach (var item in model.Products)
                        {
                            var menuPostion_Product = new MenuPostion_Product();
                            menuPostion_Product = _mapper.Map<MenuPostion_Product>(item);
                            menuPostion_Product.MenuPostionCode = model.MenuPostionCode;
                            await _menuPostion_ProductRepository.AddAsync(menuPostion_Product);
                        }
                    }
                    return Ok(result);
                }
                catch (Exception ex)
                {
                    return ex.ToString();
                }
            }
            return StatusCode(409);
           
        }
        // POST api/<ProductsMenagmentController>/AddSetMenuPostion
        [HttpPost]
        [Route("AddSetMenuPostion")]
        public async Task<Object> PostSetMenuPostion(SetMenuPostionDTO model)
        {
            var setMenuPostion = await _setMenuPostionRepository.GetAsync(model.SetMenuPostionCode);
            var menuPostion = await _menuPostionRepository.GetAsync(model.SetMenuPostionCode);
            var product = await _productRepository.GetAsync(model.SetMenuPostionCode);
            if (setMenuPostion == null && menuPostion == null && product == null)
            {
                setMenuPostion = _mapper.Map<SetMenuPostion>(model);
                try
                {
                    var itemsModyficationHistory = _mapper.Map<ItemsModyficationHistory>(setMenuPostion);
                    await _itemsModyficationHistoryRepository.AddAsync(itemsModyficationHistory);
                    var result = await _setMenuPostionRepository.AddAsync(setMenuPostion);
                    if (result != null)
                    {
                        foreach (var item in model.MenuPostions)
                        {
                            var setMenuPostion_MenuPostion = new SetMenuPostion_MenuPostion();
                            setMenuPostion_MenuPostion = _mapper.Map<SetMenuPostion_MenuPostion>(item);
                            setMenuPostion_MenuPostion.SetMenuPostionCode = model.SetMenuPostionCode;
                            await _setMenuPostion_MenuPostionRepository.AddAsync(setMenuPostion_MenuPostion);
                        }
                    }
                    return Ok(result);
                }
                catch (Exception ex)
                {
                    return ex.ToString();
                }
            }
            return StatusCode(409);
        }
        // PUT api/<ProductsMenagmentController>/EditProduct/{ProductCode}
        [HttpPut]
        [Route("EditProduct/{ProductCode}")]
        public async Task<Object> PutProduct(ProductDTO model, string ProductCode)
        {
            var setMenuPostion = await _setMenuPostionRepository.GetAsync(model.ProductCode);
            var menuPostion = await _menuPostionRepository.GetAsync(model.ProductCode);
            var product = await _productRepository.GetAsync(model.ProductCode);
            if ((setMenuPostion == null && menuPostion == null && product == null) || model.ProductCode == ProductCode)
            {
                var editProduct = _mapper.Map<Product>(model);
                try
                {
                    var productDTO = await GetProduct(ProductCode);
                    var json = Newtonsoft.Json.JsonConvert.SerializeObject(productDTO);
                    var itemsModyficationHistory = _mapper.Map<ItemsModyficationHistory>(editProduct);
                    itemsModyficationHistory.OldItem = json;
                    await _itemsModyficationHistoryRepository.AddAsync(itemsModyficationHistory);
                    var result = await _productRepository.UpdateAsync(editProduct, ProductCode);
                    return Ok(result);
                }
                catch (Exception ex)
                {
                    return ex.ToString();
                }
            }
            return StatusCode(409);
        }
        // PUT api/<ProductsMenagmentController>/EditMenuPostion/{MenuPostionCode}
        [HttpPut]
        [Route("EditMenuPostion/{MenuPostionCode}")]
        public async Task<Object> PutMenuPostion(MenuPostionDTO model, string MenuPostionCode)
        {
            var setMenuPostion = await _setMenuPostionRepository.GetAsync(model.MenuPostionCode);
            var menuPostion = await _menuPostionRepository.GetAsync(model.MenuPostionCode);
            var product = await _productRepository.GetAsync(model.MenuPostionCode);
            if ((setMenuPostion == null && menuPostion == null && product == null) || model.MenuPostionCode == MenuPostionCode)
            {
                var editMenuPostion = _mapper.Map<MenuPostion>(model);
                try
                {
                    var menuPostionDTO = await GetMenuPostion(MenuPostionCode);
                    var json = Newtonsoft.Json.JsonConvert.SerializeObject(menuPostionDTO);
                    var itemsModyficationHistory = _mapper.Map<ItemsModyficationHistory>(editMenuPostion);
                    itemsModyficationHistory.OldItem = json;
                    await _itemsModyficationHistoryRepository.AddAsync(itemsModyficationHistory);
                    var result = await _menuPostionRepository.UpdateAsync(editMenuPostion, MenuPostionCode);
                    if (result != null)
                    {
                        var ingirdientsList = await _menuPostion_ProductRepository.GetAllAsync(editMenuPostion.MenuPostionCode);
                        foreach (var ingirdient in ingirdientsList)
                        {
                            await _menuPostion_ProductRepository.DeleteAsync(ingirdient);
                        }
                        foreach (var item in model.Products)
                        {
                            var menuPostion_Product = new MenuPostion_Product();
                            menuPostion_Product = _mapper.Map<MenuPostion_Product>(item);
                            menuPostion_Product.MenuPostionCode = model.MenuPostionCode;
                            await _menuPostion_ProductRepository.AddAsync(menuPostion_Product);
                        }
                    }
                    return Ok(result);
                }
                catch (Exception ex)
                {
                    return ex.ToString();
                }
            }
            return StatusCode(409);
        }
        // PUT api/<ProductsMenagmentController>/EditSetMenuPostion/{SetMenuPostionCode}
        [HttpPut]
        [Route("EditSetMenuPostion/{SetMenuPostionCode}")]
        public async Task<Object> PutSetMenuPostion(SetMenuPostionDTO model, string SetMenuPostionCode)
        {
            var setMenuPostion = await _setMenuPostionRepository.GetAsync(model.SetMenuPostionCode);
            var menuPostion = await _menuPostionRepository.GetAsync(model.SetMenuPostionCode);
            var product = await _productRepository.GetAsync(model.SetMenuPostionCode);
            if ((setMenuPostion == null && menuPostion == null && product == null) || model.SetMenuPostionCode == SetMenuPostionCode)
            {
                var editSetMenuPostion = _mapper.Map<SetMenuPostion>(model);
                try
                {
                    var setMenuPostionDTO = await GetSetMenuPostion(SetMenuPostionCode);
                    var json = Newtonsoft.Json.JsonConvert.SerializeObject(setMenuPostionDTO);
                    var itemsModyficationHistory = _mapper.Map<ItemsModyficationHistory>(editSetMenuPostion);
                    itemsModyficationHistory.OldItem = json;
                    await _itemsModyficationHistoryRepository.AddAsync(itemsModyficationHistory);
                    var result = await _setMenuPostionRepository.UpdateAsync(editSetMenuPostion, SetMenuPostionCode);
                    if (result != null)
                    {
                        var ingirdientsList = await _setMenuPostion_MenuPostionRepository.GetAllAsync(editSetMenuPostion.SetMenuPostionCode);
                        foreach (var ingirdient in ingirdientsList)
                        {
                            await _setMenuPostion_MenuPostionRepository.DeleteAsync(ingirdient);
                        }
                        foreach (var item in model.MenuPostions)
                        {
                            var setMenuPostion_MenuPostion = new SetMenuPostion_MenuPostion();
                            setMenuPostion_MenuPostion = _mapper.Map<SetMenuPostion_MenuPostion>(item);
                            setMenuPostion_MenuPostion.SetMenuPostionCode = model.SetMenuPostionCode;
                            await _setMenuPostion_MenuPostionRepository.AddAsync(setMenuPostion_MenuPostion);
                        }
                    }
                    return Ok(result);
                }
                catch (Exception ex)
                {
                    return ex.ToString();
                }
            }
            return StatusCode(409);
        }
        // DELETE: api/<ProductsMenagmentController>/DeleteProduct/{ProductCode}
        [HttpDelete("DeleteProduct/{ProductCode}")]
        public async Task<Object> DeleteProduct(string ProductCode)
        {
            try
            {
                var product = await _productRepository.GetAsync(ProductCode);

                if (product != null)
                {
                    var productDTO = await GetProduct(ProductCode);
                    var json = Newtonsoft.Json.JsonConvert.SerializeObject(productDTO);
                    var itemsModyficationHistory = _mapper.Map<ItemsModyficationHistory>(product);
                    itemsModyficationHistory.OldItem = json;
                    var result = await _productRepository.DeleteAsync(product);
                    return Ok(result);
                }
                return StatusCode(409);
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        // DELETE: api/<ProductsMenagmentController>/DeleteMenuPostion/{MenuPostionCode}
        [HttpDelete]
        [Route("DeleteMenuPostion/{MenuPostionCode}")]
        public async Task<Object> DeleteMenuPostion(string MenuPostionCode)
        {
            try
            {
                var menuPostion = await _menuPostionRepository.GetAsync(MenuPostionCode);

                if (menuPostion != null)
                {
                    var menuPostionDTO = await GetMenuPostion(MenuPostionCode);
                    var json = Newtonsoft.Json.JsonConvert.SerializeObject(menuPostionDTO);
                    var itemsModyficationHistory = _mapper.Map<ItemsModyficationHistory>(menuPostion);
                    itemsModyficationHistory.OldItem = json;
                    var ingirdientsList = await _menuPostion_ProductRepository.GetAllAsync(menuPostion.MenuPostionCode);
                    foreach (var ingirdient in ingirdientsList)
                    {
                        await _menuPostion_ProductRepository.DeleteAsync(ingirdient);
                    }
                    var result = await _menuPostionRepository.DeleteAsync(menuPostion);
                    return Ok(result);
                }
                return StatusCode(404);
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        // DELETE: api/<ProductsMenagmentController>/DeleteMenuPostion/{SetMenuPostionCode}
        [HttpDelete]
        [Route("DeleteSetMenuPostion/{SetMenuPostionCode}")]
        public async Task<Object> DeleteSetMenuPostion(string SetMenuPostionCode)
        {
            try
            {
                var setMenuPostion = await _setMenuPostionRepository.GetAsync(SetMenuPostionCode);

                if (setMenuPostion != null)
                {
                    var setMenuPostionDTO = await GetSetMenuPostion(SetMenuPostionCode);
                    var json = Newtonsoft.Json.JsonConvert.SerializeObject(setMenuPostionDTO);
                    var itemsModyficationHistory = _mapper.Map<ItemsModyficationHistory>(setMenuPostion);
                    itemsModyficationHistory.OldItem = json;
                    var ingirdientsList = await _setMenuPostion_MenuPostionRepository.GetAllAsync(setMenuPostion.SetMenuPostionCode);
                    foreach (var ingirdient in ingirdientsList)
                    {
                        await _setMenuPostion_MenuPostionRepository.DeleteAsync(ingirdient);
                    }
                    var result = await _setMenuPostionRepository.DeleteAsync(setMenuPostion);
                    return Ok(result);
                }
                return StatusCode(404);
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
    }
}
