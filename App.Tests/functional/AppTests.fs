module App.Tests

open Penpal
open NUnit.Framework
open System.IO

[<Test>]
let It_displays_a_message_when_there_are_no_penpals_to_write_to () =
    let inputReader =
        new StringReader
            "L\n\
            Q\n"
    let outputWriter = new StringWriter ()

    run inputReader outputWriter []

    Assert.That(
        outputWriter.ToString (),
        Is.EqualTo
            "\x1B[0;35m>>\x1B[0m \
            You have no penpals to write to\n\
            \x1B[0;35m>>\x1B[0m "
    )

[<Test>]
let It_displays_the_details_of_a_penpal_on_the_list () =
    let penpals =
        [{
            name = "Alice Jounet"
            address = "34 rue de la Paix, 30150 Aube, France"
            languages = ["French"; "English"]
        }]

    let inputReader =
        new StringReader
            "L\n\
            Q\n"

    let outputWriter = new StringWriter ()

    run inputReader outputWriter penpals

    Assert.That(
        outputWriter.ToString (),
        Is.EqualTo
            "\x1B[0;35m>>\x1B[0m \
            You have not written to:\n\
            Alice Jounet\n\
            34 rue de la Paix, 30150 Aube, France\n\n\
            who writes in French and English\n\
            \x1B[0;35m>>\x1B[0m "
    )
