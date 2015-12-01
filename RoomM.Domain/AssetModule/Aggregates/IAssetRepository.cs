namespace RoomM.Domain.AssetModule.Aggregates
{
    public interface IAssetRepository : IRepository<Asset>
    {
        bool isUniqueName(string name);
    }
}