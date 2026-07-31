module App

open Display
open Penpal
open System.IO

let private list (outputWriter: TextWriter) (penpals: Penpal list) =
    if penpals.IsEmpty then
        outputWriter.WriteLine "You have no penpals to write to"
    else
        let penpal = penpals.Head

        outputWriter.WriteLine "You have not written to:"
        outputWriter.WriteLine penpal.name
        outputWriter.WriteLine penpal.address
        outputWriter.WriteLine ""
        outputWriter.WriteLine (lineFor penpal.languages)

let run (inputReader: TextReader) (outputWriter: TextWriter) (penpals: Penpal list) =
    let rec loop () =
        outputWriter.Write "\x1B[0;35m>>\x1B[0m "
        let commandString = inputReader.ReadLine ()

        if commandString = "Q" then ()
        elif commandString = "L" then
            list outputWriter penpals

            loop ()
        else
            loop ()

    loop ()
