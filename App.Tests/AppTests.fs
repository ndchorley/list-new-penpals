module App.Tests

open NUnit.Framework
open System.IO

[<Test>]
let It_displays_a_message_when_there_are_no_penpals_to_write_to () =
    let reader = new StringReader("L\nQ\n")
    let writer = new StringWriter()

    run reader writer

    Assert.That(
        writer.ToString(),
        Is.EqualTo(
            "\x1B[0;35m>>\x1B[0m \
            You have no penpals to write to\n\
            \x1B[0;35m>>\x1B[0m ")
    )
