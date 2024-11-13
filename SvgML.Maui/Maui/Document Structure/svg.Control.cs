using SkiaSharp;
using SkiaSharp.Views.Maui;
using Svg.Model;
using Svg.Skia;

namespace SvgML;

/// <summary>
/// Svg control.
/// </summary>
public partial class svg
{
    static svg()
    {
        Initialize();

        // TODO:
        // ClipToBoundsProperty.OverrideDefaultValue(typeof(svg), true);

        // TODO:
        // AffectsRender<svg>(StretchProperty, StretchDirectionProperty);
        // AffectsMeasure<svg>(StretchProperty, StretchDirectionProperty);

        // TODO:
        // CssProperty.Changed.AddClassHandler<Control>(OnCssPropertyAttachedPropertyChanged);
        // CurrentCssProperty.Changed.AddClassHandler<Control>(OnCssPropertyAttachedPropertyChanged);
    }

    // TODO:
    /*
    private static void OnCssPropertyAttachedPropertyChanged(AvaloniaObject d, AvaloniaPropertyChangedEventArgs e)
    {
        if (d is Control control)
        {
            control.InvalidateMeasure();
            control.InvalidateVisual();
        }
    }
    */

    public svg()
    {
        Loaded += OnLoaded;
        PaintSurface += OnPaintSurface;
    }

    private void OnPaintSurface(object? sender, SKPaintSurfaceEventArgs e)
    {
        Render(e);
    }

    private void OnLoaded(object? sender, EventArgs e)
    {
        InvalidateMeasure();
        InvalidateSurface();
    }

    protected override void OnPropertyChanged(string propertyName = null)
    {
        base.OnPropertyChanged(propertyName);
        
        Invalidate();
    }

    protected override void OnPaintSurface(SKPaintSurfaceEventArgs e)
    {
        base.OnPaintSurface(e);

        Render(e);
    }

    private void Render(SKPaintSurfaceEventArgs e)
    {
        var canvas = e.Surface.Canvas;
        
        // TODO:
        // canvas.DrawColor(SKColors.Aqua);

        var source = this;
        
        var css = GetCss(this);
        var currentCss = GetCurrentCss(this);
        var parameters = new SvgParameters(null, string.Concat(css, ' ', currentCss));
        Load(source, parameters);

        var _svg = this;
        
        lock (_svg.Sync)
        {
            var picture = _svg.Picture;
            if (picture is null)
            {
                return;
            }

            canvas.Save();
            canvas.DrawPicture(picture);
            canvas.Restore();
        }
    }

    // TODO:
    /*
    protected override Size MeasureOverride(Size availableSize)
    {
        if (_picture == null)
        {
            return new Size();
        }

        var sourceSize = _picture is { }
            ? new Size(_picture.CullRect.Width, _picture.CullRect.Height)
            : default;

        return Stretch.CalculateSize(availableSize, sourceSize, StretchDirection);
    }
    */
    ///*
    protected override Size MeasureOverride(double widthConstraint, double heightConstraint)
    {
        //return base.MeasureOverride(widthConstraint, heightConstraint);
        return new Size(200, 100);
    }
    /*/
    
    protected override SizeRequest OnMeasure(double widthConstraint, double heightConstraint)
    {
        return new SizeRequest(new Size(200.0, 100.0));
    }

    // TODO:
    /*
    protected override Size ArrangeOverride(Size finalSize)
    {
        if (_picture == null)
        {
            return new Size();
        }

        var sourceSize = _picture is { }
            ? new Size(_picture.CullRect.Width, _picture.CullRect.Height)
            : default;

        return Stretch.CalculateSize(finalSize, sourceSize);
    }
    */
    /*
    protected override Size ArrangeOverride(Rect bounds)
    {
        //return base.ArrangeOverride(bounds);
        
        return new Size(200, 100);
    }
*/
    /*
    public override void Render(DrawingContext context)
    {
        var source = _picture;
        if (source is null)
        {
            return;
        }

        var viewPort = new Rect(Bounds.Size);
        var sourceSize = new Size(source.CullRect.Width, source.CullRect.Height);
        if (sourceSize.Width <= 0 || sourceSize.Height <= 0)
        {
            return;
        }

        var scale = Stretch.CalculateScaling(Bounds.Size, sourceSize, StretchDirection);
        var scaledSize = sourceSize * scale;
        var destRect = viewPort
            .CenterRect(new Rect(scaledSize))
            .Intersect(viewPort);
        var sourceRect = new Rect(sourceSize)
            .CenterRect(new Rect(destRect.Size / scale));

        var bounds = source.CullRect;
        var scaleMatrix = Matrix.CreateScale(
            destRect.Width / sourceRect.Width,
            destRect.Height / sourceRect.Height);
        var translateMatrix = Matrix.CreateTranslation(
            -sourceRect.X + destRect.X - bounds.Top,
            -sourceRect.Y + destRect.Y - bounds.Left);

        using var _ = ClipToBounds ? context.PushClip(destRect) : default;

        using (context.PushTransform(translateMatrix * scaleMatrix))
        {
            context.Custom(
                new SKPictureCustomDrawOperation(
                    new Rect(0, 0, bounds.Width, bounds.Height),
                    this));
        }
    }
    */

    protected override void Invalidate()
    {
        base.Invalidate();

        // TODO: Only invalidate SvgSource if its Svg property that changed.

        if (IsLoaded)
        {
            // TODO:
            // OnSourceChanged(this);
            InvalidateMeasure();
            InvalidateSurface();
        }
        
        
    }

    // TODO:
    /*
    /// <inheritdoc/>
    protected override void OnPropertyChanged(AvaloniaPropertyChangedEventArgs change)
    {
        base.OnPropertyChanged(change);

        if (change.Property == CssProperty)
        {
            var css = change.GetNewValue<string?>();
            OnCssChanged(css);
        }

        if (change.Property == CurrentCssProperty)
        {
            var currentCss = change.GetNewValue<string?>();
            OnCurrentCssChanged(currentCss);
        }

        if (change.Property == ClipToBoundsProperty)
        {
            InvalidateVisual();
        }
    }

    protected override void OnLoaded(RoutedEventArgs e)
    {
        base.OnLoaded(e);

        OnSourceChanged(this);
    }
    */

    // TODO:
    /*
    private void OnCssChanged(string? css)
    {
        var source = this;
        var currentCss = GetCurrentCss(this);
        var parameters = new SvgParameters(null, string.Concat(css, ' ', currentCss));
        Load(source, parameters);
        InvalidateMeasure();
        InvalidateVisual();
    }

    private void OnCurrentCssChanged(string? currentCss)
    {
        var source = this;
        var css = GetCss(this);
        var parameters = new SvgParameters(null, string.Concat(css, ' ', currentCss));
        Load(source, parameters);
        InvalidateMeasure();
        InvalidateVisual();
    }

    private void OnSourceChanged(svg? source)
    {
        var css = GetCss(this);
        var currentCss = GetCurrentCss(this);
        var parameters = new SvgParameters(null, string.Concat(css, ' ', currentCss));
        Load(source, parameters);
        InvalidateMeasure();
        InvalidateVisual();
    }
    */

}
