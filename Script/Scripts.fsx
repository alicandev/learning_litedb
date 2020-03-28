#load ".paket/load/main.group.fsx"

open LiteDB
open LiteDB.FSharp

// ->> BASICS <<-

// Types to work with
type Gender = Male | Female | Other
// CLIMutableAttribute to auto-increment Id
[<CLIMutable>]
type Person = { Id : int; Name : string; Age : int; Gender : Gender }

// Open database (or create if doesn't exist)
let mapper = FSharpBsonMapper()
let db = new LiteDatabase("demo.db", mapper)

// Get a collection (or create if doesn't exist)
let cit = db.GetCollection<Person>("CIT")

// Delete every document inside the `cit` collection. (Run if you need to empty the collection.)
cit.Delete(fun _ -> true) |> ignore

// Create a Person
let isaac = { Id = 0; Name = "Isaac"; Age = 37; Gender = Male }

// Insert new Person document
cit.Insert isaac |> ignore

// Update a document inside a collection
cit.Update { isaac with Name = "Isaac Abraham" } |> ignore

// Insert Bulk
cit.InsertBulk
    [ { Id = 0; Name = "Kerrie"; Age = 27; Gender = Female }
      { Id = 0; Name = "Prash"; Age = 34; Gender = Male }
      { Id = 0; Name = "Alican"; Age = 21; Gender = Male }
      { Id = 0; Name = "Mark"; Age = 50; Gender = Male } ]
|> ignore    

// Query (filter, sort, transform)
let results =
    cit.Find (fun a -> a.Age < 35)
    |> Seq.sortBy (fun a -> a.Name)
    |> Seq.map (fun a -> {| Name = a.Name; NameUpper = a.Name.ToUpper() |})
    |> Seq.take 2
    |> List.ofSeq

// Query based on discriminated union
let results2 = cit.Find (fun a -> a.Gender = Male) |> List.ofSeq