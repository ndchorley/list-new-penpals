module App.Tests

open Program
open NUnit.Framework
open System.IO

[<Test>]
let It_shows_a_message () =
    let writer = new StringWriter()

    run writer.WriteLine

    Assert.That(
        writer.ToString(),
        Is.EqualTo("Listing new penpals\n")
    )
