# Unity3D-MeleeComboTutorial
![Preview](https://user-images.githubusercontent.com/46628480/102599477-25270480-40e3-11eb-9b85-c53afad3957b.png)

# Instructions
Download the assets folder in this repository, then import the contents into your Unity 3D project. If you open up the demo scene, you will see that the scene is fairly empty and missing certain objects. You must go to the Unity Asset Store and download a free animation package to obtain the rest of the assets used for this tutorial.

# Fighting Motions Vol.1
![Fighting Motions Vol 1](https://user-images.githubusercontent.com/46628480/102599873-b6967680-40e3-11eb-8311-059f35f408e4.png)
Search for **Fighting Motions Vol.1** in the Asset Store and import the package into your Unity project. Once the package is done importing, the demo scene should look similar to the first image shown above. We will only be using six of the animations included in this package, which are listed below:

You may delete the other animations or place them in a different folder so that you have an easier time locating the animations needed for this tutorial. At this point you can proceed to the tutorial.

# Animation Events
![Animation Event Times](https://user-images.githubusercontent.com/46628480/102599911-c44bfc00-40e3-11eb-82fc-6f06e006fae7.png)
The first half of making melee combos is defining the earliest points in time at which your animations can transition to the next attack. This is done through **Animation Events**. For this tutorial, we are going to name the event **NextAction**. The best place to define **NextAction** is right after the momentum of an attack has ended; placing it any earlier will cut your animations too short, while placing it any later may cause a jarring delay between player inputs and attack transitions. The image above shows a good place to define **NextAction** for each of the five attack animations.

# MeleeAttack.cs
Animation events do nothing without a method to actually call them. You must define a method in C# called **public void NextAction()** and decide what the animation event does. In this case, we want **NextAction** to set a trigger in the animator. This method has already been written for you, which you can examine in the **MeleeAttack.cs** script. Before moving on, also note the other trigger called **MeleeAttackA**. This trigger is set once the "E" key has been pressed on the keyboard, and serves as player input to tell the animator when to proceed to the next attack.

# The Animator Controller
The second half of making melee combos is setting up animation states and transitions in the animator controller. Find the animator controller in the Animations folder and double click on it to bring up the Animator window. The idle and attack states have been set up for you - all you need now is to set up the transitions.

# Transitions Between Attack States
![Transitions Between Attack States](https://user-images.githubusercontent.com/46628480/102703456-90ccb700-4234-11eb-8643-88aaf3470acf.png)
For each attack state excluding the last, create a transition that leads to the next attack. Click on one of the transition arrows to view its properties in the inspector. Uncheck the box for **Has Exit Time** and add the **NextAction** and **MeleeAttackA** triggers for the conditions. Do this for all four transitions so that your animator controller looks like the image above.

# Transitions Back to Idle
![Transitions Back to Idle](https://user-images.githubusercontent.com/46628480/102703458-95916b00-4234-11eb-9ef5-ce877dce5c2d.png)
When making or looking for attack animations, it is good practice to have the character model return back to the idle pose by the end of the animation. This way, we don't have to rely on the animator to interpolate back to the idle state itself, which may result in silly looking transitions. As the animation package we downloaded does this for every attack animation, we only have to set up the transitions to prevent any smoothing or interpolation between animation states. Create a transition arrow for each attack state back to the idle state, and click on one of them to view the transition properties in the inspector. Expand the **Settings** drop-down menu to view even more properties. Set the exit time to 1, the transition duration to 0, and the transition offset to 0. These settings allow the idle state to play right after the end of the attack animation, with no smoothing between the end of the one state and the beginning of the other. Do this for all five transitions back to idle so that your animator controller looks like the image above.

# Finishing Touches
![Finished Animator](https://user-images.githubusercontent.com/46628480/102703465-b2c63980-4234-11eb-8a2d-ef9d4bfe09dc.png)






