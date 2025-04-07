using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGA_OOPConsoleProject.Scene
{
    public abstract class BaseScene
    {
        public string name;
        public abstract void Render();
        public abstract void Input();
        public abstract void Update();
        public abstract void Result();
        public virtual void Enter() { }        
        public virtual void SetByPrevScene() { }
        public virtual void Exit() 
        {
            GameManager.prevSceneName = name;
        }
    }
}
