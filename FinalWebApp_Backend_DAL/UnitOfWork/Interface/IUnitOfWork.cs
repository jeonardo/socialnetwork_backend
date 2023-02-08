using FinalWebApp_Backend_DAL.Entities;
using FinalWebApp_Backend_DAL.Repositories.Interface;
using FinalWebApp_Backend_DAL.Repositories.Interfaces;

namespace FinalWebApp_Backend_DAL.UnitOfWork.Interface
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }

        IAuthRepository AuthRepository { get; }

        IPostRepository PostRepository { get; }

        ILikeRepository LikeRepository { get; }

        ICommentRepository CommentRepository { get; }

        IFriendRepository FriendRepository { get; }

        IMessageRepository MessageRepository { get; }

        IRoomRepository RoomRepository { get; }

    }
}
