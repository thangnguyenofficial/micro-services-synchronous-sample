using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ThangNguyen.GlobalTicket.Client.Code;
using ThangNguyen.GlobalTicket.Client.Code.Extensions;
using ThangNguyen.GlobalTicket.Client.Models.Api;
using ThangNguyen.GlobalTicket.Client.Models.ShoppingBasket;
using ThangNguyen.GlobalTicket.Client.Services;

namespace ThangNguyen.GlobalTicket.Client.Controllers
{
    public class ShoppingBasketController : Controller
    {
        private readonly IShoppingBasketService _shoppingBasketService;
        private readonly Settings _settings;
        private IMapper _mapper;

        public ShoppingBasketController(IShoppingBasketService shoppingBasketService, Settings settings, IMapper mapper)
        {
            _shoppingBasketService = shoppingBasketService;
            _settings = settings;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var currentBaseketId = Request.Cookies.GetCurrentBasketId(_settings);
            var basketLines = await _shoppingBasketService.GetLinesForBasket(currentBaseketId);
            var basketLineViewModels = _mapper.Map<IEnumerable<BasketLineViewModel>>(basketLines);

            return View(basketLineViewModels);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddProductLine(BasketLineForCreation basketForCreation)
        {
            var basketId = Request.Cookies.GetCurrentBasketId(_settings);
            var newProductLine = await _shoppingBasketService.AddToBasket(basketId, basketForCreation);
            Response.Cookies.Append(_settings.BasketIdCookieName, newProductLine.BasketId.ToString());

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateProductLine(BasketLineForUpdate basketLineUpdate)
        {
            var basketId = Request.Cookies.GetCurrentBasketId(_settings);
            await _shoppingBasketService.UpdateProductLine(basketId, basketLineUpdate);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> RemoveProductLine(Guid basketLineId)
        {
            var basketId = Request.Cookies.GetCurrentBasketId(_settings);
            await _shoppingBasketService.RemoveProductLine(basketId, basketLineId);
            return RedirectToAction("Index");
        }
    }
}
