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

#### Proxy
Proxy is a class functioning as an interface to something else. 
Support objects that control the creation of and access to other objects.The proxy is often a small(public) object that stands in for a more complex (private) object that is activated once certain circumstances are clear.
Proxies are frontends to classes that have sensitive data or slow operations. They are often found in image-drawing systems, where the proxy places a placeholder on the screen and then activates a real drawer to fetch and render the image.
Proxies, like decorator forward requests on to another object.The difference is that the proxy relationship is set up at design time and is well-known in advance.