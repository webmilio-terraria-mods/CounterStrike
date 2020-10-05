using Terraria.UI;

namespace CounterStrike.UserInterfaces.BuyMenu
{
    public class BuyMenuState : UIState
    {
        public override void OnInitialize()
        {
            RifleMenu = new MenuPanel();
            RifleMenu.AddOption("Maverick M4A1 Carbine");
            RifleMenu.AddOption("CV 47");
            Visible = true;

            base.Append(RifleMenu);
        }

        public MenuPanel RifleMenu { get; private set; }

        public bool Visible { get; set; }
    }
}
