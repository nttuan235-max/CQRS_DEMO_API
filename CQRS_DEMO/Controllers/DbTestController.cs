using Dapper;
using Microsoft.AspNetCore.Mvc;
using CQRS_DEMO.Data;
using CQRS_DEMO.DTOS;
namespace CQRS_DEMO.Controllers
{

[ApiController]
[Route("api/dbtest")]
public class DbTestController : ControllerBase
{
    private readonly OracleConnectionFactory _factory;

    public DbTestController(OracleConnectionFactory factory)
    {
        _factory = factory;
    }

    [HttpGet ("users")]
    public async Task<IActionResult> GetUsers()
    {
    using var connection = _factory.CreateConnection();
    const string sql = @"
        SELECT
            USERS_ID AS UserID,
            NAME AS Name,
            MAIL AS Mail
        FROM USERS";
    var users= await connection.QueryAsync<UserDto>(sql);
        return Ok(new
    {
        success = true,
        message = "Kết nối Oracle thành công!",
        users
    });
    }
        [HttpGet("users/{id}")]

    public async Task<IActionResult> GetUserById(int id)
        {
            using var connection = _factory.CreateConnection();
            const string sql = @"
        SELECT
            USERS_ID AS UserID,
            NAME AS Name,
            MAIL AS Mail
        FROM USERS
        WHERE USERS_ID = :id";
            var user = await connection.QuerySingleOrDefaultAsync<UserDto>(sql, new { id });
            if (user == null)
            {
                return NotFound(new
                {
                    success = false,
                    message = $"Không tìm thấy người dùng với ID {id}."
                });
            }
            return Ok(new
            {
                success = true,
                message = "Kết nối Oracle thành công!",
                user
            });
        }
        [HttpPost("users")]
        public async Task<IActionResult> CreateUser([FromBody] UserDto user)
        {
            using var connection = _factory.CreateConnection();
            const string sql = @" INSERT INTO USERS (USERS_ID, NAME, MAIL)
        VALUES (:UserID, :Name, :Mail)";

    var rows = await connection.ExecuteAsync(sql, new
    {
        user.UserID,
        user.name,
        user.mail
    });

    if (rows == 0)
    {
        return BadRequest(new
        {
            message = "Tạo User thất bại."
        });
    }

    return Ok(new
    {
        success = true,
        message = "Tạo User thành công.",
        user
    });
}
        //try
        //{ 
        //    using var connection = _factory.CreateConnection();
        //
        //    await connection.OpenAsync();
        //
        //    var result = await connection.QuerySingleAsync<int>(
        //        "SELECT 1 FROM DUAL");
        //
        //    return Ok(new
        //    {
        //        success = true,
        //        message = "Kết nối Oracle thành công!",
        //        result
        //    });
        //}
        //catch (Exception ex)
        //{
        //    return StatusCode(500, new
        //    {
        //        success = false,
        //        message = ex.Message
        //    });
        //    
    }
}
