#load @".paket\load\main.group.fsx"

open LiteDB
open LiteDB.FSharp

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

// For the purposes of this demo, delete every collection each time the app runs.
cit.Delete(fun _ -> true) |> ignore

let alican = { Id = 0; Name = "Isaac"; Age = 37; Gender = Male }

// Insert new Person document
cit.Insert alican |> ignore

let saved = cit.FindOne(fun x -> x.Name = "Isaac")

// Update a document inside a collection
cit.Update { alican with Name = "Alican Demirtas" } |> ignore

let results =
    cit.Find (fun a -> a.Age < 40)
    |> Seq.sortBy (fun a -> a.Name)
    |> Seq.map (fun a -> {| Name = a.Name; NameUpper = a.Name.ToUpper() |})
    |> Seq.truncate 2
    |> List.ofSeq
