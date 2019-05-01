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
    public class LoanController : ControllerBase
    {
        private readonly LoanContext _profileContext;

        public LoanController(LoanContext profilecontext)
        {
            _profileContext = profilecontext;
            if (_profileContext.loans.Count() == 0)
            {


                //Profile 1
                _profileContext.loans.Add(new Loan
                {

                    username = "DTK13",
                    description = "Members 1st Loans",
                    balance = 35124.75,
                    lastActivityDate = DateTime.Now.ToString(),
                    paymentDueDate="09/24/2019",
                    minimumAmountDue=344.90,


                });
                _profileContext.SaveChanges();

                //Profile 2
                _profileContext.loans.Add(new Loan
                {
                    username = "JMax23",
                    description = "Members 1st Loans",
                    balance = 884.70,
                    lastActivityDate = DateTime.Now.ToString(),
                    paymentDueDate="05/29/2019",
                    minimumAmountDue=120.00,

                });
                _profileContext.SaveChanges();

                //Profile 3
                _profileContext.loans.Add(new Loan
                {
                    username = "EP432",
                    description = "Members 1st Checking Account",
                    balance = 11000.50,
                    lastActivityDate = DateTime.Now.ToString(),
                    paymentDueDate="06/24/2019",
                    minimumAmountDue=1070.25,

                });
                _profileContext.SaveChanges();

            }

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Loan>>> GetId()
        {
            return await _profileContext.loans.ToListAsync();
        }

        [HttpGet("{username}")]
        public async Task<ActionResult<Loan>> GetId(string Id)
        {
            var ProfileId = await _profileContext.loans.FindAsync(Id);
            if (ProfileId == null)
            {
                return NotFound();
            }
            return ProfileId;
        }
    }
}