namespace TodoApp.Playground.ExtensionMethods;


public static class StringExtensionMethods
{
    public static string Append(this string str, string value)
    {
        return str + value;
    }
    
    public static string AddTrackingParameter(this string url)
    {
        return $"{url}?__tracking=true";
    }
}

public class AddTrackingParameterHelper
{
    public string AddTrackingParameter(string url)
    {
        return $"{url}?__tracking=true";
    }
}

public class StringExtensionMethodsTests
{
    [Fact]
    public void AppendTest()
    {
        var newString = "sitebul".Append("b");
        Assert.Equal("sitebulb", newString);
    }
    
    [Fact]
    public void AppendChainedTest()
    {
        var newString = "sitebul"   
            .Append("b")
            .Append("!");
        
        Assert.Equal("sitebulb!", newString);
    }
    
    [Fact]
    public void AddTrackingParameterTestUsingExtensionMethod() 
    {
        var newString = "https://sitebulb.com".AddTrackingParameter();
        Assert.Equal("https://sitebulb.com?__tracking=true", newString);
    }   
    
    [Fact]
    public void AddTrackingParameterTestWithoutExtensionMethod()
    {
        var newString = StringExtensionMethods.AddTrackingParameter("https://sitebulb.com");
        Assert.Equal("https://sitebulb.com?__tracking=true", newString);
    } 
    
    [Fact]
    public void AddTrackingParameterClassTest()
    {
        var sut = new AddTrackingParameterHelper();
        var newString = sut.AddTrackingParameter("https://sitebulb.com");
        Assert.Equal("https://sitebulb.com?__tracking=true", newString);
    }
}