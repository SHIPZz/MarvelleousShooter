using System;

namespace CodeBase.Gameplay.Quest.Services
{
    public interface IQuestSystem : IDisposable
    {
        void Init();
    }
}