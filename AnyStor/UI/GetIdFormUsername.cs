using AnyStor.BLL;

namespace AnyStor.UI
{
    internal class GetIdFormUsername : userBLL
    {
        private string loggedUser;

        public GetIdFormUsername(string loggedUser)
        {
            this.loggedUser = loggedUser;
        }
    }
}