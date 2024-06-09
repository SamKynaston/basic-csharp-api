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

        [HttpGet]
        public ActionResult<List<AccountObj>> Get()
        {
            return Ok(Accounts);
        }

        [HttpPost]
        public ActionResult Post(AccountObj account) 
        {
            if (Accounts.Find(x => x.Id == account.Id) == null) {
                Accounts.Add(account);
                return Created(Request.Path.ToString() + '/' + account.Id, account);
            }

            return Conflict("Account already exists");
        } 
    }
}