namespace Sweepi.UserServiceAPI.Data
{
    public class UserReadDTO : IEntity
    {
      public string Id { get; set; }
      public string Name { get; set; }
      public string Email { get; set; }
    }
}