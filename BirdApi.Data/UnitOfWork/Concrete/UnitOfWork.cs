namespace BirdApi.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    private bool _disposed;

    public IGenericRepository<Account> AccountRepository { get; private set; }

    public IGenericRepository<Person> PersonRepository { get; private set; }

    public UnitOfWork(AppDbContext context)
    {
        _context = context;

        AccountRepository = new GenericRepository<Account>(context);
        PersonRepository = new GenericRepository<Person>(context);
    }

    public void Complete()
    {
        _context.SaveChanges();
    }

    public void CompleteWithTransaction()
    {
        using(var dbContextTransaction = _context.Database.BeginTransaction())
        {
            try
            {
                _context.SaveChanges();
                dbContextTransaction.Commit();
            }
            catch (Exception ex)
            {
                dbContextTransaction.Rollback();
            }
        }
    }

    protected virtual void Clean(bool disposing)
    {
        if (!_disposed)
        {
            if(disposing)
            {
                _context.Dispose();
            }
        }
        _disposed = true;
    }

    public void Dispose()
    {
        Clean(true);
        GC.SuppressFinalize(this);
    }
}
