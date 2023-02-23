module MinimalApp.Types

type CreateFilterOptionsOptions =
  abstract stringify: ('option -> string) with get, set
  
let x (myFun: 'a -> string) =
  myFun