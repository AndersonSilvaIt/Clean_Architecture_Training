using MediatR;

namespace CleanArchitecture.Application.UseCases.CreateUser
{
    // Command
    // Sealed não pode ser herdada
    // record, não pode ser alterado, é mais fácil a comparação
    public sealed record CreateUserRequest(string Email, string name) : 
        IRequest<CreateUserResponse>;
}
