using System;

namespace Code.Gameplay.Quest.Services
{
    public interface IQuestSystem : IDisposable
    {
        void Init();
    }
}