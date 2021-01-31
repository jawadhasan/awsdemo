using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AWSServerlessDemo.Core;
using AWSServerlessDemo.DataLayer;
using AWSServerlessDemo.Web.Dtos;

namespace AWSServerlessDemo.Web.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly UserRepository _userRepository;
        public UsersController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        [HttpGet]
        public IActionResult Get()
        {
            var users = _userRepository.GetAll();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var user = _userRepository.GetById(id);
            return Ok(user);
        }


        [HttpPost("add")]
        public IActionResult Add([FromBody] UserDto userDto)
        {

            var user = new User();
            user.Email = userDto.Email;
            user.FirstName = userDto.FirstName;
            user.LastName = userDto.LastName;

            var insertedUser=  _userRepository.Insert(user);

            return Ok(insertedUser);
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _userRepository.RemoveById(id);
            return Ok();
        }



        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UserDto userDto)
        {

            var editableUser = _userRepository.GetById(id);

            //TODO: Validation

            editableUser.FirstName = userDto.FirstName;
            editableUser.LastName = userDto.LastName;

            var updatedUser = _userRepository.Update(editableUser);

            return Ok(updatedUser);
        }



    }
}
