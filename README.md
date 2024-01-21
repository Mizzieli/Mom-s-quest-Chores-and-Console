# Mom’s Quest Chores and Consoles (CNC) Overview

In this game, you start on a tabletop as a child whose mom wants him to do homework. Instead, you embark on a thrilling escape with your mom chasing you. Dodge obstacles like homework pages, broomsticks, while collecting fun items like game controllers and headphones. The game gets faster as you progress, and if you hit a good obstacle you gain a point, if you hit a bad obstacle it is game over as you would be caught by your mum.

## 1. Audio Scripts

### AudioManager

This script takes care of all things sound-related in your game.

- **Usage:**
  - Attach it to any GameObject in your scene.
  - Fill in the audio sources and clips in the Unity Editor.

### GameOverScreen

This script manages what happens when the game is over.

- **Usage:**
  - Attach it to your game over screen GameObject.
  - Link the text element for displaying points in the Unity Editor.
  - Ensure the AudioManager is tagged as "Audio" in your scene.

### LoopingBackground

Makes your game background scroll.

- **Usage:**
  - Attach it to the GameObject with your background image.
  - Set the scrolling speed in the Unity Editor.

## 2. Player Scripts

### MainMenu

Handles the main menu's behavior.

- **Usage:**
  - Attach it to your main menu GameObject.
  - Connect the script to your UI button in the Unity Editor.

### MotherController

Controls how your main character (the "mother") moves.

- **Usage:**
  - Attach it to your mother GameObject.
  - Adjust the speed and other settings in the Unity Editor.

### ObstacleBehavior

Decides how obstacles behave.

- **Usage:**
  - Attach it to your obstacle GameObjects.
  - Tweak the speed and other settings in the Unity Editor.

### PlayerMovement

Manages how the player moves and interacts.

- **Usage:**
  - Attach it to your player GameObject.
  - Customize the speed, jump force, etc., in the Unity Editor.

### PlayerScore

Handles the player's score and interactions.

- **Usage:**
  - Attach it to your player GameObject.
  - Make sure to tag "GoodObstacle" and "BadObstacle" accordingly.

### RandomisedObstaclesGood

Handles interactions with "GoodObstacle" GameObjects.

- **Usage:**
  - Attach it to your "GoodObstacle" GameObjects.

## 3. Score and Obstacle Management Scripts

### SaveData

Saves and loads your game's score.

- **Usage:**
  - No need to attach this one to anything.
  - Used behind the scenes for saving and loading scores.

### ScoreManager

Manages your game's score and display.

- **Usage:**
  - Attach it to any GameManager or  GameObject.
  - Connect the text elements in the Unity Editor.

### SpawnObstacle

Handles spawning obstacles during gameplay.

- **Usage:**
  - Attach it to any empty GameObject.
  - Set spawn points and obstacle prefabs in the Unity Editor.


