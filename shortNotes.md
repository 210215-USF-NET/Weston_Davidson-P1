# P0 requirements
### Store App Overview:
- The store app is a software that helps customers purchase products from your business. Designed with functionality that would make virtual shopping much simpler!

# store name: SineShop
- sells different models of synthesizers



# Functionality:
- [ ] add a new customer
    - status: working with json data
    - TODO: interface with DB When it's time!
- [ ] search customers by name
    - status: ui logic/pathing works, makes sense
    - TODO:
        - interface with DB when it's time!
- [ ] display details of an order
- [ ] place orders to store locations for customers
- [ ] view order history of customer
- [ ] view order history of location
- [ ] view location inventory
- [ ] The customer should be able to purchase multiple products
- [ ] Order histories should have the option to be sorted by date (latest to oldest and vice versa) or cost (least expensive to most expensive)
- [ ] The manager should be able to replenish inventory

# Models:
- [X] Customer
    - model working correctly in conjunction with BL
    - TODO:
        - Implement better method of generating user ID that checks against already existing DB values
- [ ] Location
    - created, not implemented yet
- [ ] Orders
    - created, not implemented yet
- [ ] Product
    - created, not implemented yet
    - product type will be physical synths
- Note: add as much models as you would need for your design

# Additional requirements:
- [ ] Exception Handling
- [ ] Input validation
- [ ] Logging
- [ ] At least 10 unit tests
- [ ] Data should be persisted, (no data should be hard coded)
- [ ] You should use SQLServer DB
- [ ] DB structure should be 3NF
- [ ] Should have an ER Diagram
- [ ] Code should have xml documentation

# Tech Stack:
- C#
- SQLServer DB
- EF Core
- Xunit
- Serilog or Nlog

# relationships in our system:
- one customer can have many orders, but one order can only belong to one customer
    - 1:M
- one and only one customer can have one and only one cart 
    - 1:1
- one and only one cart can include one and only one order 
    - 1:1
- one cart can hold many products, many products can exist in one cart
    - M:M
- many locations can hold many products
    - M:M
    - composite table: inventory
        - FK productID
        - FK locationID
        - PK inventoryID
        - include a count of product!
- One location can have many orders, but an order can only have one location
    - 1:M




# Additional Details
- copy new requirements into notes
- have most of the user structure finished by next week!!!
search customer, add customer, navigate and view location inventory, try to have a placeholder order functionality done. Models, business logic should be working. files, static collections, keep data layer far away from business logic if possible.
- do something similar to class for data stuff with toh
- set up logging as you go with serilog

- should allow multiple products and multiple KINDS of products in a single order
# P0 Notes
-   Have a theme! Make your store unique.

# Example Application
-   Marielle is using a whiteboard to create a wireframe to sketch out her Application
-   She lists the functionality requirements
-   She has the methods she wants, so how will she go about designing her application?
-   Think about design before implementation or anything else
-   Consider things like classes, interfaces that will be implemented based on what sort of things will be needed (relationships, is-a, has-a relationships, properties etc.)
-   When you're prototyping, try to limit your properties. You want to lay groundwork more than you want to create full implementation. Full implmementation can come later.
-   Keep your models lean - don't add unnecessary properties
-   This is also a test of scalability once you want to add additional properties or elements

## Classlib declaration for a project in dotnet can be used as a class library which your primary application references :)

# Store App Notes
-   Naming format: FirstName_LastName-P0
-   Include a readme in your github repo for the project
-   Required to provide an MVP - a minimum viable product
-   Try to meet as many of the minimum requirements as possible - what should a store app be able to do?
-   Don't just reach the minimum requirements - go further beyond!
-   If you don't have the whole project planned beforehand, do vertical development instead of horizontal
    -   Build things as you need them - jump between things and you won't get bored when developing business logic
-   Don't forget about exception handling!
-   Due Date - March 3rd!
-   This week - logic and UI
-   Next week - database (probably since it's SQL week)
-   Week after that - Presentation prep!

# log to a JSON file, and every time you run program at a certain date, sorta show that in that folder maybe - new requirements for the project

# Object Structure Brainstorming

### Customer
- first name
- last name
- ID
- password (stored as hash)


### Cart
- CartID
- FK Customer ID
- FK Product
- grab certain product info using composite key between cartID and Product?
- will need to figure out ER for this one tbh


### Location
- PK LocationID
- Name
- (composite key for inventory?)


### Order
- PK OrderID
- Name
- Date
- FK customerID

### Product
- ProductID
- Name
- Another composite key for keeping track of product supply based on inventory?
- I need to research DBs lol


# presentation tips:
- introduce yourself for presentation!
- make sure in groups, you communicate setup beforehand


# console application notes - https://www.youtube.com/watch?v=dKBuvdGsYYc
- simple, robust, low dev cost, great for automation
1. parameter parsing
1. data input
1. data processing
1. data output
- libraries that will help!
    - ConsoleTables - https://github.com/khalidabuhakmeh/ConsoleTables provides console output and sample output
    - CommandDotNet


# Factory Method Pattern
1. Factory Method Pattern
    - why do we need this pattern?
        - we use lots of different objects and classes
        - dependency injection is programming by wishful thinking (what if I already had a thing that did this, this, and this)
        - at some point, though, that thing has to be constructed
        - new has to happen at some point!
        - the question is, where to we instantiate them?
        - when you are about to instantiate, let's encapsulate that instantiation, so you can use the factory whenever you want to instantiate
        - now, why create a wrapper around new?
            - well, the instantiation may be very complex
            - also about polymorphism - a factory that wraps the construction, and the factory is an instance, you can swap the instance for another instance of a different thing
        - as an example, many classes can implement from one interface
            - let's say you want to instantiate one of these classes
            - if you don't know what you need, then you would want to pass this in
            - a program 
1. Abstract Factory Pattern

# abstract factory notes
- an abstract factory pattern uses a super factory, or a "factory of factories".
- The factory pattern is a way of replacing manual object instantiation with delegation to a class whose purpose is to create objects