using MediatR;
using Microsoft.IdentityModel.Tokens;
using RO.DevTest.Application.Contracts.Infrastructure;
using RO.DevTest.Application.Contracts.Persistance.Repositories;
using RO.DevTest.Domain.Entities;
using RO.DevTest.Domain.Exception;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RO.DevTest.Application.Features.Auth.Commands.LoginCommand
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IIdentityAbstractor _identityAbstractor;
        private readonly IConfiguration _configuration;

        public LoginCommandHandler(IUserRepository userRepository, IIdentityAbstractor identityAbstractor, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _identityAbstractor = identityAbstractor;
            _configuration = configuration;
        }

        public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            // Buscar o usuário pelo email
            var user = await _userRepository.GetByEmailAsync(request.Email);
            if (user == null || user.Password != request.Password)
            {
                throw new BadRequestException("Email ou senha inválidos.");
            }

            // Gerar claims
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };

            // Gerar token JWT
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: creds
            );

            var token = new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);

            return new LoginResponse
            {
                Token = token
            };
        }
    }
}
