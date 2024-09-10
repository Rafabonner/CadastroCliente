using CadastroCliente.Domain;

namespace CadastroCliente.Interfaces
{
    public interface IClienteRepository
    {
        Task<IList<Cliente>> GetAllAsync();
        Task<Cliente> GetAsync(int id);
        Task<bool> UpdateAsync(Cliente cliente);
        Task<bool> CreateAsycn(Cliente cliente);
        Task<bool> DeleteAsync(int id);
    }
}
