using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTycoon.Engine.Upgrades
{
    public class EspressoMachine : BaseUpgrade
    {
        public EspressoMachine()
        {
            Name = "Espresso Machine";
            Cost = 1000;
        }

        protected override bool UnlockCondition(GameManager manager)
            => manager.HasPipeline;

        protected override void ApplyEffect(GameManager manager)
        {
            manager.HasEspressoMachine = true;
            throw new Exception("Apply effect espresso machine - To be implemented");
        }
    }
}
