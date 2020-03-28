#r "LiteDB.dll"
#r "LiteDB.FSharp.dll"
#r "Newtonsoft.Json.dll"

open LiteDB
open LiteDB.FSharp
open System

// Define some types to use
type Genre = Rock | Pop | Metal
type Album = { Id: int ; Name: string; YearReleased: int ; Genre: Genre }

// Create a database if not exists
let mapper = FSharpBsonMapper()
let db = new LiteDatabase("demo.db", mapper)

// Create a collection if not exists
let albums = db.GetCollection<Album>("albums")

// Insert a list of albums
[ { Id = 1 ; Name = "Cool Album" ; YearReleased = 1998 ; Genre = Rock }
  { Id = 2 ; Name = "This Album's Name is \"Name\"" ; YearReleased = 2015 ; Genre = Rock }
  { Id = 3 ; Name = "Creative Album Name" ; YearReleased = 1991 ; Genre = Rock }
  { Id = 4 ; Name = "Return of the Edge-lord" ; YearReleased = 1993 ; Genre = Rock }
  { Id = 5 ; Name = "Sunny Beaches Confuse Me" ; YearReleased = 2019 ; Genre = Rock } ]
|> List.iter (fun x -> albums.Insert x |> ignore)





