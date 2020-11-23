namespace FSharpBackend

open System.Numerics
open System.Collections.Generic
open FSharpBackend

type FSharpFinder(minVal: double, maxVal: double, z0: Complex, c: Complex) =
    
    let func = Core.func
    
    member this.Process() =
        let xs = Core.genList minVal maxVal Core.h
        let ys = Core.genList minVal maxVal Core.h
        let complexList = Core.complexPoints xs ys
        let (good, bad) = Core.findInvariant func c complexList
        let goodList = List(Seq.ofList good)
        let badList = List(Seq.ofList bad)
        (goodList, badList)
        
    static member UnzipComplexListIntoTwo(listCSharp: ResizeArray<_>) =
        let list = Seq.toList listCSharp
        let newList = list |> List.map (Core.unwrap)
        let leftList = ResizeArray(List.map fst newList)
        let rightList = ResizeArray(List.map snd newList)
        (leftList, rightList)
    
        
        

