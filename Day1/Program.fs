module Program

open System

[<EntryPoint>]
let main argv =
    let linesSeq = System.IO.File.ReadLines("input.txt") |> Seq.map (fun x -> x |> int)
    let sum = linesSeq |> Seq.sum
    
    let firstRepeatingFrequency =
        seq { 
            while true do
                yield! linesSeq
        }
        |> Seq.scan (fun (set, sum) i -> (Set.add sum set, sum + i)) (Set.empty, 0)
        |> Seq.find (fun (set, sum) -> Set.contains sum set)
        |> snd
        
    printfn "%d" sum
    printfn "%d" firstRepeatingFrequency
    0
