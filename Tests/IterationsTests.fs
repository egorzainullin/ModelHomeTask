open NUnit.Framework
open FsUnit
open System.Numerics

open Iterations

let doubleFloat32 (x, y) = (float32 x, float32 y)

[<Test>]
let ``gen list should produce correct lists`` () =
    let list =
        [ (1.0, 2.0); (3.0, 4.0); (5.0, 6.0) ]
        |> List.map doubleFloat32
        |> PolygonalLine.wrapLine

    let actual =
        [ (1.0, 2.0); (3.0, 4.0); (5.0, 6.0) ]
        |> List.map (fun (x, y) -> (float32 x, float32 y))
        |> List.map Vector2

    list |> should equal actual
 
let h = float32 0.01

let c = (float32)2.0

let func = Core.funcWithSubstitution c

let line1 = [ (1.0, 2.0); (3.0, 4.0); (5.0, 6.0) ] |> List.map doubleFloat32 |> PolygonalLine.wrapLine
let line2 = [ (1.0, 0.0); (3.0, 0.0); (5.0, 0.0) ] |> List.map doubleFloat32 |> PolygonalLine.wrapLine

[<Test>]
let ``process should change line``() =
    let runner = IterRunner(line2, func, h)
    let receivedRunner = runner.Process()
    let line = receivedRunner.Line
    line.Length |> should equal 3
    


    
    
