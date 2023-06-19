INCLUDE globals.ink

#speaker:Dawn
#portrait:DawnNeutral
{ supportAI == 0: -> DawnAssistance | -> DawnAssistanceEnding }
=== DawnAssistance ===
Hey newbie! My name's Dawn.
Do you think you can help me out real quick?
    * { derailment < 10 } [Sure thing!]
        Thanks so much!
        Ok I just need you to help me with this logic file.
        ~ supportAI = supportAI + 10
        -> DawnAssistanceEnding
    * [Sorry, I'm busy at the moment.]
        That's ok.
        You probably have a lot on your plate.
        ~ supportAI = -10
        -> DawnAssistanceEnding

=== DawnAssistanceEnding ===
{supportAI > 0:
    Thanks for helping me today.
- else:
    It was nice meeting you anyway.
}

-> END