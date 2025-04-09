namespace KGA_OOPConsoleProject
{
    public abstract class Equipment : Item
    {
        public enum EquipType { Armor, Weapon }
        protected int durability;
        public int Durability {  get { return durability; } }
        protected EquipType type;
        public EquipType Type { get { return type; } }

        public Equipment(char symbol, Vector2 position) : base(ConsoleColor.Cyan, symbol, position, false)
        {
            isUsable = false;
            durability = 100;
        }
        public Equipment()
        {
            isUsable = false;
            durability = 100;
        }


        public void Equip()
        {
            if (durability > 0)
            {
                GameManager.Player.Equip(this);
            }
            else
            {
                Util.PrintText("심하게 마모되어 장비할 수 없다...");
            }
        }
        public void UnEquip()
        {
            GameManager.Player.UnEquip(this);
        }

        public override void Interact(Player player)
        {
            Util.PrintText($"{name}을 획득했다!");
            GameManager.Player.Inventory.Add(this);
        }
    }
}
