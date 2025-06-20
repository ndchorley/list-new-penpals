module App.Tests

open NUnit.Framework

[<Test>]
let It_displays_a_message () =
    let mutable output = ""

    let writeLine line =
        output <- output + line + "\n"

    listNewPenpals writeLine

    Assert.That(output, Is.EqualTo("List new penpals\n"))
