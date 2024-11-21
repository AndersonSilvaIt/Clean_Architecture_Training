using AutoMapper;
using CleanArchitecture.Domain.Interfaces;
using MediatR;

namespace CleanArchitecture.Application.UseCases.UpdateUser
{
    public sealed class UpdateUserHandler : IRequestHandler<UpdateUserRequest, UpdateUserResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateUserHandler(IUserRepository userRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<UpdateUserResponse> Handle(UpdateUserRequest command, CancellationToken cancellationToken)
        {
            var user = await _userRepository.Get(command.Id, cancellationToken);

            if (user == null) return default;

            user.Email = command.Email;
            user.Name = command.Email;

            _userRepository.Update(user);

            await _unitOfWork.Commit(cancellationToken);

            return _mapper.Map<UpdateUserResponse>(user);
        }
    }
}
