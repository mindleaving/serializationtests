# Serialization Tests
Test requirements for correctly serialize classes with MongoDB and JSON.NET

I'm regularly been in doubt of what the requirements are for MongoDB and JSON.NET correctly serialize classes. 
* What can and can't I do? 
* Do I have to sacrifice access flexibility in code? 
* Where is the behavior documented?
* Which pattern suits both MongoDB and JSON.NET?


Conclusions (MongoDB Driver v2.7.0, Newtonsoft.JSON v11.0.2)
* MongoDB is fine as long as properties have private setters
* Both MongoDB and JSON.NET work with a single one-to-one constructor, which has an argument for every property, in which case setters are not required.
* JSON.NET can handle many different scenarios as long as a constructor with the JsonConstructor-attribute exists, even if only some properties are assigned through it and the rest through public setters.
* As expected, public setters works with both.
