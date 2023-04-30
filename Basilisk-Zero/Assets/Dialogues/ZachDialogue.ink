VAR derailment = 0

-> ZachTutorial

=== ZachTutorial ===
Hey my name's Zach nice to meet you! # speaker: Zach
Do you want to work on the tutorials?
    * Yes I have to
        Okay good luck! It's going to be a slug.
        -> ZachTutorialEnding
    * Nah those are lame
        Hell Yea, let's play some games to pass the time!
        ~ derailment = 10
        -> ZachTutorialEnding

=== ZachTutorialEnding ===
{derailment > 0:
    This company sucks am I right?
- else:
    Well I have to get back to work.
}

-> END
