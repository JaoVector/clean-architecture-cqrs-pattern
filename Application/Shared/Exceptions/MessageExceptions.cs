namespace FollowMe.Application.Shared.Exceptions
{
    public class MessageExceptions : Exception
    {
        public MessageExceptions(string message) : base(message) { }
    }

    public class ErroAoGerarMensagemUsuaurio : Exception 
    {
        public ErroAoGerarMensagemUsuaurio(string message) : base(message) { }
    }

    public class ErroAoGerarMensagemPedido : Exception 
    {
        public ErroAoGerarMensagemPedido(string message) : base(message) { }
    }
}
