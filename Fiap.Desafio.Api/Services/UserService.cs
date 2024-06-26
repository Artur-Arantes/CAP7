using Fiap.Desafio.Api.Data;
using Fiap.Desafio.Api.Data.Repositories;
using Fiap.Desafio.Api.Dtos;
using Fiap.Desafio.Api.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Fiap.Desafio.Api.Services;
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        private IPermissionRepository _permissionRepository;
        private IUserPermissionRepository _userPermissionRepository;
        private IPersonRepository _personRepository;
        private readonly DatabaseContext _databaseContext;

        public UserService(IPermissionRepository permissionRepository, IUserRepository userRepository,
            DatabaseContext databaseContext, IUserPermissionRepository userPermissionRepository,
            IPersonRepository personRepository)
        {
            _userPermissionRepository = userPermissionRepository;
            _permissionRepository = permissionRepository;
            _userRepository = userRepository;
            _databaseContext = databaseContext;
            _personRepository = personRepository;
        } 
    
        public void Add(UserModel user)
        {
            PermissionModel permissionModel = new PermissionModel
            {
                Name = "user"
            };

            PermissionModel permission = _permissionRepository.get(permissionModel);

            if (permission == null)
            {
                throw new Exception("Permission not found for name 'user'");
            }

            _userRepository.Add(user); 


            UserPermissionModel userPermissionModel = new UserPermissionModel
            {
                UserId = user.Id,
                PermissionId = permission.Id
            };
            _userPermissionRepository.add(userPermissionModel);
            user.UserPermissions.Add(userPermissionModel);
            _userRepository.Update(user); 
        }

        public UserModel Get(long id)
        {
         UserModel user =  _userRepository.GetById(id);
         if (user != null)
         {
             return user;
         }
         return null;
        }

        public bool IsLoginAuthorized(LoginDto loginDto)
        {

            PersonModel person = _personRepository.GetById(loginDto.Login);
            if (person != null)
            {
             UserModel userModel =  _userRepository.getByPerson(person);
             return userModel != null && userModel.Password.Equals(loginDto.password);
            }

            return false;
        }
        
            
        public void Delete(long id)
        {
            _userRepository.delete(id);
        }
    }