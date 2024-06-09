using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace AccountsAPI.Controllers 
{
    [ApiController]
    [Route("api/[controller]/")]
    public class AccountsController: ControllerBase
    {
        private static List<AccountObj> Accounts = new List<AccountObj>
        {
            new AccountObj {Id = 1, Username = "Test"}
        };

        private AccountObj CreateAccount(string username)
        {

            var id = Accounts.Any() ? Accounts.Max(x => x.Id) : 1;

            AccountObj NewAccount = new AccountObj { 
                Id = id + 1,
                Username = username
            };

            Accounts.Add(NewAccount);

            return NewAccount;
        }

        [HttpGet]
        public ActionResult<List<AccountObj>> Get()
        {
            return Ok(Accounts);
        }

        [HttpPost]
        public ActionResult Post(string username) 
        {
            AccountObj newAccount = CreateAccount(username);
            return Created(Request.Path.ToString() + '/' + newAccount.Id, newAccount);
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