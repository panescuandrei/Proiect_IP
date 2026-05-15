using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTycoon.Engine.Upgrades
{
    public class Pipeline : BaseUpgrade
    {
        public Pipeline()
        {
            Name = "CI/CD Pipeline";
            Cost = 700;
        }

        protected override bool UnlockCondition(GameManager manager)
            => manager.HasDualMonitor == true;

        protected override void ApplyEffect(GameManager manager)
    => manager.HasPipeline = true;

        public override void OnBugTriggered(GameManager manager)
            => manager.ReduceBugClicks(3); // reduce cu 3
    }
}
