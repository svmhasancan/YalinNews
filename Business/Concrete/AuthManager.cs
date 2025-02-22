using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Security.Hashing;
using Core.Security.JWT;
using Core.Utilities.Results;
using Entities.DTOs;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;
        public AuthManager(IUserService userService,ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims.Data);

            return new SuccessDataResult<AccessToken>(accessToken,Messages.AccessTokenCreated);
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByMail(userForLoginDto.Email);
            if (!userToCheck.Success)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, 
                userToCheck.Data.PasswordHash, 
                userToCheck.Data.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }

            return new SuccessDataResult<User>(userToCheck.Data, Messages.SuccessfulLogin);
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto)
        {
            byte[] passwordHash, passwordSalt;
            var userToCheck = _userService.GetByMail(userForRegisterDto.Email).Data;

            if(userToCheck != null)
            {
                return new ErrorDataResult<User>(Messages.UserAlreadyExists);
            }

            HashingHelper.CreatePasswordHash(userForRegisterDto.Password,out passwordHash,out passwordSalt);

            var user = new User
            {
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                Email = userForRegisterDto.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };

            _userService.Add(user);

            return new SuccessDataResult<User>(user,Messages.UserRegistered);
        }

        public IResult UserExists(string email)
        {
            var userToCheck = _userService.GetByMail(email).Data;

            if(userToCheck == null)
            {
                return new ErrorResult(Messages.UserNotFound);
            }

            return new SuccessResult(Messages.UserAlreadyExists);
        }
    }
} 