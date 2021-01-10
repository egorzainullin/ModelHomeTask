module LogisticGrid.Charting

open XPlot.Plotly
open LogisticGrid.Model

let toStyledScatter xs ys color =
    Scatter(
        x = xs,
        y = ys,
        mode = "markers",
        marker =
            Marker(
                color = color,
                size = 1,
                line =
                    Line(
                        color = "white",
                        width = 0.5
                    )
            )
    )

