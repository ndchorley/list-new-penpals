module App.Tests

open Program
open NUnit.Framework

[<Test>]
let It_shows_a_message () =
    let mutable written = ""
    let writeLineToString line = written <- written + line + "\n"
    
    run writeLineToString

    Assert.That(written, Is.EqualTo("Listing new penpals\n"))
