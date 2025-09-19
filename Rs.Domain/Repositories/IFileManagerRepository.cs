using Rs.Domain.Aggregates.Files;

namespace Rs.Domain.Repositories;

public interface IFileManagerRepository
{
    void Add(FileManager file);
}