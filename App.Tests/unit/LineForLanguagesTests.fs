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

[<Test>]
let It_separates_two_languages_by_and () =
    let languages = ["French"; "English"]

    Assert.That (
       lineFor languages,
       Is.EqualTo "who writes in French and English"
    )

[<Test>]
let It_separates_more_than_two_languages_by_commas_and_an_and_between_the_last_two () =
    let languages = ["French"; "German"; "English"; "Portuguese"]

    Assert.That (
        lineFor languages,
        Is.EqualTo "who writes in French, German, English and Portuguese"
    )
