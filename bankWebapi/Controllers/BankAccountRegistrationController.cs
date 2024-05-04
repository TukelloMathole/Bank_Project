using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using static BankAccountRegistrationModel;

[ApiController]
[Route("[controller]")]
public class BankAccountRegistrationController : ControllerBase
{
    [HttpPost]
    public IActionResult RegisterPersonalInfo(AccountInfo personalInfo)
    {
        if (personalInfo == null)
        {
            return BadRequest("Invalid data provided.");
        }

        return Ok("Personal information registered successfully.");
    }
}