namespace Code.ECS.Gameplay.Features.CharacterStats.Indexing
{
    public struct StatKey
    {
        public readonly int TargetId;
        public readonly Stats Stat;

        public StatKey(int targetId, Stats stats)
        {
            TargetId = targetId;
            Stat = stats;
        }
    }
}