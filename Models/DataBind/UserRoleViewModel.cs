namespace SI_Request.Models.DataBind
{
    public class UserRoleViewModel
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public string UserName { get; set; }
        public bool IsSelected
        {
            get; set;
        }
    }
}
