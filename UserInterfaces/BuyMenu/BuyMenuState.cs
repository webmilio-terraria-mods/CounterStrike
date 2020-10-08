using CounterStrike.Guns.Categories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Terraria;
using Terraria.UI;

namespace CounterStrike.UserInterfaces.BuyMenu
{
    public class BuyMenuState : UIState
    {
        public override void OnInitialize()
        {
            MainMenu = new BuyMenuPanel();
            var categoryIndex = 1;
            
            for (var i = GunCategories.Instance.FirstIndex; i < GunCategories.Instance.NextIndex; i++)
            {
                var category = GunCategories.Instance.GetGeneric(i);
                var riflePanel = new BuyMenuPanel();

                var gunIndex = 1;
                for (var j = 0; j < category.Count; j++)
                {
                    var gun = category[j];

                    if (gun.GunItem == default)
                        continue;

                    riflePanel.AddOption($"{gunIndex} - {gun.UnlocalizedName}", gun);
                    gunIndex++;
                }

                MainMenu.AddOption($"{categoryIndex} - {category.DisplayName}", delegate { GoTo(riflePanel); });
                MainMenu.PostInitialize();

                riflePanel.PostInitialize();
                categoryIndex++;
            }

            /*MainMenu.AddOption("Pistols", delegate { GoTo(PistolMenu); } );
            MainMenu.AddOption("SMGs");
            MainMenu.AddOption("Heavy");
            MainMenu.AddOption("Rifles", delegate { GoTo(RifleMenu); });
            MainMenu.AddOption("Equipment", delegate { GoTo(EquipmentMenu); });
            MainMenu.AddOption("Grenades");
            MainMenu.PostInitialize();*/

            MainMenu.RemoveChild(MainMenu.BackButton);

            var backButton = new BuyMenuButton("Close");
            backButton.Top.Set(440, 0);
            backButton.Left.Set(10, 0);
            backButton.Height.Set(38, 0);
            backButton.Width.Set(300, 0);
            backButton.OnClick += delegate { Visible = false; };

            /*RifleMenu = new BuyMenuPanel();
            RifleMenu.AddOption("M4A4", GunDefinitions.Instance.FindGeneric(x => x.UnlocalizedName == "m4a4"));
            RifleMenu.AddOption("AK 47", GunDefinitions.Instance.FindGeneric(x => x.UnlocalizedName == "ak47"));
            RifleMenu.AddOption("AUG");
            RifleMenu.AddOption("SG 553");
            RifleMenu.PostInitialize();

            PistolMenu = new BuyMenuPanel();
            PistolMenu.AddOption("Glock-18", GunDefinitions.Instance.FindGeneric(x => x.UnlocalizedName == "glock18"));
            PistolMenu.AddOption("Desert Eagle", GunDefinitions.Instance.FindGeneric(x => x.UnlocalizedName == "deagle"));
            PistolMenu.PostInitialize();

            EquipmentMenu = new BuyMenuPanel();
            EquipmentMenu.AddOption("Kevlar");
            EquipmentMenu.AddOption("Kevlar + Helmet");
            EquipmentMenu.AddOption("Zeus x27");
            EquipmentMenu.AddOption("Diffusal Kit");
            EquipmentMenu.PostInitialize();*/

            MainMenu.Append(backButton);


            Append(MainMenu);
        }


        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            var state = Keyboard.GetState();

            bool pressedEsc = state.IsKeyDown(Keys.Escape) && !LastState.IsKeyDown(Keys.Escape);

            if (pressedEsc)
            {
                if (Visible)
                    Main.playerInventory = true;

                if(!HasChild(MainMenu))
                {
                    RemoveAllChildren();
                    Append(MainMenu);
                }
                else
                {
                    Visible = false;
                }
            }

            LastState = state;

            RecalculateChildren();
            Recalculate();
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            var mousePosition = new Vector2(Main.mouseX, Main.mouseY);

            if (MainMenu.ContainsPoint(mousePosition))
            {
                Main.LocalPlayer.mouseInterface = true;
            }

            RecalculateChildren();
            Recalculate();

            base.DrawSelf(spriteBatch);
        }

        public void GoTo(BuyMenuPanel toGo)
        {
            RemoveChild(MainMenu);
            Append(toGo);
        }


        public BuyMenuPanel MainMenu { get; private set; }

        public bool Visible { get; set; }

        public KeyboardState LastState { get; private set; }
    }
}
