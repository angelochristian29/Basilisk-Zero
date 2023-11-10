INCLUDE globals.ink

{ supportAI <= 23 && sceneToLoad == "SecondFloor": -> DawnDeflect}
{ supportAI >= 20 && sceneToLoad == "SecondFloor": -> DawnHelpUploadFile}
{ derailment > 40: -> DawnDeflect}
{ supportAI == 2: -> DawnAssistance | -> DawnGreetNicoFirst }
=== DawnAssistance ===
#speaker:Dawn
#portrait:DawnNeutral
Hey newbie! My name's Dawn.
Do you want to start on your first assignment with me?
    * { derailment < 40 } [Sure thing!]
        Thanks so much!
        Ok, I just need you to write a print statement on this logic file.
        Then I need you to upload it to the 2nd Floor computer.
        ~ supportAI = supportAI + 10
        -> DawnTypingGame
    * { derailment >= 0 } [Sorry, I'm a little busy at the moment.]
        That's ok.
        You probably have a lot on your plate.
        -> DawnAssistanceEnding

=== DawnTypingGame ===
#speaker:Dawn
#portrait:DawnNeutral
Go to your desk and interact with your computer.
    * [Ok, how do I do that?]
        Walk over to your desk and press "E" on the keyboard!
        That should open the file I wanted you to finish.
        Then go to Nico's office and borrow his keycard to the second floor.
        His office is to the right of the elevator.
        Once you're in his office and get near the keycard, press the "E" button on your keyboard.
        When you get the card, I'll meet you up on the second floor outside the room next to the elevator to help upload the file.
        ~ supportAI = supportAI + 10
        -> DONE

=== DawnAssistanceEnding ===
#speaker:Dawn
#portrait:DawnNeutral
Nico's office is to the right of the elevator by the way.
Just follow the green floor upwards towards the elevator.
#portrait:DawnHappy
It was nice meeting you.
-> DONE

=== DawnGreetNicoFirst ===
#speaker:Dawn
#portrait:DawnNeutral
Hey make sure you meet to Nico before you talk to me.
He should be walking around the desks.
-> DONE

=== DawnHelpUploadFile ===
#speaker:Dawn
#portrait:DawnHappy
Hey, I'm glad you found your way up here. Now we can upload the file.
You still wanted to help me out right?
    * [You betcha! Time to finish the job.]
        Great! The computer should be just inside this room behind me.
        All you have to do is type in the password that's on the file.
        I also heard there's a previous employee walking around yelling. Maybe you should check that out after.
        ~ derailment = derailment + 1
        -> DONE
    * [Actually, I change my mind.]
        #portrait:DawnPissed
        That's ok. I guess I'll just do the rest by myself.
        You should look for an angry guy wandering around since you're not going to help me.
        -> DONE

=== DawnDeflect ===
#speaker:Dawn
#portrait:DawnNeutral
Hey newbie. Best not to lounge around the company building.
Make sure you do your assigned tasks.
The manager will get after you eventually.
-> DONE