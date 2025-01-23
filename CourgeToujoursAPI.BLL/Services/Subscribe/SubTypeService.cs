using CourgeToujoursAPI.BLL.Interfaces.Subscribe;
using CourgeToujoursAPI.BLL.Mappers.Subscribe;
using CourgeToujoursAPI.BLL.Models.Subscribe;
using CourgeToujoursAPI.DAL.Interfaces.Subscribe;

namespace CourgeToujoursAPI.BLL.Services.Subscribe;

public class SubTypeService :ISubTypeService
{
    
    private readonly ISubTypeRepository _subRepository;

    public SubTypeService(ISubTypeRepository subRepository)
    {
        _subRepository = subRepository;
    }
    
    
    public IEnumerable<SubType> GetAll()
    {
        return _subRepository.GetAll().Select(sub => sub.toModel());
    }

 

    public SubType GetSubTypeById(int id)
    {
        throw new NotImplementedException();
    }
}