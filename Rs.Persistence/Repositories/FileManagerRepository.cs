using Rs.Domain.Aggregates.Files;
using Rs.Domain.Repositories;
using Rs.Persistence.DbPersistence;

namespace Rs.Persistence.Repositories;

public class FileManagerRepository(DataContext context) : IFileManagerRepository
{
    public void Add(FileManager file)
    {
        context.Set<FileManager>().Add(file);
    }

    public void Remove(FileManager file)
    {
        context.Set<FileManager>().Remove(file);
    }
}