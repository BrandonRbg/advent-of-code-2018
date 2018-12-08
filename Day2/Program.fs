module Program

open System

[<EntryPoint>]
let main argv =
    let linesSeq = System.IO.File.ReadLines("input.txt")
    
    let counts =
        linesSeq
        |> Seq.map (fun line -> 
               line
               |> Seq.countBy id
               |> Seq.fold (fun idCount (char, count) -> 
                      match count with
                      | 2 -> (true, (idCount |> snd))
                      | 3 -> ((idCount |> fst), true)
                      | _ -> idCount) (false, false))
        |> Seq.fold (fun totalCounts idCount -> 
               match idCount with
               | (true, true) -> ((totalCounts |> fst) + 1, (totalCounts |> snd) + 1)
               | (true, false) -> ((totalCounts |> fst) + 1, totalCounts |> snd)
               | (false, true) -> (totalCounts |> fst, (totalCounts |> snd) + 1)) (0, 0)
    printfn "%d" (fst counts * snd counts)  
    0
