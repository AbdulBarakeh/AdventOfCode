module Day6
let run() = 

    printfn "Hello from F# Day6"
    let inputRaw = System.IO.File.ReadAllText(@$"C:\Users\Abdul-mbb\Documents\Repo\AdventOfCode\2025\AOC2025\Day6\example.txt")
    // Convert to matrix
    printfn "%s" inputRaw
    let matrix = inputRaw.Split('\n') 
                |> Array.map(fun x -> x.Trim())          
                |> Array.map(fun x -> x.Split(" ") |> Array.filter(fun x -> x <> "") |> Array.map string)
    printfn "%A" matrix
    let mutable result = []

    for i in 0 .. matrix[0].Length - 1 do
        for j = 0 to matrix.Length - 1 do
            matrix[j][i] |> printf "%s "
