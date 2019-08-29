# Overview
game engine for quick building an 2d game

# Sprites

A image or a list of images for an object / animation in a game engine

Add using ALT + S

Naming convention: s_[object_name]_[action_name]

![Sprite](/gm_images/Sprites.png)

> `Name`: sprite name

> `Image`: view/edit an image in sprite<br/>
> - `Size`: view/edit size of the image<br/>
> ![Image_Size](/gm_images/Sprites_Image_Size.png)<br/>
> - `Edit image`: customize the image
> - `Import`: import an sprite (png image)

> `Texture Settings`
> TO BE UPDATE

> `Collision Mask`: Handle the collision of the sprite<br/>
> - `Mode`: Automatic / Full Image / Manual<br/>
>   Automatic: collision automatic detected by Game Maker<br/>
>   Full Image: collision is the all image size (not sprite size) <br/>
>   Manual: collision area is manually set<br/>
> - `Type`: Rectangle / Rectangle with rotation / Elipse / Diamond / Precise / Precise per frame
# Objects

An atomic object in game engine, it can be a Player, Enemy, Building,...

![Objects](/gm_images/Objects.png)

It can combine with other feature like : 
- `Events`: List of action / event for an Object<br/>
  Ex: Player has 'Run', 'Jump' events
- `Variable Definitions`: list of variables used in script

![Objects](/gm_images/Objects_2.png)

# Rooms

A stage to place the object in game engine

Gameplay will start as this stage

To display object in a room, drag an Object into room space

![Rooms](/gm_images/Rooms.png)

`Layers`: Have Instances / Background
- Instances: Objects placed in the Room
- Background: Background of the room

Next is about the display related components:
- Grid Size
- Room Size
- Camera Properties
- Viewpoint Properties

![Grid_Room_Camera](/gm_images/Room_Display_2.png)

`Grid Size`: "Base" size of an Object. It will be the base for size of all the Objects, Backgrounds, Room...

> Note: It just a "base" size, make the develops environment is easy to view and calculate, not affect much in the game itself

`Room Size`: The size of the stage(room)

> Note: Though can create Objects, or move Objects "outside" of the Room

`Camera Properties`(Camera Size): Display area when playing Application

![Camera_Viewpoint](/gm_images/Room_Display_3.png)

`Viewpoint Properties`: The Application (Windows) size

# Scripts

Scripting makes the images come to live

It means the player can integrate with the game like moving player, take the objects,...

Also scripting is doing some programming logics like counting points, tracking HP of the players...

For example:

When create an event "Step" of an object "Player" it will create a script file related to the Event.

And the coding in this script file will effects the action of the player

![Object_flow](/gm_images/Objects_2.png)

GameMaker designs the coding environment separate between the events and variable definitions:

- Can reference the variables in "Variable definitions" and use in the "Events"
  
  In the example, the `move_speed` is defined in "Variable definitions" and it can be used in the Step Event

## Game Loop:
The game loop is the overall flow control for the entire game program

In Game development, there is 4 states describe the state of every Object in the game:
1. Init
2. Update
3. Draw(Render)
4. Destroy

`Init`: the programming logic, resources need to prepare when Objects, Class is created

`Update`: the programming code is run, calculated by every frame of the game(over the time)

`Draw(Render)`: Draws/displays the object on the screen by every frame of the game(over the time)<br/>
=> Can understand that any changes made in `Update` makes the image/animation changes

`Destroy`: the programming logic when Objects is destroyed like releases the resources in memory or update the status...

---
## Event Scripting
The script in an Event is `Update` function that update changes every frame

But the point is GameMaker automatically execute `Draw(Render)` function so you don't have to worry about this

![Event_Step_Script](/gm_images/Event_1.png)

`x`, `y`: the Position of the Object. <br/>
When using `'+='`, `'-='` in the script, it will update the position of the Object every frame

### Position

In GameMaker, the position location x, y is baed on the `TOP_LEFT` of the screen : (x, y) = `(0, 0)`

And to the `right`, location `x will increases` and vice versa<br/>
To the `bottom`, location `y will increases` and vice versa

![Position](/gm_images/Event_2.png)

---

### Functions:
keyboard_check(KEY_NAME): <br/>
Check the keyboard is pressed

vk_... : Virtual Key

- vk_right
- vk_left
- vk_down
- vk_up

ord(keychar) : character key

place_meeting(LOCATION_X, LOCATION_Y, COLLISION_OBJECT) <br/>
Check Collision with target COLLISION_OBJECT or not

show_message(MESSAGE_STRING) : show an alert with an message

## Collision Mark:
Objects can set use collision of only 1 sprite (not default value "Same with sprite")

Because collision may be different between sprite and can cause little display bug in it

3 type of variables:
- local variable: using `var VAR_NAME;` only available within the script
- instance variable: using `VAR_NAME;` available within the object
- global variable: using `global.VAR_NAME` available thoughout your game

- built-in variable: default variable in the Object, change its variable will affect the Object immediately
  
  Example: `x`, `y`, `image_speed`, `image_xscale` is built-in variable

## Array, enum
```
enum item {
	sword,
	potion,
	spell,
	note
}

inventory_[item.sword] = "sword";
inventory_[item.potion] = "potion";
inventory_[item.spell] = "spell";
inventory_[item.note] = "note";

show_message("Click to play!");
```

## Direction
- right - 0 degree
- up - 90 degree
- left - 180 degree
- down - 279 degree

## sprite lookup table
`o-player` - `Create` event script file
```
// Defile enum variables
enum player {
	move
}

enum dir {
	right,
	up,
	left,
	down
}
```

```
// Sprite move lookup table
sprite_[player.move, dir.right] = s_player_run_right;
sprite_[player.move, dir.up] = s_player_run_up;
sprite_[player.move, dir.left] = s_player_run_right;
sprite_[player.move, dir.down] = s_player_run_down;
```

## New movement script - cover case press 2 opposite buttons
`o_player` - `Step` event script file

```
// Define local variables
var _x_input = keyboard_check(vk_right) - keyboard_check(vk_left);
var _y_input = keyboard_check(vk_down) - keyboard_check(vk_up);
```

```
// SIMPLE SOLUTION
// Reset animation speed so that if no move keyboard is pressed,
// the animation is stopped and reset
if _x_input == 0 and _y_input == 0 {
	image_index = 0;
	image_speed = MOVE_ANIM_STOP;
}

// and = &&, not = !
if _x_input != 0 and not place_meeting(x + MOVE_SPEED * _x_input, y, o_solid) {
	x += MOVE_SPEED * _x_input;
	if _x_input == 1 {
		direction_facing_ = dir.right;
	} else if _x_input == -1 {
		direction_facing_ = dir.left;
	}
	image_speed = MOVE_ANIM_SPEED;
	image_xscale = SCALE * _x_input;
}

if _y_input != 0 and not place_meeting(x, y + MOVE_SPEED * _y_input, o_solid) {
	y += MOVE_SPEED * _y_input;
	if _y_input == 1 {
		direction_facing_ = dir.down;
	} else if _y_input == -1 {
		direction_facing_ = dir.up;
	}
	image_speed = MOVE_ANIM_SPEED;
}

sprite_index = sprite_[player.move, direction_facing_]
```

## finate state machines
Should use event 0 - 15 to separate code

limit only has 16 states for this way

## Tileset : auto build maps quickly with resources set 


## depth

## alarm : run after X frames

## hitbox : dynamic objects. So create by using function instance_create() and store in array.  Same for bullets in shooting game


Update code via object / Update code via Creation Code by click an object on room

Update all the same objects / Update only specific object
