module Day3
let run() = 

    printfn "Hello from F# Day3"
    let mutable totalJoltage:List<int32> = []
    let input = System.IO.File.ReadLines(@$"C:\Users\Abdul-mbb\Documents\Repo\AdventOfCode\2025\AOC2025\Day3\input.txt")
    // 1. Find the largest digit
    for identifier in input do
        
        let largestDigit =
            identifier
            |> Seq.max                    // gets the char '0'..'9'

        // 2. Find the first index of that digit
        let index =
            identifier.IndexOf largestDigit

        // 3. Get substring *before* the first occurrence
        let substringLeft =
            identifier.Substring(0, index)

        // 4. Get substring *after* the first occurrence
        let substringRight =
            identifier.Substring(index + 1)

        if substringRight.Length > 0 then
            let nextLargestDigit = substringRight |> Seq.max    
            let resultingJoltage = System.Int32.Parse(largestDigit.ToString()+nextLargestDigit.ToString())
            totalJoltage <- resultingJoltage :: totalJoltage
        else
            let prevLargestDigit = substringLeft |> Seq.max
            let resultingJoltage = System.Int32.Parse(prevLargestDigit.ToString()+largestDigit.ToString())
            totalJoltage <- resultingJoltage :: totalJoltage

    List.sum totalJoltage |> printfn "The final sum is: %d"
    0