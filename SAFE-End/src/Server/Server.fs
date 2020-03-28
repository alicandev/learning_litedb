open System.IO
open System.Threading.Tasks
open Microsoft.AspNetCore.Builder
open Microsoft.Extensions.DependencyInjection
open FSharp.Control.Tasks.V2
open Giraffe
open Saturn
open Shared
open Database
open Microsoft.AspNetCore.Http

let tryGetEnv = System.Environment.GetEnvironmentVariable >> function null | "" -> None | x -> Some x
let publicPath = Path.GetFullPath "../Client/public"
let port = "SERVER_PORT" |> tryGetEnv |> Option.map uint16 |> Option.defaultValue 8085us

let create next (ctx : HttpContext) = task {
    // TODO: Remember to set the Album's ID to a guid before sending here.
    let! album = ctx.BindModelAsync<Album>()
    albums.Insert(album) |> ignore
    return! text "Album Inserted" next ctx
}

let webApp = router {
    post "/api/album" create
}

let app = application {
    url ("http://0.0.0.0:" + port.ToString() + "/")
    use_router webApp
    memory_cache
    use_static publicPath
    use_json_serializer(Thoth.Json.Giraffe.ThothSerializer())
    use_gzip
}

run app
