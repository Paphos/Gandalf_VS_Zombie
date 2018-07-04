using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameFramework.ARanger;
using Microsoft.Xna.Framework.Content;

namespace CubeTest
{
    class CustomContentLoader : ContentLoader<Kind>
    {
        public CustomContentLoader(ContentManager manager) 
            : base(manager)
        {
            this.Add(Kind.Gandalf, "gandalf_final2");
            this.Add(Kind.Zombie, "zombie_minecraft_2");
            this.Add(Kind.Projectile, "monkey_conv");
        }
    }

    public enum Kind
    {
        Gandalf,
        Zombie,
        Projectile
    }
}
