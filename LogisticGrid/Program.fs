open LogisticGrid
open XPlot.Plotly


[<EntryPoint>]
let main argv =
    let gn = 251.0
    let cp = 999.0
    let mutable array = Model.arr
    array <- Model.calculateNewState (gn, cp, array)
    let (xs1, ys1) = List.unzip Model.list1
    let (xs2, ys2) = List.unzip Model.list2
    let (xs3, ys3) = List.unzip Model.list3
    let scatter1 = Charting.toStyledScatter xs1 ys1 "blue"
    let scatter2 = Charting.toStyledScatter xs2 ys2 "yellow"
    let scatter3 = Charting.toStyledScatter xs3 ys3 "green"
    let chart =
            [ scatter1; scatter2; scatter3 ]
            |> Chart.Plot
            |> Chart.WithHeight 500
            |> Chart.WithWidth 500
    Chart.Show chart
    printfn "%A" argv
    0 // return an integer exit code
