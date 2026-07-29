module App

open System.IO

let run (inputReader: TextReader) (outputWriter: TextWriter) =
    let rec loop () =
        outputWriter.Write("\x1B[0;35m>>\x1B[0m ")
        let commandString = inputReader.ReadLine()

        if commandString = "Q" then ()
        else
            outputWriter.WriteLine("You have no penpals to write to")

            loop ()

    loop ()
