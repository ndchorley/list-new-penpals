open System.IO

let run (reader: TextReader) (writer: TextWriter) =
    writer.Write("enter command: ")

    let _ = reader.ReadLine()
    
    writer.WriteLine("")

[<EntryPoint>]
let main _ =
    run System.Console.In System.Console.Out

    0
