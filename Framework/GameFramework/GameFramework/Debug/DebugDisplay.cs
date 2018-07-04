using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Text;
using GameFramework.Graphic;
using GameFramework.Graphic.Renderers;

namespace GameFramework.Debug
{
    static public class DebugDisplay
    {
        static private Vector2 _statusLocation = new Vector2(5, 5);
        static private Renderer _renderer = null;
        static private StringBuilder _sb = new StringBuilder();
        static private Dictionary<string, string> _debugInfos = new Dictionary<string, string>();

        static public void Initialize(Renderer r)
        {
            _renderer = r;
        }

        static public void Write(string name, string value)
        {
            if (!_debugInfos.ContainsKey(name))
            {
                _debugInfos.Add(name, value);
            }
            else
            {
                _debugInfos[name] = value;
            }
        }

        static public void Commit()
        {
            _sb.AppendLine("******* WORK IN PROGRESS *******");
            _sb.AppendLine("#BuildWithMonogame");
            _sb.AppendLine("[F11] pour mettre en plein ecran");
            _sb.AppendLine("[Space] pour mettre en pause\n");

            foreach (KeyValuePair<string, string> kvp in _debugInfos)
            {
                _sb.AppendFormat("{0} = {1}\n", kvp.Key, kvp.Value);
            }

            _renderer.WriteAt(_statusLocation, _sb.ToString());
            _sb.Clear();
        }
    }
}
