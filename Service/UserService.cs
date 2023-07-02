using AutoMapper;
using Domain.Models;
using Repository;
using Service.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService()
        {
            _userRepository = new UserRepository();
            _mapper = AutomapperHelper.GetMapper();
        }
       
        public List<UserDto> GetUsers()
        {
            try
            {
                List<User> users = _userRepository.GetAll();
            return _mapper.Map<List<UserDto>>(users);
            }
            catch (Exception ex)
            {
                string MessageExcepction = ex.Message.ToString();
                string plainText = string.Join("----------", new string[3] {ex.StackTrace.ToString(), ex.InnerException.ToString(),  MessageExcepction });
                // Ruta completa del archivo que deseas guardar
                string rutaArchivo = @"C:\Temp\ErrorWCF.txt";

                File.WriteAllText(rutaArchivo, MessageExcepction);
                return null;
            }
        }

        public UserDto GetUsersById(long idUser)
        {
            User user = _userRepository.Get(idUser);
            return _mapper.Map<UserDto>(user);
        }

        public ResponseServiceDto AddUser(UserDto userDto)
        {
            User user = _mapper.Map<User>(userDto);            
            var identity  = _userRepository.Insert(user);
            if (identity <= 0)
            {
                return new ResponseServiceDto
                {
                    Message = "An error has occurred inserting the entity",
                    Result = false
                };
            }

            return new ResponseServiceDto
            {
                Message = "Entity saved succesfully",
                Result = true
            };
        }

        public ResponseServiceDto UpdateUser(UserDto userDto)
        {
            User user = _mapper.Map<User>(userDto);
            bool isSuccess = _userRepository.Update(user);
            if (!isSuccess)
            {
                return new ResponseServiceDto
                {
                    Message = "An error has occurred updating the entity",
                    Result = false
                };
            }

            return new ResponseServiceDto
            {
                Message = "Entity updated succesfully",
                Result = true
            };
        }

        public ResponseServiceDto DeleteUser(UserDeleteDto userDeleteDto)
        {
            User user = _mapper.Map<User>(userDeleteDto);
            bool isSuccess = _userRepository.Delete(user);
            if (!isSuccess)
            {
                return new ResponseServiceDto
                {
                    Message = "An error has occurred deleting the entity",
                    Result = false
                };
            }

            return new ResponseServiceDto
            {
                Message = "Entity deleted succesfully",
                Result = true
            };
        }

        public async Task<List<UserDto>> GetUsersAsyncs()
        {
            List<User> users = await _userRepository.GetAllAsync();
            return _mapper.Map<List<UserDto>>(users);
        }

        public async Task<UserDto> GetUsersByIdAsyncs(long idUser)
        {
            User user = await _userRepository.GetAsync(idUser);
            return _mapper.Map<UserDto>(user);
        }

        public async Task<ResponseServiceDto> AddUserAsyncs(UserDto userDto)
        {
            User user = _mapper.Map<User>(userDto);
            var identity = await _userRepository.InsertAsync(user);
            if (identity <= 0)
            {
                return new ResponseServiceDto
                {
                    Message = "An error has occurred inserting the entity",
                    Result = false
                };
            }

            return new ResponseServiceDto
            {
                Message = "Entity saved succesfully",
                Result = true
            };
        }

        public async Task<ResponseServiceDto> UpdateUserAsyncs(UserDto userDto)
        {
            User user = _mapper.Map<User>(userDto);
            bool isSuccess = await _userRepository.UpdateAsync(user);
            if (!isSuccess)
            {
                return new ResponseServiceDto
                {
                    Message = "An error has occurred updating the entity",
                    Result = false
                };
            }

            return new ResponseServiceDto
            {
                Message = "Entity updated succesfully",
                Result = true
            };
        }

        public async Task<ResponseServiceDto> DeleteUserAsyncs(UserDeleteDto userDeleteDto)
        {
            User user = _mapper.Map<User>(userDeleteDto);
            bool isSuccess = await _userRepository.DeleteAsync(user);
            if (!isSuccess)
            {
                return new ResponseServiceDto
                {
                    Message = "An error has occurred deleting the entity",
                    Result = false
                };
            }

            return new ResponseServiceDto
            {
                Message = "Entity deleted succesfully",
                Result = true
            };
        }
    }
}
