namespace FollowMe.Application.UseCases.Endereco.Responses
{
    public sealed record ReadEnderecoResponse
    {
        public Guid EnderecoId { get; set; }
        public string? Cep { get; set; }
        public string? Rua { get; set; }
        public string? Bairro { get; set; }
        public int? Numero { get; set; }
    }
}
