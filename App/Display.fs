module Display

let lineFor (languages: string list) =
    let prefix = "who writes in "

    let rest =
        languages
        |> List.indexed
        |> List.fold
               (fun soFar (index, language) ->
                    let separator =
                        if index = languages.Length - 1 then ""
                        elif index = languages.Length - 2 then " and "
                        else ", "

                    soFar + language + separator
                ) ""

    prefix + rest
