module Day4

let run() = 

    printfn "Hello from F# Day4"
    let mutable paperRollsAccessable = 0
    let inputRaw = System.IO.File.ReadAllText(@$"C:\Users\Abdul-mbb\Documents\Repo\AdventOfCode\2025\AOC2025\Day4\input.txt")
    // Convert to matrix
    printfn "%s" inputRaw
    let input = inputRaw.Split('\n')

    let matrix= input|> Array.map(fun v -> v.ToCharArray())
        
    for i in 0 .. matrix.Length - 1 do
        for j in 0 .. matrix[i].Length - 1 do
            let mutable count = 0
            if matrix[i][j] = '@' then
                
                try
                    if matrix[i][j+1] = '@' then 
                        count <- count + 1
                with _ -> ()
                try 
                    if matrix[i][j-1] = '@' then 
                        count <- count + 1
                with _ -> ()

                try
                    if matrix[i-1][j] = '@' then 
                        count <- count + 1
                with _ -> ()

                
                try
                    if matrix[i+1][j] = '@' then 
                        count <- count + 1
                with _ -> ()

                try
                    if matrix[i-1][j+1] = '@' then 
                        count <- count + 1
                with _ -> ()

                try
                    if matrix[i-1][j-1] = '@' then 
                        count <- count + 1
                with _ -> ()
                
                try
                    if matrix[i+1][j+1] = '@' then 
                        count <- count + 1
                with _ -> ()

                try
                    if matrix[i+1][j-1] = '@' then 
                        count <- count + 1
                with _ -> ()
                
                if count < 4 then
                    paperRollsAccessable <- paperRollsAccessable + 1
                
    printfn  "Paper Count: %d" paperRollsAccessable
    0