# Concept Connect

Download or play online at https://sfbarts.itch.io/concept-connect

## Summary
Concept Connect is an educational game that has been created with the purpose of offering an engaging space that allows you to improve your cognitive abilities, especially your memory and concentration skills. It accomplishes this purpose by making the player connect two different cards that share the same concept. In this first edition, it focuses purely on artists and their works but it can be easily translated into other topics of interest. I decided to add the pictures of the artists as part of the game since we may have heard of them many times but probably won't be able to recognize any if they were next to us. It is a way of giving a face to the names we admire.

## Game Mechanics
Concept Connect counts with two different modes of play. A "learning mode" and a "normal mode". 
### Learning Mode
The learning mode allows players to familiarize themselves with the deck of cards available. It works by allowing the player to look and select the cards facing up. Once a card is selected, the card selected and the card that is a match will be highlighted. The player can refresh the game in order to get a new set of cards.

![Learning Mode Screen](/ConceptConnect/Assets/Resources/Misc/Learning%20Mode.png?raw=true)

### Normal Mode
The normal mode is the core of the game. All cards are facing down and the goal is to uncover the matching pairs. Once a pair has been matched, it will dissapear. A timer has been added in order to create a challenging atmosphere. Once a game is finished, the player can put his name to save his record time. For the first edition, scoreboard is only persistent for the duration of the session. Once the game is closed, scores are deleted. 

![Normal Mode Screen](/ConceptConnect/Assets/Resources/Misc/NormalMode.png?raw=true)


## Game UI
The game has several UI elements that are meant to enhance the player's experience. Following UX best practices, the user is able to get anywhere in the game with 2 clicks or less.

### Universal Buttons
There is one universal button on the web version and two universal buttons on the desktop version.

- **Music button** is present on all screens of the game. It allows the player to mute/unmute the game's background music.
<br>
<img src="/ReadmeImages/Sound.jpg?raw=true" width="100">

- On the desktop version, there is also an **exit button** present in all screens to allow the player to leave the game at any moment.
<br>
 <img src="/ConceptConnect/Assets/Resources/Buttons/ExitButton.png?raw=true" width="100">

- **Home** is a third universal button that is present in all screens except the main menu. It leads to the home screen. 
<br>
<img src="/ReadmeImages/Home.png?raw=true" width="120" >

### Main Menu
<img src="/ConceptConnect/Assets/Resources/Buttons/BlueButtons.png?raw=true" width="200">

There are 3 buttons on the main menu.

- The **"START" button** leads to the game mode selection screen.<br>
- The **"SCORES" button** leads to the scoreboard screen.<br>
- The **"ABOUT" button** leads to a the screen that explains the game.


### Game Mode Selection
<img src="/ReadmeImages/GameModeSelect.png?raw=true" width="200">

There is a button for **each game mode**.

### Play Screen
Both play screens share the same core UI. Apart from the music and home buttons they also have:

- **Selectable cards** to play the game.
<br>
<br>
<img src="/ReadmeImages/Cards.png?raw=true" width="500">


- **Back button** to get to the game selection mode.
<br>
<img src="/ReadmeImages/Back.png?raw=true" width="100">


- **Refresh button** to be able to get a new deck of cards.
<br>
<img src="/ConceptConnect/Assets/Resources/Buttons/ReloadButton.png?raw=true" width="100">

## Improvements Queue

#### Important
1. Fix bug in which all cards are shown face up at the end of a normal game right before the screen that records the record.

#### Desirable
1. Implement global scoreboard functionality.
2. Implement topic selection.
