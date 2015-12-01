namespace RoomM.Domain.UserModule.Aggregates
{
    public interface IRoleRepository : IRepository<Role>
    {
        Role GetSingleByName(string roleName);
    }
}