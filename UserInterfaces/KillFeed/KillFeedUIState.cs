using Microsoft.Xna.Framework;
using Terraria.UI;

namespace CounterStrike.UserInterfaces.KillFeed
{
    public class KillFeedUIState : UIState
    {
        public override void OnInitialize()
        {
            KillFeedElement = new KillFeedElement();
            base.Append(KillFeedElement);
        }


        public override void Update(GameTime gameTime)
        {
            if (KillFeedElement == null)
            {
                KillFeedElement = new KillFeedElement();
                base.Append(KillFeedElement);
            }


            KillFeedElement?.Update(gameTime);
        }


        public KillFeedElement KillFeedElement { get; private set; }
    }
}
