// module Day8

// type JunctionBox =
//     class
//         val X : float
//         val Y : float
//         val Z : float

//         new (x: float, y: float, z: float) as this =
//             { X = x; Y = y; Z = z }
//             then
//                 printfn "Creating JunctionBox: (%g, %g, %g)" this.X this.Y this.Z
//     end

// let run() =

//     printfn "Hello from F# Day8"

//     let euclidianDistance (a: JunctionBox) (b: JunctionBox) =
//         System.Math.Sqrt(
//             System.Math.Pow(a.X - b.X, 2.0) +
//             System.Math.Pow(a.Y - b.Y, 2.0) +
//             System.Math.Pow(a.Z - b.Z, 2.0)
//         )

//     let path = System.Environment.CurrentDirectory
//     let inputRaw = System.IO.File.ReadLines($@"{path}\Day8\example.txt")

//     let junctionBoxes = ResizeArray<JunctionBox>()
//     let paths = ResizeArray<(float * JunctionBox * JunctionBox)>()

//     for line in inputRaw do
//         let parts = line.Split(',')
//         junctionBoxes.Add(
//             JunctionBox(
//                 float parts[0],
//                 float parts[1],
//                 float parts[2]
//             )
//         )

//     for i in 0 .. junctionBoxes.Count - 1 do
//         for j in i + 1 .. junctionBoxes.Count - 1 do
//             let distance = euclidianDistance junctionBoxes[i] junctionBoxes[j]
//             paths.Add((distance, junctionBoxes[i], junctionBoxes[j]))

//     let sortedPaths =
//         paths
//         |> Seq.sortBy (fun (distance, _, _) -> distance)
//         |> Seq.toList

//     for (distance, box1, box2) in sortedPaths do
//         printfn
//             "Distance: %g between (%g,%g,%g) and (%g,%g,%g)"
//             distance
//             box1.X box1.Y box1.Z
//             box2.X box2.Y box2.Z

module Day8

open System
open System.IO
open System.Collections.Generic

// ----------------------------
// Domain model
// ----------------------------

type JunctionBox(x: float, y: float, z: float) =
    member _.X = x
    member _.Y = y
    member _.Z = z

// ----------------------------
// Union-Find (Disjoint Set Union)
// ----------------------------

type UnionFind(n: int) =
    let parent = Array.init n id
    let size = Array.create n 1

    member this.Find(x: int) =
        let rec findRoot x =
            if parent[x] = x then x
            else
                parent[x] <- findRoot parent[x]   // path compression
                parent[x]
        findRoot x

    member this.Union(a: int, b: int) =
        let rootA = this.Find(a)
        let rootB = this.Find(b)

        if rootA <> rootB then
            // union by size
            if size[rootA] < size[rootB] then
                parent[rootA] <- rootB
                size[rootB] <- size[rootB] + size[rootA]
            else
                parent[rootB] <- rootA
                size[rootA] <- size[rootA] + size[rootB]

    member this.ComponentSizes() =
        parent
        |> Array.mapi (fun i _ -> this.Find(i))
        |> Array.countBy id
        |> Array.map snd

// ----------------------------
// Utility
// ----------------------------

let euclidianDistance (a: JunctionBox) (b: JunctionBox) =
    Math.Sqrt(
        Math.Pow(a.X - b.X, 2.0) +
        Math.Pow(a.Y - b.Y, 2.0) +
        Math.Pow(a.Z - b.Z, 2.0)
    )

// ----------------------------
// Main entry
// ----------------------------

let run() =
    printfn "Day 8: Playground"

    let path = Environment.CurrentDirectory
    let inputPath = $@"{path}\Day8\example.txt"
    let lines = File.ReadLines(inputPath)

    // Read junction boxes
    let boxes = ResizeArray<JunctionBox>()

    for line in lines do
        let parts = line.Split(',')
        boxes.Add(
            JunctionBox(
                float parts[0],
                float parts[1],
                float parts[2]
            )
        )

    printfn "Loaded %d junction boxes" boxes.Count

    // Generate all pairwise distances
    let paths = ResizeArray<(float * int * int)>()

    for i in 0 .. boxes.Count - 1 do
        for j in i + 1 .. boxes.Count - 1 do
            let d = euclidianDistance boxes[i] boxes[j]
            paths.Add((d, i, j))

    printfn "Generated %d distances" paths.Count

    // Sort by distance
    let sortedPaths =
        paths
        |> Seq.sortBy (fun (d, _, _) -> d)
        |> Seq.toList

    // Union-Find
    let uf = UnionFind(boxes.Count)

    let mutable connections = 0

    for (_, i, j) in sortedPaths do
        if connections < 20 then
            uf.Union(i, j)
            connections <- connections + 1

    // Compute result
    let result =
        uf.ComponentSizes()
        |> Array.sortDescending
        |> Array.take 3

    let mutable resTemp = 1

    for identifier in result do
        resTemp <- resTemp * identifier

    printfn "Answer: %d" resTemp