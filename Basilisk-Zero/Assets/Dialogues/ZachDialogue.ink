INCLUDE globals.ink


{ derailment == 0: -> ZachTutorial | -> ZachDoTutorials }
=== ZachTutorial ===
#speaker:Zach
#portrait:ZachNeutral
Hey my name's Zach. Nice to meet you!
Do you want to get straight to work?
    * { supportAI >= 0 } [Yes I have to]
        Talk to Dawn on the desk left of yours. She'll have something for you to do.
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
Do you want to be apart of a little secret project I have going on?
    * [I'm in! What's the plan?]
        ~ derailment = derailment + 10
        There's a red keycard on manager's desk in his office that I need you to grab.
        It's to the right of the elevator, you can't miss it dude.
        Once you're in his office and get near the keycard, press the "E" button on your keyboard.
        I'll meet you on the second floor after you get the card.
        -> DONE
-> END

=== ZachDoTutorials ===
#speaker:Zach
#portrait:ZachNeutral
Make sure you go to Nico's office.
Just follow the green floor upwards towards the elevator.
It's to the right of the elevator, you can't miss it dude.
Well I have to get back to "work".
-> END