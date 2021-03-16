# AbacusNextCodeChallenge
Car park charges coding challenge

Simple Console App to calculate the charge applied for both a long stay and short stay in a car park.

- I went with a Parking Visit base class and  Long/ShortVisit derived classes to calculate the overridden duration and charge methods.
- I created a ChargeableHours class to (potentially) allow changes to be made to chargeable times and also to store logic related to chargeable / nonchargeable periods of time.
- Program.cs prints the examples listed in the brief, which I've copied below:


**Parking Charge Calculator**

You run a car park that, at the moment, has two charging options - Short Stay and Long Stay. Visitors choose which option they want to use when they enter the car park and the charge is calculated when they leave based on the length of their visit.

The following charges are used:

    Short Stay
         £1.10 per hour between 8am and 6pm on weekdays, free outside of these times. Visits need not be whole hours and can last more than one day.

    Long Stay
         £7.50 per day or part day including weekends, so the minimum charge will be for one day.

Design and code a console application in C# that will be used to calculate the total cost of a visit to the car park. The solution should not require any user interaction, so example inputs can be hard coded.

No third party assemblies are required, although you may want to include your preferred unit test framework and few unit tests as a demonstration. We are interested in SOLID code and will be assessing your design decisions and the patterns you use. While there is no time limit, as a guide, the solution might take less than 2 hours to implement.

A short list of examples:

    A stay entirely outside of a chargeable period will return £0.00
    A short stay from 07/09/2017 16:50:00 to 09/09/2017 19:15:00 would cost £12.28
    A long stay from 07/09/2017 07:50:00 to 09/09/2017 05:20:00 would cost £22.50
