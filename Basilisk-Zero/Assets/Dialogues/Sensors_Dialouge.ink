INCLUDE globals.ink
-> Sensors
=== Sensors ===
Do you wish to begin fixing the sensors to repair the Basilisk?

    * { supportAI >= 0 } [Sure thing!]
        Thanks so much!
        Sensors repair in progress...
        T-minus one minute...
        Finished.
        ~ supportAI = supportAI + 10
        -> REPAIR_DONE
    
    * { derailment > 10 } [I think I would rather delete them.]
        No problem.
        Sensors being deleted...
        T-minus one minute...
        Completed. Basilisk will not be happy with you.
        ~ derailment = derailment + 10
        -> DELETE_DONE

-> REPAIR_DONE
-> END

-> DELETE_DONE
-> END