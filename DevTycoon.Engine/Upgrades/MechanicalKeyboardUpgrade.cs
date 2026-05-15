using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTycoon.Engine.Upgrades
{
    public class MechanicalKeyboardUpgrade : BaseUpgrade
    {
        public MechanicalKeyboardUpgrade()
        {
            Name = "Mechanical Keyboard";
            Cost = 250;
        }

        protected override bool UnlockCondition(GameManager manager)
            => manager.TotalLinesOfCode >= 40;

        protected override void ApplyEffect(GameManager manager)
            => manager.HasMechanicalKeyboard = true;
    }
}
