// using Code.Gameplay.Common.Time;
// using Code.Infrastructure.Systems;
// using Code.Meta.SaveLoad;
//
// namespace Code.Progress
// {
//     public class PeriodicallySaveProgressSystem : TimerExecuteSystem
//     {
//         private ISaveLoadService _saveLoadService;
//
//         public PeriodicallySaveProgressSystem(float executeIntervalSeconds, 
//             ITimeService time, ISaveLoadService saveLoadService) 
//             : base(executeIntervalSeconds, time)
//         {
//             _saveLoadService = saveLoadService;
//         }
//         
//         protected override void Execute()
//         {
//             _saveLoadService.SaveProgress();
//         }
//     }
// }