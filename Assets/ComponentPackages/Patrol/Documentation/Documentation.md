# Patrol

Add these components to guard objects and waypoints in your game to create a simple guarding behaviour. An example guard prefab is provided in the `Examples` folder to show how to link the scripts together. These scripts require a `NavMesh` in the scene, and a `NavMeshAgent` on the guarding object.

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

This script requires an object tagged "Player" to be present within the scene. This component manages the vision cone of the AI. You can set both the `View Distance` and field of view (`fov`) of the object. This is relative to the object's forward vector. For debugging, the view cone is visible in the Unity `scene view`. If the object tagged `Player` enters the view cone, the vision system triggers the `onSpotted` event. In the example scene, the `onSpotted` event is set to change the current state to [`Chase`]. The vision system's `target` variable points to the current target.

If the current `target` object leaves the vision cone, the `target` variable becomes zero. But the vision system's `lastKnownPosition` variable gets set to the target's position at that point.

### Attack

This state requires an attached `Vision` script which it checks for a current target. If it is not found, it triggers the `lostTarget` event. In the example scene, this sets the guard to the [`Investigate`] state. If it still has a target but the target is not yet in attack range, then it triggers the `outOfRange` event. In the example scene, this switches to the [`Chase`] state. Otherwise it triggers the `attack` event repeatedly. The example scene outputs the message "Shoot" in the debug log when triggered.

### Chase

This state manages the attack range. This script requires an attached `Vision` script and `NavMeshAgent`. While this state retains a target and is not yet within the given `attackRange`, it moves towards the target using the `NavMeshAgent`. If it reaches the given `attackRange`, it triggers the `inRange` event. In the example scene, this event changes the guard to the [`Attack`] state. If the `Vision` script loses its `target` then it triggers the `targetLost` event. In the example scene, this event changes the guard to the [`Investigate`] state.

### Investigate

This state requires a `Vision` component and `NavMeshAgent` attached to this object. This state simply moves to the `lastKnownPosition` recorded by the `Vision` script. If it reaches its target (and the `Vision` script does not trigger `onSpotted` then this state triggers the `onTargetNotFound` event. In the example scene, this switches the guard back to the [`Patrol`] state.

### Patrol

This state requires an attached `NavMeshAgent` script. It finds a random [`WayPoint`] object from list of `wayPoints` set on this object. Any transform with a [`WayPoint`] script attached can be added to the `wayPoints` list. If it reaches a destination, it triggers the `onWaypointReached` event. In the example scene this resets the guard state to [`Patrol`].

[`AI`]: #AI
[`Attack`]: #Attack
[`Chase`]: #Chase
[`Investigate`]: #Investigate
[`Vision`]: #Vision
[`Patrol`]: #Patrol
[`WayPoint`]: #WayPoint
