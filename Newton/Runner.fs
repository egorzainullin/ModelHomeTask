namespace Newton

open System.Numerics

type Runner() =
    class
        member this.Run() =
            let f1 = CoreModule.nf1
            let f2 = CoreModule.nf2
            let func1 = f1 >> f1
            let func2 = f2 >> f2 >> f2 >> f2
            let matrix = CoreModule.createMatrix
            let fixed1 = CoreModule.findFixed func1 matrix
            Charting.draw fixed1
            let fixed2 = CoreModule.findFixed func2 matrix
            Charting.draw fixed2 
    end