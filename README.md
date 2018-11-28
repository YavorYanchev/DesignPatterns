# DesignPatterns
Structural, Creational and Behavioral Patterns

This repository is containing design patterns that provide solutions to common problems.

The code used for the design patterns is C#.

I am using this repository only for learning purposes. Don't arrest me! :)

The patterns are from the book “C# 3.0 Design Patterns, by Judith Bishop. Copyright 2008 Judith Bishop, 978-0-596-52773-0.”


## Structural 

## Decorator
Provide a way of attaching new state and behaviour to an object dynamically.The object does not know it is being "decorated", which makes this useful pattern for evolving systems.
Decorator inherit the original class and contain an instantiation of it.
An important point about the Decorator pattern is that is based around new objects being created with their own sets of operations.Some of them might be inherited, but only down one level.

Use Decorator when you have:
*  an existing component class that may be unavailable for subclassing You want to:
* attach additional state or behaviour to an object dynamically
* make changes to some objects in a class without affecting others
* avoid subclassing, because too many classes could result

## Proxy
Proxy is a class functioning as an interface to something else. 
Support objects that control the creation of and access to other objects.The proxy is often a small(public) object that stands in for a more complex (private) object that is activated once certain circumstances are clear.
Proxies are frontends to classes that have sensitive data or slow operations. They are often found in image-drawing systems, where the proxy places a placeholder on the screen and then activates a real drawer to fetch and render the image.
Proxies, like decorator forward requests on to another object.The difference is that the proxy relationship is set up at design time and is well-known in advance.

## Bridge
Bridge pattern decouples an abstraction from its implementation enabling them to vary independently.
The bridge pattern is useful when a new version of software is brought out that will replace an existing version, but the older version must still run for its existing client base. The client code will not have to change, as it is conforming to a give abstraction, but the client will need to indicate which version it wants to use.

Use Bridge pattern when you can:
* Identify that there are operations that do not always need to be implemented the same way

You want to:
* Completely hide implementations from clients.
* Avoid binding an implementation to an abstraction directly.
* Change an implementation without even recompiling an abstraction
* Combine different parts of a system at runtime

When a class varies often, the features of OOP become very useful because changes to a program's code can be made easily with minimal prior knowledge about the program.
The bridge pattern is useful when both the class and what it does vary often.
The class itselt can be thought of as the abstraction and what the class can do
as the implementation.

## Composite

Composite pattern arranges structured hierarchies so that single components and groups of components can be treated in the same way.Typical operations
on the components include add, remove, display, find and group.
The composite pattern has to deal with 2 two types: Components and Composites
of those components. Both types agree to conform to an interface of common
operations.Composite object consists of Components, and in most cases operations on a Composite are implemented by calling the equivalent operations for its Component objects.


## Adapter
The adapter pattern enables a system to use classes whose interfaces don't quite match its requirements.
It is especially useful for off-the-shelf code, for toolkits, and for libraries. Many examples of the Adapter pattern involve input/output
because that is one domain that is constantly changing.
Toolkits also need adapters. Although they are designed for reuse, not all applications will want to use the interfaces that toolkits provide;
some might prefer to stick to a well-known, domain-specific interface. In such cases, the adapter can accept calls from the application
and transform them into calls on toolkit methods.