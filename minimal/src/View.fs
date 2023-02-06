module MinimalApp.View

open Feliz
open Feliz.UseListener

// TODO try to do the same thing on old react version and see if it breaks
[<ReactComponent>]
let InternalView (model: Model, dispatch) =
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

let view (model: Model) dispatch =
    InternalView (model, dispatch)