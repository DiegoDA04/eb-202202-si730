using si730ebu20201c334.API.Shared.Persistence.Contexts;

namespace PracticeBackend.API.Shared.Persistence.Repositories;

public class BaseRepository
{
    protected readonly AppDbContext _context;

    public BaseRepository(AppDbContext context)
    {
        _context = context;
    }
}