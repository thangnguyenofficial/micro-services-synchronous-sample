using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ThangNguyen.GlobalTicket.ShoppingBasket.Entities;
using ThangNguyen.GlobalTicket.ShoppingBasket.Infrastructure.Repositories;
using ThangNguyen.GlobalTicket.ShoppingBasket.Models;
using ThangNguyen.GlobalTicket.ShoppingBasket.Services;

namespace ThangNguyen.GlobalTicket.ShoppingBasket.Controllers
{
    [Route("api/baskets/{basketId}/basketlines")]
    [ApiController]
    public class BasketLineController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IBasketRepository _basketRepository;
        private readonly IEventRepository _eventRepository;
        private readonly IEventCatalogService _eventCatalogService;
        private readonly IBasketLineRepository _basketLineRepository;

        public BasketLineController(IMapper mapper, IBasketRepository basketRepository, IEventRepository eventRepository,
            IEventCatalogService eventCatalogService, IBasketLineRepository basketLineRepository)
        {
            _mapper = mapper;
            _basketRepository = basketRepository;
            _eventRepository = eventRepository;
            _basketLineRepository = basketLineRepository;
            _eventCatalogService = eventCatalogService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BasketLine>>> Get(Guid basketId)
        {
            if (!await _basketRepository.CheckBasketExists(basketId))
            {
                return NotFound();
            }

            var basketLines = await _basketLineRepository.GetBasketLines(basketId);
            return Ok(_mapper.Map<IEnumerable<BasketLine>>(basketLines));
        }

        [HttpGet("{basketLineId}", Name = "GetBasketLine")]
        public async Task<ActionResult<BasketLine>> GetBasketLine(Guid basketId, Guid basketLineId)
        {
            if (!await _basketRepository.CheckBasketExists(basketId))
            {
                return NotFound();
            }
            var basketLine = await _basketLineRepository.GetBasketLineById(basketLineId);
            if (basketLine == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<BasketLine>(basketLine));
        }

        [HttpPost]
        public async Task<ActionResult<BasketLine>> PostAsyncBasketLine(Guid basketId,
            [FromBody] BasketLineForCreationDto basketLineDto)
        {
            if (!await _basketRepository.CheckBasketExists(basketId))
            {
                return NotFound();
            }

            if (!await _eventRepository.CheckEventExists(basketLineDto.EventId))
            {
                var eventFromCatalog = await _eventCatalogService.GetEvent(basketLineDto.EventId);
                _eventRepository.AddEvent(eventFromCatalog);
                await _eventRepository.SaveChanges();
            }

            var basketLineEntity = _mapper.Map<BasketLine>(basketLineDto);
            var processedBasketLine = await _basketLineRepository.AddOrUpdateBasketLine(basketId, basketLineEntity);
            await _basketLineRepository.SaveChanges();

            var basketLineToReturn = _mapper.Map<BasketLine>(processedBasketLine);

            return CreatedAtRoute("GetBasketLine",
                new { basketId = basketLineEntity.BasketId, basketLineId = basketLineEntity.BasketLineId },
                basketLineToReturn);
        }

        [HttpPut("{basketLineId}")]
        public async Task<ActionResult<BasketLine>> PutAsyncBasketLine(Guid basketId, Guid basketLineId,
            [FromBody] BasketLineForUpdateDto basketLineForUpdate)
        {
            if (!await _basketRepository.CheckBasketExists(basketId))
            {
                return NotFound();
            }

            var basketLineEntity = await _basketLineRepository.GetBasketLineById(basketLineId);

            if (basketLineEntity == null)
            {
                return NotFound();
            }

            _mapper.Map(basketLineForUpdate, basketLineEntity);

            _basketLineRepository.UpdateBasketLine(basketLineEntity);
            await _basketLineRepository.SaveChanges();

            return Ok(_mapper.Map<BasketLine>(basketLineEntity));
        }

        [HttpDelete("{basketLineId}")]
        public async Task<IActionResult> Delete(Guid basketId, Guid basketLineId)
        {
            if (!await _basketRepository.CheckBasketExists(basketId))
            {
                return NotFound();
            }

            var basketLineEntity = await _basketLineRepository.GetBasketLineById(basketLineId);

            if (basketLineEntity == null)
            {
                return NotFound();
            }

            _basketLineRepository.RemoveBasketLine(basketLineEntity);
            await _basketLineRepository.SaveChanges();

            return NoContent();
        }
    }
}
