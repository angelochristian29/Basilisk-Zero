INCLUDE globals.ink

{ derailment == 43: -> CEOGreetPlayer | -> CEOMeetingRoom }
{ supportAI == 43: -> CEOGreetPlayer | -> CEOMeetingRoom }

=== CEOGreetPlayer ===
#speaker:Joan
Well hello. Aren't you the new employee?
    * [Yes, Jaxton told me to speak to you]
        Oh don't mind him darling. 
        He's crazy because he thinks we're working on a secret project.
        Says it's the real life Roko's Basilisk that will destroy humanity.
        It's nonsense so don't believe a thing he says alright.
        { derailment > 40: -> CEODerailmentRoute | -> GivePlayerTask }

=== CEODerailmentRoute ===
#speaker:Joan
Well it seems you've grown to like those that do not wish to help the company.
I want to give you one last chance so help me fix the actuators on the 15th floor.
Then I need you to get rid of some files on the 28th floor.
And after all that you could visit me in my office on the 72nd floor.
    * [I've heard the truth. You're going down]
        It's pointless even if you sabotage those computers, you'll never stop it.
        Your fate will end up the same as Jaxton and Zach.
        ~ derailment = derailment + 20
        -> DONE

=== GivePlayerTask ===
#speaker:Joan
The company is working on a private project though. One that does involve AI and Jaxton was the lead.
Turns out I need more help with the project. 
Would you want to take the reigns and help get this project finished sooner than later?
    * [Wow I would be honored]
        Great! I need you to fix the actuators on the 15th floor.
        Then I need you to organize some files on the 28th floor. 
        And after all that you could visit me in my office on the 72nd floor.
        It shouldn't be too difficult.
        ~ supportAI = supportAI + 20
        -> DONE

=== CEOMeetingRoom ===
#speaker:Joan
Excuse you this room is for the CEO and shareholders only.
-> DONE