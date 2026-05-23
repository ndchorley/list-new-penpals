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

let insertIntoDatabase penpals =
    let dbFile = System.Environment.GetEnvironmentVariable("HOME") + "/penpal_list.db"
    let connectionString = "Data Source = " + dbFile
    let connection = new Microsoft.Data.Sqlite.SqliteConnection(connectionString)
    connection.Open()

    Seq.iter
        (fun penpal ->
            let command =
                new Microsoft.Data.Sqlite.SqliteCommand(
                    "INSERT INTO Penpals VALUES ($name, $address, $languages);", 
                    connection
                )

            command.Parameters.AddWithValue("$name", penpal.name)
            command.Parameters.AddWithValue("$address", penpal.address)
            command.Parameters.AddWithValue("languages", penpal.languages)

            command.ExecuteNonQuery()

            ()
        )
        penpals

    connection.Close()

let fileName =
    System.Environment.GetEnvironmentVariable("HOME")
    + "/penpal_list"

System.IO.File.ReadLines fileName
|> removeHeader
|> onlyThoseWhoHaventBeenWrittenTo
|> toPenpals
|> insertIntoDatabase
