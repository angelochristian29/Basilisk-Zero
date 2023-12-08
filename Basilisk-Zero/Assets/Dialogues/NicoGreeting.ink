INCLUDE globals.ink

{supportAI > 10 || derailment > 10: -> NicoDefaultDialogue }
{supportAI <= 1: -> NicoFirstMeetsPlayer | -> NicoGivesAdvice}

=== NicoFirstMeetsPlayer ===
#speaker:Nico
#portrait:NicoNeutral
Hey! You're the new hire. My name's Nico, you're going to love it here!
I remember my first day like it was yesterday, but enough talk.
I want to get you started on some work.
Your desk is in between those people that the receptionist told you about.
It doesn't matter who you talk to, but either one of them will assign you your first task.
~ supportAI = supportAI + 1
~ derailment = derailment + 1
-> DONE

=== NicoGivesAdvice ===
#speaker:Nico
#portrait:NicoNeutral
Oh? You want to talk more. Well, I'll give you a little piece of advice.
Talk to Dawn first, if you want a leg up on the job.
Zach will probably show you his newest game he's been playing. Unless you're into that too.
-> DONE

=== NicoDefaultDialogue ===
#speaker:Nico
#portrait:NicoNeutral
You're going to love it here as long as you do what you are told to do.
I'm a little busy at the moment so talk to you later.
-> DONE