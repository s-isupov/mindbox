using System;
using NUnit.Framework;
using ShapeLib;

namespace ShapeLibTests;

public class CircleTests
{
    [Test]
    public void RadiusGreaterThanZeroTest()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            Circle c = new(0);
        }, "Must throw ArgumentException");
        
        Assert.Throws<ArgumentException>(() =>
        {
            Circle c = new(-5.9);
        }, "Must throw ArgumentException");
    }
    
    [Test]
    public void AreaTest()
    {
        double radius = 8.3d;
        var expected = Math.PI * radius * radius;
        var circle = new Circle(radius);
        var actual = circle.Area;
        Assert.That(actual, Is.EqualTo(expected).Within(Utils.Tolerance), $"Area should be equal to {expected}, got {actual}");
    }
}