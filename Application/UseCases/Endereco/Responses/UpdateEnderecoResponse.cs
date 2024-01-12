namespace FollowMe.Application.UseCases.Endereco.Responses
{
    public sealed record UpdateEnderecoResponse
    {
        public Guid EnderecoId { get; set; }
        public string? Cep { get; set; }
        public string? Rua { get; set; }
        public string? Bairro { get; set; }
        public int Numero { get; set; }
        public Guid UsuarioId { get; set; }
        public string? DataAtualizacao { get; set; }
    }
}
