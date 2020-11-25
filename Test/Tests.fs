module Example.Tests

open NUnit.Framework
open FsUnit


[<Test>]
let ``equality test``() =
    2 * 3 |> should equal 6
    0 |> ignore
    
        