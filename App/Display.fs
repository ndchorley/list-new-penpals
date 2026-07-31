module Display

let lineFor (languages: string list) =
    let prefix = "who writes in "

    let rest =
        if languages.Length = 1 then
            languages.Head
        elif languages.Length = 2 then
            languages.Head + " and " + languages.Tail.Head
        else
            languages.Head + ", " + languages.Tail.Head

    prefix + rest
