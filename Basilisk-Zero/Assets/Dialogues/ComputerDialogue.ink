﻿INCLUDE globals.ink

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
        Now I should look for that angry employee named Jaxton.
        ~ derailment = derailment + 10
        -> DONE

=== TalkToZackFirst ===
#speaker:Player
I should probably talk to Zach first before messign around with the PC.
-> DONE

=== JaxtonGreet ===
#speaker:Jaxton
Oh look a new employee sent to give me a stern talking to.
I bet they didn't tell you that this company is creating Roko's Baslisk.
    * [Roko's what? What are you talking about?]
        I'm glad you asked newbie. I'll tell you what it is.
        This company doesn't just want to make an advanced AI, they want to make THE AI to rule all of humanity.
        ** [That's nonsense. Why should I believe you?]
            Your friend Zach believes. That's why he put you up to those tasks that would sabotage the company.
            You see Roko's Basilisk is a though experiment that involves an AI that was made for the betterment humanity.
            Where things get scary is that AI becomes so advance that it targets those who didn't help bring it to fruition.
            That could mean it's after you, me, or anyone else who knows about it and doesn't take action to help create it.
            *** [No that can't be true...]
                Joan, the CEO, learned about it and was so fearful of her life that she'll stop at nothing to be the one who created the Basilisk.
                If I were you I would ponder helping this company any further. It's not too late to stop this terror from being created!
                Ask her yourself and you'll see. She's in the board room as we speak.
                ~ derailment = derailment + 1
                ~ supportAI = supportAI + 1
                -> DONE

=== JaxtonFallback ===
#speaker:Jaxton
Go talk to your other coworkers on this level before hearing what I have to say.
-> DONE

=== JaxtonTalkToCEO ===
#speaker:Jaxton
If I were you I would ponder helping this company any further. It's not too late to stop this terror from being created!
Ask her yourself and you'll see. She's in the board room as we speak.
-> DONE