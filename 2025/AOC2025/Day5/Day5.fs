module Day5
let run() = 

    printfn "Hello from F# Day5"
    let inputRaw = System.IO.File.ReadAllText(@$"C:\Users\Abdul-mbb\Documents\Repo\AdventOfCode\2025\AOC2025\Day5\input.txt")
    // Convert to matrix
    let rangeInput = System.Text.RegularExpressions.Regex.Split(inputRaw,"\n\B")[0]
    let test = rangeInput.Split('\n')

    let ingredientIds = System.Text.RegularExpressions.Regex.Split(inputRaw,"\n\B")[1]
    let testIngID = ingredientIds.Split('\n') |> Array.filter (fun s -> s <> "")


    let numberDictPre = testIngID|> Array.skip 1 |> Array.take (testIngID.Length - 1)


    let numberDict = numberDictPre|> Array.map (fun n -> System.Int64.Parse(n), "none") |> dict |> System.Collections.Generic.Dictionary

    for kvp in numberDict do
        for r in test do
            printfn "Processing range: %s" r
            let parts = r.Split('-') |> Array.map int64
            let startR=parts.[0]
            let endR =  parts.[1]
            if endR-kvp.Key > 0 && startR-kvp.Key < 0 then
                numberDict.[kvp.Key] <- "valid"
                printfn "Marking %d as valid" kvp.Key
                else
                    printfn "%d not in dictionary" kvp.Key
            printfn "Key: %d, Value: %s" kvp.Key kvp.Value

    // Count valid numbers
    let validCount = numberDict.Values |> Seq.filter ((=) "valid") |> Seq.length

    printfn "Number of valid numbers: %d" validCount
