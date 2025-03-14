// using Code.Common.Extensions;
// using Code.Extensions;
// using Code.Gameplay.Cameras;
// using Code.Gameplay.Cameras.Provider;
// using UnityEngine;
//
// namespace Code.Gameplay.Common.Position
// {
//     public class GetRandomPositionService : IGetRandomPositionService
//     {
//         private const float SpawnDistanceGap = 0.4f;
//         
//         private readonly ICameraProvider _cameraProvider;
//
//         public GetRandomPositionService(ICameraProvider cameraProvider)
//         {
//             _cameraProvider = cameraProvider;
//         }
//         
//         public Vector3 RandomPosition(Vector3 aroundPosition)
//         {
//             var startWithHorizontal = UnityEngine.Random.Range(0, 2) == 0;
//
//             return startWithHorizontal
//                 ? HorizontalSpawnPosition(aroundPosition)
//                 : VerticalSpawnPosition(aroundPosition);
//         }
//
//         private Vector2 HorizontalSpawnPosition(Vector2 aroundPosition)
//         {
//             Vector2[] horizontalDirections = { Vector2.left, Vector2.right };
//             var primaryDirection = horizontalDirections.PickRandom();
//
//             var horizontalOffsetDistance = _cameraProvider.WorldScreenWidth / 2 + SpawnDistanceGap;
//             var verticalRandomOffset = UnityEngine.Random.Range(-_cameraProvider.WorldScreenHeight / 2,
//                 _cameraProvider.WorldScreenHeight / 2);
//
//             return aroundPosition + primaryDirection * horizontalOffsetDistance + Vector2.up * verticalRandomOffset;
//         }
//
//
//
//         private Vector2 VerticalSpawnPosition(Vector2 aroundPosition)
//         {
//             Vector2[] verticalDirections = { Vector2.up, Vector2.down };
//             var primaryDirection = verticalDirections.PickRandom();
//
//             var verticalOffsetDistance = _cameraProvider.WorldScreenHeight / 2 + SpawnDistanceGap;
//             var horizontalRandomOffset =
//                 UnityEngine.Random.Range(-_cameraProvider.WorldScreenWidth / 2, _cameraProvider.WorldScreenWidth / 2);
//
//             return aroundPosition + primaryDirection * verticalOffsetDistance + Vector2.right * horizontalRandomOffset;
//         }
//     }
// }