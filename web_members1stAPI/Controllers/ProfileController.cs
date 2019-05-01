using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using web_members1stAPI.Models;
using System.Net.Mail;

namespace web_members1stAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    
    {
        private readonly APIContext _profileContext;
       
        public ProfileController(APIContext profilecontext)
        {
            _profileContext = profilecontext;
            if (_profileContext.Profiles.Count() == 0)
            {
                
                
                //Profile 1
                _profileContext.Profiles.Add(new Profile
                { name = "Diyar Karim",
                    username = "DTK13",
                    street_address = "119 Gamma Drive",
                    city="Pittsburgh",
                    state="PA",
                    zipCode=15239,
                    home_phone = "412-845-1970",
                    mobile_Phone="412-878-9907",
                    email_Address = "diyarkarim@yahoo.com",
                });
                _profileContext.SaveChanges();

                //Profile 2
                _profileContext.Profiles.Add(new Profile
                {
                    name = "John Max",
                    username = "JMax23",
                    street_address = "722 West St.",
                    city = "Pittsburgh",
                    state = "PA",
                    zipCode = 15289,
                    home_phone = "412-845-1844",
                    email_Address = "jmax23@yahoo.com",
                });
                _profileContext.SaveChanges();

                //Profile 3
                _profileContext.Profiles.Add(new Profile
                {
                    name = "Ellen Payne",
                    username = "EP432",
                    street_address = "14 Ferry St.",
                    city = "Monroeville",
                    state = "PA",
                    zipCode = 15239,
                    home_phone = "717-412-1852",
                    email_Address = "EPO@hotmail.com",
                });
                _profileContext.SaveChanges();

            }

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Profile>>> GetId()
        {
            return await _profileContext.Profiles.ToListAsync();
        }

        [HttpGet("{username}")]
        public async Task<ActionResult<Profile>> GetId(string Id)
        {
            var ProfileId = await _profileContext.Profiles.FindAsync(Id);
            if (ProfileId == null)
            {
                return NotFound();
            }
            return ProfileId;
        }

        [HttpPost]
        public async Task<ActionResult<Profile>> PostProfile(Profile item)
        {
            _profileContext.Profiles.Add(item);
            await _profileContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetId), new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutItem(string id, Profile item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            _profileContext.Entry(item).State = EntityState.Modified;
            await _profileContext.SaveChangesAsync();

            return NoContent();
        }
    }
}