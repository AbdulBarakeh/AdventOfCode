module Day7
let run() = 

    printfn "Hello from F# Day7"
    let path = System.Environment.CurrentDirectory
    let inputRaw = System.IO.File.ReadAllText(@$"{path}\Day7\input.txt")
    printfn "%s" inputRaw
    // Convert to matrix
    let matrix = inputRaw.Split('\n') 
                |> Array.map(fun x -> x.Trim())          
                |> Array.map(fun x -> x.ToCharArray())
    let mutable counter = 0
    for i in 0 .. matrix.Length - 1 do
        for j = 0 to matrix[i].Length - 1 do
            if i-1 > 0 && i+1 < matrix.Length && matrix[i][j] = '^' then
                if matrix[i-1][j] = '|' then
                    matrix[i][j+1] <- '|'
                    matrix[i][j-1] <- '|'
            elif i-1 > 0 && matrix[i][j] = '.' then
                if matrix[i-1][j] = '|' then
                    matrix[i][j] <- '|'
            elif matrix[i][j] = '|' then
                if i+1 < matrix.Length && matrix[i+1][j] = '.' then
                    matrix[i+1][j] <- '|'
        printfn "%A" matrix[i]
    
    for i in 0 .. matrix.Length - 1 do
        for j = 0 to matrix[i].Length - 1 do
            if i-1 > 0 && i+1 < matrix.Length && matrix[i][j] = '^' then
                if matrix[i-1][j] = '|' then
                    counter <- counter + 1
    printfn "%d" counter