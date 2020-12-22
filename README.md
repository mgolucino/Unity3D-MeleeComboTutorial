# Unity3D-MeleeComboTutorial
![Preview](https://user-images.githubusercontent.com/46628480/102599477-25270480-40e3-11eb-9b85-c53afad3957b.png)

# Instructions
Download the **MeleeComboTutorial** folder and import it into your Unity 3D project. If you open up the demo scene, you will see that the scene is fairly empty and missing certain objects. You must go to the Unity Asset Store and download a free animation package to obtain the rest of the assets used for this tutorial.

# Fighting Motions Vol.1
![Fighting Motions Vol 1](https://user-images.githubusercontent.com/46628480/102599873-b6967680-40e3-11eb-8311-059f35f408e4.png)
Search for **Fighting Motions Vol.1** in the Asset Store and import the package into your Unity project. Once the package is done importing, the demo scene should look similar to the first image shown above. We will only be using six of the animations included in this package, which are listed below:
    
    * idle_A
    * hp_straight_left_A
    * hp_straight_right_A
    * hp_hook_left_Tiramis
    * hp_upper_right_A
    * bk_rh_right_A

To easily find these files, use the search bar on the **Project** window and copy/paste these names. You may delete the other animations or place them in a different folder so that you have an easier time locating the animations needed for this tutorial. At this point you can proceed to the tutorial.

# Animation Events
![Animation Event Times](https://user-images.githubusercontent.com/46628480/102599911-c44bfc00-40e3-11eb-82fc-6f06e006fae7.png)
The first half of making melee combos is defining the earliest points in time at which your animations can transition to the next attack. This is done through [**Animation Events**](https://docs.unity3d.com/Manual/script-AnimationWindowEvent.html). For this tutorial, we are going to name the event **NextAction**. The best place to define **NextAction** is right after the momentum of an attack has ended; placing it any earlier will cut your animations too short, while placing it any later may cause a jarring delay between player inputs and attack transitions. The image above shows a good place to define **NextAction** for each of the five attack animations.

# MeleeAttack.cs
Animation events do nothing without a corresponding *public void* method of the same name to call the event. A C# script called **MeleeAttack.cs** contains a *public void* method called **NextAction()** that activates the **NextAction** trigger in the animator whenever an animation event is called. The other trigger in the script, **MeleeAttackA**, reacts to player input and tells the animator when to proceed to the next attack. You may examine the script by double clicking on **MeleeAttack.cs** in the **Scripts** folder.

# The Animator Controller
![Initial Animator](https://user-images.githubusercontent.com/46628480/102831728-1aee5a00-43b2-11eb-9eea-93b243e59f1b.png)
The second half of making melee combos is setting up animation states and transitions in the animator controller. Go to the **Animations** folder to find the animator controller - there should be an initial and complete version of the controller. Double click on the initial version to open up the **Animator** window. The animator should look like the image above, with the idle and attack states already set up for you. Each animation state should contain a **StateHandler** component which allows some code to execute each time the animator enters a different state. Do not change the values on **StateHandler** to prevent unintended results. With the animation states all set up, all you need now is to create the transitions between states.

# Transitions Between Attack States
![Transitions Between Attack States](https://user-images.githubusercontent.com/46628480/102703456-90ccb700-4234-11eb-8643-88aaf3470acf.png)
![Transition Times](https://user-images.githubusercontent.com/46628480/102836469-17ad9b00-43bf-11eb-9b00-f54cebd0a0f9.png)
For each attack state excluding the last, create a transition that leads to the next attack. Click on one of the transition arrows to view its properties in the inspector. Uncheck the box for **Has Exit Time** and add the **NextAction** and **MeleeAttackA** triggers for the conditions. Do this for all four transitions so that your animator controller looks like the image above. Then, expand the **Settings** drop-down menu and set the **Transition Duration** for each transition to the values shown in the image above.

# Transitions Back to Idle
![Transitions Back to Idle](https://user-images.githubusercontent.com/46628480/102703458-95916b00-4234-11eb-9ef5-ce877dce5c2d.png)
When making or looking for attack animations, it is good practice to have the character model return back to the idle pose by the end of the animation. This way, we don't have to rely on the animator to interpolate back to the idle state itself, which may result in silly looking transitions. As the animation package we downloaded does this for every attack animation, we only have to set up the transitions to prevent any smoothing or interpolation between animation states. Create a transition arrow for each attack state back to the idle state, and click on one of them to view the transition properties in the inspector. Expand the **Settings** drop-down menu to view even more properties. Set the exit time to 1, the transition duration to 0, and the transition offset to 0. These settings allow the idle state to play right after the end of the attack animation, with no smoothing between the end of the one state and the beginning of the other. Do this for all five transitions back to idle so that your animator controller looks like the image above.

# Finishing Touches
![Finished Animator](https://user-images.githubusercontent.com/46628480/102703465-b2c63980-4234-11eb-8a2d-ef9d4bfe09dc.png)
To finish up the animator, make a transition from idle to the first attack of your combo sequence. Use **MeleeAttackA** as the trigger and make sure to uncheck the box for **Has Exit Time**. The completed controller is shown on the image above. You can now press play on the demo scene and test out the combo sequence; five attacks should play one after another if you press the E key five times in quick succession. If you decide not to press the E key after an attack, the character should return to the idle animation. If you are not sure that you have set up the animator controller correctly, you may compare your animator controller with the complete animator found in the **Animations** folder.
