Collector Instructions
Scenes:
In the scenes folder under scenes are multiple scenes that point to one another
Start- starting screen of the game (Please start at the start scene) Game- the actual game scene
Fail- losing screen of the game
Win- winning screen of the game

Controls:
Left key- moves the player object left at a fixed velocity 
Right key- moves the player object right at a fixed velocity 
Up key- applies force so the player jumps up
W- moves the helper/box object up at a fixed velocity 
A- moves the helper/box object left at a fixed velocity 
S- moves the helper/box object down at a fixed velocity 
D- moves the helper/box object right at a fixed velocity


Win/Lose/Score:
Score +1 if the player collects a strawberry
Score -1 if the player collects a blueberry
Win- when collecting 10 strawberries before the timer counts down
Lose- when collecting less than 10 strawberries before the timer counts down

The behavior of Elements: 

Shirley/Player: person icon
- holding the left/right/up buttons moves the player in that direction
- spawns a blueberry/ strawberry every fixed amount of time
- exiting the screen causes the icon to respawn from the top of the screen
  
Helper/box: strawberry box icon that can be moved around to support the player
- holding the w, a, s, and d buttons moves the helper in that direction
- exiting the screen causes the icon to respawn from the top of the screen -
    
Strawberry: collected item randomly spawned from the top of the screen that the user collects to score
- Upon spawn, the enemy drops from the top of the screen
- Upon collision with the player, it destructs
- Increases score by 1 upon this destruction
- “Bling” sound produced by collider player
- Upon collision with the ground, selt destructs after a set amount of time
  
Blueberry: avoided item randomly spawned from the top of the screen that the user needs to avoid
- Upon spawn, the enemy drops from the top of the screen
- Upon collision with the player, it destructs
- Decrease score by 1 upon this destruction
- “Wawah” sound produced by collider player
- Upon collision with the ground, selt destructs after a set amount of time
