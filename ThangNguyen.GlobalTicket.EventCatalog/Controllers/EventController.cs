using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ThangNguyen.GlobalTicket.EventCatalog.Infrastructure.Repositories;
using ThangNguyen.GlobalTicket.EventCatalog.Models;

namespace ThangNguyen.GlobalTicket.EventCatalog.Controllers
{
    [Route("api/events")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IEventRepository _eventRepository;

        public EventController(IEventRepository eventRepository, IMapper mapper)
        {
            _mapper = mapper;
            _eventRepository = eventRepository;
        }

        [HttpGet("{eventId}")]
        public async Task<ActionResult<EventDto>> GetAsyncEvent(Guid eventId)
        {
            var result = await _eventRepository.GetEvent(eventId);
            return Ok(_mapper.Map<EventDto>(result));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventDto>>> GetAsyncEventsByCategory([FromQuery] Guid categoryId)
        {
            var result = await _eventRepository.GetEventsByCategory(categoryId);
            return Ok(_mapper.Map<List<EventDto>>(result));
        }
    }
}
