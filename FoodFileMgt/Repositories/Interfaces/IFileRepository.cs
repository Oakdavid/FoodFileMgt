namespace FoodFileMgt.Repositories.Interfaces
{
    public interface IFileRepository
    {
        string Upload(IFormFile file);
    }
}
