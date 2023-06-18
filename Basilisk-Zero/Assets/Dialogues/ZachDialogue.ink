INCLUDE globals.ink

{ derailment == 0: -> ZachTutorial | -> ZachTutorialEnding }

=== ZachTutorial ===
#speaker:Zach
#portrait:ZachNeutral
Hey my name's Zach nice to meet you!
Do you want to work on the tutorials?
    * [Yes I have to]
        Okay good luck! It's going to be a slug.
        ~ derailment = -10
        -> ZachTutorialEnding
    * { supportAI < 10 } [Nah those are lame]
        Hell Yea, let's play some games to pass the time!
        ~ derailment = 10
        -> ZachTutorialEnding

=== ZachTutorialEnding ===
#speaker:Zach
#portrait:ZachNeutral
{derailment > 0:
    This company sucks am I right?
- else:
    Well I have to get back to work.
}
-> END

