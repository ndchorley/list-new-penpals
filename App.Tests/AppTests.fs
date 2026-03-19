module App.Tests

open Program
open NUnit.Framework
open System.IO

[<Test>]
let It_shows_a_prompt_and_can_be_exited () =
    let reader = new StringReader("Q\n")
    let writer = new StringWriter()

    run reader writer

    Assert.That(
        writer.ToString(),
        Is.EqualTo(
            "enter command: \
            \n"
        )
    )
