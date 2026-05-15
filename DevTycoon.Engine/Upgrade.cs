using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DevTycoon.Patterns;

namespace DevTycoon.Engine
{
    public interface IUpgrade : IUpgradeObserver
    {
        string Name { get; }
        double Cost { get; }
        bool IsUnlocked { get; }
        bool IsPurchased { get; }
        void Purchase(GameManager manager);
    }
}
