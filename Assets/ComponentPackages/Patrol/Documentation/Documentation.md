# Patrol

Add these components to guard objects and waypoints in your game to create a simple guarding behaviour.

## Contents

This component is made from the following behaviours:
- [`AI`]
- [`Vision`]

And the following states:
- [`Attack`]
- [`Chase`]
- [`Investigate`]
- [`Patrol`]

### AI

This component manages the current state. It holds a list of states that the AI supports and when a new behaviour is requested, it activates that behaviour by name and disables any others.

### Vision

This component manages the vision cone of the AI. You can set both the `View Distance` and field of view (`fov`) of the object. This is relative to the object's forward vector. For debugging, the view cone is visible in the Unity `scene view`. If an object tagged "Player" enters the view cone, the vision system switches the current state to [`Chase`]

### Attack

This state checks the current vision target. If it is not found, it reverts to the [`Investigate`] state. If it still has a target but the target is not yet in range, then it switches to the [`Chase`] state. Otherwise it attacks.

### Chase

This state manages the attack range. While this state retains a target and is not yet within attack range, then it moves towards the target. If it reaches attack range, then it transitions into the attack state.

### Investigate

This state simply moves to the last known position of the player as recorded by the vision system. If it does not see the player from there, it switches back into a [`Patrol`] state.

### Patrol

This state finds a random [`WayPoint`] object from the supplied list and navigates to it. If it reaches that point, it finds another random [`WayPoint`] and navigates to that.

[`AI`]: #AI
[`Attack`]: #Attack
[`Chase`]: #Chase
[`Investigate`]: #Investigate
[`Vision`]: #Vision
[`Patrol`]: #Patrol
[`WayPoint`]: #WayPoint
