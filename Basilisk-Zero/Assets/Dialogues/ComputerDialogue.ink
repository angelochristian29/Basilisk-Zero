INCLUDE globals.ink

{ derailment >= 82 && sceneToLoad == "TwentyEighthFloor": -> FileAlreadyRecovered }
{ derailment >= 70 && sceneToLoad == "TwentyEighthFloor": -> RecoverFiles}
{ derailment >= 30 && sceneToLoad == "SecondFloor": -> HackComputer }

=== HackComputer ===
#speaker:Player
Okay so I logged into the computer.
Now all I need to do is plug in the USB with the virus.
I might get fired for this ...
    * [Plug in USB]
        Okay, I think that did it!
        OH YEA the computer doesn't work anymore.
        Now I should look for that angry employee.
        ~ derailment = derailment + 10
        -> DONE

=== TalkToZackFirst ===
#speaker:Player
I should probably talk to Zach first before messign around with the PC.
-> DONE

=== RecoverFiles ===
#speaker:Player
alright so this device I have surpasses security and authorization on this system
I wonder what they have here
Well there's only one way to find out
    * [Plug in USB]
        Okay, I think that did it!
        Let me check.
        Oh DANG! what do they have here
        We have to report these deaths quick
        Now I should probably get to the last level without those guards seeing me and confront the CEO
        ~ derailment = derailment + 10
        -> DONE



=== FileAlreadyRecovered ===
#speaker:Player
I already recovered these files.
There is nothing much to do here.
I better get back to the the last floor and meet that that CEO before these guards get to me. 
-> DONE