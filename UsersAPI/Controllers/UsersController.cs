using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UsersAPI.Data;
using UsersAPI.Models;

namespace UsersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly UsersAPIDbContext dbContext;

        public UsersController(UsersAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

         
        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok(dbContext.Users.ToList());
        }

        
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetUser([FromRoute] Guid id)
        {
            var user = await dbContext.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }


        [HttpPost]
        public async Task<IActionResult> AddUser(AddUserRequest addUserRequest)
        {
            var user = new User()
            {
                Id = Guid.NewGuid(),
                UserName = addUserRequest.UserName,
                Password = addUserRequest.Password,
                FullName = addUserRequest.FullName,
                Email = addUserRequest.Email,
                Phone = addUserRequest.Phone,
                CreatedOn = addUserRequest.CreatedOn,
                Status = addUserRequest.Status,
            };

            await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync();

            return Ok(user);
        }


        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> EditUser([FromRoute] Guid id, EditUserRequest editUserRequest)
        {
            var user = await dbContext.Users.FindAsync(id);

            if (user != null)
            {
                user.UserName = editUserRequest.UserName;
                user.Password = editUserRequest.Password;
                user.FullName = editUserRequest.FullName;
                user.Email = editUserRequest.Email;
                user.Phone = editUserRequest.Phone;
                user.CreatedOn = editUserRequest.CreatedOn;
                user.Status = editUserRequest.Status;

                await dbContext.SaveChangesAsync();
                return Ok(user);
            }
            return NotFound("User Doesn't Exist!!");

        }


        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteUser([FromRoute] Guid id)
        {
            var user = await dbContext.Users.FindAsync(id);

            if (user != null)
            {
                dbContext.Remove(user);
                await dbContext.SaveChangesAsync();

                return Ok(user);
            }
            return NotFound();
        }
    }
}
