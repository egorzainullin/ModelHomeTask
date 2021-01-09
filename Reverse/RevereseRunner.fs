namespace Reverse.Chart

open System.Drawing
open System.Windows.Forms
open Reverse
open Reverse.Chart


open XPlot.Plotly
open Reverse.Converter

type ReverseRunner() =
    class
        let getValuesTextBoxes text1 text2 =

            match tryParseDouble text1, tryParseDouble text2 with
            | (Some a, Some b) -> Some((a, b))
            | _ -> None

        let drawPlot (c, z0) =
           
                let k = Init.iterNumber

                let complexPoints =
                    Core.getPreImageNumberK c Init.start k

                let (rs, is) =
                    complexPoints
                    |> List.map (Core.unwrap)
                    |> List.unzip

                let scatter =
                    Scatter(x = rs, y = is, mode = "markers")

                let chart =
                    scatter
                    |> Chart.Plot
                    |> Chart.WithHeight 500
                    |> Chart.WithWidth 500

                Chart.Show chart
                0 |> ignore

        member this.Run() =
            let c = Init.defaultC
            let z0 = Init.defaultZ0
            drawPlot(c, z0)
    end

