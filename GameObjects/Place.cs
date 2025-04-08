using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGA_OOPConsoleProject.GameObjects
{
    // 필드에서 플레이어와 플레이스의 좌표가 겹쳤을 때, 이동한다
    public class Place : GameObject
    {
        private string scene;

        public Place(string scene, char symbol, Vector2 position)
            : base(ConsoleColor.Blue, symbol, position, false,true)
        {
            this.scene = scene;
        }

        public override void Interact(Player player)
        {
            GameManager.ChangeScene(scene);
        }
    }
}
