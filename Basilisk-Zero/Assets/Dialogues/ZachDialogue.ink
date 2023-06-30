INCLUDE globals.ink


{ derailment == 0: -> ZachTutorial | -> ZachDoTutorials }
=== ZachTutorial ===
#speaker:Zach
#portrait:ZachNeutral
Hey my name's Zach nice to meet you!
Do you want to work on the tutorials?
    * [Yes I have to]
        Okay good luck! It's going to be a slug.
        ~ derailment = derailment - 10
        -> ZachDoTutorials
    * { supportAI < 10 } [Nah those are lame]
        Hell Yea, let's play some games to pass the time!
        ~ derailment = derailment + 10
        -> ZachFirstMission

=== ZachFirstMission ===
#speaker:Zach
#portrait:ZachNeutral
Hey you seem a little rebellious. 
You want to help me mess around on the second floor?
    * [Sure, what do I have to do?]
        ~ derailment = derailment + 10
        Go grab the red key card for second floor clearance in the managers office. 
        It's to the right of the elevator, you can't miss it dude.
        I'll meet you up there after lunch.
        -> DONE
    * [Relax, I'm not trying to lose my job]
        That's cool but you're missing out my guy.
        I'll catch up with you after lunch.
        -> DONE
-> END

=== ZachDoTutorials ===
#speaker:Zach
#portrait:ZachNeutral
This company sucks am I right?
Well I have to get back to work.
-> END