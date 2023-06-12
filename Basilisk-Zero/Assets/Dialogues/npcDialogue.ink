-> npcGreetings

=== npcGreetings ===
#speaker:Joe
#portrait:DawnNeutral
Hey there, how's it going? 
Good morning, how are you today?
    * [Doing good]
        That's good! Hope to see you around.
        -> npcBoss
    * [Silence...]
        Oh.. okay.. Well, have a good day.
        -> DONE

=== npcBoss ===
I hope the boss is in a good mood today. I don't want to get on their bad side.
    * [Yeah, I hope so too]
        I heard if you get on his bad side, something will come and get you!
        -> npcChatter
    * [Doesn't really matter. They're probably just like us.]
        Shhh! Don't say that so loud!
        -> DONE
        
=== npcChatter ===
Have you seen the new intern around? I think they started today.
I wish I could work from home more often.
I'm so behind on my emails. I don't know how I'm going to catch up.
I really need to organize my desk. It's getting way too cluttered.
I'm so tired today. I stayed up late watching a movie last night.
I heard there's going to be a company event next month. I wonder what it'll be.

-> END