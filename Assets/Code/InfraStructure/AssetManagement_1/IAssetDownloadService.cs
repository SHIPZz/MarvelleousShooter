using Cysharp.Threading.Tasks;

namespace Code.InfraStructure.AssetManagement_1
{
  public interface IAssetDownloadService
  {
    UniTask InitializeDownloadDataAsync();
    float GetDownloadSizeMb();
    UniTask UpdateContentAsync();
  }
}