module App

open Feliz

// From Docs: https://zaid-ajaj.github.io/Feliz/#/Feliz/React/EffectfulComponents
[<ReactComponent>]
let TabCounter() =
    let (count, setCount) = React.useState(0)
    // execute this effect on every render cycle
    React.useEffect(fun () -> Browser.Dom.document.title <- sprintf "Count = %d" count)

    Html.div [
        Html.h1 count
        Html.button [
            prop.text "Increment"
            prop.onClick (fun _ -> setCount(count + 1))
        ]
    ]

let root = ReactDOM.createRoot(Browser.Dom.document.getElementById "elmish-app")
root.render(TabCounter ())