module Program

open System

let countOccurencesOfCount count (counts: seq<seq<int>>) = 
    counts
    |> Seq.fold (fun acc stringCount -> if (Seq.contains count stringCount) then acc + 1 else acc) 0

let countOccurencesOf2 = countOccurencesOfCount 2
let countOccurencesOf3 = countOccurencesOfCount 3

let getLineCounts (lines: seq<string>) =
    lines 
    |> Seq.map (fun line -> 
        line 
        |> Seq.countBy id 
        |> Seq.map (fun (_, count) -> count))

let countDifferences (a: string) (b: string) =
    Seq.zip a b
    |> Seq.fold (fun count (a, b) -> if (a <> b) then count + 1 else count ) 0

let getLineDiff line otherlines: Map<string, int> = 
    otherlines 
    |> Seq.fold (fun lineDifferences otherLine -> lineDifferences.Add(line, countDifferences line otherLine)) Map.empty

let findDifferences lines: Map<string, Map<string, int>> = 
    lines
    |> Seq.fold (fun allLinesDifferences line -> allLinesDifferences.Add(line, getLineDiff line lines)) Map.empty

[<EntryPoint>]
let main _ =
    let lineCounts = System.IO.File.ReadLines("input.txt")

    let repeating2Times = countOccurencesOf2 (getLineCounts lineCounts)
    let repeating3Times = countOccurencesOf3 (getLineCounts lineCounts)
        
    printfn "%d" (repeating2Times * repeating3Times)  
    0
