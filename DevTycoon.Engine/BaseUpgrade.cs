using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTycoon.Engine
{
    public abstract class BaseUpgrade : IUpgrade
    {
        public string Name { get; protected set; }
        public double Cost { get; protected set; }
        public bool IsUnlocked { get; private set; }
        public bool IsPurchased { get; private set; }

        // Fiecare upgrade defineste propria conditie de unlock
        protected abstract bool UnlockCondition(GameManager manager);
        // Fiecare upgrade defineste propriu efect
        protected abstract void ApplyEffect(GameManager manager);

        // Observer - se apeleaza la fiecare tick
        public void OnGameStateChanged(object gameState)
        {
            GameManager manager = (GameManager)gameState;
            if (!IsUnlocked && UnlockCondition(manager))
                IsUnlocked = true;
        }

        public void Purchase(GameManager manager)
        {
            if (!IsUnlocked || IsPurchased)
                throw new NotEnoughCodeException("Upgrade not available!");

            if (manager.LinesOfCode < Cost)
                throw new NotEnoughCodeException($"You need {Cost} lines of code for {Name}.");

            manager.SpendCode(Cost);
            ApplyEffect(manager);
            IsPurchased = true;
        }
    }
}
