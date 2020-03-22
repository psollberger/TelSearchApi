# TelSearchApi ![CI](https://github.com/psollberger/TelSearchApi/workflows/CI/badge.svg)
An API-Wrapper for tel.search.ch Queries

See: https://tel.search.ch/api/help

# Example

```csharp
var client = new TelSearchClient("<api key, empty string or null>");
var query = new TelSearchQuery(client)
{
    Query = "<general search term>",
    Language = "de"
};
var response = await query.ExecuteAsync();
//Or if it's not possible to use await
//var response = query.ExecuteAsync().GetAwaiter().GetResult();
```
