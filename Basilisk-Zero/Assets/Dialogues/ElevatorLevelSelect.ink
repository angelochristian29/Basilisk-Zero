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
    + { sceneToLoad == "SecondFloor" } [Fifteenth Level]
        ~ sceneToLoad = "FifteenthFloor"
        ~ choseLevel = true
        -> DONE
    + {  sceneToLoad == "FifteenthFloor" } [Twenty Eighth Level]
        ~ sceneToLoad = "TwentyEighthFloor"
        ~ choseLevel = true
        -> DONE
    + {  sceneToLoad == "TwentyEighthFloor" }[Seventy Second Level]
        ~ sceneToLoad = "SeventySecondFloor"
        ~ choseLevel = true
        -> DONE

