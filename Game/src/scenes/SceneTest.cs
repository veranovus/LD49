using System;
using Raylib_cs;

namespace Game {

    public class SceneTest : Scene {

        // Turn Manager
        TurnManager turnManager;

        // Entity Manager
        EntityManager entityManager;

        // Tilemap
        Tilemap tilemap;

        // Camera
        Camera2D camera2D;

        public SceneTest(SceneID sceneId) : base(sceneId) {

            // Initialize Tilemap
            tilemap = new Tilemap(16, 16, 16, "res/test_tileset.png");

            // Initialize Entity Manager
            entityManager = new EntityManager();

            // Initialize Turn Manager
            turnManager = new TurnManager(tilemap, entityManager);

            camera2D = new Camera2D(new Vector2(0, 0).ToNumerics(), new Vector2(0, 0).ToNumerics(), 0.0f, 1.0f) ;

            // Create and add entities to the Entity Manager
            EntityTest t = new EntityTest(new Transform(400, 400, 40, 40), new Color(123, 50, 255, 255));
            t.SetSprite("res/example.png");
            entityManager.AddEntity(t);
            Player p = new Player(new Transform(0, 0, 80, 80), turnManager);
            entityManager.AddEntity(p);
        }


        public override void Events() {

            // Entity Events
            entityManager.Events();
        }
        public override void Update() {
            
            // Update Tilemap
            tilemap.Update();

            // Update Entities
            entityManager.Update();
        }
        public override void Render() {

            // Clean Background
            Raylib.ClearBackground(Color.BLACK);

            Raylib.BeginMode2D(camera2D);
            RGBShader.Instance.Bind();
            
            // Render Tilemap
            tilemap.Render();

            // Render Entities
            entityManager.Render();

            RGBShader.Instance.Unbind();
            Raylib.EndMode2D();
        }
    }
}