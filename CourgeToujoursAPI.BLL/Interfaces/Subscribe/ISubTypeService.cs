using CourgeToujoursAPI.BLL.Models.Subscribe;

namespace CourgeToujoursAPI.BLL.Interfaces.Subscribe;


public interface ISubTypeService
{
   public IEnumerable<SubType> GetAll();
   public SubType GetSubTypeById(int id);
}