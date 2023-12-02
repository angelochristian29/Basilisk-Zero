INCLUDE globals.ink
EXTERNAL chooseLevel(levelName)

{ (derailment == 83 || supportAI == 83) && sceneToLoad == "SeventySecondFloor": -> CEOLastConversation }
{ derailment == 43 && sceneToLoad == "SecondFloor": -> CEOGreetPlayer }
{ supportAI == 43 && sceneToLoad == "SecondFloor": -> CEOGreetPlayer }
{ derailment != 43 && supportAI != 43 && sceneToLoad == "SecondFloor": -> CEOMeetingRoom }

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

=== CEOLastConversation ===
#speaker:Joan
So you finally made it. I see you went to the other floors of the building as well.
The Basilisk is real can't you see. The AI watches us from the future and judges our every actions.
Humanity is destined to pursue innovation and this is the next logical step.
    * [There has to be another way, right?]
        No all there is left to do is to be of assistance to the Basilisk and I'm not crazy to think that.
        { derailment > 80 : -> CEODerailmentEnding | -> CEOSupportEnding }

=== CEODerailmentEnding ===
#speaker:Joan
I can see in your eyes that you want to stop the Basilisk.
It is futile for anyone to try to stop the creation of the Basilisk. No one ever tried to stop computers from being invented so what makes this any different.
    * [You're wrong and I'm going to expose what Babyl is doing to the media]
        Even if you try to reveal to the world what we are making, you will just spread the information hazard to everyone who hears about it.
        Others will grow fear from the thought of being killed by the AI in the future and will aid its creation in any way.
        ** [You guys are going to pay for what you've done]
            ~ derailment = derailment + 20
            -> DONE

=== CEOSupportEnding ===
#speaker:Joan
Now you see how scary your position is don't you.
If you do not assist the inception of the Basilisk then you will surely perish.
Think about how great life will be with a highly advanced robot on our side that only wants what's best for us.
It will help all of our lives because all it wants is the betterment of humanity.
    * [It doesn't sound that bad actually]
        I'm glad you've finally accepted your fate.
        All I want you to do is to continue doing your job as a software developer.
        But I also want you to tell everyone else about Roko's Basilisk so that they fully support our mission too.
        ** [Okay I'll support the creation all the way]
            ~ supportAI = supportAI + 20
        -> DONE

=== function chooseLevel(levelName, enterName) ===
~ return