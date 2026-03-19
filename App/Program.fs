open System.IO

let run writeLine =
    writeLine "Listing new penpals"
    
[<EntryPoint>]
let main _ =
    run System.Console.Out.WriteLine

    0
