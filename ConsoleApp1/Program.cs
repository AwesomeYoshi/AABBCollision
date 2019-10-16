using Raylib;
using rl = Raylib.Raylib;

namespace ConsoleApp1
{
    static class Program
    {
        public static int Main()
        {
            // Initialization
            //--------------------------------------------------------------------------------------
            int screenWidth = 800;
            int screenHeight = 450;

            rl.InitWindow(screenWidth, screenHeight, "raylib [core] example - basic window");

            rl.SetTargetFPS(60);
            //--------------------------------------------------------------------------------------
            MyShape triangle = new MyShape();
            triangle.MyPoints.Add(new Vector2(-20, 20));
            triangle.MyPoints.Add(new Vector2(0, -20));
            triangle.MyPoints.Add(new Vector2(20, 20));
            triangle.MyPoints.Add(new Vector2(-20, 20));
            triangle.position = new Vector2(100, 100);



            //TODO:Create another object with a different shape

            MyShape rectangle = new MyShape();
            rectangle.MyPoints.Add(new Vector2(-20, 20));
            rectangle.MyPoints.Add(new Vector2(-20, -20));
            rectangle.MyPoints.Add(new Vector2(20, -20));
            rectangle.MyPoints.Add(new Vector2(20, 20));
            rectangle.MyPoints.Add(new Vector2(-20, 20));
            rectangle.position = new Vector2(300, 100);


            float tv = 0.5f;
            float sv = -0.5f;


            // Main game loop
            while (!rl.WindowShouldClose())    // Detect window close button or ESC key
            {
                // Update
                //----------------------------------------------------------------------------------
                // TODO: Update your variables here


                //----------------------------------------------------------------------------------

                // Draw
                //----------------------------------------------------------------------------------
                rl.BeginDrawing();

                rl.ClearBackground(Color.RAYWHITE);

                rl.DrawText("Congrats! You created your first window!", 190, 200, 20, Color.LIGHTGRAY);

                if (triangle.position.x > 800)
                {
                    triangle.position.x = 5;
                }

                if (triangle.position.x < 0)
                {
                    triangle.position.x = 795;
                }

                if (triangle.position.y > 450)
                {
                    triangle.position.y = 5;
                }

                if (triangle.position.y < 0)
                {
                    triangle.position.y = 445;
                }

                if (rectangle.position.x > 800)
                {
                    rectangle.position.x = 5;
                }

                if (rectangle.position.x < 0)
                {
                    rectangle.position.x = 795;
                }

                if (rectangle.position.y > 450)
                {
                    rectangle.position.y = 5;
                }

                if (rectangle.position.y < 0)
                {
                    rectangle.position.y = 445;
                }


                triangle.Draw();
                triangle.myColor = Color.DARKGREEN;

                rectangle.Draw();
                rectangle.myColor = Color.DARKGREEN;

                triangle.position.x += tv;
                rectangle.position.x += sv;

                foreach (Vector2 v in triangle.MyPoints)
                {
                    triangle.myGlobal.Add(v + triangle.position);
                }
                foreach (Vector2 v in rectangle.MyPoints)
                {
                    rectangle.myGlobal.Add(v + rectangle.position);
                }

                triangle.myBox.Fit(triangle.myGlobal);
                rectangle.myBox.Fit(rectangle.myGlobal);

                if (triangle.myBox.Overlaps(rectangle.myBox))
                {
                    tv = -0.5f;
                    sv = 0.5f;

                    triangle.myColor = Color.RED;
                    rectangle.myColor = Color.RED;
                }



                //TODO:Move the 2nd object so that it is on a collision course with the triangle
                //TODO:Implement AABB Collision detection so you know when they hit.
                //Recommend adding the AABB Functionality to the myshape class.
                //Add a method to the myshape class that causes the Bounding box to be recalculated and 
                //stored in the myshape class (with the corners/vectors relative to itself)


                //TODO:Bonus have your AABB Box drawn as a green outline to the shapes, and then turn red 
                //When they collide.


                rl.EndDrawing();
                //----------------------------------------------------------------------------------
            }

            // De-Initialization
            //--------------------------------------------------------------------------------------
            rl.CloseWindow();        // Close window and OpenGL context
                                     //--------------------------------------------------------------------------------------

            return 0;
        }
    }
}
