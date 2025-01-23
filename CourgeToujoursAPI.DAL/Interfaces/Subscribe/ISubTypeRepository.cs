using CourgeToujoursAPI.DAL.Entities.Subscribe;

namespace CourgeToujoursAPI.DAL.Interfaces.Subscribe;

public interface ISubTypeRepository
{
    public SubType GetSubTypeById(int id);
    public IEnumerable<SubType> GetAll();
}