namespace Battleships.Services.Controllers
{
    using System.Web.Http;

    using Battleships.Data;

    public abstract class BaseApiConroller : ApiController
    {
        private IBattleshipsData data;

        protected BaseApiConroller(IBattleshipsData data)
        {
            this.data = data;
        }

        public IBattleshipsData Data
        {
            get
            {
                return this.data;
            }
        }
    }
}