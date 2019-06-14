using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agoda.Pikachu.Api.Property;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Agoda.Pikachu.Web.Controllers
{
    [Route("api/hotel")]
    [ApiController]
    public class HotelPropertyController : ControllerBase
    {
        private readonly IHotelPropertyService _hotelPropertyService;

        public HotelPropertyController(IHotelPropertyService hotelPropertyService)
        {
            _hotelPropertyService = hotelPropertyService;
        }

        [HttpGet("{id}")]
        public async Task<PropertyModel> GetProperty(int id)
        {
            return await _hotelPropertyService.GetProperty(id);
        }
    }
}