using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTycoon.Engine.Upgrades
{
    public class DualMonitorUpgrade : BaseUpgrade
    {
        public DualMonitorUpgrade()
        {
            Name = "Dual Monitor";
            Cost = 500;
        }

        protected override bool UnlockCondition(GameManager manager)
            => manager.TotalLinesOfCode >= 100;

        protected override void ApplyEffect(GameManager manager)
            => manager.BonusCodePerClick += 1;
    }
}
