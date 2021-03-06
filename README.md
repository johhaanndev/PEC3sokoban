# PEC3_Sokoban_clone
_If Window layout error pops up when trying to open unity project, read the last lines of README file_

Video explanation (spanish): https://youtu.be/dZTkMmQCm-g

Tool to design levels quicker

This repository shows how you can use photoshop as a tool to design new levels in Unity.

As everyone played, at least once in your life, a box pusher game, there will not be any explanation of the gameplay. Instead, you will be shown how to use photoshop as your level editor tool.

**Basics**

Game goal is to move the boxes (black circles) and put them in every goal point (pink square) moving your player (blue box). Player can only move 1 box at a time, you can not move two boxes in the same direction at a time nor pull boxes. Only push 1 box. Level finishes when all goal points are filled with a box.

Mainly, this tool is about pixels and colors. To design a new level, we will set small dimensions, for example a 16x16 pixels. Then decide which colors are we usign for each element in the game:
- Black for walls.
- Red for boxes.
- Yellow for goal points.
- Walkable zones will be left empty.

Having these colors, we start drawing our level, then Unity will use a script to transfer the colors into game prefabs.

**Level Generator script**

This script will analyze pixel per pixel the picture from photoshop by calling a public Texture2D type and taking the .psd or .png picture stored in the assets directory.
With a public Transform, we will move to map where it is more convenient for the camera. This way, we assure all the map is on camera. And the last variable will be a public array for the colors.

These colors need to be a special data type, so we are setting a new script for them: ColorToPrefab.

_ColorToPrefab_

It contains two variables:
- The color used in photoshop
- The prefab we are using for each color.

With this array, we can add and delete as any elements as we want, and then chosing the colors for every prefab manually in the inspector.

This script contains two unique methods: GenerateLevel() and GenerateTile(int x, int y).

_GenerateLevel()_

It will run over every pixel in the image using two for loops like a matrix. Every loop will call the GenerateTile() to create a tile in the level

_GenerateTile(int x, int y)_

For every pixel it will call what color it is and start comparing. If the pixel's alpha is 0, then it means is a walkable pixel and just returns. If not, it runs over the colors array and check 1 by 1 if the color in the array is the same as the pixel painted. Then we instantiate the prefab in the position (x, y)

**Unity Failed to load Windows layout error**

This error might pop up when trying to open the project in Unity Hub. To solve this, you will need to go to LayoutError directory in this same repository, copy the _CurrentLayout-default.dwlt_ and paste it in the Library directory. It will say there is already a file with this name, replace it.

Once you have replaced it, click on the System Tray (in the windows bar, next to the hour and date should be little icons as wi-fi and volume), Unity Hub should appear. Right-click and Quit Unity Hub. Re-open Unity Hub and you can now use the unity project.

If this quick guide did not work (maybe the _CurrentLayout-default.dwlt_ do not fit your PC) you can use this tutorial that uses the PC layout parameters: https://www.youtube.com/watch?v=hGukVu1DR18&ab_channel=GameTrick
