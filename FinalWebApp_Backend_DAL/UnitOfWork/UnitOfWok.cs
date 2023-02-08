using FinalWebApp_Backend_DAL.Entities;
using FinalWebApp_Backend_DAL.Repositories;
using FinalWebApp_Backend_DAL.Repositories.Interface;
using FinalWebApp_Backend_DAL.Repositories.Interfaces;
using FinalWebApp_Backend_DAL.UnitOfWork.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace FinalWebApp_Backend_DAL.UnitOfWork
{
    public class UnitOfWok : IUnitOfWork
    {
        private ApplicationContext _context;
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;

        public UnitOfWok(ApplicationContext context, 
            IConfiguration configuration,
           UserManager<User> userManager)
        {
            _context = context;
            _configuration = configuration;
            _userManager = userManager;
        }

        private IUserRepository _userRepository;
        private IAuthRepository _authRepository;
        private IPostRepository _postRepository;
        private ILikeRepository _likeRepository;
        private ICommentRepository _commentRepository;
        private IFriendRepository _friendRepository;
        private IMessageRepository _messageRepository;
        private IRoomRepository _roomRepository;

        public IUserRepository UserRepository
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new UserRepository(_context, _userManager);
                }
                return _userRepository;
            }
        }

        public IAuthRepository AuthRepository 
        {
            get
            {
                if (_authRepository == null)
                {
                    _authRepository = new AuthRepository(_userManager, _configuration);
                }
                return _authRepository;
            }
        }

        public IPostRepository PostRepository
        {
            get
            {
                if (_postRepository == null)
                {
                    _postRepository = new PostRepository(_context);
                }
                return _postRepository;
            }
        }

        public ILikeRepository LikeRepository
        {
            get
            {
                if (_likeRepository == null)
                {
                    _likeRepository = new LikeRepository(_context);
                }
                return _likeRepository;
            }
        }

        public ICommentRepository CommentRepository
        {
            get
            {
                if (_commentRepository == null)
                {
                    _commentRepository = new CommentRepository(_context);
                }
                return _commentRepository;
            }
        }

        public IFriendRepository FriendRepository
        {
            get
            {
                if (_friendRepository == null)
                {
                    _friendRepository = new FriendRepository(_context);
                }
                return _friendRepository;
            }
        }

        public IMessageRepository MessageRepository
        {
            get
            {
                if (_messageRepository == null)
                {
                    _messageRepository = new MessageRepository(_context);
                }
                return _messageRepository;
            }
        }

        public IRoomRepository RoomRepository
        {
            get
            {
                if (_roomRepository == null)
                {
                    _roomRepository = new RoomRepository(_context);
                }
                return _roomRepository;
            }
        }
    }
}
