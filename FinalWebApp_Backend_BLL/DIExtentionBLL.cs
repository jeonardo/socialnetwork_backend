using FinalWebApp_Backend_BLL.Services;
using FinalWebApp_Backend_BLL.Services.Interface;
using FinalWebApp_Backend_DAL;
using Microsoft.Extensions.DependencyInjection;

namespace FinalWebApp_Backend_BLL
{
    public static class DIExtentionBLL
    {
        public static void RegisterBLLDependencies(this IServiceCollection services)
        {
            services.RegisterDependencies();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IPostService, PostService>();
            services.AddTransient<ILikeService, LikeService>();
            services.AddTransient<ICommentService, CommentService>();
            services.AddTransient<IFriendService, FriendService>();
            services.AddTransient<IMessageService, MessageService>();
            services.AddTransient<IRoomService, RoomService>();
            services.AddTransient<IMessageService, MessageService>();
        }
    }
}
