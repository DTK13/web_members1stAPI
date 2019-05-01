using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using web_members1stAPI.Models;

namespace web_members1stAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly AccountContext _profileContext;


        public AccountController(AccountContext profilecontext)
        {
            _profileContext = profilecontext;
            if (_profileContext.accounts.Count() == 0)
            {


                //Profile 1
                _profileContext.accounts.Add(new Account
                {

                    username = "DTK13",
                    description = "Members 1st savings account",
                    balance = 12500,
                    lastActivityDate = DateTime.Now.ToString(),


                });
                _profileContext.SaveChanges();

                //Profile 2
                _profileContext.accounts.Add(new Account
                {
                    username = "JMax23",
                    description = "Members 1st savings account",
                    balance = 1500.89,
                    lastActivityDate = DateTime.Now.ToString(),

                });
                _profileContext.SaveChanges();

                //Profile 3
                _profileContext.accounts.Add(new Account
                {
                    username = "EP432",
                    description = "Members 1st savings account",
                    balance = 157232.01,
                    lastActivityDate = DateTime.Now.ToString(),

                });
                _profileContext.SaveChanges();

            }

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Account>>> GetId()
        {
            return await _profileContext.accounts.ToListAsync();
        }

        [HttpGet("{username}")]
        public async Task<ActionResult<Account>> GetId(string Id)
        {
            var ProfileId = await _profileContext.accounts.FindAsync(Id);
            if (ProfileId == null)
            {
                return NotFound();
            }
            return ProfileId;
        }
    }
}