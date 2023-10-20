INCLUDE globals.ink

{ supportAI == 2: -> DawnAssistance | -> DawnAssistanceEnding }
=== DawnAssistance ===
#speaker:Dawn
#portrait:DawnNeutral
Hey newbie! My name's Dawn.
Do you want to start on your first assignment with me?
    * { derailment < 10 } [Sure thing!]
        Thanks so much!
        Ok, I just need you to write a print statement on this logic file.
        Then I need you to upload it to the 2nd Floor computer.
        ~ supportAI = supportAI + 10
        -> DawnFileUpload
    * { derailment >= 0 } [Sorry, I'm a little busy at the moment.]
        That's ok.
        You probably have a lot on your plate.
        ~ supportAI = supportAI - 10
        -> DawnAssistanceEnding

=== DawnFileUpload ===
Go to your desk and interact with your computer.
    * [Ok, how do I do that?]
        Walk over to your desk and press "E" on the keyboard!
        That should open the file I wanted you to finish.
        Then go to Nico's office and borrow his keycard to the second floor.
        His office is to the right of the elevator.
        Once you're in his office and get near the keycard, press the "E" button on your keyboard.
        When you get the card, I'll meet you up on the second floor to help upload the file.
        ~ supportAI = supportAI + 10
        -> DONE
-> END

=== DawnAssistanceEnding ===
#speaker:Dawn
#portrait:DawnNeutral
Nico's office is to the right of the elevator by the way.
Just follow the green floor upwards towards the elevator.
It was nice meeting you.
-> END