module Reverse.Chart.Init

open System.Numerics
open MathNet.Numerics
open XPlot.Plotly

let defaultC = Complex.zero

let iterNumber = 15

let defaultZ0 = Complex.One

let start = [ defaultZ0 ]

let preImage c =
    Core.getPreImageNumberK c start iterNumber

let getComplexPoints c = preImage c |> List.map Core.unwrap

let (list1, list2) = List.unzip (getComplexPoints defaultC)

// Draw plot  of points

