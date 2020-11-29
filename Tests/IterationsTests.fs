open NUnit.Framework
open FsUnit
open System.Numerics

open Iterations

[<Test>]
let ``gen list should produce correct lists`` () =
    let list =
        [ (1.0, 2.0); (3.0, 4.0); (5.0, 6.0) ]
        |> PolygonalLine.genLine

    let actual =
        [ (1.0, 2.0); (3.0, 4.0); (5.0, 6.0) ]
        |> List.map (fun (x, y) -> (float32 x, float32 y))
        |> List.map Vector2

    list |> should equal actual
 
let h = float32 0.01

let func = Program.funcWithSubstitution

let line1 = PolygonalLine.genLine [ (1.0, 2.0); (3.0, 4.0); (5.0, 6.0) ]
let line2 = PolygonalLine.genLine [ (1.0, 0.0); (3.0, 0.0); (5.0, 0.0) ]

[<Test>]
let ``process should change line``() =
    let runner = IterRunner(line2, func, h)
    let receivedRunner = runner.Process()
    let line = receivedRunner.Line
    line.Length |> should equal 3
    


    
    
