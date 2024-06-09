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

        [HttpPatch]
        public ActionResult Patch(AccountObj account)
        {
            var existingAccount = Accounts.Find(x => x.Id == account.Id);

            if (existingAccount == null) {
                return BadRequest("Object does not exist");
            }

            existingAccount.Username = account.Username;
            return Ok();
        }

        [HttpDelete]
        public ActionResult Delete(int id) 
        {
            var existingAccount = Accounts.Find(x => x.Id == id);

            if (existingAccount == null) {
                return BadRequest("Object does not exist");
            }

            Accounts.Remove(existingAccount);
            return NoContent();
        }
    }
}