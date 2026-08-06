open App
open Penpal

[<EntryPoint>]
let main _ =
    let findOnePenpal () =
        [{
             name = "John Smith"
             address = "123 A Street, Some City, UK"
             languages = ["English"]
         }]

    run
        System.Console.In
        System.Console.Out
        findOnePenpal

    0
