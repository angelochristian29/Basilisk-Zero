INCLUDE globals.ink
{ supportAI == 63 || derailment == 63: -> Sensors | -> PlayerNextBigTask }
=== Sensors ===
Do you wish to begin fixing the sensors to repair the Basilisk?

    * { supportAI > 60 } [Sure thing!]
        Thanks so much!
        Sensors repair in progress...
        T-minus one minute...
        Finished.
        #speaker:player
        That should be everything on this floor now I should go to the next level.
        Back to the elevator it is.
        ~ supportAI = supportAI + 10
        -> DONE
    
    * { derailment > 60 } [I think I would rather delete them.]
        No problem.
        Sensors being deleted...
        T-minus one minute...
        Completed. Basilisk will not be happy with you.
        #speaker:player
        That should be everything on this floor now I should go to the next level.
        Back to the elevator it is.
        ~ derailment = derailment + 10
        -> DONE

=== PlayerNextBigTask ===
#speaker:player
That should be everything on this floor now I should go to the next level.
Back to the elevator it is.
-> DONE