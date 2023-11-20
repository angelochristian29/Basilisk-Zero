{derailment >= 70 -> GuardDialogue | escort} 

=== GuardDialogue ===
#speaker:Guard
Hey you! This floor is restricted. You can't be here. Please get off this floor immediately.
* [Player gets off the floor] -> PlayerOffFloor

=== PlayerOffFloor ===
#speaker:Guard
Thank you for complying. Have a good day.
-> DONE

=== escort ===
#speaker:Guard
I assume your done with your task. I can escort you to the elevator
-> DONE