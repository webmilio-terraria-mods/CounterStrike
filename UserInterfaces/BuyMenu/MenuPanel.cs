using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.GameContent.UI.Elements;

namespace CounterStrike.UserInterfaces.BuyMenu
{
    public class MenuPanel : UIPanel
    {
        public MenuPanel()
        {
            MenuOptions = new List<MenuButton>();
            this.Width.Set(600, 0);
            this.Height.Set(600, 0);
            this.HAlign = 0.5f;
            this.VAlign = 0.5f;
        }

        public void PostInitialize()
        {
            int currentOption = 0;

            foreach(MenuButton button in MenuOptions)
            {
                button.Top.Set(20 + 34 * currentOption, 0);
                button.Left.Set(10, 0);
                this.Append(button);
                currentOption++;
            }
        }

        public void AddOption(string optionName, Action<MouseEvent> action = null)
        {
            MenuButton option = new MenuButton(optionName);
            option.Width.Set(200, 0);
            option.Height.Set(30, 0);

            MenuOptions.Add(option);
        }

        public List<MenuButton> MenuOptions { get; private set; }
    }
}
