namespace MinimalApp

type Model = int
type Msg =
    | Increment
    | Decrement

module Model =
    let init () : Model = 0

    // UPDATE

    let update (msg: Msg) (model: Model) =
        match msg with
        | Increment -> model + 1
        | Decrement -> model - 1    