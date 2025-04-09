namespace KGA_OOPConsoleProject.Items
{
    public class Armor : Equipment
    {
        protected int defence;
        public int Defence { get { return defence; } }
        public Armor()
        {
            type = EquipType.Armor;
            useDescription = "방어구를 착용했다";
        }

        public Armor(Vector2 position) : base('▣', position)
        {
            type = EquipType.Armor;
            useDescription = "방어구를 착용했다";
        }

        public override void Use()
        {
            Equip();
        }
    }
}
