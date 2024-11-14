using System;
using Microsoft.Maui.Hosting;

namespace SvgML;

public static class AppHostBuilderExtensions
{
    public static MauiAppBuilder UseSvgML(this MauiAppBuilder builder)
    {
        // TODO: Add all types from SvgML.Maui into UseSvgML() extension method
        GC.KeepAlive(typeof(svg));
        GC.KeepAlive(typeof(defs));
        GC.KeepAlive(typeof(linearGradient));
        GC.KeepAlive(typeof(stop));
        GC.KeepAlive(typeof(rect));
        GC.KeepAlive(typeof(circle));

        GC.KeepAlive(typeof(Canvas));
        
        return builder;
    }
}
