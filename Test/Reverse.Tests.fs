module Reverse.Tests

open NUnit.Framework
open FsUnit
open Reverse.Chart
open MathNet.Numerics

open Reverse.Chart.Solver

[<Test>]    
let ``solution is correct``() =
    let z = Complex.one
    let c = Complex.zero
    let xs = getSolution c z
    xs |>  should equivalent [ -Complex.onei; Complex.onei ]
    0 |> ignore