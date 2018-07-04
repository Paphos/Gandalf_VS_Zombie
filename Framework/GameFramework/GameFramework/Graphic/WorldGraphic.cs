using System;
using System.Collections.Generic;

using GameFramework.Logic;
using GameFramework.ARanger;
using GameFramework.Graphic.Renderers;

namespace GameFramework.Graphic
{
    class WorldGraphic
    {
        private SimpleWrapperContainer<WrapperGraphic> _container;

        internal WorldGraphic(IGenerator<WrapperGraphic> generator)
        {
            _container = new SimpleWrapperContainer<WrapperGraphic>(generator);
        }

        internal void Add(Entity e)
        {
            _container.Add(e);
        }

        internal void Remove(Entity e)
        {
            _container.Remove(e);
        }

        public void Draw(Renderer renderer)
        {
            foreach (WrapperGraphic wg in _container)
            {
                wg.Draw(renderer);
            }
            renderer.Render();
        }
    }
}
