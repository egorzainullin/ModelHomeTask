namespace Iterations

open System.Drawing
open XPlot.Plotly
open System.Numerics

module Core =
    
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
    
    let funcWithSubstitution c = funcWithParameter c
    
    let genCSharpFunction(c) = funcWithParameter c
    
    let toScatter (line: PolygonalLine): Scatter =
        let (xs, ys) = unzipVectors line
        Scatter(x = xs, y = ys, mode="markers")
    
    type public LineToScatter() =
        static member ToScatter(line) =
            toScatter line
   