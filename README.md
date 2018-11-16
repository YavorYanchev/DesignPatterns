# DesignPatterns
Structural, Creational and Behavioral Patterns

This repository is containing design patterns that provide solutions to common problems.

The code used for the design patterns is C#.

I am using this repository only for learning purposes. Don't arrest me! :)

The patterns are from the book “C# 3.0 Design Patterns, by Judith Bishop. Copyright 2008 Judith Bishop, 978-0-596-52773-0.”


## Design Patterns

### Structural 

#### Decorator
Provide a way of attaching new state and behaviour to an object dynamically.The object does not know it is being "decorated", which makes this useful pattern for evolving systems.
Decorator inherit the original class and contain an instantiation of it.
An important point about the Decorator pattern is that is based around new objects being created with their own sets of operations.Some of them might be inherited, but only down one level.

Use Decorator when you have:
*  an existing component class that may be unavailable for subclassing You want to:
* attach additional state or behaviour to an object dynamically
* make changes to some objects in a class without affecting others
* avoid subclassing, because too many classes could result