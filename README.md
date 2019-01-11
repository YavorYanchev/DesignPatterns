# DesignPatterns
Structural, Creational and Behavioral Patterns

This repository is containing design patterns that provide solutions to common problems.

The code used for the design patterns is C#.

I am using this repository only for learning purposes. Don't arrest me! :)

The patterns are from the book “C# 3.0 Design Patterns, by Judith Bishop. Copyright 2008 Judith Bishop, 978-0-596-52773-0.”


# Structural 

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

Participants:
* Target
* Adapter
* Adaptee
* Client

Defina a separate ```adapter``` class that converts the
(incompatible) interface of a class(```adaptee```) into another
interface (```target```) clients require.
Work through an ```adapter``` to work with (reuse) classes
that do not have the required interface.


## Facade
The role of the facade is to provide different high-level views of subsystems whose
details are hidden from users. In general, the operations that might be desirable
from a user's perspective could be made up of different selections of parts of the sybsystems.
Hiding details is akey programming concept. What makes the facade pattern different from, say,
the Decorator or Adapter patterns is that the interface it builds up can be entirely new.
It is not coupled to existing requirements, nor must it conform to existing interfaces.
There can also be several facades built up around an existing set of subsystems.


# Creational

## Factory Method
The factory method pattern is a way of creating objects, but letting subclasses decide 
exactly which class to instantiate. Various subclasses might implement the interface;
the Factory Method instantiates the appropriate subclass based on information supplied
by the client or extracted from the current state.The factory method pattern is a creational
pattern that uses factory methods to deal with the problem of creating objects without having
to specify the exact class of the object that will be created. This is done by calling a factory
method -either specified in an interface and implemented by child classes, or implemented in a base
class and optionally overriden by derived classes - rather than by calling a constructor.

## Abstract Factory
This pattern supports the creation of products that exist in families and are designed to be
produced together.The abstract factory can be refined to concrete factories, each of which can
create different products of different types and in different combinations.The pattern also isolates
the product definitions and their class names from the client so that the only way to get one of them is through a factory.For this reason, product families can easily be interchanged or updated without upsetting the structure of the client.
The abstract factory provides a way to encapsulate a group of individual factories that have a common theme without specifying their concrete classes. In normal usage the client software creates a concrete implementation of abstract factory and then uses the generic interface of the factory to create the concrete objects that are part of the theme.
The client doesn't know (or care) which concrete objects it gets from each of these internal factories since it uses only the
generic interfaces of their products.This pattern separates the details of implementation of a set of objects from their general
usage and relies on object composition, as object creation is implemented in methods exposed in the factory interface.
Use of this pattern makes it possible to interchange concrete implementations without changing the code that uses them,
even at runtime. However, employment of this pattern, as with similar design patterns, may result in unnecessary complexity 
and extra work in the initial writing of code. Additionaly, higher levels of separation and abstraction can result in systems that are more difficult to debud and mantain.

# Behavioral patterns

## Strategy
The strategy pattern involves removing an algorithm from its host
class and putting it in a separate class.There may be different algorithms(strategies)
that are applicable for a given problem.
If the algorithms are all kept in the host, messy code with
lots of conditional statements will result.
The Strategy pattern enables a client to choose which algorithms to use from a family of algorithms and gives a simple
way to access it. The algorithms can also be expressed
independently of the data they are using.