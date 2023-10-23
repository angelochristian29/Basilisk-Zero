INCLUDE globals.ink
EXTERNAL chooseLevel(levelName, enterName)

-> LevelSelect

=== LevelSelect ===
Which level would you like to go to?
    + [First Floor]
        ~ sceneToLoad = "FirstFloor"
        ~ choseLevel = true
        -> END
    + [Second Level]
        ~ sceneToLoad = "SecondFloor"
        ~ choseLevel = true
        -> END
    + [Fifteenth Level]
        ~ sceneToLoad = "FifteenthFloor"
        ~ choseLevel = true
        -> END
    + [Twenty Eighth Level]
        ~ sceneToLoad = "TwentyEighthFloor"
        ~ choseLevel = true
        -> END
    + [Seventy Second Level]
        ~ sceneToLoad = "SeventySecondFloor"
        ~ choseLevel = true
        -> END

=== function chooseLevel(levelName, enterName) ===
~ return