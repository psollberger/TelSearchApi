# TelSearchApi ![CI](https://github.com/psollberger/TelSearchApi/workflows/CI/badge.svg)
An API-Wrapper for tel.search.ch Queries

See: https://tel.search.ch/api/help

# Example

```csharp
TelSearchCore.ApiKey = "<your API Key goes here";
TelSearchQuery q = new TelSearchQuery
{
    What = "<your search term goes here>";
}
var result = await q.ExecuteAsync();
```
