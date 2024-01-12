namespace FollowMe.Application.Eventos
{
    public sealed record UsuarioEventos
    {
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Mensagem { get; set;}
    }
}
