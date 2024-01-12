namespace FollowMe.Application.UseCases.Usuario.Responses
{
    public sealed record CreateUserResponse
    {
        public Guid UsuarioId { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? DataCriacao { get; set; }
    }
}
