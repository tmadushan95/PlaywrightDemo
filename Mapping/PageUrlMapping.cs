using PlaywrightDemo.Enums;

namespace PlaywrightDemo.Mapping;

public static class PageUrlMapping
{
    public static readonly IReadOnlyDictionary<EnumPage, string> Routes =
        new Dictionary<EnumPage, string>
        {
            [EnumPage.Dashboard] = "/dashboard",
            [EnumPage.OperationUnits] = "/operational-units",
        };
}
