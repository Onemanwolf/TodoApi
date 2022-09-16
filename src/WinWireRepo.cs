using Microsoft.EntityFrameworkCore;
using src.Models;

namespace src
{
    public class WinWireRepo : IRepodb<WinWire, Contact>
    {
        private DataContext _context;
        public WinWireRepo(DataContext context)
        {
            _context = context;
        }
        public async Task<List<WinWire>> Get()
        {
            var winWires = await _context.WinWire.ToListAsync();
            return winWires;
        }
        public async Task Save(WinWire data, Contact contact)
        {
            await _context.WinWire.AddAsync(data);
            await _context.Contact.AddAsync(contact);
            await _context.SaveChangesAsync();
        }

    }

}