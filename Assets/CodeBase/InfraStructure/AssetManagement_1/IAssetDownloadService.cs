using Cysharp.Threading.Tasks;

namespace CodeBase.InfraStructure.AssetManagement_1
{
  public interface IAssetDownloadService
  {
    UniTask InitializeDownloadDataAsync();
    float GetDownloadSizeMb();
    UniTask UpdateContentAsync();
  }
}