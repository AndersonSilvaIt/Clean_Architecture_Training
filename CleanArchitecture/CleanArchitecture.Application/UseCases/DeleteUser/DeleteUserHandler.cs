using AutoMapper;
using CleanArchitecture.Domain.Interfaces;
using MediatR;

namespace CleanArchitecture.Application.UseCases.DeleteUser
{
    public sealed class DeleteUserHandler : IRequestHandler<DeleteUserRequest, DeleteUserResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteUserHandler(IUserRepository userRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<DeleteUserResponse> Handle(DeleteUserRequest command, CancellationToken cancellationToken)
        {
            var user = await _userRepository.Get(command.Id, cancellationToken);

            if (user == null) return default;

            _userRepository.Delete(user);

            await _unitOfWork.Commit(cancellationToken);

            return _mapper.Map<DeleteUserResponse>(user);
        }
    }
}
