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
-> END

=== npcBoss ===
I hope the boss is in a good mood today. I don't want to get on their bad side.
    * [Yeah, I hope so too]
        I heard if you get on his bad side, something will come and get you!
        -> DONE
    * [Doesn't really matter. They're probably just like us.]
        Shhh! Don't say that so loud!
        -> DONE
-> END