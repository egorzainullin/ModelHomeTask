namespace Reverse.Chart

open System
open System.Drawing
open System.Windows.Forms
open Reverse.Chart


open System.Numerics
open XPlot.Plotly

type ReverseRunner(c: Complex) =
    class
        let drawPlot() =
            let complexPoints = Init.getComplexPoints
            
            let k = Init.iterNumber
            let complexPoints = Core.getPreImageNumberK c Init.start k 
            let (rs, is) = complexPoints|> List.map (Core.unwrap) |> List.unzip 
            let scatter = Scatter(x = rs, y = is)
            let chart = scatter |> Chart.Plot
            Chart.Show chart
        
        
        member this.Run() =
            let form = new Form()
            let label =
                new Label(Text = "Input, left - real, right - i imaginary", Width=500)
            let button = new Button(Text = "Start")
            button.Click.Add(fun _ -> drawPlot() |> ignore)
            let textBlock1 = new TextBox(Width=200)
            let textBlock2 = new TextBox(Width=200)
            let panel = new FlowLayoutPanel()
            panel.Controls.Add(label)
            panel.Controls.Add(textBlock1)
            panel.Controls.Add(textBlock2)
            panel.Controls.Add(button)
            form.Controls.Add(panel)
            form.Size <- new Size(400, 400)
            Application.Run(form)

    end


