using GameFramework.ARanger;
using GameFramework.Graphic;
using GameFramework.Logic;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;


namespace CubeTest
{
    class CustomGraphicGenerator : IGenerator<WrapperGraphic>
    {
        private CustomContentLoader _loader;

        public CustomGraphicGenerator(CustomContentLoader loader)
        {
            this._loader = loader;
        }
        public WrapperGraphic Generate(Entity e)
        {

            EntityKind ek = (EntityKind)e;

            Model model = _loader.Get<Model>(ek.Kind);

            if (ek is Personnage)
            {
                return new PersonnageWG(e, model);
            }
            else
            {
                return new ModelWG(e, model);
            }

        }
    }
}
