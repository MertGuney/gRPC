using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace gRPC.Service.Services;
public class UserService : User.UserBase
{
    private readonly List<UserModel> _users = new();
    public UserService()
    {
        _users.Add(new UserModel { Id = 1, Name = "Mert", Surname = "Guney" });
    }

    public override Task<Response> AddUser(AddUserRequest request, ServerCallContext context)
    {
        UserModel user = new()
        {
            Id = 2,
            Name = request.Name,
            Surname = request.Surname,
        };
        _users.Add(user);

        return Task.FromResult(new Response() { Message = "User Added." });
    }

    public override async Task GetUsers(Empty request, IServerStreamWriter<UserModel> responseStream, ServerCallContext context)
    {
        foreach (var user in _users)
        {
            await responseStream.WriteAsync(user);
        }
    }
}

