namespace Iterations

type MapRunner(
               line: PolygonalLine,
               func: (float32 * float32 -> float32 * float32),
               h: float32
           ) =
    class
        member this.Line = line
        
        member this.H = h
        
        member this.Process() =
            let line' = (PolygonalLine.map func line)
            let line'' = PolygonalLine.transform h line'
            MapRunner(line'', func, h)
            
        member this.ProcessNTimes(n: int) =
            let rec processNTimes line k =
                if k = 0 then line
                else
                    let newLine = this.Process().Line
                    processNTimes newLine (k - 1)
            let newLine = processNTimes line n
            MapRunner(newLine, func, h)
    end

