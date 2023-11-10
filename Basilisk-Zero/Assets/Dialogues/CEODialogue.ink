INCLUDE globals.ink

{ derailment >= 40 || supportAI >= 30: -> CEOGreetPlayer | -> CEOMeetingRoom}

=== CEOGreetPlayer ===
Well hello. Aren't you the new employee?
    * [Yes, Jaxton told me to speak to you]
        Oh don't mind him darling. 
        He's crazy because he thinks we're working on a secret project.
        Says it's the real life Roko's Basilisk that will destroy humanity.
        It's nonsense so don't believe a thing he says alright.
        -> GivePlayerTask

=== GivePlayerTask ===
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
    * [Sorry, it's literally my first day here]
        It shouldn't be too difficult.
        All you would have to do is fix the actuators on the 15th floor.
        Then I need you to organize some files on the 28th floor. 
        And after all that you could visit me in my office on the 72nd floor.
        Well some people aren't ready for the responsibility.
        ~ derailment = derailment + 20
        -> DONE

=== CEOMeetingRoom ===
Excuse you this room is for the CEO and shareholders only.
-> DONE