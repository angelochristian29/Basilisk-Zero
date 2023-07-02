INCLUDE globals.ink

{ supportAI == 0: -> DawnAssistance | -> DawnAssistanceEnding }
=== DawnAssistance ===
#speaker:Dawn
#portrait:DawnNeutral
Hey newbie! My name's Dawn.
Do you think you can help me out real quick?
    * { derailment < 10 } [Sure thing!]
        Thanks so much!
        Ok, I just need you to help me with this logic file.
        ~ supportAI = supportAI + 10
        -> DawnFileUpload
    * { derailment >= 0 } [Sorry, I'm busy at the moment.]
        That's ok.
        You probably have a lot on your plate.
        ~ supportAI = supportAI - 10
        -> DawnAssistanceEnding

=== DawnFileUpload ===
Hey, do you think you can help me one more time?
    * [No problem, how can I help?]
        Ask the manager if you can borrow his keycard to the second floor.
        His office is to the right of the elevator.
        Tell him you want to upload a file and he'll let you know what to do.
        ~ supportAI = supportAI + 10
        -> DONE
-> END 

=== DawnAssistanceEnding ===
#speaker:Dawn
#portrait:DawnNeutral
You should go meet the manager, Nico. He's a nice guy and I think he wanted to see you.
His office is to the right of the elevator by the way.
It was nice meeting you anyway.
-> END