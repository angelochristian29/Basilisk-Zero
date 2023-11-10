INCLUDE globals.ink


{ derailment >= 20 && sceneToLoad == "SecondFloor": -> ZachFindUSB }
{ derailment >= 20 && sceneToLoad == "FirstFloor": -> ZachDeflect }
{ derailment <= 2: -> ZachTutorial | -> ZachMeetNico }
{ supportAI > 3 || derailment < 30: -> ZachDeflect }

=== ZachTutorial ===
#speaker:Zach
#portrait:ZachNeutral
Hey my name's Zach. Nice to meet you!
Do you want to get straight to work?
    * { supportAI < 10 } [Nah that sounds boring]
        Hell yea, let's play some games to pass the time!
        ~ derailment = derailment + 10
        -> ZachFirstMission
    * { supportAI >= 0 } [Yes I have to]
        Talk to Dawn on the desk left of yours. She'll have something for you to do.
        Good luck! It's going to be a slug.
        ~ derailment = derailment - 1
        -> ZachMeetNico

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
        I'll meet you on the second floor to the right of the big tree after you get the card.
        -> DONE

=== ZachMeetNico ===
#speaker:Zach
#portrait:ZachNeutral
Make sure you go to Nico's office.
Just follow the green floor upwards towards the elevator.
It's to the right of the elevator, you can't miss it dude.
Well I have to get back to "work".
-> DONE

=== ZachFindUSB ===
#speaker:Zach
#portrait:ZachNeutral
Hey, there you are. Finally, I've been waiting here forever!
Ok so what I had planned was that we use a virus to brick the computer in the room near the elevator.
The only thing is I lost the USB stick in the storage room next to us.
I already look suspicious, do you think you can help me find it?
    * [Leave it to me]
        Oh man you're a lifesave you know that!
        When you find it go to the room to the left of the elevator and use that thing on the computer.
        ~ derailment = derailment + 10
        -> ZachDeflect
    * [Sorry, I have to use that computer]
        I see. You want to help the development of AI then.
        Don't you know that language models like GPT-3 can reproduce and amplify harmful biases they were trained on.
        And I bet you didn't know that language models produce 56 times more pollution than each of us per year!
        Think carefully about who you side with man.
        -> ZachDeflect

=== ZachDeflect ===
#speaker:Zach
#portrait:ZachNeutral
Hey, what are you lurking around me for?
I'm trying to act normal can't you see.
-> DONE