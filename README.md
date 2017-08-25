# Introduction
This is a simple HelloWorld application. The purpose of the application is to output to Console as of now. However, it has been written with the output logic
kept decoupled from the console application so that it can be extended down the road.
The best way to achieve routing "HelloWorld" to almost any type of application on any type of device is to use SignalR based host that will be used to route the
message to the appropriate registered client(s). I am not including it as of now but may be creating it in a separate branch and am just indicating here to give
a general idea of where i would be heading with this business requirement

#Prequisites
1.The solution was built with VS2017 Update 3.2 but should be able to open on older version(at least VS2015 update 3)
2.The solution requires .net framework 4.7. If you dont have it installed, you can grab it from one of the 2 ways:
#
    1.Net Framework 4.7 Developer Pack
        https://www.microsoft.com/en-us/download/details.aspx?id=55168
    2.Net Framework 4.7 Runtime
        https://www.microsoft.com/en-us/download/details.aspx?id=55170


# Getting Started
1.	Open the solution is VS2017[used during the development otherwise, may have to fix some issues
2.	.Net framework 4.7 is used as target framework. If it is not installed, you can revert back to 4.6.2 while opening the solution.

# Build and Test
Compile and Run[The Startup project should be HelloWorldConsole]

# Test project
1. Test Framework used is MSTestv2
2. Tests for core classes is included
3. Both parameterised and traditional tests are included