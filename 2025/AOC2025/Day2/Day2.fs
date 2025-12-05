module Day2
open System
let run() = 


    let lineSplitter(line:string)=[","]

    let path = Environment.CurrentDirectory
    let lines = System.IO.File.ReadLines(@$"{path}\Day2\example.txt")
    
    for line in lines do
        let parts=line.Split(',')
        for range in parts do
            
        if char(parts[0]) = 'R' then
            let num = System.Int32.Parse(parts[1])
            for _ = 1 to num do
                if pos+1 = 100 then
                    pos <- 0
                else
                    pos <- pos + 1
            printfn "Current Position after R %d: %d" num pos
    