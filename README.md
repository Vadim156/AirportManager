# AirportManager
Vadim Vologin,
Class: 1080
Final Project- Sela Collage

The project is an Api simulates a control tower that allows planes to land and pass between the 8 terminals without collisions.(handle requests)

The system was built on:
Server side - C#, Asp.Net Api Core 
Database - MySQL. 
Client side - Angular

    • The project has 4 DLL parts:
    •  Part of data for the purpose of separating direct data access from the API
    •  A part of the API with one controller and a connection to the databases in order to access each table in a separate way.
    • Logic - including a part of the connection between the system terminals, according to a GRAPH data structure + a class called AirportManager that includes the entire program logic, to which the controller reaches, returns information and updates the program's database.
    •  A simulator that runs and sends planes with a POST request every 8.5 seconds (the highest speed tested and running was 6 seconds, no requested time was defined for sending the planes as I continued to improve the logic in the program). 

    • The relationships between the entities is simple 1:1 between “Terminal” and “Flight” models.
    • There is a “Logger” entity that updates logs in the database, when and which flight left which terminal (by string id-> generated by Guid).
    • Only the first terminal can have more than one flight at a time.
    • The flight can depart only after it leaves the departure zone, terminals 6/7.
    • The client side is based on Angular,fetching data from the Api and shows in which terminal each flight is.


    • The program can be tested simply by opening the “Simulator” project in the “FinalProj” project and updating the timer for sending new flights to the Api faster.
    • The program based on multithreading and asynchronous processes
    
![image](https://user-images.githubusercontent.com/106904639/220820763-05c4e320-b597-4029-98f3-26da08340a94.png)
