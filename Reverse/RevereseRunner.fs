namespace Reverse.Chart

open System.Drawing
open System.Windows.Forms
open Reverse
open Reverse.Chart


open XPlot.Plotly
open Reverse.Converter

type ReverseRunner() =
    class
        let form = new Form()
        let textBlock1 = new TextBox(Width = 200, Text = "1")
        let textBlock2 = new TextBox(Width = 200, Text = "0")

        let getValuesTextBoxes text1 text2 =

            match tryParseDouble text1, tryParseDouble text2 with
            | (Some a, Some b) -> Some((a, b))
            | _ -> None

        let drawPlot () =
            let text1 = textBlock1.Text
            let text2 = textBlock2.Text
            match getValuesTextBoxes text1 text2 with
            | Some (re, im) ->
                let k = Init.iterNumber

                let complexPoints =
                    Core.getPreImageNumberK (Core.complex re im) Init.start k

                let (rs, is) =
                    complexPoints
                    |> List.map (Core.unwrap)
                    |> List.unzip

                let scatter =
                    Scatter(x = rs, y = is, mode = "markers")

                let chart =
                    scatter
                    |> Chart.Plot
                    |> Chart.WithHeight 500
                    |> Chart.WithWidth 500

                Chart.Show chart
                0 |> ignore
            | None -> MessageBox.Show("Incorrect input") |> ignore

        member this.Run() =
            let label =
                new Label(Text = "Input, upper - real, below - i imaginary", Width = 500)

            let button = new Button(Text = "Start")
            button.Click.Add(fun _ -> do drawPlot () |> ignore)
            let panel = new FlowLayoutPanel()
            panel.Controls.Add(label)
            panel.Controls.Add(textBlock1)
            panel.Controls.Add(textBlock2)
            panel.Controls.Add(button)
            form.Controls.Add(panel)
            form.Size <- new Size(400, 400)
            Application.Run(form)
    end

