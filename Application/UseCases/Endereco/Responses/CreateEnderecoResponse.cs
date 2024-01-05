namespace FollowMe.Application.UseCases.Endereco.Responses
{
    public sealed record CreateEnderecoResponse
    {
        public Guid EnderecoId { get; set; }
        public string? Cep { get; set; }
        public string? Rua { get; set; }
        public string? Bairro { get; set; }
        public int Numero { get; set; }
        public Guid UsuarioId { get; set; }
        public string? DataCriacao { get; set; }
    }
}
