﻿using Api.Response;
using Domain.DTO.Sale;
using Domain.Interfaces.Services;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly ISaleService _service;
        private readonly ILogger<SaleController> _logger;
        private readonly IMapper _mapper;
        public SaleController(ISaleService service, ILogger<SaleController> logger, IMapper mapper)
        {
            _service = service;
            _logger = logger;
            _mapper = mapper;
        }

        /// <summary>
        /// Get All Sale Product
        /// </summary>
        /// <returns> Return Current Sale </returns>
        [HttpGet]
        public async Task<ActionResult<SaleDTO>> GetCurrentSale()
        {
            var sale = await _service.GetCurrentSale(2);
            if (sale == null)
            {
                return NotFound(ApiResponse.Fail(HttpStatusCode.NotFound));
            }
            return Ok(ApiResponse.Success(sale));
        }
    }
}
