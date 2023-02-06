module App

(**
 The famous Increment/Decrement ported from Elm.
 You can find more info about Elmish architecture and samples at https://elmish.github.io/
*)

open Elmish
open Elmish.React
// open Elmish.Debug
open Feliz

// open Feliz.UseListener

// MODEL

type Model = int

type Msg =
    | Increment
    | Decrement

let init () = 0, Cmd.none

// UPDATE

let update (msg: Msg) (model: Model) =
    match msg with
    | Increment -> model + 1, Cmd.none
    | Decrement -> model - 1, Cmd.none

// VIEW (rendered with React)

[<ReactComponent>]
let InternalView (model: Model, _) =
    let xFun = fun () -> ()
    React.useEffect(xFun, [||])
    
    Html.div [
        Html.button [
            //prop.onClick (fun _ -> dispatch Increment)
            prop.text "+"
        ]
        Html.span [ prop.text (string model) ]
        Html.button [
            //prop.onClick (fun _ -> dispatch Decrement)
            prop.text "-"
        ]
    ]

let view (model: Model) dispatch : ReactElement =
    InternalView (model, dispatch)

// App
// Program.mkProgram init update view
// |> Program.withReactBatched "elmish-app"
// |> Program.withConsoleTrace
// // |> Program.withDebugger
// |> Program.run

let x = ReactDOM.createRoot(Browser.Dom.document.getElementById "elmish-app")
x.render(view 0 ())