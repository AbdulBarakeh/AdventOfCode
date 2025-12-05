printfn "Hello from F#"
let mutable ZeroIncrementer = 0
let mutable pos=50

let lineSplitter(line:string)=[|string line.[0];line.Substring(1)|]
let lines = System.IO.File.ReadLines(@$"C:\Users\Abdul-mbb\Documents\Repo\AdventOfCode\2025\AOC2025\Day1\input.txt")
for line in lines do
    let parts=lineSplitter(line)
    if char(parts[0]) = 'R' then
        let num = System.Int32.Parse(parts[1])
        for _ = 1 to num do
            if pos+1 = 100 then
                ZeroIncrementer <- ZeroIncrementer + 1
                pos <- 0
            else
                pos <- pos + 1
        printfn "Current Position after R %d: %d" num pos

             
    else
        let num = System.Int32.Parse(parts[1])
        for _ = 1 to num do
            if pos-1 = -1 then
                ZeroIncrementer <- ZeroIncrementer + 1
                pos <- 99
            else
                pos <- pos - 1
        printfn "Current Position after L%d: %d" num pos
    if pos = 0  then
        ZeroIncrementer <- ZeroIncrementer + 1
printfn "Final Position: %d" pos
printfn "Zero Crossings: %d" ZeroIncrementer

// 2140-high
// 1052-low
// 1578-high
// 1315-wrong