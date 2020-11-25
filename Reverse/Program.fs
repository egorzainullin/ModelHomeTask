namespace Reverse

module Chart =

    open System.Numerics
    open MathNet.Numerics
    open XPlot.Plotly


    module Solver =
        let complex re im = Complex(re, im)

        let wrap x = complex x 0.0

        let unwrap (z: Complex) = z.Real, z.Imaginary

        let fz c z = z * z + c

        // z' = z^2 + c
        // z = sqrt(z' - c)

        let getSolution c z =
            let x12 = Complex.Sqrt(z - c)
            if x12 = Complex.Zero then [ x12 ] else [ -x12; x12 ]

        let getSolutionOfList c l =
            let solve = getSolution c
            List.collect solve l

        let getPreImageNumberK c currentLevel k =
            let rec getPreImageNumberK' c l k (ans: Complex list) =
                if k = 0 then
                    ans
                else
                    let newPreImages = getSolutionOfList c l
                    let newL = newPreImages
                    let newAns = (ans @ newL) |> List.distinct
                    getPreImageNumberK' c newL (k - 1) newAns

            getPreImageNumberK' c currentLevel k currentLevel

    let c = Complex.zero

    let iterNumber = 15

    let z0 = Complex.One

    let start = [ z0 ]

    let preImage =
        Solver.getPreImageNumberK c start iterNumber

    let points = preImage |> List.map Solver.unwrap

    let (list1, list2) = List.unzip points
    
    // Draw plot  of points
    
    let trace = Scatter(x = list1, y = list2, mode = "markers")

    let chart = Chart.Plot trace |> Chart.WithSize(500, 500)
    //save & show chart

    let chartHtml = chart.GetHtml()
    System.IO.File.WriteAllText("../../chart.html", chartHtml)    
        
    Chart.Show chart
    
    