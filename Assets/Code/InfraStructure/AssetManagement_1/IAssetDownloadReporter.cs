using System;

namespace Code.InfraStructure.AssetManagement_1
{
  public interface IAssetDownloadReporter : IProgress<float>
  {
    float Progress { get; }
    event Action ProgressUpdated;
    void Report(float value);
    void Reset();
  }
}