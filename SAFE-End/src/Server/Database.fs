module Database

open LiteDB
open LiteDB.FSharp
open Shared

let mapper = FSharpBsonMapper()
use db = new LiteDatabase("demo.db", mapper)
let albums = db.GetCollection<Album>("albums")



