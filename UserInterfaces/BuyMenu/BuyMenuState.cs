using CounterStrike.Guns;
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
            MainMenu = new MenuPanel();
            MainMenu.AddOption("Pistols", delegate { GoTo(PistolMenu); } );
            MainMenu.AddOption("SMGs");
            MainMenu.AddOption("Heavy");
            MainMenu.AddOption("Rifles", delegate { GoTo(RifleMenu); });
            MainMenu.AddOption("Equipment", delegate { GoTo(EquipmentMenu); });
            MainMenu.AddOption("Grenades");
            MainMenu.PostInitialize();

            MainMenu.RemoveChild(MainMenu.BackButton);

            var backButton = new MenuButton("Close");
            backButton.Top.Set(440, 0);
            backButton.Left.Set(10, 0);
            backButton.Height.Set(38, 0);
            backButton.Width.Set(300, 0);
            backButton.OnClick += delegate { Visible = false; };

            RifleMenu = new MenuPanel();
            RifleMenu.AddOption("M4A4", GunDefinitionLoader.Instance.FindGeneric(x => x.UnlocalizedName == "m4a4"));
            RifleMenu.AddOption("AK 47", GunDefinitionLoader.Instance.FindGeneric(x => x.UnlocalizedName == "ak47"));
            RifleMenu.AddOption("AUG");
            RifleMenu.AddOption("SG 553");
            RifleMenu.PostInitialize();

            PistolMenu = new MenuPanel();
            PistolMenu.AddOption("Glock-18", GunDefinitionLoader.Instance.FindGeneric(x => x.UnlocalizedName == "glock18"));
            PistolMenu.AddOption("Desert Eagle", GunDefinitionLoader.Instance.FindGeneric(x => x.UnlocalizedName == "deagle"));
            PistolMenu.PostInitialize();

            EquipmentMenu = new MenuPanel();
            EquipmentMenu.AddOption("Kevlar");
            EquipmentMenu.AddOption("Kevlar + Helmet");
            EquipmentMenu.AddOption("Zeus x27");
            EquipmentMenu.AddOption("Diffusal Kit");
            EquipmentMenu.PostInitialize();

            MainMenu.Append(backButton);


            base.Append(MainMenu);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            bool pressedEsc = Keyboard.GetState().IsKeyDown(Keys.Escape) && !LastState.IsKeyDown(Keys.Escape);
            if (pressedEsc)
            {
                if (this.Visible)
                    Main.playerInventory = true;

                if(!this.HasChild(MainMenu))
                {
                    this.RemoveAllChildren();
                    this.Append(MainMenu);
                }
                else
                {
                    Visible = false;
                }
            }

            LastState = Keyboard.GetState();

            RecalculateChildren();
            Recalculate();
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            Vector2 MousePosition = new Vector2((float)Main.mouseX, (float)Main.mouseY);

            if (RifleMenu.ContainsPoint(MousePosition))
            {
                Main.LocalPlayer.mouseInterface = true;
            }

            RecalculateChildren();
            Recalculate();

            base.DrawSelf(spriteBatch);
        }

        public void GoTo(MenuPanel toGo)
        {
            this.RemoveChild(MainMenu);
            this.Append(toGo);
        }

        public MenuPanel MainMenu { get; private set; }

        public MenuPanel RifleMenu { get; private set; }

        public MenuPanel PistolMenu { get; private set; }

        public MenuPanel EquipmentMenu { get; private set; }

        public bool Visible { get; set; }

        public KeyboardState LastState { get; private set; }
    }
}
