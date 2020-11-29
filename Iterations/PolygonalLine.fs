namespace Iterations

open System
open System.Numerics
open Iterations

type PolygonalLine = Vector2 list                    

module PolygonalLine =
    let map f l =
        let rec map' f l rev =
            match l with
            | [] -> List.rev rev
            | h :: t -> map' f t (h :: rev)

        map' f l []

    let transform h (l: PolygonalLine) =
        let rec transform' h l proc =
            match l with
            | [] -> List.rev proc
            | [ x ] -> List.rev (x :: proc)
            | (a: Vector2) :: (b: Vector2) :: tail ->
                let d = (a - b).Length()
                let extraDelta = d - h
                if extraDelta < (float32) 0.0 then
                    List.rev (b :: a :: proc)
                else
                    let c = (a + b) / (float32) 2.0
                    transform' h tail (List.rev (b :: c :: a :: proc))

        transform' h l []
        
    let genLine (list: (float*float) list) =
        let rec genList' list ans =
            match list with
            | [] -> List.rev ans
            | (x, y) :: tail ->
                let z = float32 x
                let t = float32 y
                let vector = Vector2(z, t)
                genList' tail (vector :: ans)
        genList' list []
        
       
            
         
      
        
