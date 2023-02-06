module App

(**
 The famous Increment/Decrement ported from Elm.
 You can find more info about Elmish architecture and samples at https://elmish.github.io/
*)

open Elmish
open Elmish.React
open Elmish.Debug
open Fable.React
open Fable.React.Props
open Fable.React.HookBindings

// MODEL

type Model = int

type Msg =
    | Increment
    | Decrement

let init () : Model = 0

// UPDATE

let update (msg: Msg) (model: Model) =
    match msg with
    | Increment -> model + 1
    | Decrement -> model - 1

// VIEW (rendered with React)

let viewFunction =
    FunctionComponent.Of(fun ((model: Model), dispatch) -> 
        Hooks.useEffect(fun () -> ())
        
        div [] [
            button [ OnClick(fun _ -> dispatch Increment) ] [
                str "+"
            ]
            div [] [ str (string model) ]
            button [ OnClick(fun _ -> dispatch Decrement) ] [
                str "-"
            ]
        ]
    )
let view (model: Model) dispatch = viewFunction (model, dispatch)

// App
Program.mkSimple init update view
|> Program.withReactSynchronous "elmish-app"
|> Program.withConsoleTrace
|> Program.withDebugger
|> Program.run
