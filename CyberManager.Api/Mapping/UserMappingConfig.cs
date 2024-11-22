using CyberManager.Api.Constracts.User;
using CyberManager.Application.Services.Users;
using CyberManager.Domain.Entities;
using Mapster;

namespace CyberManager.Api.Mapping;

public class UserMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<UserResult, UserResponse>()
            .Map(dest => dest, scr => scr.User);

        config.NewConfig<RegisterRequest, User>()
            .Map(dest => dest, src => src);
    }
}