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
    public class CheckingController : ControllerBase
    {
        private readonly CheckingContext _profileContext;

        public CheckingController(CheckingContext profilecontext)
        {
            _profileContext = profilecontext;
            if (_profileContext.checking.Count() == 0)
            {


                //Profile 1
                _profileContext.checking.Add(new Checking
                {

                    username = "DTK13",
                    description = "Members 1st Checking Account",
                    balance = 7577.23,
                    lastActivityDate = DateTime.Now.ToString(),


                });
                _profileContext.SaveChanges();

                //Profile 2
                _profileContext.checking.Add(new Checking
                {
                    username = "JMax23",
                    description = "Members 1st Checking Account",
                    balance = 21456.76,
                    lastActivityDate = DateTime.Now.ToString(),

                });
                _profileContext.SaveChanges();

                //Profile 3
                _profileContext.checking.Add(new Checking
                {
                    username = "EP432",
                    description = "Members 1st Checking Account",
                    balance = 25000.54,
                    lastActivityDate = DateTime.Now.ToString(),

                });
                _profileContext.SaveChanges();

            }

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Checking>>> GetId()
        {
            return await _profileContext.checking.ToListAsync();
        }

        [HttpGet("{username}")]
        public async Task<ActionResult<Checking>> GetId(string Id)
        {
            var ProfileId = await _profileContext.checking.FindAsync(Id);
            if (ProfileId == null)
            {
                return NotFound();
            }
            return ProfileId;
        }
    }
}
