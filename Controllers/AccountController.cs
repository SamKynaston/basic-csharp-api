using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace AccountsAPI.Controllers 
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountsController: ControllerBase
    {
        private static List<AccountObj> Accounts = new List<AccountObj>
        {
            new AccountObj {Id = 1, Username = "Test"}
        };
    }
}