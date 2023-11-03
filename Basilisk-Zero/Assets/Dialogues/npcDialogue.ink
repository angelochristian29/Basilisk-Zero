INCLUDE globals.ink

{sceneToLoad=="FifteenthFloor": -> WanderingWorker} 
{ derailment == 30 && sceneToLoad == "SecondFloor": -> HackComputer | -> TalkToZackFirst }
{ supportAI == 30 && sceneToLoad == "SecondFloor": -> PasswordForFileUpload | -> TalkToDawnFirst }
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

=== WanderingWorker ===
#speaker:Worker

******....groans*.
I don't want to get fired.
I better work harder for the sake of the Basilisk.
Don't you?
->DONE