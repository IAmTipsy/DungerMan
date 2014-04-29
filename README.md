DungerMan
=========

Created by 
- Jens - Classes-Enemy/Player, Pointsystem
- Mike - Network, Sound
- Simon - Level Design, Enemy-Player interaction
- Lars - Phone Controls - Player/Enemy design

These were the assigned roles but everyone helped one another troubleshoot, test and create details and corrections for each other.

Introduction:
DungerMan is a multiplayer arena game for Android, in which up to 2 players can play together to defeat various spawning enemies to get as high score as possible. Before the game can begin a host is selected to host the game and then the other player can refresh server list and join the created server if both are on the same connection. Each player will be presented with a choice to be either a wizard (ranged) or a warrior (melee) when they join the server. The game will go on untill both players are dead.


Generel Features:
Supports 2 Players
Supports WiFi
Supports Android

In-game features:
2 different types of roles to play
2 different attacks per. role (Normal and Special attacks)
Increasing difficulty over time
Point system to keep track of your score
2D point of view with 360 degree rotation possibility

Network Setup:
The network is setup with Unity's master server. This means the the connections happen through a spot in unity's master server at port 25001. When refresh is pushed in the game it will look for all active games on the current net IP, and if it finds an active game it is possible to connect to it, assuming the 3 IP channel is the same (first 3 numbers in the IP adress). Different small function are created to allow the refreshing of servers to run for 3 seconds, to clean up the instantiated objects a player brought when leaving the server. All coding related to the connection to the server is on the game object NetworkManager in the script of same name, although there is network related coding in the other scripts such as when instantiating objects for the game it is done with "Network.Instantiate..." etc.

