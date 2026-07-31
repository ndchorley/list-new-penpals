open App
open Penpal

[<EntryPoint>]
let main _ =
    run
        System.Console.In
        System.Console.Out
        [{
            name = "John Smith"
            address = "123 A Street, Some City, UK"
            languages = ["English"]
        }]

    0
