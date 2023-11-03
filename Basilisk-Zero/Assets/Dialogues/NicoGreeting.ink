INCLUDE globals.ink

{supportAI <= 1: -> NicoFirstMeetsPlayer | -> NicoGivesAdvice}
=== NicoFirstMeetsPlayer ===
#speaker:Nico
Hey you're the new hire. My name's Nico, you're going to love it here!
I remember my first day like it was yesterday, but enough talk.
I want to get you started on some work.
Your desk is in between those people that the receptionist told you about.
It doesn't matter who you talk to, but either one of them will assign you your first task.
~ supportAI = supportAI + 1
-> END

=== NicoGivesAdvice ===
#speaker:Nico
Oh you want to talk more. Well I'll give you a little piece of advice.
Talk to Dawn first if you want a leg up on the job.
Zach will probably show you his newest game he's been playing. Unless you're into that too.
-> END