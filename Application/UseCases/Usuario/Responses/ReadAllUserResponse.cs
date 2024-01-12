namespace FollowMe.Application.UseCases.Usuario.Responses
{
    public sealed record ReadAllUserResponse 
    {
        public Guid UsuarioId { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
    };
}
