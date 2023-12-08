INCLUDE globals.ink

{ (derailment == 43 || supportAI == 43) && sceneToLoad == "SecondFloor": -> JaxtonTalkToCEO }
{ (derailment == 42 || supportAI == 42) && sceneToLoad == "SecondFloor": -> JaxtonGreet }

=== JaxtonGreet ===
#speaker:Jaxton
#portrait:Jaxton
Oh! Look, a new employee sent to give me a stern talking to.
I bet they didn't tell you that this company is creating Roko's Basilisk.
    * [Roko's what? What are you talking about?]
        I'm glad you asked newbie. I'll tell you what it is.
        This company doesn't just want to make an advanced AI, they want to make THE AI to rule all of humanity.
        ** [That's nonsense. Why should I believe you?]
            Your friend Zach believes. That's why he put you up to those tasks that would sabotage the company.
            You see Roko's Basilisk is a thought experiment that involves an AI that was made for the betterment of humanity.
            Where things get scary is that AI becomes so advance that it targets those who didn't help bring it to fruition.
            That could mean it's after you, me, or anyone else who knows about it and doesn't take action to help create it.
            *** [No that can't be true...]
                Joan, the CEO, learned about it and was so fearful of her life that she'll stop at nothing to be the one who created the Basilisk.
                If I were you, I would ponder helping this company any further. It's not too late to stop this terror from being created!
                Ask her yourself and you'll see. She's in the board room as we speak.
                ~ derailment = derailment + 1
                ~ supportAI = supportAI + 1
                -> DONE

=== JaxtonFallback ===
#speaker:Jaxton
#portrait:Jaxton
Go talk to your other coworkers on this level before hearing what I have to say.
-> DONE

=== JaxtonTalkToCEO ===
#speaker:Jaxton
#portrait:Jaxton
If I were you, I would ponder helping this company any further. It's not too late to stop this terror from being created!
Ask her yourself and you'll see. She's in the board room as we speak.
-> DONE