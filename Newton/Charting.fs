module Charting

open System.Numerics
open XPlot.Plotly

let toScatter (list: (double * double) list) =
    let (xs, ys) = List.unzip list
    Scatter(x = xs, y = ys, mode = "markers")

let draw complexList =
    let list = complexList |> List.map (fun (z: Complex) -> z.Real, z.Imaginary)
    let scatter = toScatter list

    let chart =
        scatter
        |> Chart.Plot
        |> Chart.WithHeight 500
        |> Chart.WithWidth 500

    Chart.Show chart
