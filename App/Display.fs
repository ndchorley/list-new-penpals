module Display

let lineFor (languages: string list) =
    let prefix = "who writes in "

    if languages.Length = 1 then
        prefix + languages.Head
    elif languages.Length = 2 then
        prefix
        + languages.Head
        + " and "
        + languages.Tail.Head
    else
        prefix
        + languages.Head
        + ", "
        + languages.Tail.Head
