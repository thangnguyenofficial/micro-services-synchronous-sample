using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ThangNguyen.GlobalTicket.ShoppingBasket.Entities;
using ThangNguyen.GlobalTicket.ShoppingBasket.Infrastructure.Repositories;
using ThangNguyen.GlobalTicket.ShoppingBasket.Models;

namespace ThangNguyen.GlobalTicket.ShoppingBasket.Controllers
{
    [Route("api/baskets")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IBasketRepository _basketRepository;

        public BasketController(IMapper mapper, IBasketRepository basketRepository)
        {
            _mapper = mapper;
            _basketRepository = basketRepository;
        }

        [HttpGet("{basketId}", Name = "GetBasket")]
        public async Task<ActionResult<Basket>> GetAsyncBasket(Guid basketId)
        {
            var basket = await _basketRepository.GetAsyncBasketById(basketId);
            if (basket == null)
                return NotFound();

            var result = _mapper.Map<BasketDto>(basket);
            result.NumberOfItems = basket.BasketLines.Sum(bl => bl.Quantity);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Basket>> AddAsyncBasket(BasketForCreationDto basketForCreation)
        {
            var basket = _mapper.Map<Basket>(basketForCreation);

            _basketRepository.AddBasket(basket);
            await _basketRepository.SaveChanges();

            var basketAfterInserted = _mapper.Map<BasketDto>(basket);

            return CreatedAtRoute("GetBasket", new {basketId = basket.BasketId}, basketAfterInserted);
        }
    }
}
