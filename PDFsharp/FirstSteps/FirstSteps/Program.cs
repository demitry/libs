using PdfSharp.Pdf;
using PdfSharp.Drawing;
using System.Diagnostics;

namespace FirstSteps
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PdfDocument document = new PdfDocument();
            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);
            XFont font = new XFont("Verdana", 20, XFontStyleEx.Bold);
            gfx.DrawString("Hello, World!", font, XBrushes.Black, new XRect(0, 0, page.Width, page.Height), XStringFormat.Center);
            gfx.DrawString("Hello, World!", font, XBrushes.Black, new XRect(0, 30, page.Width, page.Height), XStringFormat.Center);
            string filename = "HelloWorld.pdf";
            document.Save(filename);
            Process.Start("explorer.exe", filename);
        }

        public void DrawPage(PdfPage page)
        {
            XGraphics gfx = XGraphics.FromPdfPage(page);

            DrawTitle(page, gfx, "Lines & Curves");

            DrawLine(gfx, 1);
            DrawLines(gfx, 2);
            DrawBezier(gfx, 3);
            DrawBeziers(gfx, 4);
            DrawCurve(gfx, 5);
            DrawArc(gfx, 6);
        }
        void DrawLine(XGraphics gfx, int number)
        {
            BeginBox(gfx, number, "DrawLine");

            gfx.DrawLine(XPens.DarkGreen, 0, 0, 250, 0);

            gfx.DrawLine(XPens.Gold, 15, 7, 230, 15);

            XPen pen = new XPen(XColors.Navy, 4);
            gfx.DrawLine(pen, 0, 20, 250, 20);

            pen = new XPen(XColors.Firebrick, 6);
            pen.DashStyle = XDashStyle.Dash;
            gfx.DrawLine(pen, 0, 40, 250, 40);
            pen.Width = 7.3;
            pen.DashStyle = XDashStyle.DashDotDot;
            gfx.DrawLine(pen, 0, 60, 250, 60);

            pen = new XPen(XColors.Goldenrod, 10);
            pen.LineCap = XLineCap.Flat;
            gfx.DrawLine(pen, 10, 90, 240, 90);
            gfx.DrawLine(XPens.Black, 10, 90, 240, 90);

            pen = new XPen(XColors.Goldenrod, 10);
            pen.LineCap = XLineCap.Square;
            gfx.DrawLine(pen, 10, 110, 240, 110);
            gfx.DrawLine(XPens.Black, 10, 110, 240, 110);

            pen = new XPen(XColors.Goldenrod, 10);
            pen.LineCap = XLineCap.Round;
            gfx.DrawLine(pen, 10, 130, 240, 130);
            gfx.DrawLine(XPens.Black, 10, 130, 240, 130);

            EndBox(gfx);
        }

        void DrawLines(XGraphics gfx, int number)
        {
            BeginBox(gfx, number, "DrawLines");

            XPen pen = new XPen(XColors.DarkSeaGreen, 6);
            pen.LineCap = XLineCap.Round;
            pen.LineJoin = XLineJoin.Bevel;
            XPoint[] points =
              new XPoint[] { new XPoint(20, 30), new XPoint(60, 120), new XPoint(90, 20), new XPoint(170, 90), new XPoint(230, 40) };
            gfx.DrawLines(pen, points);

            EndBox(gfx);
        }

        void DrawBezier(XGraphics gfx, int number)
        {
            BeginBox(gfx, number, "DrawBezier");

            gfx.DrawBezier(new XPen(XColors.DarkRed, 5), 20, 110, 40, 10, 170, 90, 230, 20);

            EndBox(gfx);
        }

        void DrawBeziers(XGraphics gfx, int number)
        {
            BeginBox(gfx, number, "DrawBeziers");

            XPoint[] points = new XPoint[]{new XPoint(20, 30), new XPoint(40, 120), new XPoint(80, 20), new XPoint(110, 90),
                                 new XPoint(180, 40), new XPoint(210, 40), new XPoint(220, 80)};
            XPen pen = new XPen(XColors.Firebrick, 4);
            gfx.DrawBeziers(pen, points);

            EndBox(gfx);
        }

        void DrawCurve(XGraphics gfx, int number)
        {
            BeginBox(gfx, number, "DrawCurve");

            XPoint[] points =
              new XPoint[] { new XPoint(20, 30), new XPoint(60, 120), new XPoint(90, 20), new XPoint(170, 90), new XPoint(230, 40) };
            XPen pen = new XPen(XColors.RoyalBlue, 3.5);
            gfx.DrawCurve(pen, points, 1);

            EndBox(gfx);
        }

        void DrawArc(XGraphics gfx, int number)
        {
            BeginBox(gfx, number, "DrawArc");

            XPen pen = new XPen(XColors.Plum, 4.7);
            gfx.DrawArc(pen, 0, 0, 250, 140, 190, 200);

            EndBox(gfx);
        }

        public void DrawPage(PdfPage page)
        {
            XGraphics gfx = XGraphics.FromPdfPage(page);

            DrawTitle(page, gfx, "Shapes");

            DrawRectangle(gfx, 1);
            DrawRoundedRectangle(gfx, 2);
            DrawEllipse(gfx, 3);
            DrawPolygon(gfx, 4);
            DrawPie(gfx, 5);
            DrawClosedCurve(gfx, 6);
        }

        void DrawRectangle(XGraphics gfx, int number)
        {
            BeginBox(gfx, number, "DrawRectangle");

            XPen pen = new XPen(XColors.Navy, Math.PI);

            gfx.DrawRectangle(pen, 10, 0, 100, 60);
            gfx.DrawRectangle(XBrushes.DarkOrange, 130, 0, 100, 60);
            gfx.DrawRectangle(pen, XBrushes.DarkOrange, 10, 80, 100, 60);
            gfx.DrawRectangle(pen, XBrushes.DarkOrange, 150, 80, 60, 60);

            EndBox(gfx);
        }

        void DrawRoundedRectangle(XGraphics gfx, int number)
        {
            BeginBox(gfx, number, "DrawRoundedRectangle");

            XPen pen = new XPen(XColors.RoyalBlue, Math.PI);

            gfx.DrawRoundedRectangle(pen, 10, 0, 100, 60, 30, 20);
            gfx.DrawRoundedRectangle(XBrushes.Orange, 130, 0, 100, 60, 30, 20);
            gfx.DrawRoundedRectangle(pen, XBrushes.Orange, 10, 80, 100, 60, 30, 20);
            gfx.DrawRoundedRectangle(pen, XBrushes.Orange, 150, 80, 60, 60, 20, 20);

            EndBox(gfx);
        }

        void DrawEllipse(XGraphics gfx, int number)
        {
            BeginBox(gfx, number, "DrawEllipse");

            XPen pen = new XPen(XColors.DarkBlue, 2.5);

            gfx.DrawEllipse(pen, 10, 0, 100, 60);
            gfx.DrawEllipse(XBrushes.Goldenrod, 130, 0, 100, 60);
            gfx.DrawEllipse(pen, XBrushes.Goldenrod, 10, 80, 100, 60);
            gfx.DrawEllipse(pen, XBrushes.Goldenrod, 150, 80, 60, 60);

            EndBox(gfx);
        }

        void DrawPolygon(XGraphics gfx, int number)
        {
            BeginBox(gfx, number, "DrawPolygon");

            XPen pen = new XPen(XColors.DarkBlue, 2.5);

            gfx.DrawPolygon(pen, XBrushes.LightCoral, GetPentagram(50, new XPoint(60, 70)), XFillMode.Winding);
            gfx.DrawPolygon(pen, XBrushes.LightCoral, GetPentagram(50, new XPoint(180, 70)), XFillMode.Alternate);

            EndBox(gfx);
        }

        void DrawPie(XGraphics gfx, int number)
        {
            BeginBox(gfx, number, "DrawPie");

            XPen pen = new XPen(XColors.DarkBlue, 2.5);

            gfx.DrawPie(pen, 10, 0, 100, 90, -120, 75);
            gfx.DrawPie(XBrushes.Gold, 130, 0, 100, 90, -160, 150);
            gfx.DrawPie(pen, XBrushes.Gold, 10, 50, 100, 90, 80, 70);
            gfx.DrawPie(pen, XBrushes.Gold, 150, 80, 60, 60, 35, 290);

            EndBox(gfx);
        }

        void DrawClosedCurve(XGraphics gfx, int number)
        {
            BeginBox(gfx, number, "DrawClosedCurve");

            XPen pen = new XPen(XColors.DarkBlue, 2.5);
            gfx.DrawClosedCurve(pen, XBrushes.SkyBlue,
              new XPoint[] { new XPoint(10, 120), new XPoint(80, 30), new XPoint(220, 20), new XPoint(170, 110), new XPoint(100, 90) },
              XFillMode.Winding, 0.7);

            EndBox(gfx);
        }

        public void DrawPage(PdfPage page)
        {
            XGraphics gfx = XGraphics.FromPdfPage(page);

            DrawTitle(page, gfx, "Paths");

            DrawPathOpen(gfx, 1);
            DrawPathClosed(gfx, 2);
            DrawPathAlternateAndWinding(gfx, 3);
            DrawGlyphs(gfx, 5);
            DrawClipPath(gfx, 6);
        }

        void DrawPathOpen(XGraphics gfx, int number)
        {
            BeginBox(gfx, number, "DrawPath (open)");

            XPen pen = new XPen(XColors.Navy, Math.PI);
            pen.DashStyle = XDashStyle.Dash;

            XGraphicsPath path = new XGraphicsPath();
            path.AddLine(10, 120, 50, 60);
            path.AddArc(50, 20, 110, 80, 180, 180);
            path.AddLine(160, 60, 220, 100);
            gfx.DrawPath(pen, path);

            EndBox(gfx);
        }

        void DrawPathClosed(XGraphics gfx, int number)
        {
            BeginBox(gfx, number, "DrawPath (closed)");

            XPen pen = new XPen(XColors.Navy, Math.PI);
            pen.DashStyle = XDashStyle.Dash;

            XGraphicsPath path = new XGraphicsPath();
            path.AddLine(10, 120, 50, 60);
            path.AddArc(50, 20, 110, 80, 180, 180);
            path.AddLine(160, 60, 220, 100);
            path.CloseFigure();
            gfx.DrawPath(pen, path);

            EndBox(gfx);
        }

        void DrawPathAlternateAndWinding(XGraphics gfx, int number)
        {
            BeginBox(gfx, number, "DrawPath (alternate / winding)");

            XPen pen = new XPen(XColors.Navy, 2.5);

            // Alternate fill mode
            XGraphicsPath path = new XGraphicsPath();
            path.FillMode = XFillMode.Alternate;
            path.AddLine(10, 130, 10, 40);
            path.AddBeziers(new XPoint[]{new XPoint(10, 40), new XPoint(30, 0), new XPoint(40, 20), new XPoint(60, 40),
                               new XPoint(80, 60), new XPoint(100, 60), new XPoint(120, 40)});
            path.AddLine(120, 40, 120, 130);
            path.CloseFigure();
            path.AddEllipse(40, 80, 50, 40);
            gfx.DrawPath(pen, XBrushes.DarkOrange, path);

            // Winding fill mode
            path = new XGraphicsPath();
            path.FillMode = XFillMode.Winding;
            path.AddLine(130, 130, 130, 40);
            path.AddBeziers(new XPoint[]{new XPoint(130, 40), new XPoint(150, 0), new XPoint(160, 20), new XPoint(180, 40),
                               new XPoint(200, 60), new XPoint(220, 60), new XPoint(240, 40)});
            path.AddLine(240, 40, 240, 130);
            path.CloseFigure();
            path.AddEllipse(160, 80, 50, 40);
            gfx.DrawPath(pen, XBrushes.DarkOrange, path);

            EndBox(gfx);
        }

        void DrawGlyphs(XGraphics gfx, int number)
        {
            BeginBox(gfx, number, "Draw Glyphs");

            XGraphicsPath path = new XGraphicsPath();
            path.AddString("Hello!", new XFontFamily("Times New Roman"), XFontStyle.BoldItalic, 100, new XRect(0, 0, 250, 140),
              XStringFormats.Center);

            gfx.DrawPath(new XPen(XColors.Purple, 2.3), XBrushes.DarkOrchid, path);

            EndBox(gfx);
        }

        void DrawClipPath(XGraphics gfx, int number)
        {
            BeginBox(gfx, number, "Clip through Path");

            XGraphicsPath path = new XGraphicsPath();
            path.AddString("Clip!", new XFontFamily("Verdana"), XFontStyle.Bold, 90, new XRect(0, 0, 250, 140),
              XStringFormats.Center);

            gfx.IntersectClip(path);

            // Draw a beam of dotted lines
            XPen pen = XPens.DarkRed.Clone();
            pen.DashStyle = XDashStyle.Dot;
            for (double r = 0; r <= 90; r += 0.5)
                gfx.DrawLine(pen, 0, 0, 250 * Math.Cos(r / 90 * Math.PI), 250 * Math.Sin(r / 90 * Math.PI));

            EndBox(gfx);
        }

        public void DrawPage(PdfPage page)
        {
            XGraphics gfx = XGraphics.FromPdfPage(page);

            DrawTitle(page, gfx, "Text");

            DrawText(gfx, 1);
            DrawTextAlignment(gfx, 2);
            MeasureText(gfx, 3);
        }
    }
}



//http://forum.pdfsharp.com/viewtopic.php?t=4451
//System.InvalidOperationException: 'No appropriate font found for family name "Verdana". Implement IFontResolver and assign to "GlobalFontSettings.FontResolver" to use fonts.'

//For console app:
// 1. Use  WPF version of PDFsharp
// 2. Add PresentationCore nuget package
// 3. Add "-windows" in csproj <TargetFramework>net8.0-windows</TargetFramework>
