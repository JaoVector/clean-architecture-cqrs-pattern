namespace FollowMe.Application.Shared.Exceptions
{
    public class NotFoundExceptions : Exception
    {
        public NotFoundExceptions(string message) : base(message) { }
    }

    public class UsuarioNotFound : Exception 
    {
        public UsuarioNotFound(string message) : base(message) { }
    }

    public class PedidoNotFound : Exception 
    {
        public PedidoNotFound(string message) : base(message) { }
    }

    public class ProdutoNotFound : Exception 
    {
        public ProdutoNotFound(string message) : base(message) { }
    }

    public class EnderecoNotFound : Exception 
    {
        public EnderecoNotFound(string message) : base(message) { }
    }

    public class BadRequestException : Exception 
    {
        public BadRequestException(string message) : base(message) { }
    } 

    public class ErroNoBanco : Exception 
    {
        public ErroNoBanco(string message) : base(message) { }
    }

    public class ErroAoConsultarCarrinho : Exception 
    {
        public ErroAoConsultarCarrinho(string message) : base(message) { }
    }

    public class ErroSistemico : Exception 
    {
        public ErroSistemico(string message) : base(message) {}
    }
}
