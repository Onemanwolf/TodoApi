using System.Runtime.Serialization;
using System.Data;
using Microsoft.AspNetCore.Mvc;


using src.Models;

namespace src.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class WinWireController : ControllerBase
    {



        private IRepodb<WinWire, Contact> _repo;

        public WinWireController(IRepodb<WinWire, Contact> repo)
        {
            _repo = repo;
        }
        [HttpGet(Name = "GetWinWires")]
        public async Task<ActionResult<List<WinWire>>> Get()
        {
            var winWires = await _repo.Get();
            return winWires;
        }
        [HttpPost(Name = "AddWinWire")]
        public async Task Post(WinWireDto winWire)
        {
            Contact contact;
            WinWire winwire;
            Mapper(winWire, out contact, out winwire);

            await this._repo.Save(winwire, contact);
        }

        private static void Mapper(WinWireDto winWire, out Contact contact, out WinWire winwire)
        {
            contact = new Contact()
            {
                ContactId = winWire.ContactId,
                FirstName = winWire.Contact.FirstName,
                LastName = winWire.Contact.LastName,
                Email = winWire.Contact.Email

            };
            winwire = new WinWire()
            {

                Id = winWire.Id,
                Title = winWire.Title,
                Discription = winWire.Discription,
                DateCreated = winWire.DateCreated,
                CreatedBy = winWire.CreatedBy,
                IsApproved = winWire.IsApproved,
                ApproverContactId = winWire.ApproverContactId,
                ContactId = winWire.ContactId,

            };
        }
    }
}