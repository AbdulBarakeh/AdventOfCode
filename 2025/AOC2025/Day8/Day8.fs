module Day8

open System
open System.IO
open System.Collections.Generic


type JunctionBox(x: float, y: float, z: float) =
    member _.X = x
    member _.Y = y
    member _.Z = z



let rec Find(index: int, parentSet: int[]) :int= 
    let mutable root = parentSet[index]
    if root <> parentSet[root] then 
       parentSet[index] <- Find(root, parentSet)
       root <- parentSet[index]
    root

let Union(index: int,jndex: int, parentSet: int[], rank: int[]) : bool =
    let iroot: int = Find(index, parentSet)
    let jroot: int = Find(jndex, parentSet)
    if iroot = jroot then // Already in the same set
        false
    else
        if rank[iroot] < rank[jroot] then
            parentSet[iroot] <- jroot
        elif rank[iroot] > rank[jroot] then
            parentSet[jroot] <- iroot
        else
            parentSet[jroot] <- iroot
            rank[iroot] <- rank[iroot] + 1
        true


let euclidianDistance (a: JunctionBox) (b: JunctionBox) =
    Math.Sqrt(
        Math.Pow(a.X - b.X, 2.0) +
        Math.Pow(a.Y - b.Y, 2.0) +
        Math.Pow(a.Z - b.Z, 2.0)
    )


let run() =
    printfn "Day 8: Playground"

    let path = Environment.CurrentDirectory
    let inputPath = $@"{path}\Day8\input.txt"
    let lines = File.ReadLines(inputPath)

    // Read junction boxes
    let junctionBoxes = ResizeArray<JunctionBox>()
    let paths = ResizeArray<(float * int * int)>()

    for line in lines do
        let parts = line.Split(',')
        junctionBoxes.Add(
            JunctionBox(
                float parts[0],
                float parts[1],
                float parts[2]
            )
        )

    printfn "Loaded %d junction boxes" junctionBoxes.Count

    for i in 0 .. junctionBoxes.Count - 1 do
        for j in i + 1 .. junctionBoxes.Count - 1 do
            let distance = euclidianDistance junctionBoxes[i] junctionBoxes[j]
            paths.Add((distance, i, j))

    let sortedPaths =
        paths
        |> Seq.sortBy (fun (distance, _, _) -> distance)
        |> Seq.toList


    let mutable connections = 0
    let parentSet = [| for i in 0 .. junctionBoxes.Count - 1 -> i |]
    let rank = [| for _ in 0 .. junctionBoxes.Count - 1 -> 0 |]
    for (d, i, j) in sortedPaths do
        if connections < 1000 then
            Union(i, j, parentSet, rank)|> ignore
            connections <- connections + 1
    

    let componentSizes =
        parentSet
        |> Array.mapi (fun i _ -> Find(i, parentSet))
        |> Array.countBy id
        |> Array.map snd
        |> Array.sortDescending

    // Compute result
    let result =
        componentSizes
        |> Array.sortDescending
        |> Array.take 3
        |> Array.reduce(*)

    printfn "Answer: %d" result