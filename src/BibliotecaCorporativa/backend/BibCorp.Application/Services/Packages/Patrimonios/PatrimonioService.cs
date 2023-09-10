
using AutoMapper;
using BibCorp.Application.Dto.Patrimonios;
using BibCorp.Application.Services.Contracts.Patrimonios;
using BibCorp.Domain.Models.Patrimonios;
using BibCorp.Persistence.Interfaces.Contracts.Patrimonios;

namespace BibCorp.Application.Services.Packages.Patrimonios
{
  public class PatrimonioService : IPatrimonioService
  {
    private readonly IPatrimonioPersistence _patrimonioPersistence;
    private readonly IMapper _mapper;
    public PatrimonioService(
        IPatrimonioPersistence patrimonioPersistence,
        IMapper mapper)
    {
      _patrimonioPersistence = patrimonioPersistence;
      _mapper = mapper;
    }
    public async Task<PatrimonioDto> CreatePatrimonio(PatrimonioDto patrimonioDto)
    {
      try
      {
        var patrimonio = _mapper.Map<Patrimonio>(patrimonioDto);

        _patrimonioPersistence.Create<Patrimonio>(patrimonio);

        if (await _patrimonioPersistence.SaveChangesAsync())
        {
          var patrimonioRetorno = await _patrimonioPersistence.GetPatrimonioByIdAsync(patrimonio.Id);

          return _mapper.Map<PatrimonioDto>(patrimonioRetorno);
        }

        return null;
      }
      catch (Exception e)
      {

        throw new Exception(e.Message);
      }
    }

    public async Task<bool> DeletePatrimonio(int patrimonioId)
    {
      try
      {
        var patrimonio = await _patrimonioPersistence.GetPatrimonioByIdAsync(patrimonioId);

        if (patrimonio == null)
          throw new Exception("Patrimonio para deleção náo foi encontrado!");

        _patrimonioPersistence.Delete<Patrimonio>(patrimonio);

        return await _patrimonioPersistence.SaveChangesAsync();
      }
      catch (Exception e)
      {

        throw new Exception(e.Message);
      }
    }
    public async Task<IEnumerable<PatrimonioDto>> GetAllPatrimoniosAsync()
    {
      try
      {
        var patrimonios = await _patrimonioPersistence.GetAllPatrimoniosAsync();

        if (patrimonios == null) return null;

        var patrimonioMapper = _mapper.Map<PatrimonioDto[]>(patrimonios);

        return patrimonioMapper;
      }
      catch (Exception e)
      {

        throw new Exception(e.Message);
      }
    }

    public async Task<PatrimonioDto> GetPatrimonioByIdAsync(int patrimonioId)
    {
      try
      {
        var patrimonio = await _patrimonioPersistence.GetPatrimonioByIdAsync(patrimonioId);

        if (patrimonio == null) return null;

        var patrimonioMapper = _mapper.Map<PatrimonioDto>(patrimonio);

        return patrimonioMapper;
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }

    public async Task<PatrimonioDto> UpdatePatrimonio(int patrimonioId, PatrimonioDto patrimoioDto)
    {
      try
      {
        var ptrimonio = await _patrimonioPersistence.GetPatrimonioByIdAsync(patrimonioId);

        if (ptrimonio == null) return null;

        var patrimonioUpdate = _mapper.Map(patrimoioDto, ptrimonio);

        _patrimonioPersistence.Update<Patrimonio>(patrimonioUpdate);

        if (await _patrimonioPersistence.SaveChangesAsync())
        {
          var patrimonioMapper = await _patrimonioPersistence.GetPatrimonioByIdAsync(patrimonioUpdate.Id);
          return _mapper.Map<PatrimonioDto>(patrimonioMapper);
        }

        return null;
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }


    public async Task<IEnumerable<PatrimonioDto>> GetPatrimonioByISBNAsync(string ISBN)
    {
      try
      {
        var patrimonio = await _patrimonioPersistence.GetPatrimonioByISBNAsync(ISBN);

        if (patrimonio == null) return null;

        var patrimonioMapper = _mapper.Map<PatrimonioDto[]>(patrimonio);

        return patrimonioMapper;
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }
  }
}
