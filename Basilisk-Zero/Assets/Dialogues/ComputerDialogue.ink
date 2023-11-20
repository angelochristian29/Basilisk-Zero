INCLUDE globals.ink

{ derailment >= 30 && sceneToLoad == "SecondFloor": -> HackComputer }

=== HackComputer ===
#speaker:Player
Okay so I logged into the computer.
Now all I need to do is plug in the USB with the virus.
I might get fired for this ...
    * [Plug in USB]
        Okay, I think that did it!
        OH YEA the computer doesn't work anymore.
        Now I should look for that angry employee named Jaxton.
        ~ derailment = derailment + 10
        -> DONE

=== TalkToZackFirst ===
#speaker:Player
I should probably talk to Zach first before messign around with the PC.
-> DONE
