open System.IO

let run (reader: TextReader) (writer: TextWriter) =
    let rec loop () =
        writer.Write("\x1B[0;35m>>\x1B[0m ")
        let commandString = reader.ReadLine()

        if commandString = "Q" then ()
        else
            writer.WriteLine("You have no penpals to write to")

            loop ()

    loop ()

[<EntryPoint>]
let main _ =
    run System.Console.In System.Console.Out

    0
