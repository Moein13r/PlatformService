using System.Data.SqlClient;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.DTOs;
using PlatformService.Models;
using System.Text.Encodings.Web;

namespace PlatformsService.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactRepo _repository;
        private readonly IMapper _mapper;
        public ContactsController(
            IContactRepo repoitory,
            IMapper mapper
        )
        {
            _repository = repoitory;
            _mapper = mapper;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<ContactsReadDTo>>> GetContacts(CancellationToken cancellationToken)
        {
            await Task.Delay(3000, cancellationToken);
            Console.WriteLine("-->Getting platforms....");
            var contacts = _repository.GetAll();
            if (contacts == null)
            {
                Console.WriteLine("---> have not data----");
                return BadRequest();
            }
            return Ok(_mapper.Map<IEnumerable<ContactsReadDTo>>(contacts));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <param name="Name"></param>
        /// <returns></returns>
        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<ContactsReadDTo>>> GetContactsByName(CancellationToken cancellationToken, string Name)
        {
            Console.WriteLine("-->Getting platforms....");
            await Task.Delay(3000, cancellationToken);
            if (string.IsNullOrEmpty(Name))
            {
                return BadRequest("Value Cannot Be null or empty!");
            }
            var platforms = _repository.GetContactsByName(Name);
            if (platforms == null)
            {
                Console.WriteLine("---> have not data----");
                return BadRequest();
            }
            return Ok(_mapper.Map<IEnumerable<ContactsReadDTo>>(platforms));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <param name="Contact"></param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public async Task<ActionResult> CreateContact(CancellationToken cancellationToken, ContactsCreateDTo Contact)
        {
            if (Contact == null)
            {
                return BadRequest("Value Cannot Be Null!");
            }
            await Task.Delay(3000, cancellationToken);
            var contact = _mapper.Map<Contacts>(Contact);
            _repository.AddContacts(contact);
            var res = _repository.SaveChanges();
            return Ok();
        }
    }
}