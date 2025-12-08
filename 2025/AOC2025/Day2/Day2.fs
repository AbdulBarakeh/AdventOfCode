module Day2
open System
let run() = 

    printfn "Hello from Day2"

    let mutable pos:List<int64> = []

    let theLine = System.IO.File.ReadAllText(@$"C:\Users\Abdul-mbb\Documents\Repo\AdventOfCode\2025\AOC2025\Day2\input.txt")

    let parts=theLine.Split(',')

    for line in parts do
        let range = line.Split('-')
        let startNum = int64 range.[0]
        let endNum = int64 range.[1]

        for identifier in startNum .. 1L .. endNum do
            let stringy = identifier.ToString() 
            if stringy.Length % 2 = 0 then
                let halfLength = stringy.Length / 2
                let firstHalf = System.Int64.Parse(stringy.[0..halfLength-1])
                let secondHalf = System.Int64.Parse(stringy.[halfLength..stringy.Length-1])
                firstHalf.ToString() |> printfn "First Half: %s"
                secondHalf.ToString() |> printfn "Second Half: %s"
                if firstHalf = secondHalf then
                    pos <- identifier :: pos
    List.sum pos |> printfn "The final sum is: %d"
    0
    
