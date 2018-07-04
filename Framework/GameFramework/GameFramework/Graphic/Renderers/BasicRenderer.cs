using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using GameFramework.Graphic;
using Microsoft.Xna.Framework.Content;

namespace GameFramework.Graphic.Renderers
{
    public class BasicRenderer : Renderer
    {
        private Camera _camera;
        private GraphicsDevice _graphics;
        private SpriteBatch _spritebatch;
        private SpriteFont _font;

        private Matrix _viewMatrix;

        #region Initialisation

        public BasicRenderer(GraphicSettings graphicSettings, ContentManager content, float degreeFov, Tracker tracker)
        {
            _camera = new Camera(graphicSettings, MathHelper.ToRadians(degreeFov), tracker);
            _viewMatrix = _camera.MatrixView;
            _graphics = graphicSettings.GraphicDevice;
            _spritebatch = new SpriteBatch(_graphics);
            _font = content.Load<SpriteFont>("Arial");
        }

        #endregion

        private List<ModelWG> models = new List<ModelWG>();
        private List<Tuple<Vector2, string>> texts = new List<Tuple<Vector2, string>>();

        #region API publique

        public override void Render()
        {
            _viewMatrix = _camera.MatrixView;
            
            // 3D

            foreach (ModelWG modelWrapper in models)
            {
                RenderModel(modelWrapper);
            }

            models.Clear();

            // 2D

            SaveSettings();

            _spritebatch.Begin();

            foreach (Tuple<Vector2, string> tuple in texts)
            {
                RenderText(tuple.Item1, tuple.Item2);
            }

            _spritebatch.End();

            RestoreSettings();

            texts.Clear();
        }

        public override void DrawModel(ModelWG model)
        {
            models.Add(model);
        }

        public override void WriteAt(Vector3 worldPosition, string msg)
        {
            Vector3 projectedPosition = _graphics.Viewport.Project(worldPosition, _camera.MatrixProjection, _viewMatrix, Matrix.Identity);

            if (projectedPosition.Z < 1)
            {
                Vector2 screenPosition = new Vector2(projectedPosition.X, projectedPosition.Y);
                WriteAt(screenPosition, msg);
            }
        }

        public override void WriteAt(Vector2 screenPosition, string msg)
        {
            texts.Add(new Tuple<Vector2, string>(screenPosition, msg));
        }

        #endregion

        #region Affichage / rendu final des éléments

        private void RenderModel(ModelWG modelWG)
        {

            foreach (ModelMesh mesh in modelWG.Model.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.World = modelWG.CreateLocalSpace();
                    effect.View = _viewMatrix;
                    effect.Projection = _camera.MatrixProjection;
                    effect.EnableDefaultLighting();
                }

                mesh.Draw();
            }
        }

        private void RenderText(Vector2 screenPosition, string msg)
        {
            _spritebatch.DrawString(_font, msg, screenPosition, Color.Black);
        }

        #endregion

        #region Sauvegarde et restauration des paramètres

        private BlendState _preSpriteBlendState = null;
        private DepthStencilState _preSpriteDepthStencilState = null;
        private RasterizerState _preSpriteRasterizerState = null;
        private SamplerState _preSpriteSamplerState = null;

        private void SaveSettings()
        {
            _preSpriteBlendState = _graphics.BlendState;
            _preSpriteDepthStencilState = _graphics.DepthStencilState;
            _preSpriteRasterizerState = _graphics.RasterizerState;
            _preSpriteSamplerState = _graphics.SamplerStates[0];
        }

        private void RestoreSettings()
        {
            _graphics.BlendState = _preSpriteBlendState;
            _graphics.DepthStencilState = _preSpriteDepthStencilState;
            _graphics.RasterizerState = _preSpriteRasterizerState;
            _graphics.SamplerStates[0] = _preSpriteSamplerState;
        }

        #endregion
    }
}