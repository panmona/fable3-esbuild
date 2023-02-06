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
open MinimalApp

// MODEL

// VIEW (rendered with React)

let init _ = Model.init ()
let update msg model = Model.update msg model
let view model dispatch = View.view model dispatch

// App
Program.mkSimple init update view
|> Program.withReactSynchronous "elmish-app"
|> Program.withConsoleTrace
|> Program.withDebugger
|> Program.run
