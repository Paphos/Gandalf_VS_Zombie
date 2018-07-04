using System;

using GameFramework.Logic;
using GameFramework.ARanger;
using GameFramework.Graphic.Renderers;


namespace GameFramework.Graphic
{
    public class GraphicManager
    {
        public Tracker PlayerTracker { get; private set; }
        public Renderer Renderer { get; set; }

        private WorldGraphic _worldGraphic;

        public GraphicManager(LogicManager logicManager, Tracker playerTracker, Renderer renderer, IGenerator<WrapperGraphic> generator)
        {
            Renderer = renderer;
            PlayerTracker = playerTracker;
            _worldGraphic = new WorldGraphic(generator);
            logicManager.World.Subscribe(_worldGraphic.Add, _worldGraphic.Remove);
        }

        public void Draw()
        {
            _worldGraphic.Draw(Renderer);
        }
    }
}
