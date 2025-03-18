// using Code.ECS.Systems;
//
// namespace Code.ECS.Gameplay.Features.Animations
// {
//     public sealed class AnimationFeature : Feature
//     {
//         public AnimationFeature(ISystemFactory systems)
//         {
//             
//         }
//     }
//
//
//
//     public class MarkAnimationFinishedSystem : IExecuteSystem
//     {
//         private readonly IGroup<GameEntity> _entities;
//
//         public MarkAnimationFinishedSystem(GameContext game)
//         {
//             _entities = game.GetGroup(GameMatcher
//                 .AllOf(GameMatcher.matcher));
//         }
//
//         public void Execute()
//         {
//             foreach (GameEntity entity in _entities)
//             {
//                 
//             }
//         }
//     }
// }