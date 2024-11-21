namespace CleanArchitecture.Application.UseCases.CreateUser
{
    // Retorno do Command
    // Sealed não pode ser herdada
    // record, não pode ser alterado, é mais fácil a comparação
    public sealed record CreateUserResponse
    {
        public Guid Id { get; set; }
        public string? Email { get; set; }
        public string? Name { get; set; }
    }
}
