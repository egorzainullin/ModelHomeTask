namespace Iterations

open System.Numerics
open XPlot.Plotly

type IterRunner(line: PolygonalLine, func: ((float32 * float32) -> (float32 * float32)), h: float32) =
    class        
        let ``process`` (line) =
            let func = Iterations.Core.vectorApply 
            let line2 = PolygonalLine.transform func h line
            IterRunner(line2, func, h)

        member  this.Line = line

        member this.H = h

        member this.Process() = ``process`` (this.Line)

        member this.ProcessNTimes(n: int) =
            let rec processNTimes line k =
                if k = 0 then
                    IterRunner(line, func, h)
                else
                    let newLine = (``process`` line).Line
                    processNTimes newLine (k - 1)

            processNTimes line n


        member this.Show() =
            let scatter = Core.toScatter line

            let chart =
                scatter
                |> Chart.Plot
                |> Chart.WithHeight(500)
                |> Chart.WithWidth(500)

            Chart.Show chart
    end
