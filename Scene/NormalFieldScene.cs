namespace KGA_OOPConsoleProject.Scene
{
    public class NormalFieldScene : FieldScene
    {
        public NormalFieldScene()
        {
            name = "NormalField";
            mapData = new string[]
               {
                    "┌-------------------------------------------------┐",
                    "|▧▧▧▧▧▧▧▧            ▤▤▤▤SHOP▤▤▤       ▤▤DOC▤▤▧▧▧▧|",
                    "|▤▤HOME▤▤            ▤▤▤▤▤ ▤▤▤▤▤  #    ▤□▤▤▤□▤▧□□▧|",
                    "|▤▨□▤▤▨□▤                              ▤▤▤ ▤▤▤▧▧▧▧|",
                    "|▤▤▤ ▤▤▤▤               ●●●                       |",
                    "                      ●●●●●●●          #           ",
                    "|               #       ●●●                       |",
                    "|▧▧▧▧▧▧▧                      #           ▧▧▧▧▧▧▧ |",
                    "|▤▤▤▤▨□▤                                  ▤▤▤▤□□▤ |",
                    "└-------------------------------------------------┘"
               };
            map = new bool[mapData.Length, mapData[0].Length];
            for (int y = 0; y < map.GetLength(0); y++)
            {
                for (int x = 0; x < map.GetLength(1); x++)
                {
                    map[y, x] = mapData[y][x] == ' ' ? true : false;
                }
            }
            gameObjects = new List<GameObject>();
            // gameObjects.Add(new Place("Town", 'T', new Vector2(1, 2)));
            // gameObjects.Add(new Place("Forest", 'F', new Vector2(11, 1)));
            // gameObjects.Add(new RedPotion(new Vector2(1, 4)));

            //몬스터 생성
            MonsterFactory slimeFactory = new MonsterFactory();
            Monster slime0 = slimeFactory.MonsterCreate("슬라임", new Vector2(4, 2));
            gameObjects.Add(slime0);
        }

        public override void SetByPrevScene()
        {
            if (GameManager.prevSceneName == "Town")
            {
                GameManager.Player.position = new Vector2(2, 2);

            }
            else if (GameManager.prevSceneName == "Forest")
            {
                GameManager.Player.position = new Vector2(10, 1);
            }
            else
            {
                GameManager.Player.position = new Vector2(2, 1);
            }
        }
    }
}
