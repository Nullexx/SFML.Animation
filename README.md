# SFML.Animation
SFML.Animation for SFML.Net. 

------------------------------
In the process of development.

<h3> Create Animation</h3>

To create an animation, an object of the Sprite type with a vertical SpriteSheet is required, the width and height of the frame. The first argument is an object of the RenderWindow type.

```csharp
//Example of creating an animation
Sprite spriteSheet = new Sprite(new Texture(".\location")); //Creating a SpriteSheet
int FrameWidth = 480; //SpriteSheet frame width
int FrameHeight = 400; // SpriteSheet frame height
Animation anim = new Animation(window, spriteSheet, FrameWidth, FrameHeight); // window is your RenderWindow
```

Animation can be run from the very beginning to the end, and from a certain frame to the end.

```csharp
anim.Run(); //From the beginning to the end.
```
or

```csharp
anim.Run(3, 7); //from 3 to 7 frames
```
