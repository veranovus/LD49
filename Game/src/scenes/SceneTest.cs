using System;
using Raylib_cs;

namespace Game {

    public class SceneTest : Scene {

        // Entity Manager
        EntityManager entityManager;

        public SceneTest(SceneID sceneId) : base(sceneId) {

            entityManager = new EntityManager();

            entityManager.AddEntity(new EntityTest(new Transform(100, 100, 50, 50), new Color(255, 0, 0, 255)));
        }


        public override void Events() {

            // Entity Events
            entityManager.Events();
        }
        public override void Update() {
            
            // Update Entities
            entityManager.Update();
        }
        public override void Render() {

            Raylib.ClearBackground(Color.BLACK);

            // Render entities
            entityManager.Render();
        }
    }
}