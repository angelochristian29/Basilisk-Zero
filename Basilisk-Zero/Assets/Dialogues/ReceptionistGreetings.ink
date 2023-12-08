INCLUDE globals.ink
VAR gottenHelp = false


{supportAI < 1: -> GreetingsAndHelp | -> RepeatHelp}

=== GreetingsAndHelp ===
#speaker:Alice
#portrait:AliceNeutral
Hello! Welcome to Babyl: the leader in AI technology! Press "Enter" to proceed.
My name's Alice and you're the new employee right?
Okay! Here's a map of the building. Your desk will be in between Zach and Dawn.
If you head to your left and through the door, they should be right in front of you.
The manager is around the wall behind me watching over the people at their desks. 
He should help get you situated with the company.
Hope to see you around!
~ supportAI = supportAI + 1
~ derailment = derailment + 1
-> END

=== RepeatHelp ===
#speaker:Alice
#portrait:AliceNeutral
Just head to your left and through the door, the manager should be walking around near the desks.
If you see anyone else you want to talk to, get close and press the "E" button.
Have a nice day!
-> END