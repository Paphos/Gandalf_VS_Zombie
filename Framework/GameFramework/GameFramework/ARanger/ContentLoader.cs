using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameFramework.ARanger
{
    public abstract class ContentLoader<Indexer>
    {
        private ContentManager _manager;
        private Dictionary<Indexer, Object> _loadedAssets = new Dictionary<Indexer,object>();
        private Dictionary<Indexer, string> _knownAssets = new Dictionary<Indexer,string>();

        public ContentLoader(ContentManager manager){
            _manager = manager;
        }

        protected void Add(Indexer indexer, string contentName)
        {
            _knownAssets.Add(indexer, contentName);
        }

        public ContentType Get<ContentType>(Indexer indexer)
        {
            Object content;
            if(_loadedAssets.TryGetValue(indexer,out content)){
                return (ContentType) content;
                // Exception : La ressource n'est pas au format attendu.
            }
            else{
                return Load<ContentType>(indexer);
            }
        }

        private ContentType Load<ContentType>(Indexer indexer)
        {
            string contentName = _knownAssets[indexer];
            // Exception : Aucun nom de contenu n'a été associé à l'indexeur renseigné.

            ContentType content = _manager.Load<ContentType>(contentName);
            _loadedAssets.Add(indexer, content);
            return content;
        }
    }
}
