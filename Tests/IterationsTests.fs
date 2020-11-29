open NUnit.Framework
open FsUnit
open System.Numerics

open Iterations
//
//[<Test>]
//let ``gen list should produce correct lists``() =
//    let list = [ (1,0); (2, 1); (4, 5) ] |> List.map (fun (x, y) -> (float32 x,float32 y) |> Iterations.PolygonalLine.genLine 
//    let expected = [ Vector2(1.0, 0.0); Vector2(2.0, 1.0); Vector2(4.0, 5.0) ]
//    list |> should equal expe 