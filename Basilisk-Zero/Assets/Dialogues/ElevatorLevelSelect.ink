INCLUDE globals.ink

{ sceneToLoad == "FirstFloor": -> LevelSelect }
{ sceneToLoad == "SecondFloor": -> LevelSelect }
{ sceneToLoad == "FifteenthFloor": -> LevelSelect }
{ sceneToLoad == "TwentyEighthFloor": -> LevelSelect }
{ sceneToLoad == "SeventySecondFloor": -> LevelSelect }

=== LevelSelect ===
Which level would you like to go to?
    + { supportAI < 40 && derailment < 40 } [Second Level]
        ~ sceneToLoad = "SecondFloor"
        ~ choseLevel = true
        -> DONE
    + { supportAI > 60 || derailment > 60 } [Fifteenth Level]
        ~ sceneToLoad = "FifteenthFloor"
        ~ choseLevel = true
        -> DONE
    + { supportAI > 70 || derailment > 70 } [Twenty Eighth Level]
        ~ sceneToLoad = "TwentyEighthFloor"
        ~ choseLevel = true
        -> DONE
    + { supportAI > 80 || derailment > 80 }[Seventy Second Level]
        ~ sceneToLoad = "SeventySecondFloor"
        ~ choseLevel = true
        -> DONE

