using AutoMapper;
using BibCorp.Application.Dto.Emprestimos;
using BibCorp.Application.Services.Contracts.Emprestimos;
using BibCorp.Domain.Models.Emprestimos;
using BibCorp.Persistence.Interfaces.Contracts.Emprestimos;

namespace BibCorp.Application.Services.Packages.Emprestimos
{
  public class EmprestimoService : IEmprestimoService
  {
    private readonly IEmprestimoPersistence _emprestimoPersistence;
    private readonly IMapper _mapper;
    public EmprestimoService(
        IEmprestimoPersistence emprestimoPersistence,
        IMapper mapper)
    {
      _emprestimoPersistence = emprestimoPersistence;
      _mapper = mapper;
    }
    public async Task<EmprestimoDto> CreateEmprestimo(EmprestimoDto emprestimoDto)
    {
      try
      {
        var emprestimo = _mapper.Map<Emprestimo>(emprestimoDto);

        _emprestimoPersistence.Create<Emprestimo>(emprestimo);

        if (await _emprestimoPersistence.SaveChangesAsync())
        {
          var emprestimoRetorno = await _emprestimoPersistence.GetEmprestimoByIdAsync(emprestimo.Id);

          return _mapper.Map<EmprestimoDto>(emprestimoRetorno);
        }

        return null;
      }
      catch (Exception e)
      {

        throw new Exception(e.Message);
      }
    }

    public async Task<bool> DeleteEmprestimo(int emprestimoId)
    {
      try
      {
        var emprestimo = await _emprestimoPersistence.GetEmprestimoByIdAsync(emprestimoId);

        if (emprestimo == null)
          throw new Exception("Emprestimo para deleção não foi encontrado!");

        _emprestimoPersistence.Delete<Emprestimo>(emprestimo);

        return await _emprestimoPersistence.SaveChangesAsync();
      }
      catch (Exception e)
      {

        throw new Exception(e.Message);
      }
    }
    public async Task<IEnumerable<EmprestimoDto>> GetAllEmprestimosAsync()
    {
      try
      {
        var emprestimos = await _emprestimoPersistence.GetAllEmprestimosAsync();

        if (emprestimos == null) return null;

        var emprestimoMapper = _mapper.Map<EmprestimoDto[]>(emprestimos);

        return emprestimoMapper;
      }
      catch (Exception e)
      {

        throw new Exception(e.Message);
      }
    }

    public async Task<EmprestimoDto> GetEmprestimoByIdAsync(int emprestimoId)
    {
      try
      {
        var emprestimo = await _emprestimoPersistence.GetEmprestimoByIdAsync(emprestimoId);

        if (emprestimo == null) return null;

        var emprestimoMapper = _mapper.Map<EmprestimoDto>(emprestimo);

        return emprestimoMapper;
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }

    public async Task<EmprestimoDto> UpdateEmprestimo(int emprestimoId, EmprestimoDto emprestimoDto)
    {
      try
      {
        var emprestimo = await _emprestimoPersistence.GetEmprestimoByIdAsync(emprestimoId);

        if (emprestimo == null) return null;

        var emprestimoUpdate = _mapper.Map(emprestimoDto, emprestimo);

        _emprestimoPersistence.Update<Emprestimo>(emprestimoUpdate);

        if (await _emprestimoPersistence.SaveChangesAsync())
        {
          var emprestimoMapper = await _emprestimoPersistence.GetEmprestimoByIdAsync(emprestimoUpdate.Id);
          return _mapper.Map<EmprestimoDto>(emprestimoMapper);
        }

        return null;
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }


    public async Task<IEnumerable<EmprestimoDto>> GetEmprestimosByUserNameAsync(string userName)
    {
      try
      {
        var emprestimos = await _emprestimoPersistence.GetEmprestimosByUserNameAsync(userName);

        if (emprestimos == null) return null;

        var emprestimoMapper = _mapper.Map<EmprestimoDto[]>(emprestimos);

        return emprestimoMapper;
      }
      catch (Exception e)
      {

        throw new Exception(e.Message);
      }
    }

    public async Task<IEnumerable<EmprestimoDto>> GetEmprestimosByAcervoIdAsync(int acervoId)
    {
      try
      {
        var emprestimos = await _emprestimoPersistence.GetEmprestimosByAcervoIdAsync(acervoId);

        if (emprestimos == null) return null;

        var emprestimoMapper = _mapper.Map<EmprestimoDto[]>(emprestimos);

        return emprestimoMapper;
      }
      catch (Exception e)
      {

        throw new Exception(e.Message);
      }
    }

    public async Task<IEnumerable<EmprestimoDto>> GetEmprestimosByPatrimonioIdAsync(int patrimonioId)
    {
      try
      {
        var emprestimos = await _emprestimoPersistence.GetEmprestimosByPatrimonioIdAsync(patrimonioId);

        if (emprestimos == null) return null;

        var emprestimoMapper = _mapper.Map<EmprestimoDto[]>(emprestimos);

        return emprestimoMapper;
      }
      catch (Exception e)
      {

        throw new Exception(e.Message);
      }
    }
  }
}
