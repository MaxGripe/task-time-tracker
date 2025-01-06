// Saving and loading tasks to/from JSON
namespace TaskTimeTracker

open System
open System.IO
open System.Text.Json

module Persistence =
    let filePath = "tasks.json"

    let saveTasksToFile tasks =
        let json = JsonSerializer.Serialize(tasks)
        File.WriteAllText(filePath, json)

    let loadTasksFromFile () =
        if File.Exists(filePath) then
            let json = File.ReadAllText(filePath)
            JsonSerializer.Deserialize<(string * TimeSpan) list>(json)
        else
            [("New task", TimeSpan.Zero)]
