using FollowMe.Application.Shared.Exceptions;
using FollowMe.Domain.Entities;
using FollowMe.Domain.Interfaces;
using FollowMe.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace FollowMe.Persistence.Repositories
{
    public class EnderecoRepository : BaseRepository<Endereco>, IEnderecoRepository
    {

        private readonly AppDbContext _context;

        public EnderecoRepository(AppDbContext appDb) : base(appDb)
        {
            _context = appDb;
        }

        public async Task<Endereco> ConsultaEnderecoPorId(Guid EnderecoId, CancellationToken cancellation)
        {
            try
            {
                var query = (from e in _context.Enderecos
                             where e.EnderecoId == EnderecoId
                             select new Endereco()
                             {
                                 EnderecoId = e.EnderecoId,
                                 Cep = e.Cep,
                                 Rua = e.Rua,
                                 Bairro = e.Bairro,
                                 Numero = e.Numero
                             }).FirstAsync(cancellation);

                return await query;
            }
            catch (Exception ex)
            {

                throw new ErroNoBanco($"Erro na Consulta {ex}");
            }
            
        }
    }
}
