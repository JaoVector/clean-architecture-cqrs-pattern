namespace FollowMe.Application.UseCases.Usuario.Responses
{
    public sealed record ReadUserPedidoResponse
    {
        public Guid UsuarioId { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
    }
}
