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
            try
            {
                await Task.Delay(3000, cancellationToken);
                var contacts = _repository.GetAll(cancellationToken);
                return Ok(_mapper.Map<IEnumerable<ContactsReadDTo>>(contacts.Result ?? new List<Contacts>()));
            }
            catch (Exception e)
            {
                return BadRequest();                
            }
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
            try
            {
                await Task.Delay(3000, cancellationToken);
                if (string.IsNullOrEmpty(Name))
                {
                    return BadRequest("Value Cannot Be null or empty!");
                }
                var platforms = _repository.GetContactsByName(Name, cancellationToken);

                return Ok(_mapper.Map<IEnumerable<ContactsReadDTo>>(platforms.Result.ToList() ?? new List<Contacts>()));
            }
            catch (Exception)
            {
                return BadRequest();
            }
           
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <param name="Contact"></param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public async Task<ActionResult> CreateContact(ContactsCreateDTo Contact)
        {
            if (Contact == null)
            {
                return BadRequest("Value Cannot Be Null!");
            }
            await Task.Delay(3000);
            var contact = _mapper.Map<Contacts>(Contact);
            _repository.AddContacts(contact);
            bool res = _repository.SaveChanges();
            if (!res)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}