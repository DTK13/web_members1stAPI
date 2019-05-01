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
    public class CertificateController : ControllerBase
    {
        private readonly CertificateContext _profileContext;
        public CertificateController(CertificateContext profilecontext)
        {
            _profileContext = profilecontext;
            if (_profileContext.certificates.Count() == 0)
            {


                //Profile 1
                _profileContext.certificates.Add(new Certificate
                {

                    username = "DTK13",
                    description = "Members 1st Certificate",
                    balance = 115.20,
                    lastActivityDate = DateTime.Now.ToString(),
                    interestRate= "2.1%",
                    maturityDate= "01/20/2020",


                });
                _profileContext.SaveChanges();

                //Profile 2
                _profileContext.certificates.Add(new Certificate
                {
                    username = "JMax23",
                    description = "Members 1st Certificate",
                    balance = 1000,
                    lastActivityDate = DateTime.Now.ToString(),
                    interestRate = "5.9%",
                    maturityDate = "03/15/2020",

                });
                _profileContext.SaveChanges();

                //Profile 3
                _profileContext.certificates.Add(new Certificate
                {
                    username = "EP432",
                    description = "Members 1st Certificate",
                    balance = 65002,
                    lastActivityDate = DateTime.Now.ToString(),
                    interestRate = "7.2%",
                    maturityDate = "09/03/2019",

                });
                _profileContext.SaveChanges();

            }

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Certificate>>> GetId()
        {
            return await _profileContext.certificates.ToListAsync();
        }

        [HttpGet("{username}")]
        public async Task<ActionResult<Certificate>> GetId(string Id)
        {
            var ProfileId = await _profileContext.certificates.FindAsync(Id);
            if (ProfileId == null)
            {
                return NotFound();
            }
            return ProfileId;
        }
    }
}