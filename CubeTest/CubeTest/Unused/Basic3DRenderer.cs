using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using GameFramework.Graphic;
/*
namespace CubeTest
{
    public class Basic3DRenderer : Renderer
    {
        private Camera _camera;
        private BasicEffect _effect;

        public Basic3DRenderer(GraphicsDevice graphicsDevice, float degreeFov, int screenWidth, int screenHeight, Tracker tracker)
        {
            float ratio = screenWidth / (float)screenHeight;
            _camera = new Camera(MathHelper.ToRadians(degreeFov), ratio, tracker);
            _effect = new BasicEffect(graphicsDevice);
            InitializeEffect();
        }

        private void InitializeEffect()
        {
            _effect.LightingEnabled = false;
            _effect.TextureEnabled = false;
            _effect.VertexColorEnabled = true;
            _effect.Projection = _camera.MatrixProjection;
            _effect.View = _camera.MatrixView;
            _effect.World = Matrix.Identity;
        }

        private List<ModelWG> models = new List<ModelWG>();

        public override void Render()
        {
            _effect.View = _camera.MatrixView;

            foreach (ModelWG modelWrapper in models)
            {
                RenderModel(modelWrapper);
            }

            models.Clear();
        }

        public override void DrawModel(ModelWG model)
        {
            models.Add(model);
        }

        private void RenderModel(ModelWG modelWG)
        {
            foreach (ModelMesh mesh in modelWG.Model.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.World = modelWG.CreateLocalSpace();
                    effect.View = _effect.View;
                    effect.Projection = _effect.Projection;
                    effect.EnableDefaultLighting();
                }

                mesh.Draw();
            }
        }
    }
}
*/
/*
foreach (WrapperGraphic ent in entityToBeRendered)
            {
                if (ent is EntityGraphic3D)
                {
                    EntityGraphic3D entity = (EntityGraphic3D)ent;
                    _effect.World = entity.CreateLocalSpace();

                    foreach (EffectPass pass in _effect.CurrentTechnique.Passes)
                    {
                        pass.Apply();
                        _effect.GraphicsDevice.DrawUserPrimitives(entity._primitiveType, entity._vertices, entity._firstVertexIndex, entity._nbPrimitives);
                    }
                }
                else
                {
                    ModelWG entity = (ModelWG)ent;

                    foreach (ModelMesh mesh in entity.Model.Meshes)
                    {
                        foreach (BasicEffect effect in mesh.Effects)
                        {
                            effect.World = entity.CreateLocalSpace();
                            effect.View = _effect.View;
                            effect.Projection = _effect.Projection;
                            effect.EnableDefaultLighting();
                        }

                        mesh.Draw();
                    }
                }
            }

            entityToBeRendered.Clear();
*/