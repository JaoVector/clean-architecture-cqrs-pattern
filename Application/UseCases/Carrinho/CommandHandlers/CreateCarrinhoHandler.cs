using FollowMe.Application.UseCases.Carrinho.Commands;
using FollowMe.Application.UseCases.Carrinho.Responses;
using FollowMe.Domain.Interfaces;
using MediatR;

namespace FollowMe.Application.UseCases.Carrinho.CommandHandlers
{
    public class CreateCarrinhoHandler : IRequestHandler<CreateCarrinhoRequest, CreateCarrinhoResponse>
    {
        private readonly ICarrinhoRepository _carrinhoRepo;
        private readonly IUnityOfWork _work;

        public CreateCarrinhoHandler(ICarrinhoRepository carrinhoRepo, IUnityOfWork work)
        {
            _carrinhoRepo = carrinhoRepo;
            _work = work;
        }

        public async Task<CreateCarrinhoResponse> Handle(CreateCarrinhoRequest request, CancellationToken cancellationToken)
        {
            var carrinho = new Domain.Entities.Carrinho
            {
                CarrinhoId = new Guid(),
                UsuarioId= request.UsuarioId, 
            };

            _carrinhoRepo.Cria(carrinho);

            await _work.Commit(cancellationToken);

            return new CreateCarrinhoResponse 
            {
                UsuarioId = carrinho.UsuarioId,
                CarrinhoId = carrinho.CarrinhoId
            };
        }
    }
}
