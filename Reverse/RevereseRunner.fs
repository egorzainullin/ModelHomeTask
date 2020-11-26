namespace Reverse

open System
open System.Drawing
open System.Windows.Forms

module Runner =
    open System.Numerics
    open XPlot.Plotly


    type ReverseRunner(c: Complex) =
        class
            let drawPlot() =
                Chart.chart |> Chart.Show
            
            
            member this.Run() =
                let form = new Form()
                let label =
                    new Label(Text = "Input, up block - real, below - i imaginary", Width=500)
                let button = new Button(Text = "Start")
                button.Click.Add(fun _ -> drawPlot())
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
                0

        end
    
    [<EntryPoint>]
    let main argv =
        let runner = new ReverseRunner(Complex(0.0, 0.0))
        runner.Run()
        0 // return an integer exit code
