let removeHeader lines =
    Seq.skip 2 lines

let onlyThoseWhoHaventBeenWrittenTo lines =
    Seq.filter
        (fun (line: string) -> not (line.EndsWith("|x")))
        lines

let fileName =
    System.Environment.GetEnvironmentVariable("HOME")
    + "/penpal_list"

System.IO.File.ReadLines fileName
|> removeHeader
|> onlyThoseWhoHaventBeenWrittenTo
|> Seq.iter (fun line -> printfn $"{line}")
