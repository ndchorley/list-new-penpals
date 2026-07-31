module App

open Penpal
open System.IO

let run (inputReader: TextReader) (outputWriter: TextWriter) (penpals: Penpal list) =
    let rec loop () =
        outputWriter.Write("\x1B[0;35m>>\x1B[0m ")
        let commandString = inputReader.ReadLine()

        if commandString = "Q" then ()
        elif commandString = "L" then
            if penpals.IsEmpty then
                outputWriter.WriteLine("You have no penpals to write to")
            else
                let penpal = penpals.Head

                outputWriter.WriteLine("You have not written to:")
                outputWriter.WriteLine(penpal.name)
                outputWriter.WriteLine(penpal.address)
                outputWriter.WriteLine(
                    "who writes in "
                    + penpal.languages.Head
                    + ", "
                    + penpal.languages.Tail.Head
                )
                ()

            loop ()
        else
            loop ()

    loop ()
