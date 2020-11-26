module Reverse.Chart.Core

open System.Numerics
open MathNet.Numerics

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
