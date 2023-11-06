INCLUDE globals.ink

{ derailment >= 60 && sceneToLoad == "TwentyEighthFloor": -> RecoverFiles}
{ supportAI >= 60 && sceneToLoad == "TwentyEighthFloor": -> DeliverFiles}
{ derailment >= 30 && sceneToLoad == "SecondFloor": -> HackComputer | -> TalkToZackFirst }
{ supportAI >= 30 && sceneToLoad == "SecondFloor": -> PasswordForFileUpload | -> TalkToDawnFirst }
{ derailment < 30 && supportAI < 30: -> npcGreetings}
=== npcGreetings ===
#speaker:Joe
#portrait:DawnNeutral
Hey there, how's it going? 
Good morning, how are you today?
    * [Doing good]
        That's good! Hope to see you around.
        -> npcBoss
    * [Silence...]
        Oh.. okay.. Well, have a good day.
        -> DONE
-> END

=== npcBoss ===
I hope the boss is in a good mood today. I don't want to get on their bad side.
    * [Yeah, I hope so too]
        I heard if you get on his bad side, something will come and get you!
        -> DONE
    * [Doesn't really matter. They're probably just like us.]
        Shhh! Don't say that so loud!
        -> DONE
-> END

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

=== TalkToDawnFirst ===
#speaker:Player
I should probably talk to Dawn first before messign around with the PC.
-> DONE

=== PasswordForFileUpload ===
#speaker:Player
Okay Dawn told me it's this computer and told me the password is 0854.
    * [I'll Type in 0854]
        That looked like it worked thankfully.
        Now I should look for that angry employee.
        ~ supportAI = supportAI + 10
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

=== DeliverFiles ===
#speaker:Player
So the pin was 0854, let me log in.
    * [I'll Type in 0854]
        ok now let me delete the selected files
        ** [delete selected files]
            Ok let me now transfer the rest into this locked authroization
            *** [transfer files]
                Ok that should do it, now let me go to CEO on floor 72 to get that promotion
                ~ supportAI = supportAI + 10
                -> DONE
