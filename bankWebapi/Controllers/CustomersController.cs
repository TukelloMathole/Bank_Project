﻿using Microsoft.AspNetCore.Mvc;
using bank_App.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using static BankAccountRegistrationModel;

namespace bank_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CustomersController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BankAccountRegistration>>> GetCustomers()
        {
            return await _context.BankAccountRegistration.ToListAsync();
        }
    }
}