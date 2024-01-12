namespace FollowMe.Application.UseCases.Usuario.Responses
{
    public sealed record UpdateUserResponse
    {
        public Guid UsuarioId { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? DataAtualizacao { get; set; }
    }
}
