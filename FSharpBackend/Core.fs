module FSharpBackend.Core 

    open System.Numerics

    let wrap (x, y) = Complex(x, y)

    let wrapReal x = Complex(x, 0.0)

    let unwrap (z: Complex) = (z.Real, z.Imaginary)

    let unzipComplexList l =
        let unzip (z: Complex) = (z.Real, z.Imaginary)
        List.map unzip l

    let separateTwoPartsOfComplex l =
        unzipComplexList l |> List.unzip

    let minVal = -2.0
    let maxVal = 2.0
    let number = 4
    let h = (maxVal - minVal) / float (number)

    let genList minVal (maxVal: float) h =
        let rec genList' a maxVal h l =
            if a <= maxVal then genList' (a + h) maxVal h (a :: l) else List.rev l
        genList' minVal maxVal h []

    let plusMinus x =
        if x = 0.0 then
            [ x ]
        else
            [ -x
              x ]

    let xs = genList minVal maxVal h
    //         |> List.collect plusMinus

    let ys = genList minVal maxVal h
    //         |> List.collect plusMinus

    let complexInPairList = List.zip xs ys

    let complexList' = complexInPairList |> List.map (Complex)

    let crossPoints xs ys =
        seq {
            for x in xs do
                for y in ys do
                    yield (x, y)
        }
        |> Seq.toList


    printfn "%A" crossPoints

    let complexPoints xs ys = List.map wrap (crossPoints xs ys) |> List.distinct

    let func (z: Complex) c = z ** 3.0 + c

    let z0 = wrap (0.0, 0.0)

    let c = wrap (1.0, 0.0)
    let iterNumber = 10

    let goodList = []
    let badList = []


    let findInvariant func c complexPoints =

        let rec iterFunction f z c k =
            if k = 0 then
                z
            else
                let z' = func z c
                iterFunction f z' c (k - 1)

        let checkConstraint (z: Complex) =
            let re = z.Real
            let im = z.Imaginary
            let isIn = (re >= minVal) && (re <= maxVal) && (im >= minVal) && (im <= maxVal)
            isIn

        let rec tryConstraintNumber f c z iterNumber =
            if checkConstraint c then
                let z' = func z c
                tryConstraintNumber f c z' (iterNumber - 1)
            else
                false


        let rec findInvariant' complexPoints goodList badList =
            match complexPoints with
            | z :: tail ->
                if tryConstraintNumber func c z iterNumber
                then findInvariant' tail (z :: goodList) badList
                else findInvariant' tail goodList (z :: badList)
            | _ -> (goodList, badList)

        findInvariant' complexPoints [] []
        
    let (blueList, redList) = findInvariant func c (complexPoints xs ys)    

   
