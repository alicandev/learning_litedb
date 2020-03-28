namespace Shared

open System

type Genre =
    | Rock
    | Pop
    | Metal
    member this.AsString = sprintf "%A" this

type Album =
    { Id: Guid
      Name: string
      Genre: Genre
      DateReleased: DateTime }
