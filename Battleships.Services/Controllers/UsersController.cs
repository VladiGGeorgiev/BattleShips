namespace Battleships.Services.Controllers
{
    using System.Linq;
    using System.Web.Http;

    using Battleships.Data;

    public class UsersController : BaseApiConroller
    {
        public UsersController(IBattleshipsData data) : base(data)
        {
        }

        [HttpGet]
        public IHttpActionResult GetUsersCount()
        {
            var count = this.Data.Users.All().Count();
            return this.Ok(count);
        }
    }
}