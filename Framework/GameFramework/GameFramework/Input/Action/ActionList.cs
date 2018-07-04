using GameFramework.Graphic;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework.Input.Action
{
    public class ActionList
    {
        public ActionVoid ToggleFullScreen { get; private set; }
        public ActionVoid Exit { get; private set; }

        private Game _game;
        private GraphicSettings _graphicSettings;

        public ActionList(Game game, GraphicSettings settings)
        {
            _game = game;
            _graphicSettings = settings;

            ToggleFullScreen = new ActionVoid(this.M_ToggleFullScreen);
            Exit = new ActionVoid(this.M_Exit);
        }

        private void M_Exit()
        {
            _game.Exit();
        }

        private void M_ToggleFullScreen()
        {
            _graphicSettings.FullScreen = !_graphicSettings.FullScreen;
        }
    }
}
