module App.LineForLanguagesTests

open Display
open NUnit.Framework

[<Test>]
let It_produces_a_line_for_one_language () =
    let languages = ["French"]

    Assert.That(
        lineFor languages,
        Is.EqualTo "who writes in French"
    )
