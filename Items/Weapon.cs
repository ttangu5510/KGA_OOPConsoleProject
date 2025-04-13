namespace KGA_OOPConsoleProject.Items
{
    public class Weapon : Equipment
    {
        protected int power;
        public int Power { get { return power; } }

        public Weapon()
        {
            type = EquipType.Weapon;
            useDescription = "무기를 착용했다.";
        }

        public Weapon(Vector2 position) : base('↗', position)
        {
            type = EquipType.Weapon;
            useDescription = "무기를 착용했다.";
        }

        public override void Use()
        {
            Equip();
        }
    }
}
