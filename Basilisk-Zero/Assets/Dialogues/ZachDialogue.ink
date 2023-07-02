INCLUDE globals.ink


{ derailment == 0: -> ZachTutorial | -> ZachDoTutorials }
=== ZachTutorial ===
#speaker:Zach
#portrait:ZachNeutral
Hey my name's Zach. Nice to meet you!
Do you want to get straight to work?
    * { supportAI >= 0 } [Yes I have to]
        Talk to Dawn on the desk left of yours.
        She'll have something for you to do.
        Good luck! It's going to be a slug.
        ~ derailment = derailment - 10
        -> ZachDoTutorials
    * { supportAI < 10 } [Nah that sounds boring]
        Hell yea, let's play some games to pass the time!
        ~ derailment = derailment + 10
        -> ZachFirstMission

=== ZachFirstMission ===
#speaker:Zach
#portrait:ZachNeutral
Hey you seem a little rebellious. 
You want to help me mess around on the second floor?
    * [I'm in! What's the plan?]
        ~ derailment = derailment + 10
        Go grab the red key card for second floor clearance in the managers office. 
        It's to the right of the elevator, you can't miss it dude.
        I'll meet you up there after lunch.
        -> DONE
-> END

=== ZachDoTutorials ===
#speaker:Zach
#portrait:ZachNeutral
Make sure you go to the manager's office.
Just follow the green floor upwards towards the elevator.
It's to the right of the elevator, you can't miss it dude.
Well I have to get back to work.
-> END