using Atalhos.Models;

namespace Atalhos.Server
{
  public class AmbienteServer : DataServer<AmbienteModel>
  {
    public AmbienteServer() : base(new Repositories.AmbienteRepository(new DbContext.ApplicationDbContext()))
    {
    }

    public async Task<AmbienteModel?> GetByNameAsync(string nome)
    {
      return (await _repository.GetAllAsync()).FirstOrDefault(x => x.Nome == nome);
    }

    public async Task<AmbienteModel?> GetByFullNameAsync(string fullName)
    {
      return (await _repository.GetAllAsync()).FirstOrDefault(x => x.FullName == fullName);
    }
  }
}
