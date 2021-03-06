﻿namespace Iterations

open System.Collections.Generic
open System.Numerics
open Microsoft.FSharp.Collections

type PolygonalLine = Vector2 list                    

module PolygonalLine =
    let wrapLine list =
        let rec genList' list ans =
            match list with
            | [] -> List.rev ans
            | (x, y) :: tail ->
                let z = float32 x
                let t = float32 y
                let vector = Vector2(z, t)
                genList' tail (vector :: ans)
        genList' list []
    
    let unwrapLine (line: PolygonalLine) =
        let rec unwrap' line acc =
            match line with
            | (v: Vector2) :: tail -> unwrap' tail ((v.X, v.Y) :: acc)
            | [] -> List.rev acc
        unwrap' line [] 
    
    
    let map (func :float32 * float32 -> float32 * float32)(line: PolygonalLine) =
            let unwrapped1 = unwrapLine line
            let unwrapped2 = List.map func unwrapped1
            let wrapped = wrapLine unwrapped2
            wrapped            
    
        
    let transform (func: float32 * float32 -> float32 * float32) h (l: PolygonalLine) =
        let vectorApply (func: float32 * float32 -> float32 * float32) (vector: Vector2) =
            let unwrappedVector = (vector.X, vector.Y)
            let applied = func unwrappedVector
            let wrapped = Vector2(fst applied, snd applied)
            wrapped
        let wrappedFunc = vectorApply func
        let rec transform' h l proc =
            match l with
            | [] -> List.rev proc
            | [ x ] -> List.rev (x :: proc)
            | (a: Vector2) :: (b: Vector2) :: tail ->
                let d = (wrappedFunc(a) - wrappedFunc(b)).Length()
                let extraDelta = d - h
                if extraDelta < (float32) 0.0 then
                     transform' h (b :: tail) (a :: proc)
                else
                    let c = (a + b) / (float32) 2.0
                    transform' h (a :: c:: b :: tail) proc

        transform' h l []
        
        
                
        
    
        
       
            
         
      
        
