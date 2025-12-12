module Day6
let run() = 

    printfn "Hello from F# Day6"
    let path = System.Environment.CurrentDirectory
    let inputRaw = System.IO.File.ReadAllText(@$"{path}\Day6\input.txt")
    // Convert to matrix
    let matrix = inputRaw.Split('\n') 
                |> Array.map(fun x -> x.Trim())          
                |> Array.map(fun x -> x.Split(" ") |> Array.filter(fun x -> x <> "") |> Array.map string)
    let mutable result = []

    for i in 0 .. matrix[0].Length - 1 do
        let mutable tempRes = []
        for j = 0 to matrix.Length - 1 do
            tempRes <- matrix[j][i] :: tempRes
        if tempRes[0] = "+" then
            let tempoRes = tempRes|> List.tail |> List.map(fun x -> System.Int64.Parse(x))
            result<- (tempoRes |> List.sum)::result
            else
                printfn "%A" tempRes
                let tempoRes = tempRes|> List.tail|> List.map(fun x -> System.Int64.Parse(x))
                let mutable resNum = 1:int64
                for identifier in tempoRes do
                    resNum <- resNum*identifier
                result<- resNum::result
                printfn "%A" result

    result |> List.sum |> printfn "%d"