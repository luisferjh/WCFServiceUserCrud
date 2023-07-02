using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Service
{

    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        List<UserDto> GetUsers();

        [OperationContract]
        UserDto GetUsersById(long idUser);

        [OperationContract]
        ResponseServiceDto AddUser(UserDto userDto);

        [OperationContract]
        ResponseServiceDto UpdateUser(UserDto userDto);

        [OperationContract]
        ResponseServiceDto DeleteUser(UserDeleteDto userDeleteDto);

        [OperationContract]
        Task<List<UserDto>> GetUsersAsyncs();

        [OperationContract]
        Task<UserDto> GetUsersByIdAsyncs(long idUser);

        [OperationContract]
        Task<ResponseServiceDto> AddUserAsyncs(UserDto userDto);

        [OperationContract]
        Task<ResponseServiceDto> UpdateUserAsyncs(UserDto userDto);

        [OperationContract]
        Task<ResponseServiceDto> DeleteUserAsyncs(UserDeleteDto userDeleteDto);

    }
}
