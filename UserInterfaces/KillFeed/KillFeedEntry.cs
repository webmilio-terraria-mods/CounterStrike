using Microsoft.Xna.Framework;
using Terraria;

namespace CounterStrike.UserInterfaces.KillFeed
{
    public class KillFeedEntry
    {
        public const int
            MAX_EXISTANCE_TIME = 500,
            TIME_UNTIL_REVERSE = 460;


        public KillFeedEntry(string killerName, string victimName)
        {
            KillerName = killerName;
            VictimName = victimName;
        }


        public void Update()
        {
            if (ExistsFor >= TIME_UNTIL_REVERSE)
                XOffset += 20;

            Position = new Vector2(Main.screenWidth - 400, 40) + new Vector2(XOffset, YOffset);

            ExistsFor += 1;
        }


        public string KillerName { get; private set; }
        public string VictimName { get; private set; }

        public int ExistsFor { get; private set; }

        public float XOffset { get; set; }

        public float YOffset { get; set; }

        public Vector2 Position { get; private set; }
    }
}
