module Client

open Elmish
open Elmish.React
open Fable.React
open Fable.React.Props
open Fetch.Types
open Thoth.Fetch
open Fulma
open Thoth.Json

open Shared

type Model = { Text: string }
type Msg = NoMsg
let init () : Model * Cmd<Msg> = { Text = "LiteDB with SAFE!" }, Cmd.none
let update (message : Msg) (model : Model) : Model * Cmd<Msg> = match message with NoMsg -> model, Cmd.none

let button txt onClick =
    Button.button
        [ Button.IsFullWidth
          Button.Color IsPrimary
          Button.OnClick onClick ]
        [ str txt ]

let view (model : Model) (dispatch : Msg -> unit) =
    div [] [
        Navbar.navbar [ Navbar.Color IsPrimary ] [ Navbar.Item.div [ ] [ Heading.h2 [ ] [ str "SAFE Template" ] ] ]

        Container.container [] [
            Section.section [] [
                Content.content [ Content.Modifiers [ Modifier.TextAlignment (Screen.All, TextAlignment.Centered) ] ] [
                    Heading.h3 [] [ str model.Text ]
                ]
                Columns.columns [] [
                    Column.column [] [ button "Create" (fun _ -> dispatch NoMsg) ]
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
