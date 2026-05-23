let removeHeader lines =
    Seq.skip 2 lines

let onlyThoseWhoHaventBeenWrittenTo lines =
    Seq.filter
        (fun (line: string) -> not (line.EndsWith("|x")))
        lines

type Penpal = {
    name: string
    address: string
    languages: string
}

let toPenpals lines =
    Seq.map
        (fun (line: string) ->
            let parts = line.Split("|")

            {
                name = parts[0];
                address = parts[1];
                languages = parts[2]
            }
        )
        lines

let fileName =
    System.Environment.GetEnvironmentVariable("HOME")
    + "/penpal_list"

System.IO.File.ReadLines fileName
|> removeHeader
|> onlyThoseWhoHaventBeenWrittenTo
|> toPenpals
|> Seq.iter (fun penpal -> printfn $"{penpal}")
