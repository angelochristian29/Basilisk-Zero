INCLUDE globals.ink

{derailment <= 82 && supportAI <= 63: -> GuardDialogue}
{derailment >= 83: -> GuardTrap} 
{supportAI >= 73 && supportAI < 83 : -> Directions}
{supportAI >= 83: -> Escort} 


=== GuardDialogue ===
#speaker:Guard
Hey you! This floor is restricted. You can't be here. Please get off this floor immediately.
    * [Player gets off the floor] 
        -> PlayerOffFloor

=== GuardTrap ===
#speaker:Guard
Hey you! This floor is Classified! 
What have you got in your hands?! 
I am not going to let you leave with what you have!
-> DONE

=== Directions ===
#speaker:Guard
If you are looking for the computer lab, it is just in the room on the right.
-> DONE

=== PlayerOffFloor ===
#speaker:Guard
Thank you for complying. Have a good day.
-> DONE

=== Escort ===
#speaker:Guard
I assume you're done with your task. I can escort you to the elevator.
-> DONE