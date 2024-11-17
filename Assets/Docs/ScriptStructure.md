# Script Structure & Design

When you first get into this document,
all you need to know is,
<span style="color: yellow;">
    scripts are the customized way we plant into each component
</span>
(which is I think currently the smallest unit of object in Unity).

Component describes an Unity Object in various aspects,
and scripted component controls attributes
'the object have' | 'provided by other component'.

## How we deal with interactions and relations

Now the scripts automatically act when game start,
but they won't interact with each other
if you don't link them with interactions etc.

The first thing you need to be confirmed is:
<span style="color: yellow;">
    What interaction you are really doing?
</span>

Let's say we are implementing
'player pick up kitchen object on a clear counter'.
Is the player interacting directly with the kitchen object?
The answer is no.

And the difference between directly calling the function and using event
can cause some confuse.
They are both the implement method for interaction.
You can ask ChatGPT or search on the internet for deeper knowledge.
But here I'm going to say:
<span style="color: yellow;">
    you should using event
    only when you are sure the interaction can be async with the caller.
</span>
Like animations are usually only a visual effect,
and don't actually effect the game logic.
Event is a very useful tool for interaction, but using it on everything
may also be very confusing because **the main interaction logic in game often
happened continuously or in less a second (they are not async)**.
But the sub effects underlying in the interacted object
are usually async and can use event to handle.

## ScriptableObject

I think I learned very less of the scriptable object,
they are only used in `ContainerCounter` now.

I understand it as a lesser cost data | object container.
We can use a scriptable object if a set of objects can be conclude into one.
(like kitchen object, it have model, name and sprite)
<span style="color: yellow;">
    It avoid you from cloning anything may not really appears in you prefab
</span>
(like in ContainerCounter, we need to know the info of the about to spawn
kitchen objects, but we don't actual need them
until we interact with the counter)

Also ask ChatGPT or search engine if you want to know more.

## About interface and abstract class

It's easier to understand
if you are using any other object oriented programing language.
It's kind of a shared language feature and not related with Unity or the game.
