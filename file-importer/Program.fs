open Thoth.Json.Net

let removeHeader lines =
    Seq.skip 2 lines

type Penpal = {
    name: string
    address: string
    languages: string list
    writtenTo: bool
}

let keepOnlyThoseWhoHaventBeenWrittenTo penpals =
    Seq.filter
        (fun (penpal: Penpal) -> not penpal.writtenTo)
        penpals

let parseLanguages (languageString: string) =
    languageString.Split(",")
    |> Array.map (fun language -> language.TrimStart().TrimEnd())
    |> List.ofArray

let toPenpals lines =
    Seq.map
        (fun (line: string) ->
            let parts = line.Split("|")

            {
                name = parts[0];
                address = parts[1];
                languages = parseLanguages parts[2];
                writtenTo = parts[3] = "x"
            }
        )
        lines

let connectionFor dbFile =
    let connectionString = "Data Source = " + dbFile

    let connection =
        new Microsoft.Data.Sqlite.SqliteConnection(connectionString)

    connection

let jsonOf languages =
    languages
    |> List.map Encode.string
    |> Encode.list
    |> fun json -> json.ToString()

let insertIntoDatabase penpals =
    let dbFile =
        System.Environment.GetEnvironmentVariable("HOME") +
        "/penpal_list.db"

    let connection = connectionFor dbFile

    connection.Open()

    Seq.iter
        (fun penpal ->
            let command =
                new Microsoft.Data.Sqlite.SqliteCommand(
                    "INSERT INTO Penpals VALUES ($name, $address, $languages);", 
                    connection
                )

            command.Parameters.AddWithValue("$name", penpal.name) |> ignore
            command.Parameters.AddWithValue("$address", penpal.address) |> ignore
            command.Parameters.AddWithValue("languages", jsonOf penpal.languages) |> ignore

            command.ExecuteNonQuery() |> ignore

            ()
        )
        penpals

    connection.Close()

let fileName =
    System.Environment.GetEnvironmentVariable("HOME") +
    "/penpal_list"

System.IO.File.ReadLines fileName
|> removeHeader
|> toPenpals
|> keepOnlyThoseWhoHaventBeenWrittenTo
|> insertIntoDatabase
