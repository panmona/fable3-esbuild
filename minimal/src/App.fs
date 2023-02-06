module App

(**
 The famous Increment/Decrement ported from Elm.
 You can find more info about Elmish architecture and samples at https://elmish.github.io/
*)

open Elmish
open Elmish.React
open Elmish.Debug
open Feliz

open Feliz.UseListener

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

let InternalView = React.functionComponent (fun (model, dispatch) ->
        React.useWindowListener.onBeforeUnload (fun e -> e.returnValue <- true)
        
        Html.div [
            Html.button [
                prop.onClick (fun _ -> dispatch Increment)
                prop.text "+"
            ]
            Html.span [ prop.text (string model) ]
            Html.button [
                prop.onClick (fun _ -> dispatch Decrement)
                prop.text "-"
            ]
        ]
    )

let view (model: Model) dispatch : ReactElement =
    InternalView (model, dispatch)

// App
Program.mkSimple init update view
|> Program.withReactBatched "elmish-app"
|> Program.withConsoleTrace
|> Program.withDebugger
|> Program.run
