

![image](https://user-images.githubusercontent.com/97399311/213511954-edf132ec-70fc-4922-9d59-6fd87d761a1e.png)

# Description
This is a project that aims to create unit formations for Real-Time Strategy games in unity.

In most RTS games, players can create formations for their units. This is done by selecting a group of units and then assigning them to a formation. These allow players to organize their forces and position them for maximum effectiveness on a virtual battlefield.

# Design/implementation

## Controls
![image](https://user-images.githubusercontent.com/97399311/213516317-a8e312bd-255c-4704-afed-0bdeccfed7d5.png)

Keyboard: 
- You can use wasd or zqsd to move the camera.

Mouse: 
- The scroll wheel can be used to zoom in and out.
- Right mouse button can be used for moving the formation
- Left mouse button can be used for unit selection

UI: 
- The UI consists of buttons and sliders, the buttons allow you to change the formation of the selected units, the sliders will allow you to change it's variables

![Controls](https://user-images.githubusercontent.com/97399311/213519300-dc8024b6-1c07-4afc-b272-f6d4be6f45a6.gif)

## Unit Selection
![image](https://user-images.githubusercontent.com/97399311/213520780-9f167ae5-ab00-4769-afc8-8e3d6d95a5ea.png)

Unit selection is done using the mouse and has two modes of selecting:<br>
**Clicking**<br>
Clicking shoots a raycast from the camera to the mouse position, if it hits a unit they get selected and added to the selected unit list<br>
**Dragging**<br>
Dragging has 3 phases, first when clicking it records the start position, whilst holding the button down it will update the end position and draw a visual and when you let go it will select all the units within the rectangle and reset the start and end position

**Shift**<br>
Holding shift allows for multiple selections to be added on top of eachother, whilst not holding it the previous units will be deselected if you select a new one.

All the selected units are stored in a list and given the ability to move, as well as getting a visual indicator of being selected.

![Selection](https://user-images.githubusercontent.com/97399311/213528154-06052226-ef05-466c-b13b-956301448c2c.gif)

## Group Manager

The group manager links the input from the mouse and UI with the formation system, keeping track of all the variables and where the input has been given and then sending them to the formation manager.

The angle between the X-Axis and end point is saved, this is used later for rotation of the formations.
The magnitude of the end position minus the start position is used for the radius of the circle formation.

![image](https://user-images.githubusercontent.com/97399311/213534312-755f69d2-f200-413a-b72c-e20c126d9ffd.png)

Every other variable is controlled using the UI. 

![image](https://user-images.githubusercontent.com/97399311/213534911-8e4fbe7b-b5dd-4bc7-b47e-22e5b054da91.png)


## Rectangle Formation
![image](https://user-images.githubusercontent.com/97399311/213535760-2b3244ca-2f8f-4437-bdc8-d8b2db7e5cff.png)

The rectangle formation takes 5 inputs: 
Location, amount of units, spread between the units, angle for rotation and amount of rows.

If rows are 0 the formation will be a square, with the rest being put to the side.
Otherwise it will calculate the units per row depending on how many rows were selected.
It then takes the location they need to go and calculates the middle point of the formation to be that location.

The formation is then made using 2 for loops, one for the width one for the height, with the iterators, spread and middle being used to translate the positions.

The entire formation is also rotated around the middle with the given angle, making it so it aligns with the direction the user put in.

https://user-images.githubusercontent.com/97399311/213542694-291beb36-23a6-4a0c-936d-8a081d564248.mp4

## Circle Formation
![image](https://user-images.githubusercontent.com/97399311/213539840-98b21600-62f7-412a-a11a-909445ffb09a.png)

The circle formation takes 6 inputs: 
Location, amount of units, radius of the circle, angle for rotation, amount of rings and offset between the rings.

First it calculates the units per ring with each ring having a near equal amount of units.

Then for each ring the location of the unit is calculated by calculating the angle for the current unit first.
The x position is calculated using the cosine of the angle times the radius and the z position is calculated using the sinus of the angle times the radius.
These are then added together with the location so they move to the correct spot.
For each ring the radius is expanded, with offset adding to this expansion.

Finally it is rotated using the same function as the rectangle.

https://user-images.githubusercontent.com/97399311/213543070-509ad77d-bce0-4641-8a86-f70598949f7d.mp4

# Result
The result is a project with a unit selection and formation system in place. 
The systems themselves are robust and easily expanded upon, with the system as it is now allowing for a lot of interesting results even with a limited amount of tools.

![image](https://user-images.githubusercontent.com/97399311/213521073-4c600100-9624-436d-b70d-c32c4556cacf.png)
![image](https://user-images.githubusercontent.com/97399311/213540696-d48570a4-39b0-4f74-bd16-91ad8b290131.png)

# Conclusion/Future work

The result is a competent project with a unit selection and formation system in place. <br>
Whilst it has a lot of room left for additions it has a very solid base that's easy to expand upon now that it's in place, especially when it comes to adding new formations and variables to those formations.
What is here already allows for a lot of creative uses and shows off the concept well.

There are a few things I would still like to add to his project mainly: 
- More variables for the existing formation
- Being able to group up and quick select units
- Improving unit and formation movement trough steering circles
- Adding a way to export and import custom formations, probably trough use of SVGs

All in all I am happy with this project and it was fun to work on, it especially helped me get more comfortable with unity UI and the possibilities it has. 
