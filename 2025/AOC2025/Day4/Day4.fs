module Day4
let run() = 

    printfn "Hello from F# Day4"

    let inputRaw = System.IO.File.ReadAllText(@$"C:\Repositories\AdventOfCode\2025\AOC2025\Day4\example.txt")
    // Convert to matrix
    printfn "%s" inputRaw
    let input = inputRaw.Split('\n')

    let matrix= input|> Array.map(fun v -> v.ToCharArray())
        
    // // for row in matrix do
    // //     printfn "%s" (System.String row)
    matrix[6][2] |> printfn "The element: %c"