#load ".paket/load/main.group.fsx"

open LiteDB
open LiteDB.FSharp

// ->> INSTANTIATION <<-

// Types to work with
type Gender = Male | Female | Other
// CLIMutableAttribute to auto-increment Id
type Person = { Id : int; Name : string; Age : int; Gender : Gender }

// Open database (or create if doesn't exist)
let mapper = FSharpBsonMapper()
let db = new LiteDatabase("demo.db", mapper)

// Get a collection (or create if doesn't exist)
let cit = db.GetCollection<Person>("CIT")

// Delete every document inside the `cit` collection. (Run if you need to empty the collection.)
cit.Delete(fun _ -> true)

// Bind a new Person
let isaac = { Id = 1; Name = "Isaac"; Age = 37; Gender = Male }


// ->> CRUD <<-

// CREATE a new Person document into the CIT collection
cit.Insert isaac

// READ a document from the collection
cit.FindById(BsonValue 1)

// UPDATE a document
cit.Update { isaac with Name = "Isaac Abraham" }
cit.FindById(BsonValue 1)

// DELETE a document
cit.Delete (fun x -> x.Name.Contains "Isaac")


// ->> BULK OPERATIONS <<-

// Bulk Insert
cit.InsertBulk
    [ { Id = 1; Name = "Isaac"; Age = 37; Gender = Male }
      { Id = 2; Name = "Kerrie"; Age = 27; Gender = Female }
      { Id = 3; Name = "Prash"; Age = 34; Gender = Male }
      { Id = 4; Name = "Alican"; Age = 21; Gender = Male }
      { Id = 5; Name = "Mark"; Age = 50; Gender = Male } ]
cit.FindAll() |> List.ofSeq

// Some Queries
cit.Find (fun x -> x.Name.ToUpper().Contains("A")) |> List.ofSeq
cit.Find (fun x -> 25 < x.Age && x.Age < 40) |> List.ofSeq
cit.Find (fun x -> x.Id >= 3 && x.Age % 3 = 0) |> List.ofSeq

// Bulk Update
cit.Find (fun x -> x.Age > 30)
|> Seq.map (fun a -> { a with Name = a.Name.ToUpper() })
|> Seq.sortBy (fun a -> a.Name)
|> Seq.map cit.Update
cit.FindAll() |> List.ofSeq




// Query based on discriminated union
let results2 = cit.Find (fun a -> a.Gender = Male) |> List.ofSeq