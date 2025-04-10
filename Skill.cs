namespace KGA_OOPConsoleProject
{
    public class Skill
    {
        protected string name;
        public string Name { get { return name; } }
        protected string description;
        public string Description { get { return description; } }
        protected int useMP;
        public int UseMP { get { return useMP; } }
        protected int damage;
        public int Damage { get { return damage; } }
        public Skill()
        {

        }
        public int UseSkill()
        {
            Util.PrintText($"{name} 공격!");
            GameManager.Player.UseMP(useMP);
            return damage;
        }
    }
    public class UpperSlash : Skill
    {
        public UpperSlash()
        {
            name = "어퍼슬래시";
            description = "아래에서 위로 올려쳐 적의 빈틈을 노린다";
            useMP = 4;
            damage = 7;
        }

    }
    public class FireBall : Skill
    {
        public FireBall()
        {
            name = "화염구";
            description = "화염구를 날려 적을 불태운다";
            useMP = 7;
            damage = 10;
        }
    }
    public class LightningCut : Skill
    {
        public LightningCut()
        {
            name = "섬광발도참";
            description = "빛과 같은 속도로 적을 벤다";
            useMP = 20;
            damage = 100;
        }
    }
    public class AtomicSlash : Skill
    {
        public AtomicSlash()
        {
            name = "만라참상";
            description = "시공간 조차 베는 필살기";
            useMP = 100;
            damage = 1000;
        }
    }

}
