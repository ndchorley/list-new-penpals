open System.IO

let run (reader: TextReader) (writer: TextWriter) =
    writer.Write("\x1B[0;35m>>\x1B[0m ")

    let _ = reader.ReadLine()
    
    ()

[<EntryPoint>]
let main _ =
    run System.Console.In System.Console.Out

    0
