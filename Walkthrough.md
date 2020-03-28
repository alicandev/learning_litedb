# What is LiteDB?

### Serverless Database

LiteDB is a **serverless** database delivered in a **single small DLL** fully **written in .NET C# managed code**.

### Fast and Lightweight

LiteDB is a **simple and fast NoSQL database solution**. Ideal for:

- Mobile Apps (Xamarin ready)
- Desktop/local applications
- Application file format
- Web Applications
- One database per account/user data store

### More...

- ACID transactions (Atomic, Consistent, Isolated, Durable)
- Single datafile
- Recovery data in writing failure ([WAL](https://en.wikipedia.org/wiki/Write-ahead_logging) mode (Write-ahead logging))
- Map your POCO class to BsonDocument
- Fluent API for custom mapping
- Cross collections references (DbRef)
- Store files and stream data (like GridFS in MongoDB)
- LINQ query support
- FREE for everyone - including commercial use

### What's In It for Us?

#### Zero Configuration

Zero configuration means that all we need to start using LiteDB to store data is to add the necessary packages to our project. This feature alone will dramatically decrease the time we spend setting up a database when starting the development of a new project. Additionally, it will cut down the time we spend to restore databases, as all we will need to do is to replace the `.db` file as we need.

#### F# Integration

We can seamlessly work with a LiteDB database using only F# types and functions. Our types are translated into `documents` and their fields into `BsonValue`s.



# LiteDB.FSharp

### What is LiteDB.FSharp?

F# Support for LiteDB in .NET Core and full .NET Framework.

- LiteDB.FSharp provides serialization utilities making it possible for LiteDB to understand F# types such as **records**, **unions**, **maps** etc. with support for **type-safe query expression** through F# quotations.



> ​	**DEMO**



# Performance: How Does LiteDB Compare?

Below are some comparison stats between LiteDB, MongoDB and SQLLite for **bulk insert**s.

#### LiteDB V3 vs SQLLite

```
LiteDB: default - 5000 records
==============================
Insert         :  4999 ms -     1000 records/second
Bulk           :   236 ms -    21184 records/second
Update         :  3674 ms -     1361 records/second
CreateIndex    :   176 ms -    28321 records/second
Query          :   204 ms -    24467 records/second
Delete         :   157 ms -    31722 records/second
Drop           :    17 ms -   289513 records/second
FileLength     :  7580 kb

LiteDB: encrypted - 5000 records
================================
Insert         :  5690 ms -      879 records/second
Bulk           :   280 ms -    17820 records/second
Update         :  3784 ms -     1321 records/second
CreateIndex    :   174 ms -    28669 records/second
Query          :   208 ms -    24037 records/second
Delete         :   207 ms -    24078 records/second
Drop           :    56 ms -    87898 records/second
FileLength     :  7576 kb

LiteDB: exclusive no journal - 5000 records
===========================================
Insert         :  4839 ms -     1033 records/second
Bulk           :   219 ms -    22775 records/second
Update         :  3242 ms -     1542 records/second
CreateIndex    :   176 ms -    28379 records/second
Query          :    93 ms -    53243 records/second
Delete         :   140 ms -    35574 records/second
Drop           :    14 ms -   334283 records/second
FileLength     :  7572 kb

SQLite: default - 5000 records
==============================
Insert         : 46379 ms -      108 records/second
Bulk           :   122 ms -    40827 records/second
Update         : 47470 ms -      105 records/second
CreateIndex    :    13 ms -   367266 records/second
Query          :   457 ms -    10933 records/second
Delete         :    11 ms -   441583 records/second
Drop           :    11 ms -   454141 records/second
FileLength     :  3824 kb

SQLite: encrypted - 5000 records
================================
Insert         : 49296 ms -      101 records/second
Bulk           :   122 ms -    40851 records/second
Update         : 48490 ms -      103 records/second
CreateIndex    :    36 ms -   136413 records/second
Query          :   463 ms -    10798 records/second
Delete         :    13 ms -   357189 records/second
Drop           :    25 ms -   199642 records/second
FileLength     :  3856 kb

SQLite: no journal - 5000 records
=================================
Insert         :  4107 ms -     1217 records/second
Bulk           :   106 ms -    47121 records/second
Update         :  4101 ms -     1219 records/second
CreateIndex    :     8 ms -   592916 records/second
Query          :   468 ms -    10680 records/second
Delete         :     3 ms -  1578981 records/second
Drop           :     3 ms -  1574952 records/second
FileLength     :  3824 kb
```



#### LiteDB vs MongoDB

------

ARCHITECTURE: LiteDB
 TEST KIND: InsertOne (write individual items)
 KEY GEN : Sequential
 MAX ITEMS: 1000000

## Processed: 20100  Elapsed: 5001 ms (0h 0m 5s)  Rate: 4,019.2 per second  Per item: 248.806 µs

ARCHITECTURE: MongoDB
 TEST KIND: InsertOne (write individual items)
 KEY GEN : Sequential
 MAX ITEMS: 1000000

## Processed: 30100  Elapsed: 5007 ms (0h 0m 5s)  Rate: 6,011.6 per second  Per item: 166.346 µs

------

ARCHITECTURE: LiteDB
 TEST KIND: InsertOne (write individual items)
 KEY GEN : Random
 MAX ITEMS: 1000000

## Processed: 14900  Elapsed: 5266 ms (0h 0m 5s)  Rate: 2,829.5 per second  Per item: 353.423 µs

ARCHITECTURE: MongoDB
 TEST KIND: InsertOne (write individual items)
 KEY GEN : Random
 MAX ITEMS: 1000000

## Processed: 29600  Elapsed: 5010 ms (0h 0m 5s)  Rate: 5,908.2 per second  Per item: 169.257 µs

------

ARCHITECTURE: LiteDB
 TEST KIND: UpdateOne (write individual items)
 KEY GEN : Sequential
 MAX ITEMS: 435000

## Processed: 29700  Elapsed: 5000 ms (0h 0m 5s)  Rate: 5,940.0 per second  Per item: 168.35 µs

ARCHITECTURE: MongoDB
 TEST KIND: UpdateOne (write individual items)
 KEY GEN : Sequential
 MAX ITEMS: 465000

## Processed: 24900  Elapsed: 5010 ms (0h 0m 5s)  Rate: 4,970.1 per second  Per item: 201.205 µs

------

ARCHITECTURE: LiteDB
 TEST KIND: UpdateOne (write individual items)
 KEY GEN : Random
 MAX ITEMS: 175000

## Processed: 29600  Elapsed: 5000 ms (0h 0m 5s)  Rate: 5,920.0 per second  Per item: 168.919 µs

ARCHITECTURE: MongoDB
 TEST KIND: UpdateOne (write individual items)
 KEY GEN : Random
 MAX ITEMS: 405000

## Processed: 24200  Elapsed: 5001 ms (0h 0m 5s)  Rate: 4,839.0 per second  Per item: 206.653 µs

\########################################
 WRITE BULK (Batch of 5000)
 \########################################

------

ARCHITECTURE: LiteDB
 TEST KIND: InsertBulk (bulk write items)
 KEY GEN : Sequential
 MAX ITEMS: 1000000

## Processed: 385000  Elapsed: 5016 ms (0h 0m 5s)  Rate: 76,754.4 per second  Per item: 13.029 µs

ARCHITECTURE: MongoDB
 TEST KIND: InsertBulk (bulk write items)
 KEY GEN : Sequential
 MAX ITEMS: 1000000

## Processed: 445000  Elapsed: 5025 ms (0h 0m 5s)  Rate: 88,557.2 per second  Per item: 11.292 µs

------

ARCHITECTURE: LiteDB
 TEST KIND: InsertBulk (bulk write items)
 KEY GEN : Random
 MAX ITEMS: 1000000

## Processed: 175000  Elapsed: 5080 ms (0h 0m 5s)  Rate: 34,448.8 per second  Per item: 29.029 µs

ARCHITECTURE: MongoDB
 TEST KIND: InsertBulk (bulk write items)
 KEY GEN : Random
 MAX ITEMS: 1000000

## Processed: 425000  Elapsed: 5054 ms (0h 0m 5s)  Rate: 84,091.8 per second  Per item: 11.892 µs

------

ARCHITECTURE: LiteDB
 TEST KIND: UpdateBulk (bulk write items)
 KEY GEN : Sequential
 MAX ITEMS: 395000

## Processed: 345000  Elapsed: 5045 ms (0h 0m 5s)  Rate: 68,384.5 per second  Per item: 14.623 µs

ARCHITECTURE: MongoDB
 TEST KIND: UpdateBulk (bulk write items)
 KEY GEN : Sequential
 MAX ITEMS: 460000

## Processed: 35000  Elapsed: 5739 ms (0h 0m 5s)  Rate: 6,098.6 per second  Per item: 163.971 µs

------

ARCHITECTURE: LiteDB
 TEST KIND: UpdateBulk (bulk write items)
 KEY GEN : Random
 MAX ITEMS: 170000

## Processed: 170000  Elapsed: 3434 ms (0h 0m 3s)  Rate: 49,505.0 per second  Per item: 20.2 µs

ARCHITECTURE: MongoDB
 TEST KIND: UpdateBulk (bulk write items)
 KEY GEN : Random
 MAX ITEMS: 415000

## Processed: 30000  Elapsed: 5170 ms (0h 0m 5s)  Rate: 5,802.7 per second  Per item: 172.333 µs

\########################################
 FIND ONE
 \########################################

------

ARCHITECTURE: LiteDB
 TEST KIND: FindOne (find each by id)
 KEY GEN : Sequential
 MAX ITEMS: 420000

###### Processed: 420000  Elapsed: 4202 ms (0h 0m 4s)  Rate: 99,952.4 per second  Per item: 10.005 µs

ARCHITECTURE: MongoDB
 TEST KIND: FindOne (find each by id)
 KEY GEN : Sequential
 MAX ITEMS: 445000

###### Processed: 29600  Elapsed: 5006 ms (0h 0m 5s)  Rate: 5,912.9 per second  Per item: 169.122 µs

------

ARCHITECTURE: LiteDB
 TEST KIND: FindOne (find each by id)
 KEY GEN : Random
 MAX ITEMS: 175000

###### Processed: 175000  Elapsed: 2964 ms (0h 0m 2s)  Rate: 59,041.8 per second  Per item: 16.937 µs

ARCHITECTURE: MongoDB
 TEST KIND: FindOne (find each by id)
 KEY GEN : Random
 MAX ITEMS: 390000

###### Processed: 29800  Elapsed: 5013 ms (0h 0m 5s)  Rate: 5,944.5 per second  Per item: 168.221 µs

\########################################
 ENUMERATE/READ COLLECTION
 \########################################

------

ARCHITECTURE: LiteDB
 TEST KIND: FindAllForward (enumerate forward)
 KEY GEN : Sequential
 MAX ITEMS: 370000

###### Processed: 370000  Elapsed: 2971 ms (0h 0m 2s)  Rate: 124,537.2 per second  Per item: 8.03 µs

ARCHITECTURE: MongoDB
 TEST KIND: FindAllForward (enumerate forward)
 KEY GEN : Sequential
 MAX ITEMS: 375000

###### Processed: 375000  Elapsed: 3377 ms (0h 0m 3s)  Rate: 111,045.3 per second  Per item: 9.005 µs



# LiteDB on SAFE

To set up LiteDB and LiteDB.FSharp on a project...

1. Add a reference to `LiteDB` and `LiteDB.FSharp` like so:

   ```
   nuget LiteDB ~> 4
   nuget LiteDB.FSharp
   ```

2. You will also need references in project solution file to be able to access the LiteDB and the LiteDB.FSharp module.

   ```xml
   <PackageReference Include="LiteDB" Version="4.*" />
   <PackageReference Include="LiteDB.FSharp" />
   ```

> `LiteDB.FSharp` library currently has no support for `LiteDB V5`

3. Run `paket install` and `dotnet restore` to finish setting up references.

4. Navigate to an F# source file inside the project that we have just added the references to and open the `LiteDB` and the `LiteDB.FSharp` namespaces.

   ```fsharp
   open LiteDB
   open LiteDB.FSharp
   ```

> We can now start working with LiteDB and LiteDB.FSharp! Yep. It's that easy.













 

 

 