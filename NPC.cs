using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGA_OOPConsoleProject
{
    // TODO 구현 : 샵 NPC, 집에서 엄마, 마을 사람들
    public class NPC : GameObject
    {
        public NPC()
        {
        }

        public NPC(ConsoleColor color, char symbol, Vector2 position, bool isOnce, bool isDead) : base(color, symbol, position, isOnce, isDead)
        {
        }

        public override void Interact(Player player)
        {
            throw new NotImplementedException();
        }
    }
}
