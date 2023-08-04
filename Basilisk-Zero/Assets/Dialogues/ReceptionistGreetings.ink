INCLUDE globals.ink
VAR gottenHelp = false

{gottenHelp == false: -> GreetingsAndHelp | -> RepeatHelp}
=== GreetingsAndHelp ===
#speaker:Alice
#portrait:ZachNeutral
Hello welcome to Babyl: the leader in AI technology!
My name's Alice and you're the new employee right?
Ok here's a map of the building. Your desk will be in between Zach and Dawn.
If you head to your left and through the door, they should be right in front of you.
They have some things for you to do to get you situated with the company.
Hope to see you around!
~ gottenHelp = true
-> END

=== RepeatHelp ===
#speaker:Alice
#portrait:ZachNeutral
Just head to your left and through the door, Zach and Dawn should be right in front of you.
As long as you speak to one of them they should get you going on the right path.
Have a nice day!
-> END