namespace Mandelbrot

module Core =

    open System.Numerics
    open System.Drawing
    open System.Windows.Forms

    let complex x y = Complex(x, y)
    
    let wrap x = complex x 0.0
    
    let unwrap (z: Complex) = (z.Real, z.Imaginary)

    let cMax = complex 1.0 1.0
    let cMin = complex -1.0 -1.0

    let (<=!) (x: Complex) (y: Complex) =
        (x.Real <= y.Real) && (x.Imaginary <= y.Imaginary)

    let rec isInMandelbrotSet (z, c, iter, count) =
        if (cMin <=! z) && (z <=! cMax) && (count < iter)
        then isInMandelbrotSet (((z * z * z) + c), c, iter, (count + 1))
        else count

    let scalingFactor s = s * 1.0 / 200.0
    let offsetX = -1.0
    let offsetY = -1.0

    let mapPlane (x, y, s, mx, my) =
        let fx = ((float x) * scalingFactor s) + mx
        let fy = ((float y) * scalingFactor s) + my
        complex fx fy

    let colorize c =
        let r = 20
        let g = 0
        let b = (20 * c) % 256
        Color.FromArgb(r, g, b)

    let createImage (s, mx, my, iter) =
        let image = new Bitmap(400, 400)
        for x = 0 to image.Width - 1 do
            for y = 0 to image.Height - 1 do
                let count =
                    isInMandelbrotSet (Complex.Zero, (mapPlane (x, y, s, mx, my)), iter, 0)

                if count = iter then image.SetPixel(x, y, Color.Red) else image.SetPixel(x, y, colorize (count))
        let temp = new Form()
        let label = new Label(Text = "Picture for Mandelbrot: z^3 + с", Width=400)
        temp.Controls.Add(label)
        temp.Paint.Add(fun e -> e.Graphics.DrawImage(image, 0, 0))
        temp.Size <- new Size(400, 400)
        temp


    do Application.Run(createImage (1.5, -1.5, -1.5, 20))

    