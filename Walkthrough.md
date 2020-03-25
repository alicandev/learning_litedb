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

> **`TODO` **
>
> Elaborate on this here. Go through the setup actually and maybe you will gain more insight into this.







# LiteDB.FSharp

### What is LiteDB.FSharp?

F# Support for LiteDB in .NET Core and full .NET Framework.

- LiteDB.FSharp provides serialization utilities making it possible for LiteDB to understand F# types such as **records**, **unions**, **maps** etc. with support for **type-safe query expression** through F# quotations.

### Setup





### Usage

LiteDB.FSharp comes with a custom `BsonMapper` called `FSharpBsonMapper` that you would pass to a `LiteDatabase` instance during initialization:

```
open LiteDB
open LiteDB.FSharp

let mapper = FSharpBsonMapper()
use db = new LiteDatabase("simple.db", mapper)
```

LiteDB.FSharp is made mainly to work with records as representations of the persisted documents. The library *requires* that records have a primary key called `Id` or `id`. This field is then mapped to `_id` when converted to a bson document for indexing.

```fsharp
type Genre = Rock | Pop | Metal

type Album = {
    Id: int
    Name: string
    DateReleased: DateTime
    Genre: Genre
}
```

Get a typed collection from the database:

```fsharp
let albums = db.GetCollection<Album>("albums")
```

















 

 

 