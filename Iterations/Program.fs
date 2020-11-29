namespace Iterations

open System.Drawing
open XPlot.Plotly
open System.Numerics

module Program =    
    let h = single 0.001

    let createVector x y = Vector2((float32) x, (float32) y)
    
    let unzipVector2 (v: Vector2) = v.X, v.Y
    
   (*
     function:
                x_n+1 = x_n + y_n+1
                y_n+1 = y_n + c * sin(x_n)
     transform:
                x_n+1 = x_n + y_n + c * sin(x_n)
                y_n+1 = y_n + c * sin(x_n)
    *)
    
    let funcWithParameter c (xn: float32, yn: float32) = (xn + yn + c * sin(xn), yn + c * sin(xn))
    
    let unzipVectors line = List.map (unzipVector2) line |> List.unzip 
    
    let c = float32 1.0
    
    let funcWithSubstitution = funcWithParameter c
    
    let av = createVector 0.0 0.0

    let bv = createVector 5.0 5.0

    let (line: PolygonalLine) = [ av; bv ]
    
    let iterationNumber = 10
    
    let runner = MapRunner(line,funcWithSubstitution, h)
    
    let runner2 = runner.ProcessNTimes(10)
    
    let toScatter (line: PolygonalLine): Scatter =
        let (xs, ys) = unzipVectors line
        Scatter(x = xs, y = ys, mode="lines+markers")
        
    let scatter = toScatter runner2.Line
    
    let chart = scatter |> Chart.Plot |> Chart.WithHeight 400 |> Chart.WithWidth 400
    
    Chart.Show chart
    
    [<EntryPoint>]
    let main argv =
        printfn "%A" argv
        0 // return an integer exit code
