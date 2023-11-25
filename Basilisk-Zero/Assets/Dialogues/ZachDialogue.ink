INCLUDE globals.ink

{ derailment >= 30 && sceneToLoad == "SecondFloor": -> ZachDeflect }
{ derailment >= 20 && sceneToLoad == "SecondFloor": -> ZachFindUSB }
{ derailment >= 20 && sceneToLoad == "FirstFloor": -> ZachKeycardReminder }
{ derailment == 2: -> ZachTutorial | -> ZachMeetNico }
{ supportAI > 30 || derailment < 30: -> ZachDeflect }

=== ZachTutorial ===
#speaker:Zach
#portrait:ZachNeutral
Hey my name's Zach. Nice to meet you!
Do you want to get straight to work?
    * { supportAI < 40 } [Nah that sounds boring]
        Hell yea, let's play some games to pass the time!
        ~ derailment = derailment + 10
        -> ZachFirstMission
    * { supportAI >= 0 } [Yes I have to]
        Talk to Dawn on the desk left of yours. She'll have something for you to do.
        Good luck! It's going to be a slug.
        -> ZachDeflect

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
        I'll meet you on the second floor near the storage room after you get the card.
        -> DONE

=== ZachMeetNico ===
#speaker:Zach
#portrait:ZachNeutral
Make sure you meet to Nico first before talking to us. 
He usually wanders around these desks near us.
Well I have to get back to "work".
-> DONE

=== ZachFindUSB ===
#speaker:Zach
#portrait:ZachNeutral
Hey, there you are. Finally, I've been waiting here forever!
Did you know that language models like GPT-3 can reproduce and amplify harmful biases they were trained on.
And I bet you didn't know that language models produce 56 times more pollution than each of us per year!
Ok so what I had planned was that we use a virus to brick the computer in the storage room.
The only thing is I lost the USB stick in the storage room next to us.
I already look suspicious, do you think you can help me find it?
    * [Leave it to me]
        Oh man you're a lifesave you know that!
        When you find it go to the computer near the entrance of the storage room.
        Walk up to it and press "E" on the keyboard to turn it on then stick the USB and watch the magic happen.
        I also heard there's a previous employee walking around yelling. Maybe you should check that out after.
        ~ derailment = derailment + 10
        -> ZachDeflect
    * [Sorry, I have to use that computer]
        I see. You want to help the development of AI then.
        Think carefully about who you side with man.
        -> ZachDeflect

=== ZachDeflect ===
#speaker:Zach
#portrait:ZachNeutral
Hey, what are you lurking around me for?
I'm trying to act normal can't you see.
-> DONE

=== ZachKeycardReminder ===
#speaker:Zach
#portrait:ZachNeutral
Hey remember to get the keycard from Nico's desk and I'll meet you on the second floor near the storage room.
The storage room is to the right of the giant tree on the that floor.
-> DONE

=== ZachUSBReminder ===
#speaker:Zach
#portrait:ZachNeutral
Don't forget to use that USB on the computer in the storage room.
I also heard there's a previous employee walking around yelling. Maybe you should check that out after.
-> DONE