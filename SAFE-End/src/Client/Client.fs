module Client

open System
open Elmish
open Elmish.React
open Fable.React
open Fable.React.Props
open Fetch.Types
open Thoth.Fetch
open Fulma
open Thoth.Json

open Shared

type Model = { Album : Album option ; Response : string }

type Msg =
    | Create of Album
    | Created
    | NoMsg

let init () : Model * Cmd<Msg> = { Response = "" ; Album = None }, Cmd.none

let createAlbum (album : Album) = Fetch.post("/api/album", album, Decode.Auto.generateDecoder<Album>(), [])
let readAlbumByName (albumName : string) = Fetch.fetchAs<Album>(sprintf "/api/album/%s" albumName)

let update (message : Msg) (model : Model) : Model * Cmd<Msg> =
    match message with
    | Create album ->
        let model = { Album = Some album ; Response = "Album created." }
        let command = Cmd.OfPromise.perform createAlbum album (fun _ -> NoMsg)
        model, command
    | Created -> model, Cmd.none
    | NoMsg -> model, Cmd.none

let button txt onClick =
    Button.button
        [ Button.IsFullWidth
          Button.Color IsPrimary
          Button.OnClick onClick ]
        [ str txt ]

let view (model : Model) (dispatch : Msg -> unit) =
    div [] [
        Navbar.navbar [ Navbar.Color IsPrimary ] [ Navbar.Item.div [ ] [ Heading.h2 [ ] [ str "LiteDB with SAFE" ] ] ]

        Container.container [] [
            br []
            Box.box' [] [
                Heading.h4 [] [ str model.Response ]
                Columns.columns [] [
                    Column.column [] [ Label.label [] [ str "Id:" ] ]
                    Column.column [] [ Label.label [] [ str "Name:" ] ]
                    Column.column [] [ Label.label [] [ str "Release Date:" ] ]
                    Column.column [] [ Label.label [] [ str "Genre:" ] ]
                ]
                match model.Album with
                | Some album ->
                    Columns.columns [] [
                        Column.column [] [ str (sprintf "%A" album.Id) ]
                        Column.column [] [ str album.Name ]
                        Column.column [] [ str album.Genre.AsString ]
                        Column.column [] [ str (album.DateReleased.ToShortDateString()) ]
                    ]
                | None -> ()

            ]
            Section.section [] [
                Content.content [ Content.Modifiers [ Modifier.TextAlignment (Screen.All, TextAlignment.Centered) ] ] [
                    Heading.h3 [] [ str "Controls" ]
                ]
                Heading.h4 [] [ str "Basic CRUD" ]
                Columns.columns [] [
                    Column.column [] [
                        button "Create" (fun _ ->
                            { Id = Guid.NewGuid(); Name = "My Turn"; DateReleased = DateTime.UtcNow; Genre = Rock }
                            |> Create
                            |> dispatch
                        )
                    ]
                    Column.column [] [ button "Read" (fun _ -> dispatch NoMsg) ]
                    Column.column [] [ button "Update" (fun _ -> dispatch NoMsg) ]
                    Column.column [] [ button "Delete" (fun _ -> dispatch NoMsg) ]
                ]
            ]
        ]

    ]

#if DEBUG
open Elmish.Debug
open Elmish.HMR
#endif

Program.mkProgram init update view
#if DEBUG
|> Program.withConsoleTrace
#endif
|> Program.withReactBatched "elmish-app"
#if DEBUG
|> Program.withDebugger
#endif
|> Program.run
