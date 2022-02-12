using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ThangNguyen.GlobalTicket.Client.Code;
using ThangNguyen.GlobalTicket.Client.Code.Extensions;
using ThangNguyen.GlobalTicket.Client.Models.Api;
using ThangNguyen.GlobalTicket.Client.Models.EventViewModel;
using ThangNguyen.GlobalTicket.Client.Services;

namespace ThangNguyen.GlobalTicket.Client.Controllers
{
    public class EventCatalogController : Controller
    {
        private readonly IEventCatalogService _eventCatalogService;
        private readonly IShoppingBasketService _shoppingBasketService;
        private readonly Settings _settings;

        public EventCatalogController(IEventCatalogService eventCatalogService,
            IShoppingBasketService shoppingBasketService, Settings settings)
        {
            _eventCatalogService = eventCatalogService;
            _shoppingBasketService = shoppingBasketService;
            _settings = settings;
        }

        public async Task<IActionResult> Index(Guid categoryId)
        {
            var currentBasketId = Request.Cookies.GetCurrentBasketId(_settings);

            var basket = currentBasketId == Guid.Empty ? Task.FromResult<Basket>(null) :
                _shoppingBasketService.GetBasket(currentBasketId);
            var categories = _eventCatalogService.GetCategories();
            var events = categoryId == Guid.Empty ? _eventCatalogService.GetEvents() :
                _eventCatalogService.GetEventsByCategory(categoryId);
            await Task.WhenAll(new Task[] { basket, categories, events });
            await Task.WhenAll(new Task[] { categories, events });

            var numberOfItems = basket.Result?.NumberOfItems ?? 0;

            return View(
                new EventListModel
                {
                    Events = events.Result,
                    Categories = categories.Result,
                    NumberOfItems = numberOfItems,
                    SelectedCategory = categoryId
                }
            );
        }

        public async Task<IActionResult> Detail(Guid eventId)
        {
            var eventDetail = await _eventCatalogService.GetEvent(eventId);
            return View(eventDetail);
        }

        [HttpPost]
        public IActionResult SelectCategory([FromForm] Guid selectedCategory)
        {
            return RedirectToAction("Index", new { categoryId = selectedCategory });
        }
    }
}
