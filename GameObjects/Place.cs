using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGA_OOPConsoleProject.GameObjects
{
    public class Place : GameObject
    {
        private string scene;

        public Place(string scene, char symbol, Vector2 position)
            : base(ConsoleColor.Blue, symbol, position)
        {
            this.scene = scene;
        }

        public override void Interact(Player player)
        {
            GameManager.ChangeScene(scene);
        }
    }
}
